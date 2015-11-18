using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Aegis;
using Aegis.Network;
using RPGGame.Common;



namespace RPGGame.AuthServer.Networking
{
    public class ServerSession : Session
    {
        private ServerInfo _svrInfo;





        public ServerSession()
        {
            base.NetworkEvent_Accepted += OnAccepted;
            base.NetworkEvent_Closed += OnClosed;
            base.NetworkEvent_Received += OnReceived;
            base.PacketValidator += PacketRequest.IsValidPacket;
        }


        private void OnAccepted(Session session)
        {
            _svrInfo = null;
        }


        private void OnClosed(Session session)
        {
            if (_svrInfo == null)
                return;

            _svrInfo.Status = ServerStatus.Inactivate;
            Logger.Write(LogType.Info, 2, "GameServer({0}) disconnected.", _svrInfo.Uid);
            _svrInfo = null;
        }


        private void OnReceived(Session session, StreamBuffer buffer)
        {
            PacketRequest packet = new PacketRequest(buffer);
            packet.SkipHeader();


            try
            {
                packet.Dispatch(this, "On" + Protocol.GetName(packet.PacketId));
            }
            catch (AegisException e) when (e.ResultCodeNo == AegisResult.BufferUnderflow)
            {
                Logger.Write(LogType.Err, 2, "Cannot read more data at PacketId(=0x{0:X}).", packet.PacketId);
            }
            catch (Exception e)
            {
                Logger.Write(LogType.Err, 2, e.ToString());
            }
        }


        private void OnSS_Register_Req(PacketRequest reqPacket)
        {
            PacketResponse resPacket = new PacketResponse(reqPacket);
            Int32 serverUid = reqPacket.GetInt32();


            _svrInfo = ServerCatalog.Items.Find(v => v.Uid == serverUid);
            if (_svrInfo == null)
                resPacket.ResultCodeNo = ResultCode.InvalidUid;
            else
            {
                resPacket.ResultCodeNo = ResultCode.Ok;
                _svrInfo.Status = ServerStatus.Activate;

                Logger.Write(LogType.Info, 2, "GameServer({0}) registered.", serverUid);
            }

            SendPacket(resPacket);
        }


        private void OnSS_Traffic_Ntf(PacketRequest reqPacket)
        {
            if (_svrInfo == null)
                return;

            _svrInfo.Traffic = reqPacket.GetInt32();
        }
    }
}
