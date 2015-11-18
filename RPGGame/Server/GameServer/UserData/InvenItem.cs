using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.Data.MySql;



namespace RPGGame.GameServer.UserData
{
    public class InvenItem
    {
        private readonly GameUser _user;
        public readonly List<Item> Items = new List<Item>();





        public InvenItem(GameUser user)
        {
            _user = user;
        }


        /// <summary>
        /// 새로운 ItemNo를 생성합니다.
        /// 유저는 최대 1000개의 캐릭터를 보유할 수 있습니다.
        /// </summary>
        public Int32 NextCharacterNo()
        {
            Int32 no = _user.UserNo * 1000;
            foreach (var ch in Items.OrderBy(v => v.ItemNo))
            {
                if (ch.ItemNo > no)
                    break;
                ++no;
            }

            if (no >= (_user.UserNo + 1) * 1000)
                throw new AegisException("Cannot generate more itemno(userno={0}).", _user.UserNo);

            return no;
        }


        public Item AddCharacter(Int32 itemId)
        {
            Item ch = new Item(_user, itemId, NextCharacterNo());
            Items.Add(ch);
            ch.InsertToDB();

            return ch;
        }


        public void DeleteCharacter(Int32 itemNo)
        {
            Item ch = Items.Find(v => v.ItemNo == itemNo);
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
                Int32 itemNo = reader.GetInt32(0);
                Int32 itemId = reader.GetInt32(1);
                Item ch = new Item(_user, itemId, itemNo);
                ch.PromotionId = reader.GetInt16(2);
                ch.Quantity = reader.GetInt32(3);

                Items.Add(ch);
            }
        }


        public Item Find(Int32 itemNo)
        {
            Item ch = Items.Find(v => v.ItemNo == itemNo);
            if (ch != null)
                return ch;

            throw new AegisException("Invalid itemno({0}).", itemNo);
        }
    }
}
