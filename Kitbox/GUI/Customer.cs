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

            AddCupboard(UidTreeview, UidTreeview);
            

        }

        private void AddCupboard(int uid ,int index, string Tag = "default")
        {
            pepTreeView1.Nodes.Add(uid.ToString(), "Cupboard - N" + index);
            pepTreeView1.Nodes[index -1].Tag = Tag;
            pepTreeView1.Nodes[index -1].ImageIndex = 1;

            Cupboard newCupboard = new Cupboard(uid);
            cupboardList.Add(newCupboard);

            toolStripStatusLabel1.Text = string.Format("Cupboard - N{0} added!", uid);
            toolStripStatusLabel1.ForeColor = System.Drawing.Color.Green;
        }

        private void RemoveCupboard(int uid)
        {
    

        }
        private void AddBox(int uid, int indexCupboard, int index, string tag = "Order in progress")
        {
            pepTreeView1.Nodes[indexCupboard -1].Nodes.Add(uid.ToString(), "Box - N" + index);
            pepTreeView1.Nodes[indexCupboard -1].Nodes[index -1].Tag = tag ;
            pepTreeView1.Nodes[indexCupboard -1].Nodes[index -1].ImageIndex = 0;
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
