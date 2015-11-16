using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis.Client;
using Aegis.Client.Network;



namespace RPGGame.GameClient
{
    public class Response_WorldList : Response
    {
        public struct WorldInfo
        {
            public Int32 WorldId;
            public String WorldName;
        }
        public readonly List<WorldInfo> Items = new List<WorldInfo>();



        internal Response_WorldList(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;

            Int32 count = packet.GetInt32();
            while (count-- > 0)
            {
                Items.Add(new WorldInfo()
                {
                    WorldId = packet.GetInt32(),
                    WorldName = packet.GetStringFromUtf16()
                });
            }
        }
    }


    public class Response_UserInfo : Response
    {
        public struct EnergyData
        {
            public Int32 EnergyId, Point, RemainSecond;
        }
        public struct ResourceData
        {
            public Int32 ResourceId, Point;
        }

        public readonly String Nickname;
        public readonly Int32 Level, VIPLevel;
        public readonly Int32 Exp, VIPExp;
        public readonly List<EnergyData> Energies = new List<EnergyData>();
        public readonly List<ResourceData> Resources = new List<ResourceData>();



        internal Response_UserInfo(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;

            Int32 count;


            Nickname = packet.GetStringFromUtf16();
            Level = packet.GetInt32();
            Exp = packet.GetInt32();
            VIPLevel = packet.GetInt32();
            VIPExp = packet.GetInt32();


            count = packet.GetInt32();
            while (count-- > 0)
            {
                Energies.Add(new EnergyData()
                {
                    EnergyId = packet.GetInt32(),
                    Point = packet.GetInt32(),
                    RemainSecond = packet.GetInt32()
                });
            }


            count = packet.GetInt32();
            while (count-- > 0)
            {
                Resources.Add(new ResourceData()
                {
                    ResourceId = packet.GetInt32(),
                    Point = packet.GetInt32()
                });
            }
        }
    }


    public class Response_InvenCharacter : Response
    {
        public struct CharacterData
        {
            public Int32 CharacterNo, CharacterId;
            public Int32 Level, Exp, GradeId, PromotionId;
        }
        public readonly Int32 MainCharacterNo, MaxInventoryCount;
        public readonly List<CharacterData> Items = new List<CharacterData>();



        internal Response_InvenCharacter(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;


            MainCharacterNo = packet.GetInt32();
            MaxInventoryCount = packet.GetInt32();

            Int32 count = packet.GetInt32();
            while (count-- > 0)
            {
                Items.Add(new CharacterData()
                {
                    CharacterNo = packet.GetInt32(),
                    CharacterId = packet.GetInt32(),
                    Level = packet.GetInt32(),
                    Exp = packet.GetInt32(),
                    GradeId = packet.GetInt32(),
                    PromotionId = packet.GetInt32()
                });
            }
        }
    }


    public class Response_InvenItem : Response
    {
        public struct ItemData
        {
            public Int32 ItemNo, ItemId;
            public Int32 PromotionId, Quantity;
        }
        public readonly Int32 MaxInventoryCount;
        public readonly List<ItemData> Items = new List<ItemData>();



        internal Response_InvenItem(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;


            MaxInventoryCount = packet.GetInt32();

            Int32 count = packet.GetInt32();
            while (count-- > 0)
            {
                Items.Add(new ItemData()
                {
                    ItemNo = packet.GetInt32(),
                    ItemId = packet.GetInt32(),
                    PromotionId = packet.GetInt32(),
                    Quantity = packet.GetInt32()
                });
            }
        }
    }
}
