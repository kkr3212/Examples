using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.Data.MySQL;
using RPGGame.Common;
using RPGGame.GameServer.GameData;



namespace RPGGame.GameServer.UserData
{
    public partial class GameUser
    {
        public static Boolean IsValidNickname(String nickname)
        {
            if (nickname.Length < 4 || nickname.Length > 16)
                return false;


            String bannedCh = "`~!@#$%^&*(){}[]|-+=/\\\"\';:<>,.";
            for (Int32 i = 0; i < bannedCh.Length; ++i)
            {
                if (nickname.IndexOf(bannedCh[i]) != -1)
                    return false;
            }

            return true;
        }


        /// <summary>
        /// GameDB에 저장된 유저의 모든 정보를 가져와 GameUser 객체를 설정합니다.
        /// </summary>
        public void LoadFromDB(Action<Int32> actionOnComplete)
        {
            using (DBCommand cmd = GameDB.NewCommand(UserNo))
            {
                Boolean isNewUser = false;


                cmd.CommandText.Append("select nickname, level, exp, vip_level, vip_exp, main_characterno, last_managermailno");
                cmd.CommandText.Append(" from t_userinfo where userno=@userno;");

                cmd.CommandText.Append("select characterno, characterid, level, exp, gradeid, promotionid");
                cmd.CommandText.Append(" from t_inventory_character where userno=@userno;");

                cmd.CommandText.Append("select itemno, itemid, promotionid, quantity");
                cmd.CommandText.Append(" from t_inventory_item where userno=@userno;");

                cmd.CommandText.Append("select decktype, slotno, characterno");
                cmd.CommandText.Append(" from t_playdeck where userno=@userno;");

                cmd.CommandText.Append("select energyid, point, last_updatetime");
                cmd.CommandText.Append(" from t_userinfo_energy where userno=@userno;");

                cmd.CommandText.Append("select resourceid, point");
                cmd.CommandText.Append(" from t_userinfo_resource where userno=@userno;");

                cmd.BindParameter("@userno", UserNo);
                cmd.PostQuery(() =>
                {
                    var reader = cmd.Reader;
                    Int32 mainCharacterNo;

                    //  t_userinfo
                    if (reader.Read())
                    {
                        Nickname = reader.GetString(0);
                        Level = reader.GetInt16(1);
                        Exp = reader.GetInt32(2);
                        VIPLevel = reader.GetInt16(3);
                        VIPExp = reader.GetInt32(4);
                        mainCharacterNo = reader.GetInt32(5);
                        LastManagerMailNo = reader.GetInt32(6);


                        reader.NextResult(); InvenCharacter.LoadFromDB(reader);
                        reader.NextResult(); InvenItem.LoadFromDB(reader);
                        reader.NextResult(); PlayDeck.LoadFromDB(reader);
                        reader.NextResult(); Energy.LoadFromDB(reader);
                        reader.NextResult(); Resource.LoadFromDB(reader);

                        MainCharacter = InvenCharacter.Find(mainCharacterNo);
                    }
                    else
                    {
                        isNewUser = true;
                        return;
                    }
                },
                (exception) =>
                {
                    if (exception != null)
                    {
                        actionOnComplete(ResultCode.Database_Error);
                        Logger.Write(LogType.Err, 2, exception.ToString());
                    }
                    else if (isNewUser == true)
                        actionOnComplete(ResultCode.NewUser);
                    else
                        actionOnComplete(ResultCode.Ok);
                });
            }
        }


        /// <summary>
        /// 최초접속시 플레이어의 기본정보 및 초기지급 캐릭터 등을 설정합니다.
        /// </summary>
        public Int32 InitUser(String nickname)
        {
            if (Nickname != null)
                return ResultCode.InvalidOperation;


            //  초기 유저정보 설정
            Nickname = nickname;
            Level = 1;
            Exp = 0;
            VIPLevel = 1;
            VIPExp = 0;


            //  초기지급 캐릭터
            foreach (var data in FirstSupply.CharacterData.Items)
                InvenCharacter.AddCharacter(data.CharacterId);
            MainCharacter = InvenCharacter.Items[0];


            //  초기지급 에너지 & 리소스
            Energy.FirstSupply();
            Resource.FirstSupply();


            //  DB에 유저정보 추가
            using (DBCommand cmd = GameDB.NewCommand(UserNo))
            {
                cmd.CommandText.Append("insert into t_userinfo values(@0, @1, @2, @3, @4, @5, @6, 0);");
                cmd.BindParameter("@0", UserNo);
                cmd.BindParameter("@1", Nickname);
                cmd.BindParameter("@2", Level);
                cmd.BindParameter("@3", Exp);
                cmd.BindParameter("@4", VIPLevel);
                cmd.BindParameter("@5", VIPExp);
                cmd.BindParameter("@6", MainCharacter.CharacterNo);
                cmd.PostQueryNoReader();
            }


            return ResultCode.Ok;
        }
    }
}
