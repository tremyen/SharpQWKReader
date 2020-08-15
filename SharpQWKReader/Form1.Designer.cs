namespace SharpQWKReader
{
    partial class SharpQWKReader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstForuns = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMsgInThisPacket = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBBSPhone = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPacketCreationDate = new System.Windows.Forms.Label();
            this.lblDoorReg = new System.Windows.Forms.Label();
            this.lblSysopName = new System.Windows.Forms.Label();
            this.lblCityState = new System.Windows.Forms.Label();
            this.lblBBSName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstMessages = new System.Windows.Forms.ListView();
            this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.To = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(723, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 742);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(723, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstForuns);
            this.groupBox1.Location = new System.Drawing.Point(338, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 225);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Foruns";
            // 
            // lstForuns
            // 
            this.lstForuns.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstForuns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstForuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstForuns.FullRowSelect = true;
            this.lstForuns.GridLines = true;
            this.lstForuns.HideSelection = false;
            this.lstForuns.Location = new System.Drawing.Point(3, 16);
            this.lstForuns.MultiSelect = false;
            this.lstForuns.Name = "lstForuns";
            this.lstForuns.Size = new System.Drawing.Size(371, 206);
            this.lstForuns.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstForuns.TabIndex = 0;
            this.lstForuns.UseCompatibleStateImageBehavior = false;
            this.lstForuns.View = System.Windows.Forms.View.Details;
            this.lstForuns.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mensagens";
            this.columnHeader3.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMsgInThisPacket);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblBBSPhone);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblUserName);
            this.groupBox2.Controls.Add(this.lblPacketCreationDate);
            this.groupBox2.Controls.Add(this.lblDoorReg);
            this.groupBox2.Controls.Add(this.lblSysopName);
            this.groupBox2.Controls.Add(this.lblCityState);
            this.groupBox2.Controls.Add(this.lblBBSName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 225);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BBS Info";
            // 
            // lblMsgInThisPacket
            // 
            this.lblMsgInThisPacket.AutoSize = true;
            this.lblMsgInThisPacket.Location = new System.Drawing.Point(181, 193);
            this.lblMsgInThisPacket.Name = "lblMsgInThisPacket";
            this.lblMsgInThisPacket.Size = new System.Drawing.Size(22, 13);
            this.lblMsgInThisPacket.TabIndex = 15;
            this.lblMsgInThisPacket.Text = "< >";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Messages in this packet";
            // 
            // lblBBSPhone
            // 
            this.lblBBSPhone.AutoSize = true;
            this.lblBBSPhone.Location = new System.Drawing.Point(181, 52);
            this.lblBBSPhone.Name = "lblBBSPhone";
            this.lblBBSPhone.Size = new System.Drawing.Size(22, 13);
            this.lblBBSPhone.TabIndex = 13;
            this.lblBBSPhone.Text = "< >";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "BBS Phone";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(181, 172);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(22, 13);
            this.lblUserName.TabIndex = 11;
            this.lblUserName.Text = "< >";
            // 
            // lblPacketCreationDate
            // 
            this.lblPacketCreationDate.AutoSize = true;
            this.lblPacketCreationDate.Location = new System.Drawing.Point(181, 148);
            this.lblPacketCreationDate.Name = "lblPacketCreationDate";
            this.lblPacketCreationDate.Size = new System.Drawing.Size(22, 13);
            this.lblPacketCreationDate.TabIndex = 10;
            this.lblPacketCreationDate.Text = "< >";
            // 
            // lblDoorReg
            // 
            this.lblDoorReg.AutoSize = true;
            this.lblDoorReg.Location = new System.Drawing.Point(181, 124);
            this.lblDoorReg.Name = "lblDoorReg";
            this.lblDoorReg.Size = new System.Drawing.Size(22, 13);
            this.lblDoorReg.TabIndex = 9;
            this.lblDoorReg.Text = "< >";
            // 
            // lblSysopName
            // 
            this.lblSysopName.AutoSize = true;
            this.lblSysopName.Location = new System.Drawing.Point(181, 100);
            this.lblSysopName.Name = "lblSysopName";
            this.lblSysopName.Size = new System.Drawing.Size(22, 13);
            this.lblSysopName.TabIndex = 8;
            this.lblSysopName.Text = "< >";
            // 
            // lblCityState
            // 
            this.lblCityState.AutoSize = true;
            this.lblCityState.Location = new System.Drawing.Point(181, 77);
            this.lblCityState.Name = "lblCityState";
            this.lblCityState.Size = new System.Drawing.Size(22, 13);
            this.lblCityState.TabIndex = 7;
            this.lblCityState.Text = "< >";
            // 
            // lblBBSName
            // 
            this.lblBBSName.AutoSize = true;
            this.lblBBSName.Location = new System.Drawing.Point(181, 28);
            this.lblBBSName.Name = "lblBBSName";
            this.lblBBSName.Size = new System.Drawing.Size(22, 13);
            this.lblBBSName.TabIndex = 6;
            this.lblBBSName.Text = "< >";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "User name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mail packet creation time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mail door registration #, BBSID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "BBS Sysop name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "BBS city and state";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "BBS name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstMessages);
            this.groupBox3.Location = new System.Drawing.Point(12, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(703, 137);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Messages";
            // 
            // lstMessages
            // 
            this.lstMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Index,
            this.From,
            this.To,
            this.Subject});
            this.lstMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMessages.FullRowSelect = true;
            this.lstMessages.HideSelection = false;
            this.lstMessages.Location = new System.Drawing.Point(3, 16);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(697, 118);
            this.lstMessages.TabIndex = 0;
            this.lstMessages.UseCompatibleStateImageBehavior = false;
            this.lstMessages.View = System.Windows.Forms.View.Details;
            this.lstMessages.SelectedIndexChanged += new System.EventHandler(this.lstMessages_SelectedIndexChanged);
            // 
            // From
            // 
            this.From.Text = "From";
            this.From.Width = 120;
            // 
            // To
            // 
            this.To.DisplayIndex = 1;
            this.To.Text = "To";
            this.To.Width = 120;
            // 
            // Subject
            // 
            this.Subject.DisplayIndex = 2;
            this.Subject.Text = "Subject";
            this.Subject.Width = 360;
            // 
            // Index
            // 
            this.Index.Text = "Index";
            this.Index.Width = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtMensagem);
            this.groupBox4.Location = new System.Drawing.Point(12, 402);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(703, 337);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Read Pannel";
            // 
            // txtMensagem
            // 
            this.txtMensagem.Location = new System.Drawing.Point(3, 19);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(697, 312);
            this.txtMensagem.TabIndex = 0;
            // 
            // SharpQWKReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 764);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SharpQWKReader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sharp QWK Reader";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstForuns;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPacketCreationDate;
        private System.Windows.Forms.Label lblDoorReg;
        private System.Windows.Forms.Label lblSysopName;
        private System.Windows.Forms.Label lblCityState;
        private System.Windows.Forms.Label lblBBSName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lstMessages;
        private System.Windows.Forms.ColumnHeader From;
        private System.Windows.Forms.ColumnHeader To;
        private System.Windows.Forms.ColumnHeader Subject;
        private System.Windows.Forms.Label lblBBSPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.Label lblMsgInThisPacket;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader Index;
    }
}

