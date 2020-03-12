﻿namespace GUI
{
    partial class Authentication
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authentication));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pepTextbox1 = new KitboxEcamGUI.PepTextbox();
            this.pepTextbox2 = new KitboxEcamGUI.PepTextbox();
            this.pepButton1 = new KitboxEcamGUI.PepButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(95, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 79);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(188, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kitbox - ECAM";
            // 
            // pepTextbox1
            // 
            this.pepTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pepTextbox1.EnabledCalc = true;
            this.pepTextbox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pepTextbox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepTextbox1.Location = new System.Drawing.Point(75, 167);
            this.pepTextbox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pepTextbox1.MaxLength = 32767;
            this.pepTextbox1.MultiLine = false;
            this.pepTextbox1.Name = "pepTextbox1";
            this.pepTextbox1.ReadOnly = false;
            this.pepTextbox1.Size = new System.Drawing.Size(420, 27);
            this.pepTextbox1.TabIndex = 2;
            this.pepTextbox1.Tag = "Username";
            this.pepTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pepTextbox1.UseSystemPasswordChar = false;
            this.pepTextbox1.TextChanged += new System.EventHandler(this.pepTextbox1_TextChanged);
            // 
            // pepTextbox2
            // 
            this.pepTextbox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pepTextbox2.EnabledCalc = true;
            this.pepTextbox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pepTextbox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepTextbox2.Location = new System.Drawing.Point(75, 218);
            this.pepTextbox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pepTextbox2.MaxLength = 32767;
            this.pepTextbox2.MultiLine = false;
            this.pepTextbox2.Name = "pepTextbox2";
            this.pepTextbox2.ReadOnly = false;
            this.pepTextbox2.Size = new System.Drawing.Size(420, 27);
            this.pepTextbox2.TabIndex = 3;
            this.pepTextbox2.Tag = "Password";
            this.pepTextbox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.pepTextbox2.UseSystemPasswordChar = true;
            this.pepTextbox2.TextChanged += new System.EventHandler(this.pepTextbox2_TextChanged);
            this.pepTextbox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pepTextbox1_KeyUp);
            this.pepTextbox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pepTextbox1_KeyUp);
            // 
            // pepButton1
            // 
            this.pepButton1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.pepButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton1.Location = new System.Drawing.Point(75, 272);
            this.pepButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pepButton1.Name = "pepButton1";
            this.pepButton1.Size = new System.Drawing.Size(420, 38);
            this.pepButton1.TabIndex = 4;
            this.pepButton1.Text = "Connection";
            this.pepButton1.UseVisualStyleBackColor = true;
            this.pepButton1.Click += new System.EventHandler(this.pepButton1_Click);
            // 
            // Authentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(576, 336);
            this.Controls.Add(this.pepButton1);
            this.Controls.Add(this.pepTextbox2);
            this.Controls.Add(this.pepTextbox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(594, 383);
            this.MinimumSize = new System.Drawing.Size(594, 383);
            this.Name = "Authentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authentication";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private KitboxEcamGUI.PepTextbox pepTextbox1;
        private KitboxEcamGUI.PepTextbox pepTextbox2;
        private KitboxEcamGUI.PepButton pepButton1;
    }
}

