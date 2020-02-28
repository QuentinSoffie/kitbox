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

namespace Kitbox.GUI
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
        private static Kitbox.Order.Order ourOrder;
        private void button1_Click(object sender, EventArgs e)
        {
            uidTreeview += 1;
            

            Kitbox.GUI.ViewCupboard mypanel = new Kitbox.GUI.ViewCupboard(pepTreeView1, ourOrder.GetCupboard(uidTreeview), uidTreeview);
            AddCupboard(uidTreeview, uidTreeview, mypanel);
            splitContainer1.Panel2.Controls.Add(mypanel);
            mypanel.BringToFront();
            mypanel.Dock = DockStyle.Fill;

        }

        public void AddCupboard(int uid, int index, ViewCupboard view, string tag = "Contains 0 box")
        {
            pepTreeView1.Nodes.Add(uid.ToString(), "Cupboard - Uid " + uid);
            pepTreeView1.Nodes[index -1].Tag = tag;
            pepTreeView1.Nodes[index -1].ImageIndex = 1;

            ourOrder.Add(uid, view);
            
        }

        public static void RemoveCupboard(int uid)
        {
            Console.WriteLine("ypooo");
            ourOrder.Remove(uid);

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
            int uidClicked = int.Parse(e.Node.Name) - 1;
            Cupboard selectedCupboard = ourOrder.GetCupboard(uidClicked);
            Console.WriteLine("select " + uidClicked);
            selectedCupboard.BringFront();

            //update by gui

        }
        
    }
}
