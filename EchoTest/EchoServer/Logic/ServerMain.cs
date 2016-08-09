using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.Network;
using Aegis.Calculate;



namespace EchoServer.Logic
{
    public static class ServerMain
    {
        public static void StartServer(System.Windows.Forms.TextBox ctrl)
        {
            try
            {
                LogMedia.AddTextBoxLogger(ctrl);
                Logger.Info("EchoServer (AegisNetwork {0})", Aegis.Framework.AegisVersion);


                (new IntervalCounter("ReceiveCount", 1000)).Start();
                (new IntervalCounter("ReceiveBytes", 1000)).Start();


                var channel = NetworkChannel.CreateChannel("ClientNetwork");
                channel.SessionGenerator = () => { return new ClientSession(); };
                channel.MaxSessionCount = 100;
                channel.Acceptor.ListenIpAddress = "127.0.0.1";
                channel.Acceptor.ListenPortNo = 10100;
                channel.Acceptor.Listen();
            }
            catch (Exception e)
            {
                Logger.Err(e.ToString());
            }
        }


        public static void StopServer()
        {
            IntervalCounter.Counters["ReceiveCount"]?.Dispose();
            IntervalCounter.Counters["ReceiveBytes"]?.Dispose();

            NetworkChannel.Release();
            LogMedia.DeleteAllLogger();
        }


        public static int GetActiveSessionCount()
        {
            NetworkChannel channel = NetworkChannel.Channels["ClientNetwork"];
            return channel?.ActiveSessions.Count ?? 0;
        }
    }
}
