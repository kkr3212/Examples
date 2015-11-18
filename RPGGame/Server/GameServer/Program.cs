using System;
using System.Threading;
using System.Windows.Forms;
using System.ServiceProcess;



namespace RPGGame.GameServer
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
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);


                ThreadStart threadProc = delegate { Application.Run(new FormMain()); };
                Thread thread = new Thread(threadProc);

                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            }
            else
            {
                ServiceBase.Run(ServerSystem.ServerMain.Instance);
            }
        }
    }
}
