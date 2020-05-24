using System;
using System.Windows.Forms;

namespace Kitbox.Customer
{
    /// <summary>
    /// This is the about window. It displays the company's informations.
    /// </summary>
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ecam.be/");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://creativecommons.org/licenses/by-nc-nd/2.0/");
        }
    }
}
