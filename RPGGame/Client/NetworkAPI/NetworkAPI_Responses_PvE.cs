using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis.Client;
using Aegis.Client.Network;



namespace NetworkAPI
{
    public class Response_PvE_PlayDeck : Response
    {
        public struct Data
        {
            public Int32 SlotNo, CharacterNo;
        }
        public readonly List<Data> Items = new List<Data>();



        internal Response_PvE_PlayDeck(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;


            Int32 count = packet.GetInt32();
            while (count-- > 0)
            {
                Items.Add(new Data()
                {
                    SlotNo = packet.GetInt32(),
                    CharacterNo = packet.GetInt32()
                });
            }
        }
    }


    public class Response_PvE_WorldList : Response
    {
        public struct Data
        {
            public Int32 WorldId;
            public String Name;
            public Int32 NeedVIPLevel, NeedPlayerLevel, NeedCharacterLevel;
        }
        public readonly List<Data> Items = new List<Data>();



        internal Response_PvE_WorldList(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;

            Int32 count = packet.GetInt32();
            while (count-- > 0)
            {
                Items.Add(new Data()
                {
                    WorldId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16(),
                    NeedVIPLevel = packet.GetInt32(),
                    NeedPlayerLevel = packet.GetInt32(),
                    NeedCharacterLevel = packet.GetInt32()
                });
            }
        }
    }


    public class Response_PvE_FieldList : Response
    {
        public struct Data
        {
            public Int32 FieldId;
            public String Name;
            public Int32 NeedVIPLevel, NeedPlayerLevel;
        }
        public readonly List<Data> Items = new List<Data>();



        internal Response_PvE_FieldList(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;

            Int32 count = packet.GetInt32();
            while (count-- > 0)
            {
                Items.Add(new Data()
                {
                    FieldId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16(),
                    NeedVIPLevel = packet.GetInt32(),
                    NeedPlayerLevel = packet.GetInt32()
                });
            }
        }
    }


    public class Response_PvE_DungeonList : Response
    {
        public struct Data
        {
            public Int32 DungeonId;
            public String Name;
            public Int32 Level, EnterFee_EnergyId, EnterFee_Amount;
        }
        public readonly List<Data> Items = new List<Data>();



        internal Response_PvE_DungeonList(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;

            Int32 count = packet.GetInt32();
            while (count-- > 0)
            {
                Items.Add(new Data()
                {
                    DungeonId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16(),
                    Level = packet.GetInt32(),
                    EnterFee_EnergyId = packet.GetInt32(),
                    EnterFee_Amount = packet.GetInt32()
                });
            }
        }
    }


    public class Response_PvE_EnterDungeon : Response
    {
        public struct MonsterData
        {
            public Int32 MonsterNo, MonsterId;
            public String Name;
            public Int32 GradeId, PromotionId, Level;
        }
        public struct RoundData
        {
            public Int32 RoundId;
            public String Name;
            public Boolean IsBossRound;
            public List<MonsterData> Monsters;
        }
        public readonly List<RoundData> Rounds = new List<RoundData>();



        internal Response_PvE_EnterDungeon(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;

            Int32 count = packet.GetInt32();
            while (count-- > 0)
            {
                RoundData round = new RoundData();
                round.RoundId = packet.GetInt32();
                round.Name = packet.GetStringFromUtf16();
                round.IsBossRound = packet.GetBoolean();
                round.Monsters = new List<MonsterData>();
                Rounds.Add(round);


                Int32 monsterCount = packet.GetInt32();
                while (monsterCount-- > 0)
                {
                    MonsterData monster = new MonsterData();
                    monster.MonsterNo = packet.GetInt32();
                    monster.MonsterId = packet.GetInt32();
                    monster.Name = packet.GetStringFromUtf16();
                    monster.GradeId = packet.GetInt32();
                    monster.PromotionId = packet.GetInt32();
                    monster.Level = packet.GetInt32();
                    round.Monsters.Add(monster);
                }
            }
        }
    }
}
