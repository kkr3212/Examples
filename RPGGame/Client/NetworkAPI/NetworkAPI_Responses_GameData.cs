using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis.Client;
using Aegis.Client.Network;



namespace NetworkAPI
{
    public class Response_GameData_Codes : Response
    {
        public struct EnergyData
        {
            public Int32 EnergyId;
            public String Name;
        }
        public struct ResourceData
        {
            public Int32 ResourceId;
            public String Name;
        }
        public struct RaceData
        {
            public Int32 RaceId;
            public String Name;
        }
        public struct DamageTypeData
        {
            public Int32 DamageTypeId;
            public String Name;
        }
        public struct GradeData
        {
            public Int32 GradeId, GradeType, Priority;
            public String Name;
        }
        public struct PromotionData
        {
            public Int32 PromotionId, PromotionType, Priority;
            public String Name;
        }
        public struct JobData
        {
            public Int32 JobId;
            public String Name;
        }
        public struct CharacterTypeData
        {
            public Int32 CharacterTypeId;
            public String Name;
        }
        public struct PositionData
        {
            public Int32 PositionId, PositionType;
            public String Name;
        }
        public readonly List<EnergyData> Energy = new List<EnergyData>();
        public readonly List<ResourceData> Resource = new List<ResourceData>();
        public readonly List<RaceData> Race = new List<RaceData>();
        public readonly List<DamageTypeData> DamageType = new List<DamageTypeData>();
        public readonly List<GradeData> Grade = new List<GradeData>();
        public readonly List<PromotionData> Promotion = new List<PromotionData>();
        public readonly List<JobData> Job = new List<JobData>();
        public readonly List<CharacterTypeData> CharacterType = new List<CharacterTypeData>();
        public readonly List<PositionData> Position = new List<PositionData>();



        internal Response_GameData_Codes(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;


            Int32 count;


            count = packet.GetInt32();
            while (count-- > 0)
            {
                Energy.Add(new EnergyData()
                {
                    EnergyId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16()
                });
            }


            count = packet.GetInt32();
            while (count-- > 0)
            {
                Resource.Add(new ResourceData()
                {
                    ResourceId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16()
                });
            }


            count = packet.GetInt32();
            while (count-- > 0)
            {
                Race.Add(new RaceData()
                {
                    RaceId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16()
                });
            }


            count = packet.GetInt32();
            while (count-- > 0)
            {
                DamageType.Add(new DamageTypeData()
                {
                    DamageTypeId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16()
                });
            }


            count = packet.GetInt32();
            while (count-- > 0)
            {
                Grade.Add(new GradeData()
                {
                    GradeId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16(),
                    GradeType = packet.GetInt32(),
                    Priority = packet.GetInt32()
                });
            }


            count = packet.GetInt32();
            while (count-- > 0)
            {
                Promotion.Add(new PromotionData()
                {
                    PromotionId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16(),
                    PromotionType = packet.GetInt32(),
                    Priority = packet.GetInt32()
                });
            }


            count = packet.GetInt32();
            while (count-- > 0)
            {
                Job.Add(new JobData()
                {
                    JobId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16()
                });
            }


            count = packet.GetInt32();
            while (count-- > 0)
            {
                CharacterType.Add(new CharacterTypeData()
                {
                    CharacterTypeId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16()
                });
            }


            count = packet.GetInt32();
            while (count-- > 0)
            {
                Position.Add(new PositionData()
                {
                    PositionId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16(),
                    PositionType = packet.GetInt32()
                });
            }
        }
    }





    public class Response_CharacterBook : Response
    {
        public struct Data
        {
            public Int32 CharacterId, RaceId, CharacterTypeId, JobId, PositionId, DamageTypeId;
            public String Name;
            public Int32 InitGradeId, InitPromotionId, MaxGradeId, MaxPromotionId;
            public Int32 AP, DP, HP;
        }
        public readonly List<Data> Items = new List<Data>();



        internal Response_CharacterBook(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;

            Int32 count = packet.GetInt32();
            while (count-- > 0)
            {
                Items.Add(new Data()
                {
                    CharacterId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16(),
                    RaceId = packet.GetInt32(),
                    CharacterTypeId = packet.GetInt32(),
                    JobId = packet.GetInt32(),
                    PositionId = packet.GetInt32(),
                    DamageTypeId = packet.GetInt32(),
                    InitGradeId = packet.GetInt32(),
                    InitPromotionId = packet.GetInt32(),
                    MaxGradeId = packet.GetInt32(),
                    MaxPromotionId = packet.GetInt32(),
                    AP = packet.GetInt32(),
                    DP = packet.GetInt32(),
                    HP = packet.GetInt32()
                });
            }
        }
    }





    public class Response_MonsterBook : Response
    {
        public struct Data
        {
            public Int32 MonsterId, MonsterTypeId, PositionId, GradeId, PromotionId, DamageTypeId;
            public String Name;
            public Int32 FixedLevel, AP, DP, HP;
        }
        public readonly List<Data> Items = new List<Data>();



        internal Response_MonsterBook(SecurePacket packet)
            : base(packet)
        {
            if (ResultCodeNo != ResultCode.Ok)
                return;

            Int32 count = packet.GetInt32();
            while (count-- > 0)
            {
                Items.Add(new Data()
                {
                    MonsterId = packet.GetInt32(),
                    Name = packet.GetStringFromUtf16(),
                    MonsterTypeId = packet.GetInt32(),
                    PositionId = packet.GetInt32(),
                    GradeId = packet.GetInt32(),
                    PromotionId = packet.GetInt32(),
                    DamageTypeId = packet.GetInt32(),
                    FixedLevel = packet.GetInt32(),
                    AP = packet.GetInt32(),
                    DP = packet.GetInt32(),
                    HP = packet.GetInt32()
                });
            }
        }
    }
}
