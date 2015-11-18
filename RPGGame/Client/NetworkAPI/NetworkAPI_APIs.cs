using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis.Client;
using Aegis.Client.Network;



namespace NetworkAPI
{
    public static partial class Requester
    {
        ////////////////////////////////////////////////////////////////////////////////
        //  Authentication
        private static Int32 _userNo, _authKey;


        public static void Auth_WorldList(APICallbackHandler<Response_WorldList> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_Auth_WorldList_Req"));
            reqPacket.PutInt32(0);  //  UserNo
            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response_WorldList(resPacket)); });
        }


        public static void Auth_RegisterGuest(String userToken, APICallbackHandler<Response> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_Auth_RegisterGuest_Req"));
            reqPacket.PutInt32(0);  //  UserNo
            reqPacket.PutStringAsUtf16(userToken);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response(resPacket)); });
        }


        public static void Auth_LoginGuest(Int32 worldId, String userToken, APICallbackHandler<Response> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_Auth_Guest_Req"));
            reqPacket.PutInt32(0);  //  UserNo
            reqPacket.PutInt32(worldId);
            reqPacket.PutStringAsUtf16(userToken);

            _request.SendPacket(reqPacket, (resPacket) =>
            {
                Int32 ret = resPacket.GetInt32();
                if (ret == ResultCode.Ok)
                {
                    _userNo = resPacket.GetInt32();
                    _authKey = resPacket.GetInt32();
                    _request.HostAddress = resPacket.GetStringFromUtf16();
                    _request.HostPortNo = resPacket.GetInt32();
                    _request.ConnectionAliveTime = 0;
                    _request.Disconnect();

                    Auth_LoginGameServer(callback);
                }
                else
                    callback(new Response(ret));
            });
        }


        private static void Auth_LoginGameServer(APICallbackHandler<Response> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_Login_Req"));
            reqPacket.PutInt32(_userNo);
            reqPacket.PutInt32(_authKey);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response(resPacket)); });
        }



        ////////////////////////////////////////////////////////////////////////////////
        //  Game Data
        public static void GameData_Codes(APICallbackHandler<Response_GameData_Codes> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_GameData_Codes_Req"));
            reqPacket.PutInt32(_userNo);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response_GameData_Codes(resPacket)); });
        }


        public static void GameData_CharacterBook(Int32 startId, APICallbackHandler<Response_CharacterBook> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_GameData_CharacterBook_Req"));
            reqPacket.PutInt32(_userNo);
            reqPacket.PutInt32(startId);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response_CharacterBook(resPacket)); });
        }


        public static void GameData_MonsterBook(Int32 startId, APICallbackHandler<Response_MonsterBook> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_GameData_MonsterBook_Req"));
            reqPacket.PutInt32(_userNo);
            reqPacket.PutInt32(startId);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response_MonsterBook(resPacket)); });
        }



        ////////////////////////////////////////////////////////////////////////////////
        //  User Data
        public static void UserData_Init(String nickname, APICallbackHandler<Response> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_UserData_InitUser_Req"));
            reqPacket.PutInt32(_userNo);
            reqPacket.PutStringAsUtf16(nickname);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response(resPacket)); });
        }


        public static void UserData_UserInfo(APICallbackHandler<Response_UserInfo> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_UserData_UserInfo_Req"));
            reqPacket.PutInt32(_userNo);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response_UserInfo(resPacket)); });
        }


        public static void UserData_InvenCharacter(APICallbackHandler<Response_InvenCharacter> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_UserData_InvenCharacter_Req"));
            reqPacket.PutInt32(_userNo);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response_InvenCharacter(resPacket)); });
        }



        ////////////////////////////////////////////////////////////////////////////////
        //  PvE
        public static void PvE_GetDeck(DeckType deckType, APICallbackHandler<Response_PvE_PlayDeck> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_PvE_GetDeck_Req"));
            reqPacket.PutInt32(_userNo);
            reqPacket.PutInt32((Int32)deckType);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response_PvE_PlayDeck(resPacket)); });
        }


        public static void PvE_SetDeck(DeckType deckType, Int32[] characterNo, APICallbackHandler<Response> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_PvE_SetDeck_Req"));
            reqPacket.PutInt32(_userNo);
            reqPacket.PutInt32((Int32)deckType);
            reqPacket.PutInt32(characterNo.Length);
            for (Int32 i = 0; i < characterNo.Length; ++i)
            {
                reqPacket.PutInt32(i);
                reqPacket.PutInt32(characterNo[i]);
            }

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response(resPacket)); });
        }


        public static void PvE_WorldList(APICallbackHandler<Response_PvE_WorldList> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_PvE_WorldList_Req"));
            reqPacket.PutInt32(_userNo);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response_PvE_WorldList(resPacket)); });
        }


        public static void PvE_FieldList(Int32 parentWorldId, APICallbackHandler<Response_PvE_FieldList> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_PvE_FieldList_Req"));
            reqPacket.PutInt32(_userNo);
            reqPacket.PutInt32(parentWorldId);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response_PvE_FieldList(resPacket)); });
        }


        public static void PvE_DungeonList(Int32 parentField, APICallbackHandler<Response_PvE_DungeonList> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_PvE_DungeonList_Req"));
            reqPacket.PutInt32(_userNo);
            reqPacket.PutInt32(parentField);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response_PvE_DungeonList(resPacket)); });
        }


        public static void PvE_EnterDungeon(Int32 dungeonId, APICallbackHandler<Response_PvE_EnterDungeon> callback)
        {
            SecurePacket reqPacket = new SecurePacket(Protocol.GetID("CS_PvE_EnterDungeon_Req"));
            reqPacket.PutInt32(_userNo);
            reqPacket.PutInt32(dungeonId);

            _request.SendPacket(reqPacket, (resPacket) => { callback(new Response_PvE_EnterDungeon(resPacket)); });
        }
    }
}
