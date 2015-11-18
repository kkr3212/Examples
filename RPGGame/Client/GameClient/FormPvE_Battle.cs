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
using GameClient.Books;
using NetworkAPI;



namespace GameClient
{
    public partial class FormPvE_Battle : Form
    {
        private Response_PvE_EnterDungeon _response;



        public FormPvE_Battle()
        {
            InitializeComponent();
        }


        public void OnViewEntered()
        {
            FormMain.SetMessage("Requesting EnterDungeon...");
            NetworkAPI.Requester.PvE_EnterDungeon(FormPvE.SelectedDungeonId, (response) =>
            {
                _lvRound.Items.Clear();
                _response = response;


                foreach (var round in _response.Rounds)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = round.RoundId.ToString();
                    lvi.SubItems.Add(round.Name);
                    if (round.IsBossRound == true)
                        lvi.SubItems.Add("Boss");
                    else
                        lvi.SubItems.Add("Normal");

                    _lvRound.Items.Add(lvi);
                }

                FormMain.SetMessageReady();
            });
        }


        private void OnClick_Back(object sender, EventArgs e)
        {
            UIViews.ChangeView<FormGameMain>();
        }


        private void OnSelect_Round(object sender, EventArgs e)
        {
            if (_lvRound.SelectedItems.Count == 0)
                return;


            _lvMonster.Items.Clear();


            Int32 roundId = Int32.Parse(_lvRound.SelectedItems[0].Text);
            foreach (var monster in _response.Rounds.Find(v => v.RoundId == roundId).Monsters)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = monster.MonsterId.ToString();
                lvi.SubItems.Add(monster.MonsterId.ToString());
                lvi.SubItems.Add(monster.Name);
                lvi.SubItems.Add(GameCode.Grade[monster.GradeId].Name);
                lvi.SubItems.Add(GameCode.Promotion[monster.PromotionId].Name);
                lvi.SubItems.Add(monster.Level.ToString());
                _lvMonster.Items.Add(lvi);
            }
        }
    }
}
