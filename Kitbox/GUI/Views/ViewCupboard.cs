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
        private TreeView pep;
        private Cupboard cupboard;

        public ViewCupboard(TreeView pep, Cupboard cupboard, int uid)
        {
            InitializeComponent();
            this.Uid = uid;
            this.pep = pep;
            this.cupboard = cupboard;

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
            pep.Nodes.RemoveAt(Uid);

        }
    }
}
