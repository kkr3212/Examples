using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Windows.Forms;
using Aegis;
using RPGGame.Common;



namespace RPGGame.GameServer.ServerSystem
{
    public class ServerMain : ServiceBase
    {
        public static ServerMain Instance { get { return Singleton<ServerMain>.Instance; } }
        public static String AES_IV { get; private set; }
        public static String AES_Key { get; private set; }
        public static Boolean IsStarted { get; private set; } = false;





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
                LogMedia.SetTextFileLogger(@".\log", "GameServer");


                Logger.Write(LogType.Info, 2, "Starting GameServer...");
                Starter.Initialize(@".\Config.xml");
                {
                    DBCatalog.Refresh();
                    ServerCatalog.Refresh();
                    UserManager.Initialize();
                    GameData.GameDataLoader.Refresh();
                    GameMap.GameMapLoader.Refresh();

                    AES_IV = Starter.CustomData.GetValue("AES/IV");
                    AES_Key = Starter.CustomData.GetValue("AES/Key");
                }


                IsStarted = true;
                Starter.CreateNetworkChannel("NetworkClient")
                       .StartNetwork(() => { return new ClientSession(); }, 0, 0)
                       .OpenListener(ServerCatalog.MyServerInfo.ListenIpAddress, ServerCatalog.MyServerInfo.ListenPortNo);

                Starter.CreateNetworkChannel("NetworkAuth")
                       .StartNetwork(() => { return new AuthSession(); }, 1, 1);
            }
            catch (Exception e)
            {
                IsStarted = false;
                Logger.Write(LogType.Err, 2, e.ToString());
            }
        }


        public void StopServer()
        {
            IsStarted = false;

            Starter.Release();
            DBCatalog.Release();
            UserManager.Release();

            Logger.Write(LogType.Err, 2, "GameServer Stopped.");
            LogMedia.DeleteAllLogger();
        }
    }
}
