using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Windows.Forms;
using Aegis;
using RPGGame.Common;



namespace RPGGame.AuthServer
{
    public class ServerMain : ServiceBase
    {
        public static ServerMain Instance { get { return Singleton<ServerMain>.Instance; } }
        public static String AES_IV { get; private set; }
        public static String AES_Key { get; private set; }





        private ServerMain()
        {
        }


        override protected void OnStart(string[] args)
        {
            StartServer(null);
        }


        override protected void OnStop()
        {
            StopServer();
        }


        public void StartServer(TextBox ctrl)
        {
            try
            {
                System.IO.Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                LogMedia.SetTextBoxLogger(ctrl);
                LogMedia.SetTextFileLogger(@".\log", "AuthServer");


                Logger.Write(LogType.Info, 2, "RPGGame AuthServer (Build {0})", Definitions.BuildNo);
                Logger.Write(LogType.Info, 2, "Starting AuthServer...");
                Starter.Initialize(@".\Config.xml");
                {
                    DBCatalog.Refresh();
                    ServerCatalog.Refresh();
                    WorldCatalog.Refresh();

                    AES_IV = Starter.CustomData.GetValue("AES/IV");
                    AES_Key = Starter.CustomData.GetValue("AES/Key");
                }

                Starter.CreateNetworkChannel("NetworkClient")
                       .StartNetwork(() => { return new Networking.ClientSession(); }, 0, 0)
                       .OpenListener(ServerCatalog.MyServerInfo.ListenIpAddress, ServerCatalog.MyServerInfo.ListenPortNo);

                Starter.CreateNetworkChannel("NetworkServer")
                       .StartNetwork(() => { return new Networking.ServerSession(); }, 0, 0)
                       .OpenListener(ServerCatalog.MyServerInfo.ListenIpAddress, 10101);
            }
            catch (Exception e)
            {
                Logger.Write(LogType.Err, 2, e.ToString());
            }
        }


        public void StopServer()
        {
            DBCatalog.Release();
            Starter.Release();

            Logger.Write(LogType.Info, 2, "Server Stopped.");
            LogMedia.DeleteAllLogger();
        }
    }
}
