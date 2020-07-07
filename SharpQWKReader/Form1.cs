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
            Q.OpenQWKPacket();
            var forunsListView = new List<ListViewItem>();
            var foruns = Q.GetForuns();
        }
    }
}
