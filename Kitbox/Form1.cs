using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DBMethods;
using MySql.Data.MySqlClient;

namespace Kitbox
{
    public partial class Form1 : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void personnaliserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pepButton1_Click(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = "Getting informations ...";

            string firstname = pepTextbox2.Text;
            string surname = pepTextbox3.Text;
            string adress = pepTextbox4.Text.Replace("'", " ");
            string email = pepTextbox5.Text;
            string phonenumber = pepTextbox6.Text;

            if (firstname == "" || surname == "" || adress == "" || email == "")
            {
                MessageBox.Show("Field(s) missing !", "Error ! ");
    
            }
            else
            {

                Console.WriteLine("Getting Connection ...");
                toolStripStatusLabel1.Text = "Getting Connection ...";

                MySqlConnection conn = DBMethods.DBUtils.GetDBConnection();

                try
                {
                    Console.WriteLine("Openning Connection ...");
                    toolStripStatusLabel1.Text = "Openning Connection ...";

                    conn.Open();
                    Console.WriteLine("Connection successful!");
                    toolStripStatusLabel1.Text = "Connection successful!";
                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;

                    DBMethods.DataBaseMethods.SqlAddCustomer(firstname, surname, adress, email, phonenumber, conn);

                    toolStripStatusLabel1.Text = "Customer added!";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Green;

                    

                    

                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                    toolStripStatusLabel1.Text = "Error: see cmd !";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel.Add(panel3);

            listPanel[0].BringToFront();
        }

        private void createNewCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listPanel[1].BringToFront();
        }

        private void createNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listPanel[0].BringToFront();
        }

        private void pepButton2_Click(object sender, EventArgs e)
        {
            int nbrBox =  treeView1.GetNodeCount(false);

            if (nbrBox <= 7)
            {

                string panelColor = pepCombobox1.Text;
                string doorColor = pepCombobox2.Text;
                string height = pepCombobox3.Text;
                string depth = pepCombobox4.Text;
                string width = pepCombobox5.Text;

                TreeNode newTreeNode = new TreeNode(String.Format("Box {0}", nbrBox+1));

                TreeNode panelColorNode = new TreeNode(String.Format("Panel color : {0}", panelColor));
                TreeNode doorColorNode = new TreeNode(String.Format("Door color : {0}", doorColor));
                TreeNode heightNode = new TreeNode(String.Format("Height : {0}", height));
                TreeNode depthNode = new TreeNode(String.Format("Deep : {0}", depth));
                TreeNode widthNode = new TreeNode(String.Format("Width : {0}", width));

                newTreeNode.Nodes.Add(panelColorNode);
                newTreeNode.Nodes.Add(doorColorNode);
                newTreeNode.Nodes.Add(heightNode);
                newTreeNode.Nodes.Add(depthNode);
                newTreeNode.Nodes.Add(widthNode);

                treeView1.Nodes.Add(newTreeNode);

                toolStripStatusLabel1.Text = String.Format("Box {0} added!", nbrBox +1);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                MessageBox.Show("Sorry, 7 boxes allowed!", "Too much boxes");
            }

            var variable = new Form1();
            variable.Show();
        }

        private void pepButton3_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }

        private void pepButton5_Click(object sender, EventArgs e)
        {
            try
            {
                
                TreeNode selected = treeView1.SelectedNode;

                if (treeView1.SelectedNode == selected.Nodes[0])
                {
                    Console.WriteLine("Error: can't delete property");
                    toolStripStatusLabel1.Text = "Error: can't delete property";
                    toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    treeView1.SelectedNode.Remove();

                    int nbrBox = treeView1.GetNodeCount(false);

                    int i = 0;

                    while(i < nbrBox)
                    {
                        treeView1.Nodes[i].Text = String.Format("Box {0}", i+1);
                        i++;
                    }
                    
                }
                
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
                toolStripStatusLabel1.Text = "Error: see cmd !";
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;

            }
            
        }

        private void pepButton4_Click(object sender, EventArgs e)
        {
            if (treeView1.GetNodeCount(true) == 0)
            {
                MessageBox.Show("Please create a box !", "There is no box");
            }
            else
            {
                listPanel[2].BringToFront();
            }
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pepCombobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Getting Connection ...");
                toolStripStatusLabel1.Text = "Getting Connection ...";

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                DBMethods.DataBaseMethods.SqlChoose("Ref", "Piece", "'Panneau HB'", conn);
            }

            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
                toolStripStatusLabel1.Text = "Error: see cmd !";
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }



        }
    }
}
