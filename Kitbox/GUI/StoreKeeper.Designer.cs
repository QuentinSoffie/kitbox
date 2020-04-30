namespace Kitbox.GUI
{
    partial class StoreKeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreKeeper));
            this.pepCombobox1 = new KitboxEcamGUI.PepCombobox();
            this.pepTextbox1 = new KitboxEcamGUI.PepTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.pepButton1 = new KitboxEcamGUI.PepButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.recherchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pepTreeView1 = new KitboxEcamGUI.PepTreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pepGroupBox1 = new KitboxEcamGUI.PepGroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pepGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pepCombobox1
            // 
            this.pepCombobox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pepCombobox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pepCombobox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pepCombobox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.pepCombobox1.FormattingEnabled = true;
            this.pepCombobox1.ItemHeight = 20;
            this.pepCombobox1.Items.AddRange(new object[] {
            "",
            "Order number",
            "Customer"});
            this.pepCombobox1.Location = new System.Drawing.Point(167, 23);
            this.pepCombobox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pepCombobox1.Name = "pepCombobox1";
            this.pepCombobox1.Size = new System.Drawing.Size(135, 26);
            this.pepCombobox1.TabIndex = 0;
            this.pepCombobox1.SelectedIndexChanged += new System.EventHandler(this.pepCombobox1_SelectedIndexChanged);
            // 
            // pepTextbox1
            // 
            this.pepTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pepTextbox1.EnabledCalc = true;
            this.pepTextbox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pepTextbox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepTextbox1.Location = new System.Drawing.Point(316, 22);
            this.pepTextbox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pepTextbox1.MaxLength = 32767;
            this.pepTextbox1.MultiLine = false;
            this.pepTextbox1.Name = "pepTextbox1";
            this.pepTextbox1.ReadOnly = false;
            this.pepTextbox1.Size = new System.Drawing.Size(507, 27);
            this.pepTextbox1.TabIndex = 1;
            this.pepTextbox1.Tag = "Search by name or by order...";
            this.pepTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pepTextbox1.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search by :";
            // 
            // pepButton1
            // 
            this.pepButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.pepButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton1.Location = new System.Drawing.Point(828, 22);
            this.pepButton1.Name = "pepButton1";
            this.pepButton1.Size = new System.Drawing.Size(142, 27);
            this.pepButton1.TabIndex = 3;
            this.pepButton1.Text = "Search !";
            this.pepButton1.UseVisualStyleBackColor = true;
            this.pepButton1.Click += new System.EventHandler(this.pepButton1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recherchesToolStripMenuItem,
            this.stockToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // recherchesToolStripMenuItem
            // 
            this.recherchesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderToolStripMenuItem,
            this.componentToolStripMenuItem,
            this.customerToolStripMenuItem});
            this.recherchesToolStripMenuItem.Name = "recherchesToolStripMenuItem";
            this.recherchesToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.recherchesToolStripMenuItem.Text = "Search";
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.orderToolStripMenuItem.Text = "Order";
            // 
            // componentToolStripMenuItem
            // 
            this.componentToolStripMenuItem.Name = "componentToolStripMenuItem";
            this.componentToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.componentToolStripMenuItem.Text = "Component";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.customerToolStripMenuItem.Text = "Customer";
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewPartToolStripMenuItem});
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.stockToolStripMenuItem.Text = "Stock";
            // 
            // createNewPartToolStripMenuItem
            // 
            this.createNewPartToolStripMenuItem.Name = "createNewPartToolStripMenuItem";
            this.createNewPartToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.createNewPartToolStripMenuItem.Text = "Create new compnent";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 88);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pepTreeView1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Calibri", 12F);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2MinSize = 600;
            this.splitContainer1.Size = new System.Drawing.Size(1260, 561);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.SplitterWidth = 11;
            this.splitContainer1.TabIndex = 5;
            // 
            // pepTreeView1
            // 
            this.pepTreeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pepTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pepTreeView1.Caption = false;
            this.pepTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pepTreeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pepTreeView1.ItemHeight = 40;
            this.pepTreeView1.Location = new System.Drawing.Point(0, 0);
            this.pepTreeView1.Name = "pepTreeView1";
            this.pepTreeView1.Online = false;
            this.pepTreeView1.Size = new System.Drawing.Size(300, 561);
            this.pepTreeView1.TabIndex = 0;
            this.pepTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.pepTreeView1_AfterSelect);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(450, 272);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 51);
            this.panel1.TabIndex = 6;
            // 
            // pepGroupBox1
            // 
            this.pepGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pepGroupBox1.Controls.Add(this.pepButton1);
            this.pepGroupBox1.Controls.Add(this.pepCombobox1);
            this.pepGroupBox1.Controls.Add(this.pepTextbox1);
            this.pepGroupBox1.Controls.Add(this.label1);
            this.pepGroupBox1.Location = new System.Drawing.Point(119, 27);
            this.pepGroupBox1.Name = "pepGroupBox1";
            this.pepGroupBox1.Size = new System.Drawing.Size(1003, 52);
            this.pepGroupBox1.TabIndex = 4;
            this.pepGroupBox1.TabStop = false;
            // 
            // StoreKeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.pepGroupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "StoreKeeper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StoreKeeper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pepGroupBox1.ResumeLayout(false);
            this.pepGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KitboxEcamGUI.PepCombobox pepCombobox1;
        private KitboxEcamGUI.PepTextbox pepTextbox1;
        private System.Windows.Forms.Label label1;
        private KitboxEcamGUI.PepButton pepButton1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem recherchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewPartToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private KitboxEcamGUI.PepGroupBox pepGroupBox1;
        private KitboxEcamGUI.PepTreeView pepTreeView1;
    }
}