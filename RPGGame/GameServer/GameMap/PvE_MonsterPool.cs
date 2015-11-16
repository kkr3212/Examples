using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using RPGGame.Common.Excel;
using RPGGame.GameServer.GameData;



namespace RPGGame.GameServer.GameMap
{
    public class PvE_MonsterPool
    {
        public class MonsterData
        {
            public readonly MonsterBook.Data Base;
            public readonly Int32 RoundId;
            public readonly Int32 MonsterId, AppearType, Prob;
            public readonly Int32 KillReward_PlayerExp, KillReward_CharacterExp;
            public readonly Int32 KillReward_ResourceId, KillReward_Amount;
            public readonly Int32 MonsterNo;
            public Int32 Level { get; set; }



            public MonsterData(Int32 monsterNo, MonsterData data)
            {
                MonsterNo = monsterNo;
                RoundId = data.RoundId;
                MonsterId = data.MonsterId;
                AppearType = data.AppearType;
                Prob = data.Prob;
                KillReward_PlayerExp = data.KillReward_PlayerExp;
                KillReward_CharacterExp = data.KillReward_CharacterExp;
                KillReward_ResourceId = data.KillReward_ResourceId;
                KillReward_Amount = data.KillReward_Amount;

                Base = MonsterBook.Find(MonsterId);
            }


            public MonsterData(ExcelSheet sheet)
            {
                RoundId = sheet.GetCellValue("round_id").Value;
                MonsterId = sheet.GetCellValue("monster_id").Value;
                AppearType = sheet.GetCellValue("appear_type").Value;
                Prob = sheet.GetCellValue("prob").Value;
                KillReward_PlayerExp = sheet.GetCellValue("kill_reward_playerexp").Value;
                KillReward_CharacterExp = sheet.GetCellValue("kill_reward_characterexp").Value;
                KillReward_ResourceId = sheet.GetCellValue("kill_reward_resourceid").Value;
                KillReward_Amount = sheet.GetCellValue("kill_reward_amount").Value;

                Base = MonsterBook.Find(MonsterId);
            }
        }
        public static readonly List<MonsterData> Items = new List<MonsterData>();



        public static void Refresh()
        {
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/MapPvE"), 3, 4, 5))
            {
                Items.Clear();
                var sheet = excel.GetSheet("monsterpool").Load();
                while (sheet.NextRow())
                    Items.Add(new MonsterData(sheet));
            }
        }
    }
}
