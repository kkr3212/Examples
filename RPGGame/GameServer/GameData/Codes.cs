using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGGame.Common.Excel;
using Aegis;



namespace RPGGame.GameServer.GameData
{
    public static class Codes
    {
        public struct Energy
        {
            public static readonly Dictionary<Int32, Energy> Items = new Dictionary<Int32, Energy>();

            public readonly Int32 EnergyId;
            public readonly String Name;
            public Energy(ExcelSheet sheet)
            {
                EnergyId = sheet.GetCellValue("energy_id").Value;
                Name = sheet.GetCellValue("name").Value;
                Items.Add(EnergyId, this);
            }
        }
        public struct Resource
        {
            public static readonly Dictionary<Int32, Resource> Items = new Dictionary<Int32, Resource>();

            public readonly Int32 ResourceId;
            public readonly String Name;
            public Resource(ExcelSheet sheet)
            {
                ResourceId = sheet.GetCellValue("resource_id").Value;
                Name = sheet.GetCellValue("name").Value;
                Items.Add(ResourceId, this);
            }
        }
        public struct Race
        {
            public static readonly Dictionary<Int32, Race> Items = new Dictionary<Int32, Race>();

            public readonly Int32 RaceId;
            public readonly String Name;
            public Race(ExcelSheet sheet)
            {
                RaceId = sheet.GetCellValue("race_id").Value;
                Name = sheet.GetCellValue("name").Value;
                Items.Add(RaceId, this);
            }
        }
        public struct DamageType
        {
            public static readonly Dictionary<Int32, DamageType> Items = new Dictionary<Int32, DamageType>();

            public readonly Int32 DamageTypeId;
            public readonly String Name;
            public DamageType(ExcelSheet sheet)
            {
                DamageTypeId = sheet.GetCellValue("damagetype_id").Value;
                Name = sheet.GetCellValue("name").Value;
                Items.Add(DamageTypeId, this);
            }
        }
        public struct Grade
        {
            public static readonly Dictionary<Int32, Grade> Items = new Dictionary<Int32, Grade>();

            public readonly Int32 GradeId, GradeType, Priority;
            public readonly String Name;
            public Grade(ExcelSheet sheet)
            {
                GradeId = sheet.GetCellValue("grade_id").Value;
                GradeType = sheet.GetCellValue("grade_type").Value;
                Name = sheet.GetCellValue("name").Value;
                Priority = sheet.GetCellValue("grade_priority").Value;
                Items.Add(GradeId, this);
            }
        }
        public struct Promotion
        {
            public static readonly Dictionary<Int32, Promotion> Items = new Dictionary<Int32, Promotion>();

            public readonly Int32 PromotionId, PromotionType, Priority;
            public readonly String Name;
            public Promotion(ExcelSheet sheet)
            {
                PromotionId = sheet.GetCellValue("promotion_id").Value;
                PromotionType = sheet.GetCellValue("promotion_type").Value;
                Name = sheet.GetCellValue("name").Value;
                Priority = sheet.GetCellValue("promotion_priority").Value;
                Items.Add(PromotionId, this);
            }
        }
        public struct Job
        {
            public static readonly Dictionary<Int32, Job> Items = new Dictionary<Int32, Job>();

            public readonly Int32 JobId;
            public readonly String Name;
            public Job(ExcelSheet sheet)
            {
                JobId = sheet.GetCellValue("job_id").Value;
                Name = sheet.GetCellValue("name").Value;
                Items.Add(JobId, this);
            }
        }
        public struct CharacterType
        {
            public static readonly Dictionary<Int32, CharacterType> Items = new Dictionary<Int32, CharacterType>();

            public readonly Int32 CharacterTypeId;
            public readonly String Name;
            public CharacterType(ExcelSheet sheet)
            {
                CharacterTypeId = sheet.GetCellValue("charactertype_id").Value;
                Name = sheet.GetCellValue("name").Value;
                Items.Add(CharacterTypeId, this);
            }
        }
        public struct Position
        {
            public static readonly Dictionary<Int32, Position> Items = new Dictionary<Int32, Position>();

            public readonly Int32 PositionId, PositionType;
            public readonly String Name;
            public Position(ExcelSheet sheet)
            {
                PositionId = sheet.GetCellValue("position_id").Value;
                PositionType = sheet.GetCellValue("position_type").Value;
                Name = sheet.GetCellValue("name").Value;
                Items.Add(PositionId, this);
            }
        }





        public static void Refresh()
        {
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/Codes"), 3, 4, 5))
            {
                ExcelSheet sheet;


                Energy.Items.Clear();
                sheet = excel.GetSheet("code_energy").Load();
                while (sheet.NextRow())
                    new Energy(sheet);


                Resource.Items.Clear();
                sheet = excel.GetSheet("code_resource").Load();
                while (sheet.NextRow())
                    new Resource(sheet);


                Race.Items.Clear();
                sheet = excel.GetSheet("code_race").Load();
                while (sheet.NextRow())
                    new Race(sheet);


                DamageType.Items.Clear();
                sheet = excel.GetSheet("code_damagetype").Load();
                while (sheet.NextRow())
                    new DamageType(sheet);


                Grade.Items.Clear();
                sheet = excel.GetSheet("code_grade").Load();
                while (sheet.NextRow())
                    new Grade(sheet);


                Promotion.Items.Clear();
                sheet = excel.GetSheet("code_promotion").Load();
                while (sheet.NextRow())
                    new Promotion(sheet);


                Job.Items.Clear();
                sheet = excel.GetSheet("code_job").Load();
                while (sheet.NextRow())
                    new Job(sheet);


                CharacterType.Items.Clear();
                sheet = excel.GetSheet("code_charactertype").Load();
                while (sheet.NextRow())
                    new CharacterType(sheet);


                Position.Items.Clear();
                sheet = excel.GetSheet("code_position").Load();
                while (sheet.NextRow())
                    new Position(sheet);
            }
        }
    }
}
