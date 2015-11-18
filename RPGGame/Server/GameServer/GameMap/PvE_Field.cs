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
    public class PvE_Field
    {
        public static readonly List<PvE_Field> Fields = new List<PvE_Field>();

        public readonly PvE_World World;
        public readonly Int32 FieldId;
        public readonly String Name;
        public readonly Int32 NeedVIPLevel, NeedPlayerLevel, PrecedingFieldId;
        public readonly List<PvE_Dungeon> SubDungeons = new List<PvE_Dungeon>();





        public PvE_Field(ExcelSheet sheet)
        {
            FieldId = sheet.GetCellValue("field_id").Value;
            Name = sheet.GetCellValue("name").Value;
            NeedVIPLevel = sheet.GetCellValue("need_vip_lv").Value;
            NeedPlayerLevel = sheet.GetCellValue("need_player_lv").Value;
            PrecedingFieldId = sheet.GetCellValue("preceding_field_id").Value;
            Fields.Add(this);


            Int32 worldId = sheet.GetCellValue("parent_world_id").Value;
            World = PvE_World.Worlds.Find(v => v.WorldId == worldId);
            World.SubFields.Add(this);
        }


        public static void Refresh()
        {
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/MapPvE"), 3, 4, 5))
            {
                Fields.Clear();
                var sheet = excel.GetSheet("field").Load();
                while (sheet.NextRow())
                    new PvE_Field(sheet);
            }
        }


        public static PvE_Field Find(Int32 fieldId)
        {
            PvE_Field field = Fields.Find(v => v.FieldId == fieldId);
            if (field != null)
                return field;

            throw new AegisException(ResultCode.InvalidUid, "Invalid fieldId({0}).", fieldId);
        }
    }
}
