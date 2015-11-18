using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGGame.Common.Excel;
using Aegis;



namespace RPGGame.GameServer.GameData
{
    public static class PlayerBook
    {
        public class PlayerLevel
        {
            public static readonly Dictionary<Int32, PlayerLevel> Items = new Dictionary<Int32, PlayerLevel>();
            public static Int32 MinLevel { get { return Items.Values.Select(v => v.Level).Min(); } }
            public static Int32 MaxLevel { get { return Items.Values.Select(v => v.Level).Max(); } }
            public readonly Int32 Level, NeedExp;
            public readonly Int32 MaxCharacterInventory, MaxItemInventory, MaxFriendCount, MaxCharacterLevel;

            public PlayerLevel(ExcelSheet sheet)
            {
                Level = sheet.GetCellValue("player_lv").Value;
                NeedExp = sheet.GetCellValue("need_exp").Value;
                MaxCharacterInventory = sheet.GetCellValue("max_characterinventory").Value;
                MaxItemInventory = sheet.GetCellValue("max_iteminventory").Value;
                MaxFriendCount = sheet.GetCellValue("max_friendcount").Value;
                MaxCharacterLevel = sheet.GetCellValue("max_characterlv").Value;
                Items.Add(Level, this);
            }
        }
        public class VIPLevel
        {
            public static readonly Dictionary<Int32, VIPLevel> Items = new Dictionary<Int32, VIPLevel>();
            public static Int32 MinLevel { get { return Items.Values.Select(v => v.Level).Min(); } }
            public static Int32 MaxLevel { get { return Items.Values.Select(v => v.Level).Max(); } }
            public readonly Int32 Level, NeedCash;

            public VIPLevel(ExcelSheet sheet)
            {
                Level = sheet.GetCellValue("vip_lv").Value;
                NeedCash = sheet.GetCellValue("need_cash").Value;
                Items.Add(Level, this);
            }
        }
        public class Energy
        {
            public static readonly List<Energy> Items = new List<Energy>();
            public readonly Int32 PlayerLevel, EnergyId;
            public readonly Int32 MaxPoint, CoolTime, RegainValue;
            public readonly Int32 LevelUp_IncType, LevelUp_IncValue;

            public Energy(ExcelSheet sheet)
            {
                PlayerLevel = sheet.GetCellValue("player_lv").Value;
                EnergyId = sheet.GetCellValue("energy_id").Value;
                MaxPoint = sheet.GetCellValue("max_point").Value;
                CoolTime = sheet.GetCellValue("cooltime").Value;
                RegainValue = sheet.GetCellValue("regain_value").Value;
                LevelUp_IncType = sheet.GetCellValue("levelup_inctype").Value;
                LevelUp_IncValue = sheet.GetCellValue("levelup_incvalue").Value;
                Items.Add(this);
            }


            public static Energy GetData(Int32 playerLevel, Int32 energyId)
            {
                var item = Items.Find(v => v.PlayerLevel == playerLevel && v.EnergyId == energyId);
                if (item == null)
                    throw new AegisException("No matches data in BookPlayer.Energy(playerLevel={0}, energyId={1}).", playerLevel, energyId);

                return item;
            }
        }





        public static void Refresh()
        {
            PlayerLevel.Items.Clear();
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/Player"), 3, 4, 5))
            {
                var sheet = excel.GetSheet("player_level").Load();
                while (sheet.NextRow())
                    new PlayerLevel(sheet);
            }


            VIPLevel.Items.Clear();
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/Player"), 3, 4, 5))
            {
                var sheet = excel.GetSheet("vip_level").Load();
                while (sheet.NextRow())
                    new VIPLevel(sheet);
            }


            Energy.Items.Clear();
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/Player"), 3, 4, 5))
            {
                var sheet = excel.GetSheet("player_energy").Load();
                while (sheet.NextRow())
                    new Energy(sheet);
            }
        }
    }
}
