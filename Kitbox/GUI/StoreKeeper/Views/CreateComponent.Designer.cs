namespace Kitbox.GUI.StoreKeeper.Views
{
    partial class CreateComponent
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
            this.pepGroupBox1 = new KitboxEcamGUI.PepGroupBox();
            this.pepCombobox1 = new KitboxEcamGUI.PepCombobox();
            this.pepGroupBox2 = new KitboxEcamGUI.PepGroupBox();
            this.pepGroupBox3 = new KitboxEcamGUI.PepGroupBox();
            this.pepGroupBox4 = new KitboxEcamGUI.PepGroupBox();
            this.pepGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pepButton1
            // 
            this.pepButton1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.pepButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton1.Location = new System.Drawing.Point(1127, 583);
            this.pepButton1.Name = "pepButton1";
            this.pepButton1.Size = new System.Drawing.Size(110, 37);
            this.pepButton1.TabIndex = 0;
            this.pepButton1.Text = "pepButton1";
            this.pepButton1.UseVisualStyleBackColor = true;
            // 
            // pepGroupBox1
            // 
            this.pepGroupBox1.Controls.Add(this.pepCombobox1);
            this.pepGroupBox1.Location = new System.Drawing.Point(105, 37);
            this.pepGroupBox1.Name = "pepGroupBox1";
            this.pepGroupBox1.Size = new System.Drawing.Size(200, 182);
            this.pepGroupBox1.TabIndex = 1;
            this.pepGroupBox1.TabStop = false;
            this.pepGroupBox1.Text = "Ref/code";
            // 
            // pepCombobox1
            // 
            this.pepCombobox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pepCombobox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pepCombobox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pepCombobox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.pepCombobox1.FormattingEnabled = true;
            this.pepCombobox1.ItemHeight = 20;
            this.pepCombobox1.Location = new System.Drawing.Point(35, 48);
            this.pepCombobox1.Name = "pepCombobox1";
            this.pepCombobox1.Size = new System.Drawing.Size(121, 26);
            this.pepCombobox1.TabIndex = 2;
            // 
            // pepGroupBox2
            // 
            this.pepGroupBox2.Location = new System.Drawing.Point(311, 37);
            this.pepGroupBox2.Name = "pepGroupBox2";
            this.pepGroupBox2.Size = new System.Drawing.Size(200, 100);
            this.pepGroupBox2.TabIndex = 3;
            this.pepGroupBox2.TabStop = false;
            this.pepGroupBox2.Text = "Caract";
            // 
            // pepGroupBox3
            // 
            this.pepGroupBox3.Location = new System.Drawing.Point(579, 175);
            this.pepGroupBox3.Name = "pepGroupBox3";
            this.pepGroupBox3.Size = new System.Drawing.Size(319, 283);
            this.pepGroupBox3.TabIndex = 4;
            this.pepGroupBox3.TabStop = false;
            this.pepGroupBox3.Text = "Stock/prix";
            // 
            // pepGroupBox4
            // 
            this.pepGroupBox4.Location = new System.Drawing.Point(959, 208);
            this.pepGroupBox4.Name = "pepGroupBox4";
            this.pepGroupBox4.Size = new System.Drawing.Size(278, 266);
            this.pepGroupBox4.TabIndex = 4;
            this.pepGroupBox4.TabStop = false;
            this.pepGroupBox4.Text = "Info fournisseur";
            // 
            // CreateComponent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(6)))));
            this.Controls.Add(this.pepGroupBox4);
            this.Controls.Add(this.pepGroupBox3);
            this.Controls.Add(this.pepGroupBox2);
            this.Controls.Add(this.pepGroupBox1);
            this.Controls.Add(this.pepButton1);
            this.Name = "CreateComponent";
            this.Size = new System.Drawing.Size(1284, 637);
            this.pepGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KitboxEcamGUI.PepButton pepButton1;
        private KitboxEcamGUI.PepGroupBox pepGroupBox1;
        private KitboxEcamGUI.PepCombobox pepCombobox1;
        private KitboxEcamGUI.PepGroupBox pepGroupBox2;
        private KitboxEcamGUI.PepGroupBox pepGroupBox3;
        private KitboxEcamGUI.PepGroupBox pepGroupBox4;
    }
}
