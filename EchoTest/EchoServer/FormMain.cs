using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EchoServer.Logic;



namespace EchoServer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            _btnStart.Enabled = true;
            _btnStop.Enabled = false;
        }


        private void OnClick_Start(object sender, EventArgs e)
        {
            _btnStart.Enabled = false;
            _btnStop.Enabled = true;

            _tbLog.Text = "";

            ServerMain.StartServer(_tbLog);
            (new Aegis.Calculate.IntervalTimer("Update", 100, UpdateStatistics)).Start();
        }


        private void OnClick_Stop(object sender, EventArgs e)
        {
            _btnStart.Enabled = true;
            _btnStop.Enabled = false;

            Aegis.Calculate.IntervalTimer.Timers["Update"].Dispose();
            ServerMain.StopServer();
        }


        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            OnClick_Stop(null, null);
            ServerMain.StopServer();
        }


        private void UpdateStatistics()
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { UpdateStatistics(); });
            else
            {
                int sessionCount = ServerMain.GetActiveSessionCount();
                int receiveCount = Aegis.Calculate.IntervalCounter.Counters["ReceiveCount"].Value;
                int receiveBytes = Aegis.Calculate.IntervalCounter.Counters["ReceiveBytes"].Value;


                _lbActiveSession.Text = String.Format("{0:N0}", sessionCount);
                _lbReceiveCount.Text = String.Format("{0:N0}", receiveCount);
                _lbReceiveBytes.Text = String.Format("{0:N0}", receiveBytes);
                _lbTaskCount.Text = Aegis.Threading.AegisTask.TaskCount.ToString();
            }
        }
    }
}
