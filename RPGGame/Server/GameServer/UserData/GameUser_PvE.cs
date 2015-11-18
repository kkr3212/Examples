using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.Converter;
using Aegis.Data.MySql;
using RPGGame.Common;
using RPGGame.GameServer.GameData;
using RPGGame.GameServer.GameMap;



namespace RPGGame.GameServer.UserData
{
    public class PlayingRound
    {
        public readonly PvE_Round Round;
        public readonly List<PvE_MonsterPool.MonsterData> Monsters = new List<PvE_MonsterPool.MonsterData>();


        public PlayingRound(PvE_Round round)
        {
            Round = round;


            //  MonsterPool에서 해당 라운드의 몬스터목록 추출
            Randomizer<PvE_MonsterPool.MonsterData> rand = new Randomizer<PvE_MonsterPool.MonsterData>();
            foreach (var monster in PvE_MonsterPool.Items.Where(v => v.RoundId == round.RoundId))
                rand.AddItem(monster.Prob, monster);


            //  지정된 수 만큼 임의로 몬스터 선택
            for (Int32 i = 0; i < round.MonsterCount; ++i)
            {
                var monsterData = new PvE_MonsterPool.MonsterData(i + 1, rand.NextItem(0, false));
                Monsters.Add(monsterData);


                if (monsterData.Base.FixedLevel == 0)
                    monsterData.Level = Round.Dungeon.Level;
                else
                    monsterData.Level = monsterData.Base.FixedLevel;
            }
        }
    }





    public partial class GameUser
    {
        public List<PlayingRound> PlayingRounds = new List<PlayingRound>();





        public void EnterDungeon(Int32 dungeonId)
        {
            PlayingRounds.Clear();


            PvE_Dungeon dungeon = PvE_Dungeon.Find(dungeonId);
            foreach (var round in dungeon.SubRounds)
            {
                PlayingRound pr = new PlayingRound(round);
                PlayingRounds.Add(pr);
            }
        }
    }
}
