using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Kitbox.Classes;

namespace GUI
{
    public partial class Customer : Form
    {

        private List<Cupboard> cupboardList = new List<Cupboard>(); 
        public Customer()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        private int UidTreeview = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            UidTreeview += 1;


            AddCupboard(UidTreeview);
            

        }

        private void AddCupboard(int Uid)//,int Index, string Tag)
        {
            pepTreeView1.Nodes.Add(Uid.ToString(), "Cupboard - N" + Uid);
            //pepTreeView1.Nodes[Uid -1].Tag = Tag;
            pepTreeView1.Nodes[Uid -1].ImageIndex = 1;

            Cupboard newCupboard = new Cupboard(Uid);
            cupboardList.Add(newCupboard);

            toolStripStatusLabel1.Text = string.Format("Cupboard - N{0} added!", Uid);
            toolStripStatusLabel1.ForeColor = System.Drawing.Color.Green;
        }

        private void RemoveCupboard(int Uid)
        {
            TreeNode selectedNode = pepTreeView1.SelectedNode;
            selectedNode.Remove();

            //cupboardList.RemoveAt(1);

        }
        private void AddBox(int Uid, int IndexCupboard)//,int Index), string Tag)
        {
            pepTreeView1.Nodes[IndexCupboard -1].Nodes.Add(Uid.ToString(), "Box - N" + Uid);
            pepTreeView1.Nodes[IndexCupboard -1].Nodes[Uid -1].Tag = "Order in progress";
            pepTreeView1.Nodes[IndexCupboard -1].Nodes[Uid -1].ImageIndex = 0;
        }

        private void RemoveBox(int Uid)
        {

        }

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int uidClicked = int.Parse(e.Node.Name);
        }
    }
}
