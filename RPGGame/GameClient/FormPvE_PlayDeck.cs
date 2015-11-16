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
    public partial class FormPvE_PlayDeck : Form
    {
        public FormPvE_PlayDeck()
        {
            InitializeComponent();
        }


        public void OnViewEntered()
        {
            _lvDeck.Items.Clear();
            _lvInventory.Items.Clear();

            FormMain.SetMessage("Request InvenCharacter...");
            NetworkAPI.UserData_InvenCharacter(OnRecv_InvenCharacter);
        }


        private void OnClick_Back(object sender, EventArgs e)
        {
            UIViews.ChangeView<FormPvE>();
        }


        private void OnRecv_InvenCharacter(Response_InvenCharacter response)
        {
            _lvInventory.Items.Clear();
            foreach (var ch in response.Items)
            {
                var book = Books.CharacterBook.Items.Find(v => v.CharacterId == ch.CharacterId);
                ListViewItem lvi = new ListViewItem();
                lvi.Text = ch.CharacterNo.ToString();
                lvi.SubItems.Add(book.Name);
                lvi.SubItems.Add(Books.GameCode.Grade[ch.GradeId].Name);
                lvi.SubItems.Add(Books.GameCode.Promotion[ch.PromotionId].Name);
                lvi.SubItems.Add(String.Format("{0} ({1})", ch.Level, ch.Exp));
                lvi.SubItems.Add(Books.GameCode.Race[book.RaceId].Name);
                lvi.SubItems.Add(Books.GameCode.CharacterType[book.CharacterTypeId].Name);
                lvi.SubItems.Add(Books.GameCode.Job[book.JobId].Name);
                lvi.SubItems.Add(Books.GameCode.Position[book.PositionId].Name);
                _lvInventory.Items.Add(lvi);
            }


            FormMain.SetMessage("Request PlayDeck...");
            NetworkAPI.PvE_GetDeck(DeckType.PvE_Normal, (responseDeck) =>
            {
                foreach (var data in responseDeck.Items)
                {
                    foreach (ListViewItem lvi in _lvInventory.Items)
                    {
                        if (lvi.Text == data.CharacterNo.ToString())
                        {
                            lvi.Selected = true;
                            break;
                        }
                    }
                }

                OnClick_AddToDeck(null, null);
                FormMain.SetMessageReady();
            });
        }


        private void OnClick_AddToDeck(object sender, EventArgs e)
        {
            foreach (var item in _lvInventory.SelectedItems)
            {
                ListViewItem lvi = ((item as ListViewItem).Clone() as ListViewItem);
                _lvDeck.Items.Add(lvi);

                _lvInventory.Items.Remove((ListViewItem)item);
            }
        }


        private void OnClick_RemoveFromDeck(object sender, EventArgs e)
        {
            foreach (var item in _lvDeck.SelectedItems)
            {
                ListViewItem lvi = ((item as ListViewItem).Clone() as ListViewItem);
                _lvInventory.Items.Add(lvi);

                _lvDeck.Items.Remove((ListViewItem)item);
            }
        }


        private void OnClick_Cancel(object sender, EventArgs e)
        {
            UIViews.ChangeView<FormGameMain>();
        }


        private void OnClick_Apply(object sender, EventArgs e)
        {
            if (_lvDeck.Items.Count >= Constants.MaxDeckSlotCount)
            {
                MessageBox.Show(String.Format("최대 {0}개까지 편성 가능합니다.", Constants.MaxDeckSlotCount));
                return;
            }


            Int32[] characterNo = new Int32[Constants.MaxDeckSlotCount];
            Int32 count = 0;
            foreach (var item in _lvDeck.Items)
            {
                ListViewItem lvi = (ListViewItem)item;
                characterNo[count++] = Int32.Parse(lvi.Text);
            }


            FormMain.SetMessageBlue("Request SetPlayDeck...");
            NetworkAPI.PvE_SetDeck(DeckType.PvE_Normal, characterNo, (response) =>
            {
                if (response.ResultCodeNo != ResultCode.Ok)
                    FormMain.SetMessageRed(ResultCode.ToString(response.ResultCodeNo));

                FormMain.SetMessageReady();
            });
        }
    }
}
