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
            this.SuspendLayout();
            // 
            // pepButton1
            // 
            this.pepButton1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.pepButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pepButton1.Location = new System.Drawing.Point(395, 123);
            this.pepButton1.Name = "pepButton1";
            this.pepButton1.Size = new System.Drawing.Size(334, 104);
            this.pepButton1.TabIndex = 0;
            this.pepButton1.Text = "pepButton1";
            this.pepButton1.UseVisualStyleBackColor = true;
            // 
            // ViewComponentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pepButton1);
            this.Name = "ViewComponentSearch";
            this.Size = new System.Drawing.Size(1086, 549);
            this.ResumeLayout(false);

        }

        #endregion

        private KitboxEcamGUI.PepButton pepButton1;
    }
}
