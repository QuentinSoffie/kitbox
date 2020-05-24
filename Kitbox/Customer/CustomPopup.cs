using System;
using System.Windows.Forms;

namespace Kitbox.Customer
{
    /// <summary>
    /// This is a custom popup used to show messages.
    /// </summary>
    public partial class CustomPopup : Form
    {
        public CustomPopup(string message)
        {
            InitializeComponent();
            label1.Text = message;
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
