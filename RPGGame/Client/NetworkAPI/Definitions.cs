using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace NetworkAPI
{
    public enum ServerType
    {
        None = 0,
        AuthServer = 1,
        Cache = 2,
        GameServer = 3
    }





    public static class Protocol
    {
        private static readonly Dictionary<UInt16, String> _ids = new Dictionary<UInt16, String>()
        {
            {0x1000, "CS_Hello_Ntf"},

            {0x2001, "CS_Auth_WorldList_Req"}, {0x2002, "CS_Auth_WorldList_Res"},
            {0x2003, "CS_Auth_RegisterGuest_Req"}, {0x2004, "CS_Auth_RegisterGuest_Res"},
            {0x2005, "CS_Auth_Guest_Req"}, {0x2006, "CS_Auth_Guest_Res"},
            {0x200F, "CS_Auth_ForceClosing_Ntf"},

            {0x3001, "CS_Login_Req"}, {0x3002, "CS_Login_Res"},
            {0x3003, "CS_GameData_Codes_Req"}, {0x3004, "CS_GameData_Codes_Res"},
            {0x3005, "CS_GameData_CharacterBook_Req"}, {0x3006, "CS_GameData_CharacterBook_Res"},
            {0x3007, "CS_GameData_MonsterBook_Req"}, {0x3008, "CS_GameData_MonsterBook_Res"},

            {0x3101, "CS_UserData_InitUser_Req"}, {0x3102, "CS_UserData_InitUser_Res"},
            {0x3103, "CS_UserData_UserInfo_Req"}, {0x3104, "CS_UserData_UserInfo_Res"},
            {0x3105, "CS_UserData_InvenCharacter_Req"}, {0x3106, "CS_UserData_InvenCharacter_Res"},
            {0x3107, "CS_UserData_InvenItem_Req"}, {0x3108, "CS_UserData_InvenItem_Res"},

            {0x3201, "CS_PvE_GetDeck_Req"}, {0x3202, "CS_PvE_GetDeck_Res"},
            {0x3203, "CS_PvE_SetDeck_Req"}, {0x3204, "CS_PvE_SetDeck_Res"},
            {0x3205, "CS_PvE_WorldList_Req"}, {0x3206, "CS_PvE_WorldList_Res"},
            {0x3207, "CS_PvE_FieldList_Req"}, {0x3208, "CS_PvE_FieldList_Res"},
            {0x3209, "CS_PvE_DungeonList_Req"}, {0x320A, "CS_PvE_DungeonList_Res"},
            {0x320B, "CS_PvE_EnterDungeon_Req"}, {0x320C, "CS_PvE_EnterDungeon_Res"},
        };
        public static UInt16 GetID(String name)
        {
            foreach (var id in _ids)
            {
                if (id.Value == name)
                    return id.Key;
            }

            throw new Exception(String.Format("Invalid protocol name({0}).", name));
        }
        public static String GetName(UInt16 id)
        {
            String name;
            if (_ids.TryGetValue(id, out name) == true)
                return name;

            throw new Exception(String.Format("Invalid protocol id(0x{0:X}).", id));
        }
    }





    public static class ResultCode
    {
        public const Int32 Ok = 0;
        public const Int32 Unknown_Error = 1;
        public const Int32 Database_Error = 2;
        public const Int32 System_Error = 3;
        public const Int32 InvalidUid = 4;

        public const Int32 NoAvailableServer = 100;
        public const Int32 ServiceClosed = 101;
        public const Int32 ExistsUserToken = 102;
        public const Int32 NewUser = 103;

        public const Int32 InvalidUserToken = 200;
        public const Int32 InvalidUserNo = 201;
        public const Int32 InvalidAuthKey = 202;
        public const Int32 InvalidOperation = 203;
        public const Int32 InvalidDeckType = 204;





        public static String ToString(Int32 resultCode)
        {
            switch (resultCode)
            {
                case Ok: return "Ok";
                case Unknown_Error: return "Unknown_Error";
                case Database_Error: return "Database_Error";
                case System_Error: return "System_Error";
                case InvalidUid: return "InvalidUid";

                case NoAvailableServer: return "NoAvailableServer";
                case ServiceClosed: return "ServiceClosed";
                case ExistsUserToken: return "ExistsUserToken";
                case NewUser: return "NewUser";

                case InvalidUserToken: return "InvalidUserToken";
                case InvalidUserNo: return "InvalidUserNo";
                case InvalidAuthKey: return "InvalidAuthKey";
                case InvalidOperation: return "InvalidOperation";
                case InvalidDeckType: return "InvalidDeckType";
            }

            return String.Format($"Unknown ResultCode(={resultCode}).");
        }
    }





    public enum DeckType
    {
        PvE_Normal,
        PvE_Training,
        PvP_BattleField,
        PvP_Crusade,
        Count
    }





    public static class Constants
    {
        public const Int32 MaxDeckSlotCount = 5;
    }
}
