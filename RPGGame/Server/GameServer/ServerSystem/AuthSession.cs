using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegis;
using Aegis.Network;
using Aegis.Threading;
using RPGGame.Common;



namespace RPGGame.GameServer.ServerSystem
{
    public class AuthSession : Session
    {
        public static AuthSession Instance { get; private set; }
        private ThreadCancellable _threadRun;





        public AuthSession()
        {
            Instance = this;

            base.NetworkEvent_Connected += OnConnected;
            base.NetworkEvent_Closed += OnClosed;
            base.NetworkEvent_Received += OnReceived;
            base.PacketValidator += SecurePacketResponse.IsValidPacket;

            TryConnect();
        }


        private void TryConnect()
        {
            if (ServerMain.IsStarted == false)
                return;

            ServerInfo info = ServerCatalog.Items.Find(v => v.ServerType == ServerType.AuthServer);
            if (info == null)
            {
                Logger.Write(LogType.Err, 2, "There is no AuthServer information.");
                return;
            }

            Connect(info.SystemIpAddress, 10101);
        }


        private void OnConnected(Session session, Boolean connected)
        {
            if (connected == false)
            {
                TryConnect();
                return;
            }

            PacketRequest reqPacket = new PacketRequest(Protocol.GetID("SS_Register_Req"));
            reqPacket.PutInt32(ServerCatalog.MyServerInfo.Uid);
            SendAndResponse(reqPacket, (resPacket) =>
            {
                Logger.Write(LogType.Info, 2, "Connected to the AuthServer.");


                _threadRun = ThreadCancellable.CallPeriodically(1000, () =>
                {
                    PacketRequest ntfPacket = new PacketRequest(Protocol.GetID("SS_Traffic_Ntf"));
                    ntfPacket.PutInt32(Statistics.CCU);
                    SendPacket(ntfPacket);

                    return Connected;
                });
            });
        }


        private void OnClosed(Session session)
        {
            _threadRun?.Cancel();

            TryConnect();
            Logger.Write(LogType.Info, 2, "AuthServer connection closed.");
        }


        private void OnReceived(Session session, StreamBuffer buffer)
        {
        }


        private void SendAndResponse(PacketRequest reqPacket, Action<PacketResponse> actionOnReceived)
        {
            SendPacket(reqPacket,
            (p) =>
            {
                return reqPacket.SeqNo == PacketResponse.GetSeqNo(p);
            },
            (s, p) =>
            {
                PacketResponse packet = new PacketResponse(p);
                packet.SkipHeader();

                actionOnReceived(packet);
            });
        }
    }
}
