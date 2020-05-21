namespace Kitbox.GUI.StoreKeeper.Views
{
    partial class ViewComponentSearch
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
            this.pepButton1 = new KitboxEcamGUI.PepButton();
            this.pepButton2 = new KitboxEcamGUI.PepButton();
            this.pepButton3 = new KitboxEcamGUI.PepButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pepButton5 = new KitboxEcamGUI.PepButton();
            this.pepButton4 = new KitboxEcamGUI.PepButton();
            this.pepGroupBox1 = new KitboxEcamGUI.PepGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pepNumericUpDown1 = new KitboxEcamGUI.PepNumericUpDown();
            this.panel1.SuspendLayout();
            this.pepGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pepNumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pepButton1
            // 
            this.pepButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepButton1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.pepButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton1.Location = new System.Drawing.Point(590, 271);
            this.pepButton1.Name = "pepButton1";
            this.pepButton1.Size = new System.Drawing.Size(155, 35);
            this.pepButton1.TabIndex = 0;
            this.pepButton1.Text = "Increase";
            this.pepButton1.UseVisualStyleBackColor = true;
            this.pepButton1.Click += new System.EventHandler(this.pepButton1_Click);
            // 
            // pepButton2
            // 
            this.pepButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepButton2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.pepButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton2.Location = new System.Drawing.Point(590, 312);
            this.pepButton2.Name = "pepButton2";
            this.pepButton2.Size = new System.Drawing.Size(155, 35);
            this.pepButton2.TabIndex = 1;
            this.pepButton2.Text = "Decrease";
            this.pepButton2.UseVisualStyleBackColor = true;
            this.pepButton2.Click += new System.EventHandler(this.pepButton2_Click);
            // 
            // pepButton3
            // 
            this.pepButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepButton3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.pepButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton3.Location = new System.Drawing.Point(590, 374);
            this.pepButton3.Name = "pepButton3";
            this.pepButton3.Size = new System.Drawing.Size(155, 63);
            this.pepButton3.TabIndex = 2;
            this.pepButton3.Text = "Delete component";
            this.pepButton3.UseVisualStyleBackColor = true;
            this.pepButton3.Click += new System.EventHandler(this.pepButton3_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.pepButton5);
            this.panel1.Controls.Add(this.pepButton4);
            this.panel1.Controls.Add(this.pepGroupBox1);
            this.panel1.Controls.Add(this.pepNumericUpDown1);
            this.panel1.Controls.Add(this.pepButton1);
            this.panel1.Controls.Add(this.pepButton3);
            this.panel1.Controls.Add(this.pepButton2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 637);
            this.panel1.TabIndex = 3;
            // 
            // pepButton5
            // 
            this.pepButton5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepButton5.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pepButton5.ForeColor = System.Drawing.Color.Khaki;
            this.pepButton5.Location = new System.Drawing.Point(218, 187);
            this.pepButton5.Name = "pepButton5";
            this.pepButton5.Size = new System.Drawing.Size(349, 249);
            this.pepButton5.TabIndex = 5;
            this.pepButton5.Text = "Confirm";
            this.pepButton5.UseVisualStyleBackColor = true;
            this.pepButton5.Visible = false;
            this.pepButton5.Click += new System.EventHandler(this.pepButton5_Click);
            // 
            // pepButton4
            // 
            this.pepButton4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepButton4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.pepButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton4.Location = new System.Drawing.Point(218, 399);
            this.pepButton4.Name = "pepButton4";
            this.pepButton4.Size = new System.Drawing.Size(349, 37);
            this.pepButton4.TabIndex = 2;
            this.pepButton4.Text = "Validate";
            this.pepButton4.UseVisualStyleBackColor = true;
            this.pepButton4.Visible = false;
            this.pepButton4.Click += new System.EventHandler(this.pepButton4_Click);
            // 
            // pepGroupBox1
            // 
            this.pepGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepGroupBox1.Controls.Add(this.label2);
            this.pepGroupBox1.Controls.Add(this.label1);
            this.pepGroupBox1.Location = new System.Drawing.Point(218, 168);
            this.pepGroupBox1.MaximumSize = new System.Drawing.Size(437, 211);
            this.pepGroupBox1.Name = "pepGroupBox1";
            this.pepGroupBox1.Size = new System.Drawing.Size(349, 211);
            this.pepGroupBox1.TabIndex = 4;
            this.pepGroupBox1.TabStop = false;
            this.pepGroupBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 55);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Khaki;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(78, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Next value:";
            // 
            // pepNumericUpDown1
            // 
            this.pepNumericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepNumericUpDown1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pepNumericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepNumericUpDown1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pepNumericUpDown1.Location = new System.Drawing.Point(590, 188);
            this.pepNumericUpDown1.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.pepNumericUpDown1.Name = "pepNumericUpDown1";
            this.pepNumericUpDown1.Size = new System.Drawing.Size(155, 71);
            this.pepNumericUpDown1.TabIndex = 3;
            this.pepNumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ViewComponentSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.panel1);
            this.Name = "ViewComponentSearch";
            this.Size = new System.Drawing.Size(972, 637);
            this.panel1.ResumeLayout(false);
            this.pepGroupBox1.ResumeLayout(false);
            this.pepGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pepNumericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KitboxEcamGUI.PepButton pepButton1;
        private KitboxEcamGUI.PepButton pepButton2;
        private KitboxEcamGUI.PepButton pepButton3;
        private System.Windows.Forms.Panel panel1;
        private KitboxEcamGUI.PepNumericUpDown pepNumericUpDown1;
        private KitboxEcamGUI.PepGroupBox pepGroupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private KitboxEcamGUI.PepButton pepButton4;
        private KitboxEcamGUI.PepButton pepButton5;
    }
}
