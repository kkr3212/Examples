using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Aegis;
using Aegis.Utils.Converter;
using Aegis.Threading;
using Aegis.Data.MySQL;
using RPGGame.Common;
using RPGGame.GameServer.UserData;



namespace RPGGame.GameServer.ServerSystem
{
    public static class UserManager
    {
        private class UserData
        {
            public readonly GameUser _user;
            public readonly Stopwatch _heartPulse = Stopwatch.StartNew();

            public UserData(GameUser user)
            {
                _user = user;
            }
        }

        private static Dictionary<Int32, UserData> _users = new Dictionary<Int32, UserData>();
        private static ThreadCancellable _thread;
        private static Int32 _maxAliveSecond;





        public static void Initialize()
        {
            _maxAliveSecond = Starter.CustomData.GetValue("UserManager/maxAliveSecond").ToInt32();

            _users = new Dictionary<Int32, UserData>();
            _thread = ThreadCancellable.CallInterval(1000, CheckExpiredUser);
        }


        public static void Release()
        {
            _thread?.Cancel();
            _thread = null;

            _users.Clear();
        }


        public static GameUser Find(Int32 userNo)
        {
            UserData userData;
            if (_users.TryGetValue(userNo, out userData) == false)
                return null;

            return userData._user;
        }


        public static void HeartPulse(GameUser user)
        {
            UserData userData;
            if (_users.TryGetValue(user.UserNo, out userData) == false)
                return;

            userData._heartPulse.Restart();
        }


        public static void Login(Int32 userNo, Int32 authKey, Action<GameUser, Int32> actionOnComplete)
        {
            GameUser user = Find(userNo);
            if (user != null)
                Logout(userNo);


            using (DBCommand cmd = AuthDB.NewCommand())
            {
                Int32 dbAuthKey = -1;


                cmd.CommandText.Append($"select authkey from t_accounts where userno={userNo};");
                cmd.PostQuery(() =>
                {
                    if (cmd.Reader.Read())
                        dbAuthKey = cmd.Reader.GetInt32(0);
                },
                (exception) =>
                {
                    if (exception != null)
                    {
                        actionOnComplete(null, ResultCode.Database_Error);
                        Logger.Write(LogType.Err, 2, exception.ToString());
                    }
                    //  인증키 확인
                    else if (dbAuthKey == authKey)
                    {
                        //  유저데이터 및 게임데이터 로드
                        user = new GameUser(userNo);
                        user.LoadFromDB((result) =>
                        {
                            _users.Add(userNo, new UserData(user));
                            actionOnComplete(user, result);
                        });
                    }
                    //  잘못된 인증키
                    else
                        actionOnComplete(null, ResultCode.InvalidAuthKey);
                });
            }
        }


        public static void Logout(Int32 userNo)
        {
            _users.Remove(userNo);
        }


        private static Boolean CheckExpiredUser()
        {
            SpinWorker.Dispatch(() =>
            {
                List<UserData> expired = new List<UserData>();
                foreach (UserData userData in _users.Values)
                {
                    if (userData._heartPulse.ElapsedMilliseconds / 1000 > _maxAliveSecond)
                        expired.Add(userData);
                }


                foreach (var userData in expired)
                    Logout(userData._user.UserNo);
            });

            return true;
        }
    }
}
