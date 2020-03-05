using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitbox.GUI
{
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
