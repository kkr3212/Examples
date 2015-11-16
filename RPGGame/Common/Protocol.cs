using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RPGGame.Common
{
    public static class Protocol
    {
        //  Request와 Response는 연결된 숫자로 정의해야 합니다.
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


            {0x9001, "SS_Register_Req"}, {0x9002, "SS_Register_Res"},
            {0x9003, "SS_Traffic_Ntf"}
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
}
