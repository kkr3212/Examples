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
    public static class CharacterBook
    {
        public class Data
        {
            public static readonly List<Data> Items = new List<Data>();
            public readonly Int32 CharacterId, RaceId, CharacterTypeId, JobId, PositionId, DamageTypeId;
            public readonly String Name;
            public readonly Int32 InitGradeId, InitPromotionId, MaxGradeId, MaxPromotionId;
            public readonly Int32 AP, DP, HP;

            public Data(ExcelSheet sheet)
            {
                CharacterId = sheet.GetCellValue("character_id").Value;
                Name = sheet.GetCellValue("character_name").Value;
                RaceId = sheet.GetCellValue("race_id").Value;
                CharacterTypeId = sheet.GetCellValue("charactertype_id").Value;
                JobId = sheet.GetCellValue("job_id").Value;
                PositionId = sheet.GetCellValue("position_id").Value;
                DamageTypeId = sheet.GetCellValue("damagetype_id").Value;
                InitGradeId = sheet.GetCellValue("init_grade_id").Value;
                InitPromotionId = sheet.GetCellValue("init_promotion_id").Value;
                MaxGradeId = sheet.GetCellValue("max_grade_id").Value;
                MaxPromotionId = sheet.GetCellValue("max_promotion_id").Value;
                AP = sheet.GetCellValue("ap").Value;
                DP = sheet.GetCellValue("dp").Value;
                HP = sheet.GetCellValue("hp").Value;
                Items.Add(this);
            }
        }
        public class LevelData
        {
            public static readonly List<LevelData> Items = new List<LevelData>();
            public readonly Int32 Level, NeedExp;

            public LevelData(ExcelSheet sheet)
            {
                Level = sheet.GetCellValue("character_lv").Value;
                NeedExp = sheet.GetCellValue("need_exp").Value;
                Items.Add(this);
            }
        }





        public static void Refresh()
        {
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/Character"), 3, 4, 5))
            {
                ExcelSheet sheet;


                Data.Items.Clear();
                sheet = excel.GetSheet("book_character").Load();
                while (sheet.NextRow())
                    new Data(sheet);


                LevelData.Items.Clear();
                sheet = excel.GetSheet("book_character_lv").Load();
                while (sheet.NextRow())
                    new LevelData(sheet);
            }
        }


        public static CharacterBook.Data Find(Int32 characterId)
        {
            CharacterBook.Data data = CharacterBook.Data.Items.Find(v => v.CharacterId == characterId);
            if (data == null)
                throw new AegisException(ResultCode.System_Error, "Invalid CharacterId(={0}).", characterId);

            return data;
        }
    }
}
