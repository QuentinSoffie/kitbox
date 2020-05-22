﻿namespace Kitbox.GUI.StoreKeeper.Views
{
    partial class SearchComponent
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pepGroupBox1 = new KitboxEcamGUI.PepGroupBox();
            this.pepButton1 = new KitboxEcamGUI.PepButton();
            this.pepCombobox1 = new KitboxEcamGUI.PepCombobox();
            this.pepTextbox1 = new KitboxEcamGUI.PepTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pepTreeView1 = new KitboxEcamGUI.PepTreeView();
            this.panel1.SuspendLayout();
            this.pepGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pepGroupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 76);
            this.panel1.TabIndex = 10;
            // 
            // pepGroupBox1
            // 
            this.pepGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pepGroupBox1.Controls.Add(this.pepButton1);
            this.pepGroupBox1.Controls.Add(this.pepCombobox1);
            this.pepGroupBox1.Controls.Add(this.pepTextbox1);
            this.pepGroupBox1.Controls.Add(this.label1);
            this.pepGroupBox1.Location = new System.Drawing.Point(133, -12);
            this.pepGroupBox1.Name = "pepGroupBox1";
            this.pepGroupBox1.Size = new System.Drawing.Size(1017, 86);
            this.pepGroupBox1.TabIndex = 8;
            this.pepGroupBox1.TabStop = false;
            // 
            // pepButton1
            // 
            this.pepButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.pepButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton1.Location = new System.Drawing.Point(849, 38);
            this.pepButton1.Name = "pepButton1";
            this.pepButton1.Size = new System.Drawing.Size(146, 28);
            this.pepButton1.TabIndex = 3;
            this.pepButton1.Text = "Search !";
            this.pepButton1.UseVisualStyleBackColor = true;
            this.pepButton1.Click += new System.EventHandler(this.pepButton1_Click);
            // 
            // pepCombobox1
            // 
            this.pepCombobox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepCombobox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pepCombobox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pepCombobox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pepCombobox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.pepCombobox1.FormattingEnabled = true;
            this.pepCombobox1.ItemHeight = 20;
            this.pepCombobox1.Items.AddRange(new object[] {
            "Reference",
            "Code"});
            this.pepCombobox1.Location = new System.Drawing.Point(172, 39);
            this.pepCombobox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pepCombobox1.Name = "pepCombobox1";
            this.pepCombobox1.Size = new System.Drawing.Size(135, 26);
            this.pepCombobox1.TabIndex = 0;
            this.pepCombobox1.SelectedIndexChanged += new System.EventHandler(this.pepCombobox1_SelectedIndexChanged);
            // 
            // pepTextbox1
            // 
            this.pepTextbox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pepTextbox1.EnabledCalc = true;
            this.pepTextbox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pepTextbox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepTextbox1.Location = new System.Drawing.Point(324, 38);
            this.pepTextbox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pepTextbox1.MaxLength = 32767;
            this.pepTextbox1.MultiLine = false;
            this.pepTextbox1.Name = "pepTextbox1";
            this.pepTextbox1.ReadOnly = false;
            this.pepTextbox1.Size = new System.Drawing.Size(507, 27);
            this.pepTextbox1.TabIndex = 1;
            this.pepTextbox1.Tag = "Search by reference or by code...";
            this.pepTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pepTextbox1.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(5, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search by :";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 80);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pepTreeView1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.splitContainer1.Size = new System.Drawing.Size(1276, 549);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.SplitterWidth = 11;
            this.splitContainer1.TabIndex = 11;
            // 
            // pepTreeView1
            // 
            this.pepTreeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pepTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pepTreeView1.Caption = false;
            this.pepTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pepTreeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pepTreeView1.ItemHeight = 50;
            this.pepTreeView1.Location = new System.Drawing.Point(0, 0);
            this.pepTreeView1.Name = "pepTreeView1";
            this.pepTreeView1.Online = false;
            this.pepTreeView1.Size = new System.Drawing.Size(312, 549);
            this.pepTreeView1.TabIndex = 0;
            this.pepTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.pepTreeView1_AfterSelect);
            // 
            // SearchComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "SearchComponent";
            this.Size = new System.Drawing.Size(1282, 632);
            this.panel1.ResumeLayout(false);
            this.pepGroupBox1.ResumeLayout(false);
            this.pepGroupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private KitboxEcamGUI.PepGroupBox pepGroupBox1;
        private KitboxEcamGUI.PepButton pepButton1;
        private KitboxEcamGUI.PepCombobox pepCombobox1;
        private KitboxEcamGUI.PepTextbox pepTextbox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private KitboxEcamGUI.PepTreeView pepTreeView1;
    }
}