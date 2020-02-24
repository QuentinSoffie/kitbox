using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Kitbox.Components;

namespace Kitbox.GUI2
{
    public partial class Customer : Form
    {

       
        public Customer()
        {
            InitializeComponent();
            ourOrder = new Kitbox.Order.Order();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        private int uidTreeview = 0;
        private Kitbox.Order.Order ourOrder;
        private void button1_Click(object sender, EventArgs e)
        {
            uidTreeview += 1;
            AddCupboard(uidTreeview, uidTreeview);
            Kitbox.GUI2.ViewCupboard mypanel = new Kitbox.GUI2.ViewCupboard();
       
            splitContainer1.Panel2.Controls.Add(mypanel);
            mypanel.BringToFront();
            mypanel.Dock = DockStyle.Fill;

        }

        public void AddCupboard(int uid ,int index, string tag = "Contains 0 box")
        {
            pepTreeView1.Nodes.Add(uid.ToString(), "Cupboard - Uid " + uid);
            pepTreeView1.Nodes[index -1].Tag = tag;
            pepTreeView1.Nodes[index -1].ImageIndex = 1;

            ourOrder.Add(uid);

            
        }

        public void RemoveCupboard(int uid)
        {
            Console.WriteLine("ypooo");
            
        }
        private void AddBox(int uid, int indexCupboard, int index, string tag = "Order in progress")
        {
            pepTreeView1.Nodes[indexCupboard -1].Nodes.Add(uid.ToString(), "Box - N" + index);
            pepTreeView1.Nodes[indexCupboard -1].Nodes[index -1].Tag = tag ;
            pepTreeView1.Nodes[indexCupboard -1].Nodes[index -1].ImageIndex = 0;
        }

        private void RemoveBox(int uid)
        {
            

        }

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int uidClicked = int.Parse(e.Node.Name);
        }
    }
}
