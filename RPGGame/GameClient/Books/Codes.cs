using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGGame.GameClient;



namespace RPGGame.GameClient.Books
{
    public static class GameCode
    {
        public static readonly Dictionary<Int32, Response_GameData_Codes.EnergyData> Energy = new Dictionary<Int32, Response_GameData_Codes.EnergyData>();
        public static readonly Dictionary<Int32, Response_GameData_Codes.ResourceData> Resource = new Dictionary<Int32, Response_GameData_Codes.ResourceData>();
        public static readonly Dictionary<Int32, Response_GameData_Codes.RaceData> Race = new Dictionary<Int32, Response_GameData_Codes.RaceData>();
        public static readonly Dictionary<Int32, Response_GameData_Codes.DamageTypeData> DamageType = new Dictionary<Int32, Response_GameData_Codes.DamageTypeData>();
        public static readonly Dictionary<Int32, Response_GameData_Codes.GradeData> Grade = new Dictionary<Int32, Response_GameData_Codes.GradeData>();
        public static readonly Dictionary<Int32, Response_GameData_Codes.PromotionData> Promotion = new Dictionary<Int32, Response_GameData_Codes.PromotionData>();
        public static readonly Dictionary<Int32, Response_GameData_Codes.JobData> Job = new Dictionary<Int32, Response_GameData_Codes.JobData>();
        public static readonly Dictionary<Int32, Response_GameData_Codes.CharacterTypeData> CharacterType = new Dictionary<Int32, Response_GameData_Codes.CharacterTypeData>();
        public static readonly Dictionary<Int32, Response_GameData_Codes.PositionData> Position = new Dictionary<Int32, Response_GameData_Codes.PositionData>();
    }


    public static class CharacterBook
    {
        public static readonly List<Response_CharacterBook.Data> Items = new List<Response_CharacterBook.Data>();
    }


    public static class MonsterBook
    {
        public static readonly List<Response_MonsterBook.Data> Items = new List<Response_MonsterBook.Data>();
    }
}
