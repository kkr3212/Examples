using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGGame.Common.Excel;
using Aegis;



namespace RPGGame.GameServer.GameData
{
    public static class ItemBook
    {
        public class Data
        {
            public static readonly List<Data> Items = new List<Data>();
            public readonly Int32 ItemId, ItemType, PromotionId;
            public readonly String Name;
            public readonly Int32 ItemCount, MaxCarryCount, TargetReferenceId;
            public readonly Int32 SaleResourceId, SaleResourceAmount;

            public Data(ExcelSheet sheet)
            {
                ItemId = sheet.GetCellValue("item_id").Value;
                Name = sheet.GetCellValue("item_name").Value;
                ItemType = sheet.GetCellValue("item_type").Value;
                PromotionId = sheet.GetCellValue("promotion_id").Value;
                ItemCount = sheet.GetCellValue("item_count").Value;
                MaxCarryCount = sheet.GetCellValue("max_carrycount").Value;
                TargetReferenceId = sheet.GetCellValue("target_reference_id").Value;
                SaleResourceId = sheet.GetCellValue("sale_resourceid").Value;
                SaleResourceAmount = sheet.GetCellValue("sale_resourceamount").Value;
                Items.Add(this);
            }
        }





        public static void Refresh()
        {
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/Item"), 3, 4, 5))
            {
                ExcelSheet sheet;


                Data.Items.Clear();
                sheet = excel.GetSheet("book_item").Load();
                while (sheet.NextRow())
                    new Data(sheet);
            }
        }
    }
}
