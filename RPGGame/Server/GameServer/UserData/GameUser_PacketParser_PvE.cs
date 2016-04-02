using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.Utils.Converter;
using RPGGame.Common;
using RPGGame.GameServer.GameData;



namespace RPGGame.GameServer.UserData
{
    public partial class GameUser
    {
        private void OnCS_PvE_GetDeck_Req(SecurePacketRequest reqPacket)
        {
            DeckType deckType = (DeckType)reqPacket.GetInt32();
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket);


            try
            {
                PlayDeck.Deck deck = PlayDeck[deckType];
                Int32 slotNo = 0, idxCount;


                resPacket.ResultCodeNo = ResultCode.Ok;
                idxCount = resPacket.PutInt32(0);
                foreach (Character ch in deck.Characters)
                {
                    resPacket.PutInt32(slotNo);
                    if (ch == null)
                        resPacket.PutInt32(0);
                    else
                        resPacket.PutInt32(ch.CharacterNo);

                    ++slotNo;
                }
                resPacket.OverwriteInt32(idxCount, slotNo);
            }
            catch (AegisException e)
            {
                resPacket.Clear();
                resPacket.ResultCodeNo = e.ResultCodeNo;
            }

            SendPacket(resPacket);
        }


        private void OnCS_PvE_SetDeck_Req(SecurePacketRequest reqPacket)
        {
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket);


            try
            {
                DeckType deckType = (DeckType)reqPacket.GetInt32();
                Int32 count = reqPacket.GetInt32();
                PlayDeck.Deck deck = PlayDeck[deckType];


                //  수신된 데이터로 덱 구성
                deck.Clear();
                while (count-- > 0)
                {
                    Int32 slotNo = reqPacket.GetInt32();
                    Int32 characterNo = reqPacket.GetInt32();

                    deck.Characters[slotNo] = InvenCharacter.FindOrNull(characterNo);
                }


                //  DB에 업데이트
                PlayDeck.UpdateToDB(deckType);
            }
            catch (AegisException e)
            {
                resPacket.Clear();
                resPacket.ResultCodeNo = e.ResultCodeNo;
            }

            SendPacket(resPacket);
        }


        private void OnCS_PvE_WorldList_Req(SecurePacketRequest reqPacket)
        {
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket, 4096);
            Int32 count = 0;
            Int32 idxCount = resPacket.PutInt32(count);
            foreach (var data in GameMap.PvE_World.Worlds)
            {
                resPacket.PutInt32(data.WorldId);
                resPacket.PutStringAsUtf16(data.Name);
                resPacket.PutInt32(data.NeedVIPLevel);
                resPacket.PutInt32(data.NeedPlayerLevel);
                resPacket.PutInt32(data.NeedCharacterLevel);
                ++count;
            }


            resPacket.ResultCodeNo = ResultCode.Ok;
            resPacket.OverwriteInt32(idxCount, count);
            SendPacket(resPacket);
        }


        private void OnCS_PvE_FieldList_Req(SecurePacketRequest reqPacket)
        {
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket, 4096);


            try
            {
                //  상위 월드정보
                Int32 worldId = reqPacket.GetInt32();
                var world = GameMap.PvE_World.Find(worldId);


                //  결과 패킷
                Int32 count = 0;
                Int32 idxCount = resPacket.PutInt32(count);
                foreach (var data in world.SubFields)
                {
                    resPacket.PutInt32(data.FieldId);
                    resPacket.PutStringAsUtf16(data.Name);
                    resPacket.PutInt32(data.NeedVIPLevel);
                    resPacket.PutInt32(data.NeedPlayerLevel);
                    ++count;
                }

                resPacket.ResultCodeNo = ResultCode.Ok;
                resPacket.OverwriteInt32(idxCount, count);
            }
            catch (AegisException e)
            {
                resPacket.ResultCodeNo = e.ResultCodeNo;
            }


            SendPacket(resPacket);
        }


        private void OnCS_PvE_DungeonList_Req(SecurePacketRequest reqPacket)
        {
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket, 4096);


            try
            {
                //  상위 필드정보
                Int32 fieldId = reqPacket.GetInt32();
                var field = GameMap.PvE_Field.Find(fieldId);


                //  결과 패킷
                Int32 count = 0;
                Int32 idxCount = resPacket.PutInt32(count);
                foreach (var data in field.SubDungeons)
                {
                    resPacket.PutInt32(data.DungeonId);
                    resPacket.PutStringAsUtf16(data.Name);
                    resPacket.PutInt32(data.Level);
                    resPacket.PutInt32(data.EnterFee_EnergyId);
                    resPacket.PutInt32(data.EnterFee_Amount);
                    ++count;
                }

                resPacket.ResultCodeNo = ResultCode.Ok;
                resPacket.OverwriteInt32(idxCount, count);
            }
            catch (AegisException e)
            {
                resPacket.ResultCodeNo = e.ResultCodeNo;
            }


            SendPacket(resPacket);
        }


        private void OnCS_PvE_EnterDungeon_Req(SecurePacketRequest reqPacket)
        {
            Int32 dungeonId = reqPacket.GetInt32();
            SecurePacketResponse resPacket = new SecurePacketResponse(reqPacket);


            try
            {
                EnterDungeon(dungeonId);


                resPacket.ResultCodeNo = ResultCode.Ok;
                Int32 roundCount = 0, idxRoundCount = resPacket.PutInt32(0);
                foreach (var playingRound in PlayingRounds)
                {
                    resPacket.PutInt32(playingRound.Round.RoundId);
                    resPacket.PutStringAsUtf16(playingRound.Round.Name);
                    resPacket.PutBoolean(playingRound.Round.IsBossRound);

                    Int32 monsterCount = 0, idxMonsterCount = resPacket.PutInt32(0);
                    foreach (var monster in playingRound.Monsters)
                    {
                        resPacket.PutInt32(monster.MonsterNo);
                        resPacket.PutInt32(monster.MonsterId);
                        resPacket.PutStringAsUtf16(monster.Base.Name);
                        resPacket.PutInt32(monster.Base.GradeId);
                        resPacket.PutInt32(monster.Base.PromotionId);
                        resPacket.PutInt32(monster.Level);

                        ++monsterCount;
                    }
                    resPacket.OverwriteInt32(idxMonsterCount, monsterCount);
                    ++roundCount;
                }
                resPacket.OverwriteInt32(idxRoundCount, roundCount);
            }
            catch (AegisException e)
            {
                resPacket.Clear();
                resPacket.ResultCodeNo = e.ResultCodeNo;
            }

            SendPacket(resPacket);
        }
    }
}
