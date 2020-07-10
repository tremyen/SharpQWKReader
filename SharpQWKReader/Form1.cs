using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Q = QWK.Methods;

namespace SharpQWKReader
{
    public partial class SharpQWKReader : Form
    {
        public string forumId = "0";
        public ulong messagePointer = 0;

        public SharpQWKReader()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Q.OpenQWKPacket("ABUTRE2.QWK", "TMP\\");

            var bbsInfo = Q.GetBBSInfo("TMP\\");
            lblBBSName.Text = bbsInfo.BbsName;
            lblBBSPhone.Text = bbsInfo.BbsPhone;
            lblCityState.Text = bbsInfo.BbsLocation;
            lblDoorReg.Text = bbsInfo.MailDoorReg;
            lblPacketCreationDate.Text = bbsInfo.MailPacketCreationTime;
            lblSysopName.Text = bbsInfo.SysopName;
            lblUserName.Text = bbsInfo.UserName;
            lblMsgInThisPacket.Text = bbsInfo.MessagesInPacket.ToString();

            var forunsListView = new List<ListViewItem>();
            var foruns = Q.GetForuns("TMP\\");
            foreach (var forum in foruns)
            {
                var row = new string[] { forum.ID, forum.Name, forum.NumberOfMessages.ToString() };
                var lvItem = new ListViewItem(row);
                lstForuns.Items.Add(lvItem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstForuns.SelectedItems.Count == 0) return;
                lstMessages.Items.Clear();
                forumId = lstForuns.SelectedItems[0].Text;
                var messages = Q.GetForumMessages("TMP\\", forumId.ToString());
                foreach (var message in messages)
                {
                    var row = new string[] { message.Index.ToString(),message.From,message.To,message.Subject };
                    var lvItem = new ListViewItem(row);
                    lstMessages.Items.Add(lvItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void lstMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstMessages.SelectedItems.Count == 0) return;
                txtMensagem.Text = string.Empty;
                messagePointer = Convert.ToUInt64(lstMessages.SelectedItems[0].Text);
                var message = Q.GetMessage("TMP\\", messagePointer);
                txtMensagem.Text = message.Body;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
