using System;
using System.Collections.Generic;
using System.Linq;
using Aegis;
using Aegis.Data.MySQL;
using Aegis.Utils.Converter;
using MySql.Data.MySqlClient;



namespace RPGGame.Common
{
    public enum DBType
    {
        None = 0,
        System = 1,
        Auth = 2,
        Game = 3
    }


    public struct DBInfo
    {
        public Int32 Uid, WorldId;
        public DBType DBType;
        public String DBName, IPAddress, UserId, UserPwd, CharSet;
        public Int32 PortNo, ShardKeyStart, ShardKeyEnd;
    }





    public static class DBCatalog
    {
        public static List<DBInfo> Items { get; private set; }



        static DBCatalog()
        {
            Items = new List<DBInfo>();
        }


        public static void Refresh()
        {
            String dbName = Starter.CustomData.GetValue("SystemDB/dbname");
            String dbHost = Starter.CustomData.GetValue("SystemDB/ipaddress");
            Int32 dbPort = Starter.CustomData.GetValue("SystemDB/portno").ToInt32();
            String userId = Starter.CustomData.GetValue("SystemDB/userid");
            String userPwd = Starter.CustomData.GetValue("SystemDB/userpwd");

            ConnectionPool systemDB = new ConnectionPool(dbHost, dbPort, "", dbName, userId, userPwd);
            using (DBCommand cmd = new DBCommand(systemDB))
            {
                cmd.CommandText.Append("select uid, worldid, dbtype, dbname, ipaddress, portno, userid, passwd");
                cmd.CommandText.Append(", charset, shardkey_start, shardkey_end");
                cmd.CommandText.Append(" from t_listdb;");
                MySqlDataReader reader = cmd.Query();

                while (reader.Read())
                {
                    DBInfo info = new DBInfo()
                    {
                        Uid = reader.GetInt32(0),
                        WorldId = reader.GetInt32(1),
                        DBType = (DBType)reader.GetInt32(2),
                        DBName = reader.GetString(3),
                        IPAddress = reader.GetString(4),
                        PortNo = reader.GetInt32(5),
                        UserId = reader.GetString(6),
                        UserPwd = reader.GetString(7),
                        CharSet = (reader.IsDBNull(8) == true ? "" : reader.GetString(8)),
                        ShardKeyStart = (reader.IsDBNull(9) == true ? 0 : reader.GetInt32(9)),
                        ShardKeyEnd = (reader.IsDBNull(10) == true ? 0 : reader.GetInt32(10))
                    };
                    Items.Add(info);


                    if (info.DBType == DBType.System)
                        SystemDB.Initialize(info);

                    else if (info.DBType == DBType.Auth)
                        AuthDB.Initialize(info);

                    else if (info.DBType == DBType.Game)
                        GameDB.AddDBInfo(info);
                }
            }
            systemDB.Release();
        }


        public static void Release()
        {
            SystemDB.Release();
            AuthDB.Release();
            GameDB.Release();

            Items.Clear();
        }
    }





    public static class SystemDB
    {
        public static DBInfo DBInfo { get; private set; }
        public static ConnectionPool MySql { get; internal set; }
        public static Int32 TotalQPS { get { return MySql.GetTotalQPS(); } }


        internal static void Initialize(DBInfo info)
        {
            DBInfo = info;
            MySql = new ConnectionPool(DBInfo.IPAddress, DBInfo.PortNo, DBInfo.CharSet, DBInfo.DBName, DBInfo.UserId, DBInfo.UserPwd);
        }


        internal static void Release()
        {
            if (MySql != null)
            {
                MySql.Release();
                MySql = null;
            }
        }


        public static DBCommand NewCommand()
        {
            return new DBCommand(MySql);
        }
    }





    public static class AuthDB
    {
        public static DBInfo DBInfo { get; private set; }
        public static ConnectionPool MySql { get; internal set; }
        public static Int32 TotalQPS { get { return MySql.GetTotalQPS(); } }


        internal static void Initialize(DBInfo info)
        {
            DBInfo = info;
            MySql = new ConnectionPool(DBInfo.IPAddress, DBInfo.PortNo, DBInfo.CharSet, DBInfo.DBName, DBInfo.UserId, DBInfo.UserPwd);
        }


        internal static void Release()
        {
            if (MySql != null)
            {
                MySql.Release();
                MySql = null;
            }
        }


        public static DBCommand NewCommand()
        {
            return new DBCommand(MySql);
        }
    }





    public static class GameDB
    {
        private static List<Tuple<DBInfo, ConnectionPool>> _listDB = new List<Tuple<DBInfo, ConnectionPool>>();
        public static List<ConnectionPool> MySqls { get { return _listDB.Select(v => v.Item2).ToList(); } }
        public static Int32 TotalQPS
        {
            get
            {
                Int32 qps = 0;
                foreach (var data in _listDB)
                    qps += data.Item2.GetTotalQPS();

                return qps;
            }
        }


        internal static void AddDBInfo(DBInfo info)
        {
            ConnectionPool mysql = new ConnectionPool(info.IPAddress, info.PortNo, info.CharSet, info.DBName, info.UserId, info.UserPwd);
            Tuple<DBInfo, ConnectionPool> data = new Tuple<DBInfo, ConnectionPool>(info, mysql);
            _listDB.Add(data);
        }


        internal static void Release()
        {
            foreach (var data in _listDB)
                data.Item2.Release();

            _listDB.Clear();
        }


        public static ConnectionPool GetMySql(Int32 shardKey)
        {
            foreach (var data in _listDB)
            {
                if (data.Item1.ShardKeyStart <= shardKey && shardKey <= data.Item1.ShardKeyEnd)
                    return data.Item2;
            }

            throw new AegisException(ResultCode.System_Error, "Invalid ShardKey({0}).", shardKey);
        }


        public static DBCommand NewCommand(Int32 shardKey)
        {
            foreach (var data in _listDB)
            {
                if (data.Item1.ShardKeyStart <= shardKey && shardKey <= data.Item1.ShardKeyEnd)
                    return new DBCommand(data.Item2);
            }

            throw new AegisException(ResultCode.System_Error, "Invalid ShardKey({0}).", shardKey);
        }
    }
}
