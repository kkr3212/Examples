using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using RPGGame.Common.Excel;
using RPGGame.Common;



namespace RPGGame.GameServer.GameMap
{
    public class PvE_World
    {
        public static readonly List<PvE_World> Worlds = new List<PvE_World>();
        public readonly Int32 WorldId, ModeType;
        public readonly String Name;
        public readonly Int32 NeedVIPLevel, NeedPlayerLevel, NeedCharacterLevel;
        public readonly List<PvE_Field> SubFields = new List<PvE_Field>();





        public PvE_World(ExcelSheet sheet)
        {
            WorldId = sheet.GetCellValue("world_id").Value;
            Name = sheet.GetCellValue("name").Value;
            ModeType = sheet.GetCellValue("mode_type").Value;
            NeedVIPLevel = sheet.GetCellValue("need_vip_lv").Value;
            NeedPlayerLevel = sheet.GetCellValue("need_player_lv").Value;
            NeedCharacterLevel = sheet.GetCellValue("need_character_lv").Value;
            Worlds.Add(this);
        }


        public static void Refresh()
        {
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/MapPvE"), 3, 4, 5))
            {
                Worlds.Clear();
                var sheet = excel.GetSheet("world").Load();
                while (sheet.NextRow())
                    new PvE_World(sheet);
            }
        }


        public static PvE_World Find(Int32 worldId)
        {
            PvE_World world = Worlds.Find(v => v.WorldId == worldId);
            if (world != null)
                return world;

            throw new AegisException(ResultCode.InvalidUid, "Invalid worldId({0}).", worldId);
        }
    }
}
