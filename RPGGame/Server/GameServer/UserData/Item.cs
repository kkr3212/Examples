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
    public class Item
    {
        private readonly GameUser _user;
        public readonly ItemBook.Data Base;
        public readonly Int32 ItemNo;
        public Int32 PromotionId { get; set; }
        public Int32 Quantity { get; set; }





        public Item(GameUser user, Int32 itemId, Int32 itemNo)
        {
            _user = user;
            Base = ItemBook.Data.Items.Find(v => v.ItemId == itemId);
            if (Base == null)
                throw new AegisException("Invalid itemId={0}.", itemId);


            ItemNo = itemNo;
            PromotionId = 0;
            Quantity = Base.ItemCount;
        }


        public void InsertToDB()
        {
            using (var cmd = GameDB.NewCommand(_user.UserNo))
            {
                cmd.CommandText.Append("insert into t_inventory_item");
                cmd.CommandText.Append(" values(@itemno, @userno, @itemid, @promotionid, @quantity);");
                cmd.BindParameter("@itemno", ItemNo);
                cmd.BindParameter("@userno", _user.UserNo);
                cmd.BindParameter("@itemid", Base.ItemId);
                cmd.BindParameter("@promotionid", PromotionId);
                cmd.BindParameter("@quantity", Quantity);
                cmd.PostQueryNoReader();
            }
        }


        public void UpdateToDB()
        {
            using (var cmd = GameDB.NewCommand(_user.UserNo))
            {
                cmd.CommandText.Append("update t_inventory_item");
                cmd.CommandText.Append(" set promotionid=@promotionid, quantity=@quantity");
                cmd.CommandText.Append(" where itemno=@itemno;");
                cmd.BindParameter("@promotionid", PromotionId);
                cmd.BindParameter("@quantity", Quantity);
                cmd.BindParameter("@characterno", ItemNo);
                cmd.PostQueryNoReader();
            }
        }


        public void DeleteFromDB()
        {
            using (var cmd = GameDB.NewCommand(_user.UserNo))
            {
                cmd.CommandText.Append("delete from t_inventory_item");
                cmd.CommandText.Append(" where itemno=@itemno;");
                cmd.BindParameter("@itemno", ItemNo);
                cmd.PostQueryNoReader();
            }
        }
    }
}
