using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                Aegis.Framework.Running += () =>
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                };

                Aegis.Framework.Start(false);
            }
            else
            {
                Aegis.Framework.Initialized += (args) =>
                {
                    Logic.ServerMain.StartServer(null);
                    return true;
                };
                Aegis.Framework.Finalizing += () =>
                {
                    Logic.ServerMain.StopServer();
                };

                Aegis.Framework.Start(true);
            }
        }
    }
}
