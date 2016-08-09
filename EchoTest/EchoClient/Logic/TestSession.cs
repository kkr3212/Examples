using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.IO;
using Aegis.Network;



namespace EchoClient.Logic
{
    public class TestSession : Session
    {
        private byte[] _tempBuffer = new byte[1024 * 1024];





        public TestSession()
        {
            base.EventConnect += OnConnected;
            base.EventClose += OnClosed;
            base.EventReceive += OnReceived;
            base.PacketValidator += Packet.IsValidPacket;

            CreatePacketDispatcher(this, (ref StreamBuffer source, out string key) =>
            {
                source = new Packet(source as StreamBuffer);
                key = (source as Packet).PacketId.ToString();
                (source as Packet).SkipHeader();
            });
        }


        public void Connect()
        {
            Connect("127.0.0.1", 10100);
        }


        private void OnConnected(IOEventResult result)
        {
            if (result.Result == AegisResult.Ok)
                Logger.Info("[{0}] Connected", SessionId);
            else
                Connect("127.0.0.1", 10100);
        }


        private void OnClosed(IOEventResult result)
        {
            if (result.Result == AegisResult.Ok)
            {
                Logger.Info("[{0}] Closed", SessionId);
            }
            else
            {
                Logger.Info("[{0}] Closed by remote.", SessionId);
                Connect("127.0.0.1", 10100);
            }
        }


        private void OnReceived(IOEventResult result)
        {
            Packet packet = new Packet(result.Buffer);
            Logger.Err("Invalid packet received(PacketId={0:X})", packet.PacketId);
        }


        [TargetMethod(Protocol.Hello_Ntf)]
        private void Hello_Ntf(Packet packet)
        {
            Packet reqPacket = new Packet(Protocol.Echo_Req);
            reqPacket.Write(_tempBuffer, 0, FormMain.BufferSize);
            SendPacket(reqPacket);
        }


        [TargetMethod(Protocol.Echo_Res)]
        private void Echo_Res(Packet packet)
        {
            Packet reqPacket = new Packet(Protocol.Echo_Req);
            reqPacket.Write(_tempBuffer, 0, FormMain.BufferSize);


            SendPacket(reqPacket,
                        (buffer) => { return Packet.GetPacketId(buffer.Buffer) == Protocol.Echo_Res; },
                        (result) =>
                        {
                            packet.SkipHeader();
                            Echo_Res(new Packet(result.Buffer));
                        }
                );
        }
    }
}
