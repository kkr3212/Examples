using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using Aegis;
using Aegis.Network;



namespace RPGGame.Common
{
    public class PacketRequest : Packet
    {
        private static Int32 _seqNo = 0;
        public new const Int32 HeaderSize = Packet.HeaderSize + 4;
        public Int32 SeqNo
        {
            get { return GetInt32(Packet.HeaderSize); }
            private set { OverwriteInt32(Packet.HeaderSize, value); }
        }





        public PacketRequest(StreamBuffer source)
            : base(source)
        {
        }


        public PacketRequest(UInt16 packetId)
            : base(packetId)
        {
            SeqNo = Interlocked.Increment(ref _seqNo);
        }


        public PacketRequest(UInt16 packetId, UInt16 capacity)
            : base(packetId, capacity)
        {
            SeqNo = Interlocked.Increment(ref _seqNo);
        }


        public override StreamBuffer Clone()
        {
            PacketRequest packet = new PacketRequest(this);
            packet.ResetReadIndex();
            packet.ResetWriteIndex();
            packet.Read(ReadBytes);

            return packet;
        }


        public override void SkipHeader()
        {
            base.SkipHeader();
            GetInt32();         //  SeqNo
        }


        public static new Boolean IsValidPacket(StreamBuffer buffer, out int packetSize)
        {
            if (buffer.WrittenBytes < HeaderSize)
            {
                packetSize = 0;
                return false;
            }

            packetSize = buffer.GetUInt16();
            return (packetSize > 0 && buffer.WrittenBytes >= packetSize);
        }


        public void Dispatch(Object instance, String methodName)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (method == null)
                throw new AegisException("No {0} method in {1}.", methodName, instance.GetType().Name);

            method.Invoke(instance, new object[] { this });
        }
    }
}
