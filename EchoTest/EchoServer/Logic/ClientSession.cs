using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.IO;
using Aegis.Calculate;
using Aegis.Network;



namespace EchoServer.Logic
{
    public class ClientSession : Session
    {
        public ClientSession()
        {
            base.EventAccept += OnAcceptd;
            base.EventClose += OnClosed;
            base.EventReceive += OnReceived;
            base.PacketValidator += Packet.IsValidPacket;

            CreatePacketDispatcher(this, (ref StreamBuffer source, out string key) =>
            {
                source = new Packet(source as StreamBuffer);
                key = (source as Packet).PacketId.ToString();
                (source as Packet).SkipHeader();


                IntervalCounter.Counters["ReceiveCount"].Add(1);
                IntervalCounter.Counters["ReceiveBytes"].Add((source as Packet).Buffer.Length);
            });
        }


        private void OnAcceptd(IOEventResult result)
        {
            Logger.Info("[{0}] Accepted", SessionId);


            //  Hello packet을 클라이언트에 전달
            Packet packet = new Packet(Protocol.Hello_Ntf);
            SendPacket(packet);
        }


        private void OnClosed(IOEventResult result)
        {
            Logger.Info("[{0}] Closed", SessionId);
        }


        private void OnReceived(IOEventResult result)
        {
            IntervalCounter.Counters["ReceiveCount"].Add(1);
            IntervalCounter.Counters["ReceiveBytes"].Add(result.Buffer.Length);


            Packet packet = new Packet(result.Buffer);
            Logger.Err("Invalid packet received(PacketId={0:X})", packet.PacketId);
        }


        [TargetMethod(Protocol.Echo_Req)]
        private void Echo_Req(Packet packet)
        {
            Packet resPacket = new Packet(Protocol.Echo_Res);
            SendPacket(resPacket);
        }
    }
}
