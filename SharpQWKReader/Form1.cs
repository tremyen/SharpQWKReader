using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Q = QWK.Methods;

namespace SharpQWKReader
{
    public partial class SharpQWKReader : Form
    {
        public string forumId = "0";
        public Int64 messagePointer = 0;

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
                var row = new string[] { forum.ForumID, forum.ForumName };
                var lvItem = new ListViewItem(row);
                listView1.Items.Add(lvItem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0) return;
                lstIndiceAberto.Items.Clear();
                forumId = listView1.SelectedItems[0].Text;
                var messagePointers = Q.ReadNDXFile("TMP\\", forumId.ToString());
                foreach (var messagePointer in messagePointers)
                {
                    var row = new string[] { messagePointer.messageBytesLocation.ToString() };
                    var lvItem = new ListViewItem(row);
                    lstIndiceAberto.Items.Add(lvItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstIndiceAberto_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstMessages.Items.Clear();
            txtMensagem.Text = string.Empty;
            try
            {
                if (lstIndiceAberto.SelectedItems.Count == 0) return;
                lstIndiceAberto.Items.Clear();
                messagePointer = Convert.ToInt64(lstIndiceAberto.SelectedItems[0].Text);
                var message = Q.GetMessage("TMP\\", messagePointer);
                var rowHeader = new string[] { message.From, message.To, message.Subject };
                var lvItemHeader = new ListViewItem(rowHeader);
                lstMessages.Items.Add(lvItemHeader);
                txtMensagem.Text = message.Body;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
