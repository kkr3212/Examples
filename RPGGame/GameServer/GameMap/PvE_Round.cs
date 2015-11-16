using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGGame.Common.Excel;
using Aegis;



namespace RPGGame.GameServer.GameMap
{
    public class PvE_Round
    {
        public static readonly List<PvE_Round> Rounds = new List<PvE_Round>();

        public readonly PvE_Dungeon Dungeon;
        public readonly Int32 RoundId, OrderNo, MonsterCount;
        public readonly String Name;
        public readonly Boolean IsBossRound;





        public PvE_Round(ExcelSheet sheet)
        {
            RoundId = sheet.GetCellValue("round_id").Value;
            OrderNo = sheet.GetCellValue("round_orderno").Value;
            IsBossRound = (sheet.GetCellValue("is_boss_round").Value == 1);
            Name = sheet.GetCellValue("name").Value;
            MonsterCount = sheet.GetCellValue("monster_count").Value;
            Rounds.Add(this);


            Int32 dungeonId = sheet.GetCellValue("parent_dungeon_id").Value;
            Dungeon = PvE_Dungeon.Dungeons.Find(v => v.DungeonId == dungeonId);
            Dungeon.SubRounds.Add(this);
        }


        public static void Refresh()
        {
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/MapPvE"), 3, 4, 5))
            {
                Rounds.Clear();
                var sheet = excel.GetSheet("round").Load();
                while (sheet.NextRow())
                    new PvE_Round(sheet);
            }
        }
    }
}
