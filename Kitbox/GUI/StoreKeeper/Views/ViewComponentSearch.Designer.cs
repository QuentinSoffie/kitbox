﻿namespace Kitbox.GUI.StoreKeeper.Views
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
            this.pepGroupBox1 = new KitboxEcamGUI.PepGroupBox();
            this.pepNumericUpDown1 = new KitboxEcamGUI.PepNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pepButton4 = new KitboxEcamGUI.PepButton();
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
            this.pepButton1.Location = new System.Drawing.Point(386, 161);
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
            this.pepButton2.Location = new System.Drawing.Point(386, 202);
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
            this.pepButton3.Location = new System.Drawing.Point(386, 274);
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
            this.panel1.Controls.Add(this.pepGroupBox1);
            this.panel1.Controls.Add(this.pepNumericUpDown1);
            this.panel1.Controls.Add(this.pepButton1);
            this.panel1.Controls.Add(this.pepButton3);
            this.panel1.Controls.Add(this.pepButton2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 418);
            this.panel1.TabIndex = 3;
            // 
            // pepGroupBox1
            // 
            this.pepGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepGroupBox1.Controls.Add(this.pepButton4);
            this.pepGroupBox1.Controls.Add(this.label2);
            this.pepGroupBox1.Controls.Add(this.label1);
            this.pepGroupBox1.Location = new System.Drawing.Point(124, 65);
            this.pepGroupBox1.Name = "pepGroupBox1";
            this.pepGroupBox1.Size = new System.Drawing.Size(249, 272);
            this.pepGroupBox1.TabIndex = 4;
            this.pepGroupBox1.TabStop = false;
            // 
            // pepNumericUpDown1
            // 
            this.pepNumericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pepNumericUpDown1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pepNumericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepNumericUpDown1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pepNumericUpDown1.Location = new System.Drawing.Point(386, 84);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(9, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Next value: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // pepButton4
            // 
            this.pepButton4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.pepButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton4.Location = new System.Drawing.Point(0, 222);
            this.pepButton4.Name = "pepButton4";
            this.pepButton4.Size = new System.Drawing.Size(249, 37);
            this.pepButton4.TabIndex = 2;
            this.pepButton4.Text = "Validate";
            this.pepButton4.UseVisualStyleBackColor = true;
            this.pepButton4.Visible = false;
            // 
            // ViewComponentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.panel1);
            this.Name = "ViewComponentSearch";
            this.Size = new System.Drawing.Size(673, 418);
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
    }
}
