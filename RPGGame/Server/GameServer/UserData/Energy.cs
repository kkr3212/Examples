using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.Data.MySql;
using RPGGame.Common;
using RPGGame.GameServer.GameData;



namespace RPGGame.GameServer.UserData
{
    public class Energy
    {
        public class Data
        {
            private readonly GameUser _user;
            private Int32 _point;


            public readonly Int32 EnergyId;
            public Int32 Point
            {
                get
                {
                    Recovery();
                    return _point;
                }
                set
                {
                    var data = PlayerBook.Energy.GetData(_user.Level, EnergyId);

                    //  최대치일 경우에만 LastUpdateTime을 갱신한다.
                    if (_point >= data.MaxPoint)
                        LastUpdateTime = DateTime.Now;

                    _point = value;
                    if (_point < 0)
                        _point = 0;
                }
            }
            public DateTime LastUpdateTime { get; private set; }
            public Int32 RemainSecond
            {
                get
                {
                    var data = PlayerBook.Energy.GetData(_user.Level, EnergyId);
                    if (_point >= data.MaxPoint)
                        return 0;

                    Int32 elapsedSec = (Int32)(DateTime.Now - LastUpdateTime).TotalSeconds;
                    Int32 remainSec = data.CoolTime - elapsedSec;

                    return (remainSec < 0 ? 0 : remainSec);
                }
            }





            public Data(GameUser user, Int32 energyId)
            {
                _user = user;
                EnergyId = energyId;

                _point = PlayerBook.Energy.GetData(_user.Level, EnergyId).MaxPoint;
                LastUpdateTime = DateTime.Now;
            }


            public Data(GameUser user, Int32 energyId, Int32 point, DateTime lastUpdateTime)
            {
                _user = user;
                EnergyId = energyId;

                _point = point;
                LastUpdateTime = lastUpdateTime;
            }


            /// <summary>
            /// 에너지를 사용한 후 포인트 회복 처리
            /// </summary>
            private void Recovery()
            {
                var data = PlayerBook.Energy.GetData(_user.Level, EnergyId);
                if (_point >= data.MaxPoint)
                    return;


                //  포인트 회복
                Int32 elapsedSec = (Int32)(DateTime.Now - LastUpdateTime).TotalSeconds;
                Int32 recoveryPoint = elapsedSec / data.CoolTime;
                Int32 remainSec = elapsedSec % data.CoolTime;


                if (recoveryPoint > 0)
                {
                    _point += recoveryPoint * data.RegainValue;
                    if (_point > data.MaxPoint)
                        _point = data.MaxPoint;

                    LastUpdateTime = DateTime.Now.AddSeconds(0 - remainSec);
                }
            }


            /// <summary>
            /// 플레이어의 현재 레벨에 따라 에너지 회복
            /// </summary>
            public void RecoveryByLevelUp()
            {
                var data = PlayerBook.Energy.GetData(_user.Level, EnergyId);


                //  최대 회복
                if (data.LevelUp_IncType == 0)
                {
                    _point = data.MaxPoint;
                    LastUpdateTime = DateTime.MinValue;
                }
                //  고정 회복
                else if (data.LevelUp_IncType == 1)
                {
                    _point += data.LevelUp_IncValue;
                    if (_point >= data.MaxPoint)
                        LastUpdateTime = DateTime.MinValue;
                }
            }
        }





        public readonly List<Data> Items = new List<Data>();
        private readonly GameUser _user;





        public Energy(GameUser user)
        {
            _user = user;
        }


        public Data this[Int32 energyId]
        {
            get
            {
                Data data = Items.Find(v => v.EnergyId == energyId);
                if (data == null)
                    throw new AegisException("Invalid EnergyId(={0}).", energyId);

                return data;
            }
        }


        /// <summary>
        /// 초기지급 에너지 설정
        /// </summary>
        public void FirstSupply()
        {
            Items.Clear();
            foreach (var data in Codes.Energy.Items)
            {
                Data energy = new Data(_user, data.Value.EnergyId);
                Items.Add(energy);
            }


            //  Insert to DB
            using (var cmd = GameDB.NewCommand(_user.UserNo))
            {
                Int32 idx = 0;


                cmd.CommandText.Append("insert into t_userinfo_energy values");
                foreach (var energy in Items)
                {
                    cmd.CommandText.AppendFormat("(@{0}, @{1}, @{2}, @{3}),", idx + 0, idx + 1, idx + 2, idx + 3);
                    cmd.BindParameter(String.Format("@{0}", idx + 0), _user.UserNo);
                    cmd.BindParameter(String.Format("@{0}", idx + 1), energy.EnergyId);
                    cmd.BindParameter(String.Format("@{0}", idx + 2), energy.Point);
                    cmd.BindParameter(String.Format("@{0}", idx + 3), energy.LastUpdateTime);
                    idx += 4;
                }
                cmd.CommandText[cmd.CommandText.Length - 1] = ';';
                cmd.PostQueryNoReader();
            }
        }


        /// <summary>
        /// 플레이어의 현재 레벨에 따라 에너지 회복 
        /// </summary>
        public void RecoveryByLevelUp()
        {
            foreach (Data energy in Items)
                energy.RecoveryByLevelUp();
        }


        public void LoadFromDB(DataReader reader)
        {
            Items.Clear();
            while (reader.Read())
            {
                Int32 energyId = reader.GetInt16(0);
                Int32 point = reader.GetInt32(1);
                DateTime lastUpdateTime = reader.GetDateTime(2);

                Items.Add(new Data(_user, energyId, point, lastUpdateTime));
            }
        }


        public void UpdateToDB()
        {
        }
    }
}
