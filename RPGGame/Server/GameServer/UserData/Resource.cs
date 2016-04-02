using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis.Data.MySQL;
using RPGGame.Common;
using MySql.Data.MySqlClient;



namespace RPGGame.GameServer.UserData
{
    public class Resource
    {
        public class Data
        {
            public readonly Int32 ResourceId;
            public Int32 Point { get; set; }

            public Data(Int32 resourceId)
            {
                ResourceId = resourceId;
            }

            public Data(Int32 resourceId, Int32 point)
            {
                ResourceId = resourceId;
                Point = point;
            }
        }


        public List<Data> Items { get; } = new List<Data>();
        private readonly GameUser _user;

        public Int32 this[Int32 resourceId]
        {
            get
            {
                Data data = Items.Find(v => v.ResourceId == resourceId);
                if (data == null)
                    data = AddResource(resourceId, 0);

                return data.Point;
            }
            set
            {
                Data data = Items.Find(v => v.ResourceId == resourceId);
                if (data == null)
                    data = AddResource(resourceId, value);
                else
                    data.Point = value;
            }
        }





        public Resource(GameUser user)
        {
            _user = user;
        }


        /// <summary>
        /// 초기지급 리소스 설정
        /// </summary>
        public void FirstSupply()
        {
            Items.Clear();
            foreach (var data in GameData.FirstSupply.ResourceData.Items)
            {
                Data resource = new Data(data.ResourceId);
                resource.Point = data.Point;
                Items.Add(resource);
            }


            //  Insert to DB
            using (var cmd = GameDB.NewCommand(_user.UserNo))
            {
                Int32 idx = 0;


                cmd.CommandText.Append("insert into t_userinfo_resource values");
                foreach (var energy in Items)
                {
                    cmd.CommandText.AppendFormat("(@{0}, @{1}, @{2}),", idx + 0, idx + 1, idx + 2);
                    cmd.BindParameter(String.Format("@{0}", idx + 0), _user.UserNo);
                    cmd.BindParameter(String.Format("@{0}", idx + 1), energy.ResourceId);
                    cmd.BindParameter(String.Format("@{0}", idx + 2), energy.Point);
                    idx += 3;
                }
                cmd.CommandText[cmd.CommandText.Length - 1] = ';';
                cmd.PostQueryNoReader();
            }
        }


        public Data AddResource(Int32 resourceId, Int32 point)
        {
            Data resource = new Data(resourceId);
            resource.Point = point;
            Items.Add(resource);


            using (var cmd = GameDB.NewCommand(_user.UserNo))
            {
                cmd.CommandText.Append("insert into t_userinfo_resource values(@0, @1, @2);");
                cmd.BindParameter("@0", _user.UserNo);
                cmd.BindParameter("@1", resourceId);
                cmd.BindParameter("@2", point);
                cmd.PostQueryNoReader();
            }

            return resource;
        }


        public void LoadFromDB(MySqlDataReader reader)
        {
            Items.Clear();
            while (reader.Read())
            {
                Int32 resourceId = reader.GetInt16(0);
                Int32 point = reader.GetInt32(1);

                Items.Add(new Data(resourceId, point));
            }
        }


        public void UpdateToDB()
        {
            using (DBCommand cmd = GameDB.NewCommand(_user.UserNo))
            {
                foreach (Data data in Items)
                {
                    cmd.CommandText.AppendFormat("update t_userinfo_resource set point={0} where userno={1} and resourceid={2};",
                                                 data.Point, _user.UserNo, data.ResourceId);
                }
                cmd.PostQueryNoReader();
            }
        }
    }
}
