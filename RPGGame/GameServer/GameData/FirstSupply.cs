using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGGame.Common.Excel;
using Aegis;



namespace RPGGame.GameServer.GameData
{
    public static class FirstSupply
    {
        public struct CharacterData
        {
            public static readonly List<CharacterData> Items = new List<CharacterData>();

            public readonly Int32 CharacterId;
            public CharacterData(ExcelSheet sheet)
            {
                CharacterId = sheet.GetCellValue("character_id").Value;
                Items.Add(this);
            }
        }
        public struct ResourceData
        {
            public static readonly List<ResourceData> Items = new List<ResourceData>();

            public readonly Int32 ResourceId, Point;
            public ResourceData(ExcelSheet sheet)
            {
                ResourceId = sheet.GetCellValue("resource_id").Value;
                Point = sheet.GetCellValue("point").Value;
                Items.Add(this);
            }
        }





        public static void Refresh()
        {
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/Player"), 3, 4, 5))
            {
                ExcelSheet sheet;


                CharacterData.Items.Clear();
                sheet = excel.GetSheet("first_supply_character").Load();
                while (sheet.NextRow())
                    new CharacterData(sheet);


                ResourceData.Items.Clear();
                sheet = excel.GetSheet("first_supply_resource").Load();
                while (sheet.NextRow())
                    new ResourceData(sheet);
            }
        }
    }
}
