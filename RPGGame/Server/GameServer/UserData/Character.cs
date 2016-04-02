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
    public class Character
    {
        private readonly GameUser _user;
        public readonly CharacterBook.Data Base;
        public readonly Int32 CharacterNo;
        public Int32 Level { get; set; }
        public Int32 Exp { get; set; }
        public Int32 GradeId { get; set; }
        public Int32 PromotionId { get; set; }





        public Character(GameUser user, Int32 characterId, Int32 characterNo)
        {
            _user = user;
            Base = CharacterBook.Find(characterId);


            CharacterNo = characterNo;
            Level = 1;
            Exp = 0;

            GradeId = Base.InitGradeId;
            PromotionId = Base.InitPromotionId;
        }


        public void InsertToDB()
        {
            using (var cmd = GameDB.NewCommand(_user.UserNo))
            {
                cmd.CommandText.Append("insert into t_inventory_character");
                cmd.CommandText.Append(" values(@characterno, @userno, @characterid, @level, @exp, @gradeid, @promotionid);");
                cmd.BindParameter("@characterno", CharacterNo);
                cmd.BindParameter("@userno", _user.UserNo);
                cmd.BindParameter("@characterid", Base.CharacterId);
                cmd.BindParameter("@level", Level);
                cmd.BindParameter("@exp", Exp);
                cmd.BindParameter("@gradeid", GradeId);
                cmd.BindParameter("@promotionid", PromotionId);
                cmd.PostQueryNoReader();
            }
        }


        public void UpdateToDB()
        {
            using (var cmd = GameDB.NewCommand(_user.UserNo))
            {
                cmd.CommandText.Append("update t_inventory_character");
                cmd.CommandText.Append(" set level=@level, exp=@exp, gradeid=@gradeid, promotionid=@promotionid)");
                cmd.CommandText.Append(" where characterno=@characterno;");
                cmd.BindParameter("@level", Level);
                cmd.BindParameter("@exp", Exp);
                cmd.BindParameter("@gradeid", GradeId);
                cmd.BindParameter("@promotionid", PromotionId);
                cmd.BindParameter("@characterno", CharacterNo);
                cmd.PostQueryNoReader();
            }
        }


        public void DeleteFromDB()
        {
            using (var cmd = GameDB.NewCommand(_user.UserNo))
            {
                cmd.CommandText.Append("delete from t_inventory_character");
                cmd.CommandText.Append(" where characterno=@characterno;");
                cmd.BindParameter("@characterno", CharacterNo);
                cmd.PostQueryNoReader();
            }
        }
    }
}
