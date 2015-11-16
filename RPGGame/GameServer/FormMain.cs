using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace RPGGame.GameServer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            _btnStart.Enabled = true;
            _btnStop.Enabled = false;
            _cbLogLevel.SelectedIndex = 3;
        }



        private void OnClick_Start(object sender, EventArgs e)
        {
            _btnStart.Enabled = false;
            _btnStop.Enabled = true;
            _tbLog.Text = "";

            ServerSystem.ServerMain.Instance.StartServer(_tbLog);
        }


        private void OnClick_Stop(object sender, EventArgs e)
        {
            _btnStart.Enabled = true;
            _btnStop.Enabled = false;

            ServerSystem.ServerMain.Instance.StopServer();
        }


        private void OnSelect_LogLevel(object sender, EventArgs e)
        {
            Aegis.Logger.EnabledLevel = _cbLogLevel.SelectedIndex;
        }


        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            ServerSystem.ServerMain.Instance.StopServer();
        }
    }
}
