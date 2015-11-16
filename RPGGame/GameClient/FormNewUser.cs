using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPGGame.GameClient.WinFormHelper;



namespace RPGGame.GameClient
{
    public partial class FormNewUser : Form
    {
        public FormNewUser()
        {
            InitializeComponent();
        }


        public void OnViewEntered()
        {
            _tbNickname.Text = FormLogin.UserToken;
            FormMain.SetMessageReady();
        }


        public void OnViewLeaved()
        {
        }


        private void OnClick_Ok(object sender, EventArgs e)
        {
            NetworkAPI.UserData_Init(_tbNickname.Text, (response) =>
            {
                if (response.ResultCodeNo != ResultCode.Ok)
                {
                    FormMain.SetMessageRed(ResultCode.ToString(response.ResultCodeNo));
                    return;
                }

                UIViews.ChangeView<FormGameMain>();
            });
        }
    }
}
