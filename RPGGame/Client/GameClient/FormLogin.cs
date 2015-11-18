using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClient.WinFormHelper;
using NetworkAPI;



namespace GameClient
{
    public partial class FormLogin : Form
    {
        public static String UserToken { get; private set; }





        public FormLogin()
        {
            InitializeComponent();


            _tbServerIp.Text = "127.0.0.1";
            _tbPortNo.Text = "10100";
            _tbUserToken.Text = "Test1";
        }


        public void OnViewEntered()
        {
            OnClick_RefreshWorldList(null, null);
        }


        public void OnViewLeaved()
        {
        }


        private void OnClick_RefreshWorldList(object sender, EventArgs e)
        {
            Requester.SetAuthServer(_tbServerIp.Text, _tbPortNo.Text.ToInt32());


            //  접속 가능한 World 목록 요청
            _lvWorld.Items.Clear();
            Requester.Auth_WorldList((response) =>
            {
                foreach (var info in response.Items)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = info.WorldId.ToString();
                    lvi.SubItems.Add(info.WorldName);

                    _lvWorld.Items.Add(lvi);
                }


                if (response.Items.Count > 0)
                    _lvWorld.Items[0].Selected = true;

                FormMain.SetMessageReady();
            });
        }


        private void OnClick_Register(object sender, EventArgs e)
        {
            //  UserToken으로 가입 요청
            Requester.Auth_RegisterGuest(_tbUserToken.Text, (response) =>
            {
                if (response.ResultCodeNo != ResultCode.Ok)
                {
                    FormMain.SetMessageRed(ResultCode.ToString(response.ResultCodeNo));
                    return;
                }

                FormMain.SetMessageBlue("Registered as guest.");
            });
        }


        private void OnClick_Login(object sender, EventArgs e)
        {
            if (_lvWorld.SelectedItems.Count == 0)
            {
                FormMain.SetMessageRed("Select a world.");
                return;
            }

            Int32 worldId = Int32.Parse(_lvWorld.SelectedItems[0].Text);
            UserToken = _tbUserToken.Text;


            //  UserToken을 사용해 로그인 요청
            Requester.Auth_LoginGuest(worldId, UserToken, (response) =>
            {
                if (response.ResultCodeNo == ResultCode.Ok)
                    UIViews.ChangeView<FormGameMain>();

                else if (response.ResultCodeNo == ResultCode.NewUser)
                    UIViews.ChangeView<FormNewUser>();

                else
                    FormMain.SetMessageRed(ResultCode.ToString(response.ResultCodeNo));
            });
        }
    }
}
