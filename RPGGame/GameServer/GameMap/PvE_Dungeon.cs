using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGGame.Common;
using RPGGame.Common.Excel;
using Aegis;



namespace RPGGame.GameServer.GameMap
{
    public class PvE_Dungeon
    {
        public static readonly List<PvE_Dungeon> Dungeons = new List<PvE_Dungeon>();

        public readonly PvE_Field Field;
        public readonly Int32 DungeonId, Level, StageType;
        public readonly String Name;
        public readonly Int32 Ticket_RewardPlayerExp, Ticket_RewardResourceId, Ticket_RewardAmount;
        public readonly Int32 EnterFee_EnergyId, EnterFee_Amount;
        public readonly Int32 ClearFee_TicketId, ClearFee_TicketCount;
        public readonly List<PvE_Round> SubRounds = new List<PvE_Round>();





        public PvE_Dungeon(ExcelSheet sheet)
        {
            DungeonId = sheet.GetCellValue("dungeon_id").Value;
            Name = sheet.GetCellValue("name").Value;
            Level = sheet.GetCellValue("level").Value;
            StageType = sheet.GetCellValue("stage_type").Value;
            Ticket_RewardPlayerExp = sheet.GetCellValue("ticket_rewardplayerexp").Value;
            Ticket_RewardResourceId = sheet.GetCellValue("ticket_rewardresourceid").Value;
            Ticket_RewardAmount = sheet.GetCellValue("ticket_rewardamount").Value;
            EnterFee_EnergyId = sheet.GetCellValue("enter_fee_energy_id").Value;
            EnterFee_Amount = sheet.GetCellValue("enter_fee_amount").Value;
            Ticket_RewardPlayerExp = sheet.GetCellValue("ticket_rewardplayerexp").Value;
            ClearFee_TicketId = sheet.GetCellValue("clear_fee_ticket_id").Value;
            ClearFee_TicketCount = sheet.GetCellValue("clear_fee_ticketcount").Value;
            Dungeons.Add(this);


            Int32 fieldId = sheet.GetCellValue("parent_field_id").Value;
            Field = PvE_Field.Fields.Find(v => v.FieldId == fieldId);
            Field.SubDungeons.Add(this);
        }


        public static void Refresh()
        {
            using (var excel = new ExcelLoader(Starter.CustomData.GetValue("DataFile/MapPvE"), 3, 4, 5))
            {
                Dungeons.Clear();
                var sheet = excel.GetSheet("dungeon").Load();
                while (sheet.NextRow())
                    new PvE_Dungeon(sheet);
            }
        }


        public static PvE_Dungeon Find(Int32 dungeonId)
        {
            PvE_Dungeon dungeon = Dungeons.Find(v => v.DungeonId == dungeonId);
            if (dungeon != null)
                return dungeon;

            throw new AegisException(ResultCode.InvalidUid, "Invalid dungeonId({0}).", dungeonId);
        }
    }
}
