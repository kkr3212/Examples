using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGGame.Common;
using RPGGame.Common.Excel;
using Aegis;



namespace RPGGame.GameServer.GameData
{
    public static class MonsterBook
    {
        public class Data
        {
            public static readonly List<Data> Items = new List<Data>();
            public readonly Int32 MonsterId, MonsterTypeId, PositionId, GradeId, PromotionId, DamageTypeId;
            public readonly String Name;
            public readonly Int32 FixedLevel, AP, DP, HP;

            public Data(ExcelSheet sheet)
            {
                MonsterId = sheet.GetCellValue("monster_id").Value;
                Name = sheet.GetCellValue("monster_name").Value;
                MonsterTypeId = sheet.GetCellValue("monstertype_id").Value;
                PositionId = sheet.GetCellValue("position_id").Value;
                GradeId = sheet.GetCellValue("grade_id").Value;
                PromotionId = sheet.GetCellValue("promotion_id").Value;
                DamageTypeId = sheet.GetCellValue("damagetype_id").Value;
                FixedLevel = sheet.GetCellValue("fixed_lv").Value;
                AP = sheet.GetCellValue("ap").Value;
                DP = sheet.GetCellValue("dp").Value;
                HP = sheet.GetCellValue("hp").Value;

                Items.Add(this);
            }
        }





        public static void Refresh()
        {
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/Character"), 3, 4, 5))
            {
                ExcelSheet sheet;


                Data.Items.Clear();
                sheet = excel.GetSheet("book_monster").Load();
                while (sheet.NextRow())
                    new Data(sheet);
            }
        }


        public static MonsterBook.Data Find(Int32 monsterId)
        {
            MonsterBook.Data data = MonsterBook.Data.Items.Find(v => v.MonsterId == monsterId);
            if (data == null)
                throw new AegisException(ResultCode.System_Error, "Invalid MonsterId(={0}).", monsterId);

            return data;
        }
    }
}
