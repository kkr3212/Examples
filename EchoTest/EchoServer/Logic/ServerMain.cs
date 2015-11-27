using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.Network;



namespace EchoServer.Logic
{
    public static class ServerMain
    {
        public static void StartServer(System.Windows.Forms.TextBox ctrl)
        {
            try
            {
                LogMedia.SetTextBoxLogger(ctrl);
                Logger.Write(LogType.Info, 2, "EchoServer (AegisNetwork {0})", Aegis.Configuration.Environment.AegisVersion);

                Starter.Initialize();
                Starter.CreateNetworkChannel("ClientNetwork")
                       .StartNetwork(delegate { return new ClientSession(); }, 1, 100)
                       .OpenListener("127.0.0.1", 10100);
            }
            catch (Exception e)
            {
                Logger.Write(LogType.Err, 2, e.ToString());
            }
        }


        public static void StopServer()
        {
            Starter.StopNetwork("ClientNetwork");
            Starter.Release();
            LogMedia.DeleteAllLogger();
        }


        public static Int32 GetActiveSessionCount()
        {
            NetworkChannel channel = NetworkChannel.Channels.Find(v => v.Name == "ClientNetwork");
            return channel?.ActiveSessions.Count ?? 0;
        }
    }
}
