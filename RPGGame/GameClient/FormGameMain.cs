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
    public partial class FormGameMain : Form
    {
        private Button[] _btnSubMenu = new Button[12];





        public FormGameMain()
        {
            InitializeComponent();

            _btnSubMenu[0] = _btnSub0;
            _btnSubMenu[1] = _btnSub1;
            _btnSubMenu[2] = _btnSub2;
            _btnSubMenu[3] = _btnSub3;
            _btnSubMenu[4] = _btnSub4;
            _btnSubMenu[5] = _btnSub5;
            _btnSubMenu[6] = _btnSub6;
            _btnSubMenu[7] = _btnSub7;
            _btnSubMenu[8] = _btnSub8;
            _btnSubMenu[9] = _btnSub9;
            _btnSubMenu[10] = _btnSub10;
            _btnSubMenu[11] = _btnSub11;
        }


        public void OnViewEntered()
        {
            foreach (var btn in _btnSubMenu)
                btn.Hide();

            _btnPvE.Checked = false;
            _btnPvP.Checked = false;
            _btnShop.Checked = false;
            _btnEtc.Checked = false;


            FormMain.SetMessage("Request Codes...");
            NetworkAPI.GameData_Codes(OnRecv_GameData_Code);
        }


        public void OnViewLeaved()
        {
        }


        private void SetSubMenu(Int32 menuNo, String title)
        {
            _btnSubMenu[menuNo].Text = title;
            _btnSubMenu[menuNo].Show();
        }


        private void OnClick_Refresh(object sender, EventArgs e)
        {
            NetworkAPI.UserData_UserInfo(OnRecv_UserInfo);
        }


        private void OnSelect_Contents(object sender, EventArgs e)
        {
            foreach (var btn in _btnSubMenu)
                btn.Hide();


            if (_btnPvE.Checked)
            {
                SetSubMenu(0, "일반/정예");
                //SetSubMenu(1, "훈련소");
            }
            else if (_btnPvP.Checked)
            {
            }
            else if (_btnShop.Checked)
            {
            }
            else if (_btnEtc.Checked)
            {
                SetSubMenu(0, "캐릭터 인벤");
                //SetSubMenu(1, "아이템 인벤");
            }
        }


        private void OnClick_SubMenu(object sender, EventArgs e)
        {
            switch ((sender as Button).Text)
            {
                case "일반/정예": UIViews.ChangeView<FormPvE>(); break;
                case "훈련소": /*UIViews.ChangeView<(FormMain.View_Training_Main);*/ break;
                case "캐릭터 인벤": UIViews.ChangeView<FormInvenCharacter>(); break;
                case "아이템 인벤":/*UIViews.ChangeView(FormMain.View_Etc_InvenItem);*/ break;
            }
        }


        private void OnRecv_GameData_Code(Response_GameData_Codes response)
        {
            Books.GameCode.Energy.Clear();
            foreach (var data in response.Energy)
                Books.GameCode.Energy.Add(data.EnergyId, data);


            Books.GameCode.Resource.Clear();
            foreach (var data in response.Resource)
                Books.GameCode.Resource.Add(data.ResourceId, data);


            Books.GameCode.Race.Clear();
            foreach (var data in response.Race)
                Books.GameCode.Race.Add(data.RaceId, data);


            Books.GameCode.DamageType.Clear();
            foreach (var data in response.DamageType)
                Books.GameCode.DamageType.Add(data.DamageTypeId, data);


            Books.GameCode.Grade.Clear();
            foreach (var data in response.Grade)
                Books.GameCode.Grade.Add(data.GradeId, data);


            Books.GameCode.Promotion.Clear();
            foreach (var data in response.Promotion)
                Books.GameCode.Promotion.Add(data.PromotionId, data);


            Books.GameCode.Job.Clear();
            foreach (var data in response.Job)
                Books.GameCode.Job.Add(data.JobId, data);


            Books.GameCode.CharacterType.Clear();
            foreach (var data in response.CharacterType)
                Books.GameCode.CharacterType.Add(data.CharacterTypeId, data);


            Books.GameCode.Position.Clear();
            foreach (var data in response.Position)
                Books.GameCode.Position.Add(data.PositionId, data);


            FormMain.SetMessage("Request CharacterBook...");
            Books.CharacterBook.Items.Clear();
            NetworkAPI.GameData_CharacterBook(0, OnRecv_CharacterBook);
        }



        private void OnRecv_CharacterBook(Response_CharacterBook response)
        {
            if (response.Items.Count == 0)
            {
                FormMain.SetMessage("Request MonsterBook...");
                Books.MonsterBook.Items.Clear();
                NetworkAPI.GameData_MonsterBook(0, OnRecv_MonsterBook);
                return;
            }


            Int32 lastId = 0;
            foreach (var data in response.Items)
            {
                Books.CharacterBook.Items.Add(data);
                lastId = data.CharacterId;
            }

            NetworkAPI.GameData_CharacterBook(lastId + 1, OnRecv_CharacterBook);
        }



        private void OnRecv_MonsterBook(Response_MonsterBook response)
        {
            if (response.Items.Count == 0)
            {
                FormMain.SetMessage("Request UserInfo...");
                NetworkAPI.UserData_UserInfo(OnRecv_UserInfo);
                return;
            }


            Int32 lastId = 0;
            foreach (var data in response.Items)
            {
                Books.MonsterBook.Items.Add(data);
                lastId = data.MonsterId;
            }

            NetworkAPI.GameData_MonsterBook(lastId + 1, OnRecv_MonsterBook);
        }


        private void OnRecv_UserInfo(Response_UserInfo response)
        {
            this.PerformOnMainThread(() =>
            {
                _lbNickname.Text = response.Nickname;
                _tbUserLevel.Text = response.Level.ToString();
                _tbUserExp.Text = response.Exp.ToString();
                _tbVIPLevel.Text = response.VIPLevel.ToString();
                _tbVIPExp.Text = response.VIPExp.ToString();


                _lvEnergy.Items.Clear();
                foreach (var energy in response.Energies)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = energy.EnergyId.ToString();
                    lvi.SubItems.Add(Books.GameCode.Energy[energy.EnergyId].Name);
                    lvi.SubItems.Add(energy.Point.ToString());
                    lvi.SubItems.Add(energy.RemainSecond.ToString());

                    _lvEnergy.Items.Add(lvi);
                }


                _lvResource.Items.Clear();
                foreach (var resource in response.Resources)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = resource.ResourceId.ToString();
                    lvi.SubItems.Add(Books.GameCode.Resource[resource.ResourceId].Name);
                    lvi.SubItems.Add(resource.Point.ToString());

                    _lvResource.Items.Add(lvi);
                }

                FormMain.SetMessageReady();
            });
        }
    }
}
