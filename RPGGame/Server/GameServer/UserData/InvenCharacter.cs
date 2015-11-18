using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.Data.MySql;



namespace RPGGame.GameServer.UserData
{
    public class InvenCharacter
    {
        private readonly GameUser _user;
        public readonly List<Character> Items = new List<Character>();





        public InvenCharacter(GameUser user)
        {
            _user = user;
        }


        /// <summary>
        /// 새로운 CharacterNo를 생성합니다.
        /// 유저는 최대 1000개의 캐릭터를 보유할 수 있습니다.
        /// </summary>
        public Int32 NextCharacterNo()
        {
            Int32 no = _user.UserNo * 1000;
            foreach (var ch in Items.OrderBy(v => v.CharacterNo))
            {
                if (ch.CharacterNo > no)
                    break;
                ++no;
            }

            if (no >= (_user.UserNo + 1) * 1000)
                throw new AegisException("Cannot generate more characterno(userno={0}).", _user.UserNo);

            return no;
        }


        public Character AddCharacter(Int32 characterId)
        {
            Character ch = new Character(_user, characterId, NextCharacterNo());
            Items.Add(ch);
            ch.InsertToDB();

            return ch;
        }


        public void DeleteCharacter(Int32 characterNo)
        {
            Character ch = Items.Find(v => v.CharacterNo == characterNo);
            if (ch != null)
            {
                Items.Remove(ch);
                ch.DeleteFromDB();
            }
        }


        public void LoadFromDB(DataReader reader)
        {
            Items.Clear();
            while (reader.Read())
            {
                Int32 characterNo = reader.GetInt32(0);
                Int32 characterId = reader.GetInt32(1);
                Character ch = new Character(_user, characterId, characterNo);
                ch.Level = reader.GetInt16(2);
                ch.Exp = reader.GetInt32(3);
                ch.GradeId = reader.GetInt16(4);
                ch.PromotionId = reader.GetInt16(5);

                Items.Add(ch);
            }
        }


        public Character Find(Int32 characterNo)
        {
            Character ch = Items.Find(v => v.CharacterNo == characterNo);
            if (ch != null)
                return ch;

            throw new AegisException("Invalid characterno({0}).", characterNo);
        }


        public Character FindOrNull(Int32 characterNo)
        {
            Character ch = Items.Find(v => v.CharacterNo == characterNo);
            return ch;
        }
    }
}
