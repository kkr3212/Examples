using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis.Network;
using Aegis.Data.MySQL;
using MySql.Data.MySqlClient;



namespace RPGGame.Common
{
    public enum ServerType
    {
        None = 0,
        AuthServer = 1,
        Cache = 2,
        GameServer = 3
    }


    public enum ServerStatus
    {
        Inactivate = 0,
        Activate
    }


    public class ServerInfo
    {
        public Int32 Uid { get; internal set; }
        public Int32 WorldId { get; internal set; }
        public Int32 Traffic { get; set; }
        public ServerType ServerType { get; internal set; }
        public ServerStatus Status { get; set; }
        public String ServerName { get; internal set; }
        public String SystemIpAddress { get; internal set; }
        public String ListenIpAddress { get; internal set; }
        public Int32 ListenPortNo { get; internal set; }
        public Session Session { get; set; }
    }





    public static class ServerCatalog
    {
        public static List<ServerInfo> Items { get; private set; } = new List<ServerInfo>();
        public static ServerInfo MyServerInfo { get; private set; }





        public static void Refresh()
        {
            Items.Clear();
            using (DBCommand cmd = SystemDB.NewCommand())
            {
                cmd.CommandText.Append("select uid, worldid, servertype, servername, system_ipaddress, listen_ipaddress, listen_portno");
                cmd.CommandText.Append(" from t_listserver;");

                MySqlDataReader reader = cmd.Query();
                while (reader.Read())
                {
                    Items.Add(new ServerInfo()
                    {
                        Uid = reader.GetInt32(0),
                        WorldId = reader.GetInt32(1),
                        ServerType = (ServerType)reader.GetInt32(2),
                        ServerName = reader.GetString(3),
                        SystemIpAddress = reader.GetString(4),
                        ListenIpAddress = reader.GetString(5),
                        ListenPortNo = reader.GetInt32(6),
                        Status = ServerStatus.Inactivate,
                        Traffic = 0
                    });
                }
            }


            MyServerInfo = null;
            foreach (var info in Items)
            {
                if (info.Uid == Aegis.Starter.ServerID)
                {
                    MyServerInfo = info;
                    break;
                }
            }
        }
    }
}
