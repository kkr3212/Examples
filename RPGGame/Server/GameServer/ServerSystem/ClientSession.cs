using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegis;
using Aegis.Network;
using Aegis.Utils;
using RPGGame.Common;
using RPGGame.GameServer.UserData;



namespace RPGGame.GameServer.ServerSystem
{
    public partial class ClientSession : Session
    {
        private String _aesIV, _aesKey;
        private GameUser _user;





        public ClientSession()
        {
            base.NetworkEvent_Accepted += OnAccepted;
            base.NetworkEvent_Closed += OnClosed;
            base.NetworkEvent_Received += OnReceived;
            base.PacketValidator += PacketRequest.IsValidPacket;
        }


        private void OnAccepted(Session session)
        {
            //  초기화
            _user = null;



            //  각 8비트마다 0이 나오지 않는 임의 숫자 생성
            Int32 seed = 0;
            seed |= Randomizer.NextNumber(1, 255) << 24;
            seed |= Randomizer.NextNumber(1, 255) << 16;
            seed |= Randomizer.NextNumber(1, 255) << 8;
            seed |= Randomizer.NextNumber(1, 255);


            //  패킷 암호화 키 생성
            {
                String characterSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
                char[] ascii = new char[16];


                for (Int32 i = 0; i < 16; ++i)
                {
                    Int32 val = seed & (0x6E << i);
                    ascii[i] = characterSet[(val % characterSet.Length)];
                }
                _aesIV = new String(ascii);


                for (Int32 i = 0; i < 16; ++i)
                {
                    Int32 val = seed & (0xF4 << i);
                    ascii[i] = characterSet[(val % characterSet.Length)];
                }
                _aesKey = new String(ascii);
            }


            SecurePacket ntfPacket = new SecurePacket(Protocol.GetID("CS_Hello_Ntf"));
            ntfPacket.PutInt32(ResultCode.Ok);
            ntfPacket.PutInt32((Int32)ServerType.GameServer);
            ntfPacket.PutInt32(seed);
            ntfPacket.Encrypt(ServerMain.AES_IV, ServerMain.AES_Key);
            base.SendPacket(ntfPacket);
        }


        private void OnClosed(Session session)
        {
            if (_user != null)
                _user.Session = null;
            _user = null;
        }


        private void OnReceived(Session session, StreamBuffer buffer)
        {
            SecurePacketRequest reqPacket = new SecurePacketRequest(buffer);
            reqPacket.Decrypt(_aesIV, _aesKey);
            reqPacket.SkipHeader();


            Statistics.ReceivedBytes.Add(reqPacket.Size);
            Statistics.ReceivedCount.Add(1);


            try
            {
                if (reqPacket.PacketId == Protocol.GetID("CS_Login_Req"))
                    OnCS_Login_Req(reqPacket);
                else
                {
                    _user = UserManager.Find(reqPacket.UserNo);
                    if (_user == null)
                    {
                        ForceClose("Invalid UserNo.");
                        return;
                    }
                    if (reqPacket.SeqNo != _user.SeqNo + 1)
                    {
                        ForceClose("Invalid Sequence Number.");
                        return;
                    }

                    _user.SeqNo = reqPacket.SeqNo;
                    _user.Session = this;
                    reqPacket.Dispatch(_user, "On" + Protocol.GetName(reqPacket.PacketId));

                    UserManager.HeartPulse(_user);
                }
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
            packet.Encrypt(_aesIV, _aesKey);
            base.SendPacket(buffer, onSent);


            Statistics.SentBytes.Add(packet.Size);
            Statistics.SentCount.Add(1);
        }


        public void ForceClose(String message)
        {
            SecurePacket ntfPacket = new SecurePacket(Protocol.GetID("CS_Auth_ForceClosing_Ntf"));
            ntfPacket.PutStringAsUtf16(message);

            SendPacket(ntfPacket, (sentPacket) =>
            {
                Close();
            });
        }


        private void OnCS_Login_Req(SecurePacketRequest reqPacket)
        {
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket);
            Int32 authKey = reqPacket.GetInt32();


            UserManager.Login(reqPacket.UserNo, authKey, (user, resultCode) =>
            {
                user.SeqNo = reqPacket.SeqNo;

                resPacket.ResultCodeNo = resultCode;
                SendPacket(resPacket);
            });
        }
    }
}
