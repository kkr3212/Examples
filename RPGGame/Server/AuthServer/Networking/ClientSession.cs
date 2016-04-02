using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Aegis;
using Aegis.Network;
using Aegis.Utils;
using Aegis.Data.MySQL;
using RPGGame.Common;



namespace RPGGame.AuthServer.Networking
{
    public class ClientSession : Session
    {
        public ClientSession()
        {
            base.NetworkEvent_Accepted += OnAccepted;
            base.NetworkEvent_Closed += OnClosed;
            base.NetworkEvent_Received += OnReceived;
            base.PacketValidator += PacketRequest.IsValidPacket;
        }


        private void OnAccepted(Session session)
        {
            SecurePacket ntfPacket = new SecurePacket(Protocol.GetID("CS_Hello_Ntf"));
            ntfPacket.PutInt32(ResultCode.Ok);
            ntfPacket.PutInt32((Int32)ServerType.AuthServer);
            SendPacket(ntfPacket);
        }


        private void OnClosed(Session session)
        {
        }


        private void OnReceived(Session session, StreamBuffer buffer)
        {
            SecurePacketRequest reqPacket = new SecurePacketRequest(buffer);
            reqPacket.Decrypt(ServerMain.AES_IV, ServerMain.AES_Key);
            reqPacket.SkipHeader();


            try
            {
                reqPacket.Dispatch(this, "On" + Protocol.GetName(reqPacket.PacketId));
            }
            catch (AegisException e) when (e.ResultCodeNo == AegisResult.BufferUnderflow)
            {
                Logger.Write(LogType.Err, 2, "Cannot read more data at PacketId(=0x{0:X}).", reqPacket.PacketId);
            }
            catch (Exception e)
            {
                Logger.Write(LogType.Err, 2, e.ToString());
            }
        }


        public override void SendPacket(StreamBuffer buffer, Action<StreamBuffer> onSent = null)
        {
            SecurePacket packet = (SecurePacket)buffer;
            packet.Encrypt(ServerMain.AES_IV, ServerMain.AES_Key);
            base.SendPacket(buffer, onSent);
        }


        private void OnCS_Auth_WorldList_Req(SecurePacketRequest reqPacket)
        {
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket);
            Int32 idxCount, count = 0;


            resPacket.ResultCodeNo = ResultCode.Ok;
            idxCount = resPacket.PutInt32(count);
            foreach (var world in WorldCatalog.Items
                                              .Where(v => v.IsOpen == true))
            {
                resPacket.PutInt32(world.WorldId);
                resPacket.PutStringAsUtf16(world.WorldName);
                ++count;
            }


            resPacket.OverwriteInt32(idxCount, count);
            SendPacket(resPacket);
        }


        private void OnCS_Auth_RegisterGuest_Req(SecurePacketRequest reqPacket)
        {
            String userToken = reqPacket.GetStringFromUtf16();
            Int32 ret = 0, userNo = 0, authKey = 0;


            using (DBCommand cmd = AuthDB.NewCommand())
            {
                cmd.CommandText.Append("call sp_auth_register_guest(@0);");
                cmd.BindParameter("@0", userToken);
                cmd.PostQuery(
                    () =>
                    {
                        if (cmd.Reader.Read())
                        {
                            ret = cmd.Reader.GetInt32(0);
                            userNo = cmd.Reader.GetInt32(1);
                            authKey = cmd.Reader.GetInt32(2);
                        }
                    },
                    (exception) =>
                    {
                        SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket);
                        if (exception != null)
                        {
                            resPacket.ResultCodeNo = ResultCode.Database_Error;
                            Logger.Write(LogType.Err, 2, exception.ToString());
                        }
                        else if (ret == 0)
                        {
                            resPacket.ResultCodeNo = ResultCode.Ok;
                            resPacket.PutInt32(userNo);
                            resPacket.PutInt32(authKey);
                        }
                        else if (ret == 1)
                            resPacket.ResultCodeNo = ResultCode.ExistsUserToken;

                        SendPacket(resPacket);
                    });
            }
        }


        private void OnCS_Auth_Guest_Req(SecurePacketRequest reqPacket)
        {
            Int32 worldId = reqPacket.GetInt32();
            String userToken = reqPacket.GetStringFromUtf16();
            Boolean hasData = false;
            Int32 userNo = 0, authKey = 0;


            using (DBCommand cmd = AuthDB.NewCommand())
            {
                cmd.CommandText.Append("select userno, authkey from t_accounts");
                cmd.CommandText.Append(" where usertoken=@0;");
                cmd.BindParameter("@0", userToken);
                cmd.PostQuery(
                    () =>
                    {
                        if ((hasData = cmd.Reader.Read()) == true)
                        {
                            userNo = cmd.Reader.GetInt32(0);
                            authKey = cmd.Reader.GetInt32(1);
                        }
                    },
                    (exception) =>
                    {
                        SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket);
                        if (exception != null)
                        {
                            resPacket.ResultCodeNo = ResultCode.Database_Error;
                            Logger.Write(LogType.Err, 2, exception.ToString());
                        }
                        else if (hasData == true)
                        {
                            ServerInfo gameServerInfo = ServerCatalog.Items
                                                                     .Where(v => v.WorldId == worldId &&
                                                                                 v.Status == ServerStatus.Activate &&
                                                                                 v.ServerType == ServerType.GameServer)
                                                                     .OrderBy(v => v.Traffic)
                                                                     .FirstOrDefault();

                            if (gameServerInfo == null)
                                resPacket.ResultCodeNo = ResultCode.NoAvailableServer;
                            else
                            {
                                resPacket.ResultCodeNo = ResultCode.Ok;
                                resPacket.PutInt32(userNo);
                                resPacket.PutInt32(authKey);
                                resPacket.PutStringAsUtf16(gameServerInfo.SystemIpAddress);
                                resPacket.PutInt32(gameServerInfo.ListenPortNo);
                            }
                        }
                        else
                            resPacket.ResultCodeNo = ResultCode.InvalidUserToken;

                        SendPacket(resPacket);
                    });
            }
        }
    }
}
