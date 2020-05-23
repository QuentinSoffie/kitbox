namespace Kitbox.GUI.StoreKeeper.Views
{
    partial class OrderSuppliers
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pepButton1 = new KitboxEcamGUI.PepButton();
            this.pepTreeView1 = new KitboxEcamGUI.PepTreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pepButton4 = new KitboxEcamGUI.PepButton();
            this.pepGroupBox7 = new KitboxEcamGUI.PepGroupBox();
            this.pepGroupBox6 = new KitboxEcamGUI.PepGroupBox();
            this.pepGroupBox1 = new KitboxEcamGUI.PepGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pepTreeView2 = new KitboxEcamGUI.PepTreeView();
            this.pepTreeView3 = new KitboxEcamGUI.PepTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pepGroupBox7.SuspendLayout();
            this.pepGroupBox6.SuspendLayout();
            this.pepGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pepButton1);
            this.splitContainer1.Panel1.Controls.Add(this.pepTreeView1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1282, 584);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 0;
            // 
            // pepButton1
            // 
            this.pepButton1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pepButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pepButton1.Location = new System.Drawing.Point(0, 511);
            this.pepButton1.Name = "pepButton1";
            this.pepButton1.Size = new System.Drawing.Size(312, 73);
            this.pepButton1.TabIndex = 1;
            this.pepButton1.Text = "Check stock";
            this.pepButton1.UseVisualStyleBackColor = true;
            this.pepButton1.Click += new System.EventHandler(this.pepButton1_Click);
            // 
            // pepTreeView1
            // 
            this.pepTreeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pepTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pepTreeView1.Caption = false;
            this.pepTreeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pepTreeView1.ItemHeight = 50;
            this.pepTreeView1.Location = new System.Drawing.Point(0, 0);
            this.pepTreeView1.Name = "pepTreeView1";
            this.pepTreeView1.Online = false;
            this.pepTreeView1.Size = new System.Drawing.Size(312, 510);
            this.pepTreeView1.TabIndex = 0;
            this.pepTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.pepTreeView1_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.splitContainer2.Panel2.Controls.Add(this.pepButton4);
            this.splitContainer2.Panel2.Controls.Add(this.pepGroupBox7);
            this.splitContainer2.Panel2.Controls.Add(this.pepGroupBox6);
            this.splitContainer2.Panel2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer2.Size = new System.Drawing.Size(974, 584);
            this.splitContainer2.SplitterDistance = 486;
            this.splitContainer2.TabIndex = 0;
            // 
            // pepButton4
            // 
            this.pepButton4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pepButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton4.Location = new System.Drawing.Point(42, 489);
            this.pepButton4.Name = "pepButton4";
            this.pepButton4.Size = new System.Drawing.Size(394, 41);
            this.pepButton4.TabIndex = 16;
            this.pepButton4.Text = "Confirm order";
            this.pepButton4.UseVisualStyleBackColor = true;
            this.pepButton4.Visible = false;
            this.pepButton4.Click += new System.EventHandler(this.pepButton4_Click);
            // 
            // pepGroupBox7
            // 
            this.pepGroupBox7.Controls.Add(this.pepTreeView3);
            this.pepGroupBox7.Location = new System.Drawing.Point(42, 255);
            this.pepGroupBox7.Name = "pepGroupBox7";
            this.pepGroupBox7.Size = new System.Drawing.Size(394, 216);
            this.pepGroupBox7.TabIndex = 2;
            this.pepGroupBox7.TabStop = false;
            this.pepGroupBox7.Text = "Order supplier 2";
            // 
            // pepGroupBox6
            // 
            this.pepGroupBox6.Controls.Add(this.pepTreeView2);
            this.pepGroupBox6.Location = new System.Drawing.Point(42, 15);
            this.pepGroupBox6.Name = "pepGroupBox6";
            this.pepGroupBox6.Size = new System.Drawing.Size(394, 216);
            this.pepGroupBox6.TabIndex = 1;
            this.pepGroupBox6.TabStop = false;
            this.pepGroupBox6.Text = "Order supplier 1";
            // 
            // pepGroupBox1
            // 
            this.pepGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pepGroupBox1.Controls.Add(this.label1);
            this.pepGroupBox1.Location = new System.Drawing.Point(408, -11);
            this.pepGroupBox1.Name = "pepGroupBox1";
            this.pepGroupBox1.Size = new System.Drawing.Size(428, 54);
            this.pepGroupBox1.TabIndex = 9;
            this.pepGroupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(96, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Order for suppliers";
            // 
            // pepTreeView2
            // 
            this.pepTreeView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pepTreeView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pepTreeView2.Caption = false;
            this.pepTreeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pepTreeView2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pepTreeView2.ItemHeight = 50;
            this.pepTreeView2.Location = new System.Drawing.Point(3, 22);
            this.pepTreeView2.Name = "pepTreeView2";
            this.pepTreeView2.Online = false;
            this.pepTreeView2.Size = new System.Drawing.Size(388, 191);
            this.pepTreeView2.TabIndex = 1;
            // 
            // pepTreeView3
            // 
            this.pepTreeView3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pepTreeView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pepTreeView3.Caption = false;
            this.pepTreeView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pepTreeView3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pepTreeView3.ItemHeight = 50;
            this.pepTreeView3.Location = new System.Drawing.Point(3, 22);
            this.pepTreeView3.Name = "pepTreeView3";
            this.pepTreeView3.Online = false;
            this.pepTreeView3.Size = new System.Drawing.Size(388, 191);
            this.pepTreeView3.TabIndex = 1;
            // 
            // OrderSuppliers
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pepGroupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OrderSuppliers";
            this.Size = new System.Drawing.Size(1282, 632);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pepGroupBox7.ResumeLayout(false);
            this.pepGroupBox6.ResumeLayout(false);
            this.pepGroupBox1.ResumeLayout(false);
            this.pepGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private KitboxEcamGUI.PepTreeView pepTreeView1;
        private KitboxEcamGUI.PepButton pepButton1;
        private KitboxEcamGUI.PepGroupBox pepGroupBox1;
        private System.Windows.Forms.Label label1;
        private KitboxEcamGUI.PepButton pepButton4;
        private KitboxEcamGUI.PepGroupBox pepGroupBox7;
        private KitboxEcamGUI.PepGroupBox pepGroupBox6;
        private KitboxEcamGUI.PepTreeView pepTreeView3;
        private KitboxEcamGUI.PepTreeView pepTreeView2;
    }
}
