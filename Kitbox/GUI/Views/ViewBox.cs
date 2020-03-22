using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Kitbox.Order;

namespace Kitbox.GUI
{
    public partial class ViewBox : UserControl
    {
        public int Uid { get; set; }
        public Box Box;
        public TreeviewManager MainTreeView;

        public ViewBox(int uid, Box box, TreeviewManager treeView)
        {
            InitializeComponent();
            this.Uid = uid;
            this.Box = box;
            this.MainTreeView = treeView;
            LoadGUI();
        }
        private void LoadGUI()
        {
            LoadCombobox();
            LoadChat();
            label13.Text = "Box - " + Uid;
            label2.Text = Uid.ToString();
        }

        private void LoadCombobox()
        {

        }
        private void LoadChat()
        {

        }

        private void ViewCupboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {


        }
    }
}
