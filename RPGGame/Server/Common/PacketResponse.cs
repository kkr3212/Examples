using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.Network;



namespace RPGGame.Common
{
    public class PacketResponse : Packet
    {
        public new const Int32 HeaderSize = Packet.HeaderSize + 8;
        public Int32 SeqNo
        {
            get { return GetInt32(Packet.HeaderSize); }
            private set { OverwriteInt32(Packet.HeaderSize, value); }
        }
        public Int32 ResultCodeNo
        {
            get { return GetInt32(Packet.HeaderSize + 4); }
            set { OverwriteInt32(Packet.HeaderSize + 4, value); }
        }





        public static Int32 GetSeqNo(StreamBuffer source)
        {
            if (source.BufferSize < HeaderSize)
                return -1;

            return source.GetInt32(Packet.HeaderSize);
        }


        private PacketResponse()
        {
        }


        public PacketResponse(StreamBuffer source)
            : base(source)
        {
        }


        public PacketResponse(SecurePacketRequest requestPacket, UInt16 capacity = 0)
        {
            if (capacity > 0)
                Capacity(capacity);

            PacketId = (UInt16)(requestPacket.PacketId + 1);
            SeqNo = requestPacket.SeqNo;
            ResultCodeNo = 0;
        }


        public PacketResponse(SecurePacketRequest requestPacket, Int32 resultCode, UInt16 capacity = 0)
        {
            if (capacity > 0)
                Capacity(capacity);

            PacketId = (UInt16)(requestPacket.PacketId + 1);
            SeqNo = requestPacket.SeqNo;
            ResultCodeNo = resultCode;
        }


        public override StreamBuffer Clone()
        {
            PacketResponse packet = new PacketResponse();
            packet.Write(Buffer);

            packet.ResetReadIndex();
            packet.ResetWriteIndex();
            packet.Read(ReadBytes);

            return packet;
        }


        public override void SkipHeader()
        {
            base.SkipHeader();
            GetInt32();         //  ResultCode
        }


        public override void Clear()
        {
            Int32 seqNo = SeqNo;

            base.Clear();
            SeqNo = seqNo;
        }


        public override void Clear(byte[] source, int index, int size)
        {
            Int32 seqNo = SeqNo;

            base.Clear(source, index, size);
            SeqNo = seqNo;
        }


        public override void Clear(StreamBuffer source)
        {
            Int32 seqNo = SeqNo;

            base.Clear(source);
            SeqNo = seqNo;
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
    }
}
