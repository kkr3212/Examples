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
    public partial class FormPvE : Form
    {
        public static Int32 SelectedDungeonId { get; private set; }





        public FormPvE()
        {
            InitializeComponent();
        }


        public void OnViewEntered()
        {
            _lvWorld.Items.Clear();
            _lvField.Items.Clear();
            _lvDungeon.Items.Clear();
            _lvDeck.Items.Clear();
            _lvMercenary.Items.Clear();


            FormMain.SetMessage("Request InvenCharacter...");
            NetworkAPI.UserData_InvenCharacter((response) =>
            {
                FormMain.SetMessage("Request PlayDeck...");
                NetworkAPI.PvE_GetDeck(DeckType.PvE_Normal, (responseDeck) =>
                {
                    foreach (var data in responseDeck.Items)
                    {
                        var ch = response.Items.Find(v => v.CharacterNo == data.CharacterNo);
                        if (ch.CharacterId == 0)
                            continue;

                        var book = Books.CharacterBook.Items.Find(v => v.CharacterId == ch.CharacterId);
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = book.Name;
                        lvi.SubItems.Add(Books.GameCode.Grade[ch.GradeId].Name);
                        lvi.SubItems.Add(Books.GameCode.Promotion[ch.PromotionId].Name);
                        lvi.SubItems.Add(ch.Level.ToString());

                        _lvDeck.Items.Add(lvi);
                    }


                    FormMain.SetMessage("Request WorldList...");
                    NetworkAPI.PvE_WorldList(OnRecv_WorldList);
                });
            });
        }


        private void OnClick_Back(object sender, EventArgs e)
        {
            UIViews.ChangeView<FormGameMain>();
        }


        private void OnClick_CheckDeck(object sender, EventArgs e)
        {
            UIViews.ChangeView<FormPvE_PlayDeck>();
        }


        private void OnRecv_WorldList(Response_PvE_WorldList response)
        {
            _lvWorld.Items.Clear();
            _lvField.Items.Clear();
            _lvDungeon.Items.Clear();

            foreach (var data in response.Items)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = data.WorldId.ToString();
                lvi.SubItems.Add(data.Name);

                _lvWorld.Items.Add(lvi);
            }

            FormMain.SetMessageReady();
        }


        private void OnSelected_World(object sender, EventArgs e)
        {
            if (_lvWorld.SelectedItems.Count == 0)
                return;


            Int32 worldId = Int32.Parse(_lvWorld.SelectedItems[0].Text);

            FormMain.SetMessage("Request FieldList...");
            NetworkAPI.PvE_FieldList(worldId, (response) =>
            {
                _lvField.Items.Clear();
                _lvDungeon.Items.Clear();

                foreach (var data in response.Items)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = data.FieldId.ToString();
                    lvi.SubItems.Add(data.Name);

                    _lvField.Items.Add(lvi);
                }

                FormMain.SetMessageReady();
            });
        }


        private void OnSelected_Field(object sender, EventArgs e)
        {
            if (_lvField.SelectedItems.Count == 0)
                return;


            Int32 fieldId = Int32.Parse(_lvField.SelectedItems[0].Text);

            FormMain.SetMessage("Request DungeonList...");
            NetworkAPI.PvE_DungeonList(fieldId, (response) =>
            {
                _lvDungeon.Items.Clear();

                foreach (var data in response.Items)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = data.DungeonId.ToString();
                    lvi.SubItems.Add(data.Name);
                    lvi.SubItems.Add(data.Level.ToString());
                    lvi.Tag = data;

                    _lvDungeon.Items.Add(lvi);
                }

                FormMain.SetMessageReady();
            });
        }


        private void OnClick_Enter(object sender, EventArgs e)
        {
            if (_lvDungeon.SelectedItems.Count == 0)
                return;


            SelectedDungeonId = Int32.Parse(_lvDungeon.SelectedItems[0].Text);
            UIViews.ChangeView<FormPvE_Battle>();
        }
    }
}
