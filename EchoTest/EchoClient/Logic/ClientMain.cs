using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aegis;
using Aegis.Network;



namespace EchoClient.Logic
{
    public class ClientMain
    {
        private static List<TestSession> _listClient = new List<TestSession>();





        public static void Start(Int32 clientCount, System.Windows.Forms.TextBox ctrl)
        {
            try
            {
                LogMedia.AddTextBoxLogger(ctrl);
                Logger.Info("EchoClient (AegisNetwork {0})", Aegis.Framework.AegisVersion);


                while (clientCount-- > 0)
                {
                    var session = new TestSession();
                    _listClient.Add(session);
                    session.Connect();
                }
            }
            catch (Exception e)
            {
                Logger.Err(e.ToString());
            }
        }


        public static void Stop()
        {
            foreach (var session in _listClient)
                session.Close();
            _listClient.Clear();

            LogMedia.DeleteAllLogger();
        }
    }
}