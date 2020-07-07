using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Q = QWK.Methods;

namespace SharpQWKReader
{
    public partial class SharpQWKReader : Form
    {
        public SharpQWKReader()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Q.OpenQWKPacket("ABUTRE2.QWK", "TMP\\");
            
            var bbsInfo = Q.GetBBSInfo("TMP\\");
            lblBBSName.Text = bbsInfo.BbsName;
            lblCityState.Text = bbsInfo.BbsLocation;
            lblDoorReg.Text = bbsInfo.MailDoorReg;
            lblPacketCreationDate.Text = bbsInfo.MailPacketCreationTime;
            lblSysopName.Text = bbsInfo.SysopName;
            lblUserName.Text = bbsInfo.UserName;

            var forunsListView = new List<ListViewItem>();
            var foruns = Q.GetForuns("TMP\\");
            foreach (var forum in foruns)
            {                
                var row = new string[] {forum.ForumId,forum.ForumName};
                var lvItem = new ListViewItem(row);
                listView1.Items.Add(lvItem);
            }

            var messages = Q.GetAllMessages("TMP\\");
            foreach (var message in messages)
            {
                var row = new string[] { message.From, message.To, message.Subject };
                var lvItem = new ListViewItem(row);
                lstMessages.Items.Add(lvItem);
            }
        }   
    }
}
