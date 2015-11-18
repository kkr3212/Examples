using System;
using System.Windows.Forms;



namespace RPGGame.AuthServer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            _btnStart.Enabled = true;
            _btnStop.Enabled = false;


            this.Text = String.Format("RPGGame AuthServer (Build {0})", RPGGame.Common.Definitions.BuildNo);
        }



        private void OnClick_Start(object sender, EventArgs e)
        {
            _btnStart.Enabled = false;
            _btnStop.Enabled = true;
            _tbLog.Text = "";

            ServerMain.Instance.StartServer(_tbLog);
        }


        private void OnClick_Stop(object sender, EventArgs e)
        {
            _btnStart.Enabled = true;
            _btnStop.Enabled = false;

            ServerMain.Instance.StopServer();
        }


        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            ServerMain.Instance.StopServer();
        }
    }
}
