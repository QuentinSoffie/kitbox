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
using Kitbox.Components;
using Kitbox;

namespace Kitbox.GUI
{
    public partial class ViewCupboard : UserControl
    {
        public int Uid { get; set; }
        private TreeView tree;
        private Cupboard cupboard;

        public ViewCupboard(TreeView tree, Cupboard cupboard, int uid)
        {
            InitializeComponent();
            this.Uid = uid;
            this.tree = tree;
            this.cupboard = cupboard;
            label4.Text = (uid-1).ToString();

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

        public void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("testr");
            RemoveCupboard();

        }
        public void RemoveCupboard()
        {
            Console.WriteLine("suppr");
            tree.Nodes.RemoveAt(Uid-1);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
