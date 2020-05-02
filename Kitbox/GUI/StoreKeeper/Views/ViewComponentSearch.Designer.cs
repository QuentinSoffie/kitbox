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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RichTextBox_console = new KitboxEcamGUI.PepRichTextBox();
            this.pepGroupBox1 = new KitboxEcamGUI.PepGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pepGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pepGroupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 561);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Location = new System.Drawing.Point(23, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(914, 481);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.RichTextBox_console);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.splitContainer1.Size = new System.Drawing.Size(914, 481);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.SplitterWidth = 11;
            this.splitContainer1.TabIndex = 0;
            // 
            // RichTextBox_console
            // 
            this.RichTextBox_console.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBox_console.AutoWordSelection = false;
            this.RichTextBox_console.BackColor = System.Drawing.Color.Transparent;
            this.RichTextBox_console.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.RichTextBox_console.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.RichTextBox_console.Location = new System.Drawing.Point(0, 0);
            this.RichTextBox_console.Margin = new System.Windows.Forms.Padding(2);
            this.RichTextBox_console.Name = "RichTextBox_console";
            this.RichTextBox_console.ReadOnly = false;
            this.RichTextBox_console.Size = new System.Drawing.Size(302, 481);
            this.RichTextBox_console.TabIndex = 4;
            this.RichTextBox_console.WordWrap = true;
            // 
            // pepGroupBox1
            // 
            this.pepGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pepGroupBox1.Controls.Add(this.label1);
            this.pepGroupBox1.Location = new System.Drawing.Point(85, -7);
            this.pepGroupBox1.Name = "pepGroupBox1";
            this.pepGroupBox1.Size = new System.Drawing.Size(790, 71);
            this.pepGroupBox1.TabIndex = 0;
            this.pepGroupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(182, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Order :";
            // 
            // ViewComponentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel1);
            this.Name = "ViewComponentSearch";
            this.Size = new System.Drawing.Size(961, 561);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pepGroupBox1.ResumeLayout(false);
            this.pepGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private KitboxEcamGUI.PepGroupBox pepGroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private KitboxEcamGUI.PepRichTextBox RichTextBox_console;
    }
}
