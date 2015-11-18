using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.Converter;
using RPGGame.Common;
using RPGGame.GameServer.GameData;



namespace RPGGame.GameServer.UserData
{
    public partial class GameUser
    {
        private void OnCS_GameData_Codes_Req(SecurePacketRequest reqPacket)
        {
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket, 65000);
            resPacket.ResultCodeNo = ResultCode.Ok;


            //  Energy
            resPacket.PutInt32(Codes.Energy.Items.Count);
            foreach (var data in Codes.Energy.Items.Values)
            {
                resPacket.PutInt32(data.EnergyId);
                resPacket.PutStringAsUtf16(data.Name);
            }


            //  Resource
            resPacket.PutInt32(Codes.Resource.Items.Count);
            foreach (var data in Codes.Resource.Items.Values)
            {
                resPacket.PutInt32(data.ResourceId);
                resPacket.PutStringAsUtf16(data.Name);
            }


            //  Race
            resPacket.PutInt32(Codes.Race.Items.Count);
            foreach (var data in Codes.Race.Items.Values)
            {
                resPacket.PutInt32(data.RaceId);
                resPacket.PutStringAsUtf16(data.Name);
            }


            //  DamageType
            resPacket.PutInt32(Codes.DamageType.Items.Count);
            foreach (var data in Codes.DamageType.Items.Values)
            {
                resPacket.PutInt32(data.DamageTypeId);
                resPacket.PutStringAsUtf16(data.Name);
            }


            //  Grade
            resPacket.PutInt32(Codes.Grade.Items.Count);
            foreach (var data in Codes.Grade.Items.Values)
            {
                resPacket.PutInt32(data.GradeId);
                resPacket.PutStringAsUtf16(data.Name);
                resPacket.PutInt32(data.GradeType);
                resPacket.PutInt32(data.Priority);
            }


            //  Promotion
            resPacket.PutInt32(Codes.Promotion.Items.Count);
            foreach (var data in Codes.Promotion.Items.Values)
            {
                resPacket.PutInt32(data.PromotionId);
                resPacket.PutStringAsUtf16(data.Name);
                resPacket.PutInt32(data.PromotionType);
                resPacket.PutInt32(data.Priority);
            }


            //  Promotion
            resPacket.PutInt32(Codes.Job.Items.Count);
            foreach (var data in Codes.Job.Items.Values)
            {
                resPacket.PutInt32(data.JobId);
                resPacket.PutStringAsUtf16(data.Name);
            }


            //  CharacterType
            resPacket.PutInt32(Codes.CharacterType.Items.Count);
            foreach (var data in Codes.CharacterType.Items.Values)
            {
                resPacket.PutInt32(data.CharacterTypeId);
                resPacket.PutStringAsUtf16(data.Name);
            }


            //  Position
            resPacket.PutInt32(Codes.Position.Items.Count);
            foreach (var data in Codes.Position.Items.Values)
            {
                resPacket.PutInt32(data.PositionId);
                resPacket.PutStringAsUtf16(data.Name);
                resPacket.PutInt32(data.PositionType);
            }

            SendPacket(resPacket);
        }


        private void OnCS_GameData_CharacterBook_Req(SecurePacketRequest reqPacket)
        {
            Int32 startId = reqPacket.GetInt32();
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket, 65000);
            resPacket.ResultCodeNo = ResultCode.Ok;


            Int32 count = 0;
            Int32 idxCount = resPacket.PutInt32(count);
            foreach (var ch in CharacterBook.Data.Items
                                                 .Where(v => v.CharacterId >= startId)
                                                 .OrderBy(v => v.CharacterId))
            {
                resPacket.PutInt32(ch.CharacterId);
                resPacket.PutStringAsUtf16(ch.Name);
                resPacket.PutInt32(ch.RaceId);
                resPacket.PutInt32(ch.CharacterTypeId);
                resPacket.PutInt32(ch.JobId);
                resPacket.PutInt32(ch.PositionId);
                resPacket.PutInt32(ch.DamageTypeId);
                resPacket.PutInt32(ch.InitGradeId);
                resPacket.PutInt32(ch.InitPromotionId);
                resPacket.PutInt32(ch.MaxGradeId);
                resPacket.PutInt32(ch.MaxPromotionId);
                resPacket.PutInt32(ch.AP);
                resPacket.PutInt32(ch.DP);
                resPacket.PutInt32(ch.HP);

                if (++count >= 400)
                    break;
            }
            resPacket.OverwriteInt32(idxCount, count);
            SendPacket(resPacket);
        }


        private void OnCS_GameData_MonsterBook_Req(SecurePacketRequest reqPacket)
        {
            Int32 startId = reqPacket.GetInt32();
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket, 65000);
            resPacket.ResultCodeNo = ResultCode.Ok;


            Int32 count = 0;
            Int32 idxCount = resPacket.PutInt32(count);
            foreach (var ch in MonsterBook.Data.Items
                                               .Where(v => v.MonsterId >= startId)
                                               .OrderBy(v => v.MonsterId))
            {
                resPacket.PutInt32(ch.MonsterId);
                resPacket.PutStringAsUtf16(ch.Name);
                resPacket.PutInt32(ch.MonsterTypeId);
                resPacket.PutInt32(ch.PositionId);
                resPacket.PutInt32(ch.GradeId);
                resPacket.PutInt32(ch.PromotionId);
                resPacket.PutInt32(ch.DamageTypeId);
                resPacket.PutInt32(ch.FixedLevel);
                resPacket.PutInt32(ch.AP);
                resPacket.PutInt32(ch.DP);
                resPacket.PutInt32(ch.HP);

                if (++count >= 400)
                    break;
            }
            resPacket.OverwriteInt32(idxCount, count);
            SendPacket(resPacket);
        }
    }
}
