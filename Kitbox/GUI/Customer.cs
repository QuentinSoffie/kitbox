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
            Console.WriteLine(UidTreeview);
            AddCupboard(UidTreeview, UidTreeview);

            AddBox(UidTreeview, 1, 1);


        }

        private void AddCupboard(int Uid, int index)//, string Tag)
        {
            
            Cupboard newCupboard = new Cupboard();

            cupboardList.Add(newCupboard);
            
            pepTreeView1.Nodes.Add(Uid.ToString(), "Cupboard - N" + index);
            //pepTreeView1.Nodes[index -1].Tag = Tag;
            pepTreeView1.Nodes[index -1].ImageIndex = 1;
            toolStripStatusLabel1.Text = "Cupboard added!";

        }
        private void AddBox(int Uid, int indexCupboard, int index)//, string Tag)
        {
            pepTreeView1.Nodes[indexCupboard -1].Nodes.Add(Uid.ToString(), "Box - N" + index);
            pepTreeView1.Nodes[indexCupboard -1].Nodes[index -1].Tag = "Order in progress";
            pepTreeView1.Nodes[indexCupboard -1].Nodes[index -1].ImageIndex = 0;
            toolStripStatusLabel1.Text = "Box added!";
        }



        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int uidClicked = int.Parse(e.Node.Name);
            toolStripStatusLabel1.Text = "Box selected";
        }
    }
}
