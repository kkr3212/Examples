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
    public partial class FormInvenCharacter : Form
    {
        public FormInvenCharacter()
        {
            InitializeComponent();
        }


        public void OnViewEntered()
        {
            FormMain.SetMessage("Request InvenCharacter...");
            NetworkAPI.UserData_InvenCharacter(OnRecv_InvenCharacter);
        }


        private void OnClick_Back(object sender, EventArgs e)
        {
            UIViews.ChangeView<FormGameMain>();
        }


        private void OnRecv_InvenCharacter(Response_InvenCharacter response)
        {
            _tbCount.Text = String.Format("{0} / {1}", response.Items.Count, response.MaxInventoryCount);
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


                if (ch.CharacterNo == response.MainCharacterNo)
                {
                    lvi.ForeColor = Color.Red;
                    _tbMainCharacter.Text = book.Name;
                }
            }


            FormMain.SetMessageReady();
        }
    }
}
