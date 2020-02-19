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

using Kitbox.Classes;

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


                try
                {
                    Console.WriteLine("Openning Connection ...");
                    toolStripStatusLabel1.Text = "Openning Connection ...";

                    Console.WriteLine("Connection successful!");
                    toolStripStatusLabel1.Text = "Connection successful!";
                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;

                    DBMethods.DataBaseMethods.SqlAddCustomer(firstname, surname, adress, email, phonenumber);

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

            try
            {
                SetComboboxValues("Piece", "Ref", "Panneau HB", "Couleur", pepCombobox1);
                SetComboboxValues("Piece", "Ref", "Porte", "Couleur", pepCombobox2);  

                SetComboboxValues("Piece", "Ref", "Panneau GD", "hauteur", pepCombobox3);
                SetComboboxValues("Piece", "Ref", "Panneau GD", "profondeur", pepCombobox4);
                SetComboboxValues("Piece", "Ref", "Panneau Ar", "largeur", pepCombobox5);

            }

            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
                toolStripStatusLabel1.Text = "Error: see cmd !";
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void createNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listPanel[0].BringToFront();
        }

        private void pepButton2_Click(object sender, EventArgs e)
        {
            int nbrBox =  treeView1.GetNodeCount(false);

            if (nbrBox < 7)
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

                SetComboboxValues("Piece", "Ref", "Cornieres", "Couleur", pepCombobox6);

                foreach(TreeNode boxe in treeView1.Nodes)
                {
                    Console.WriteLine(boxe.Text);
                    foreach (TreeNode node in boxe.Nodes)
                    {
                        Console.WriteLine(node.Text);
                        
                    }
                    
                }
                


                int nbrTree = treeView1.GetNodeCount(false);

                
                for (int i = 1; i < nbrTree + 1; i++)
                {

                    dataGridView1.Columns.Add("Box" + i, "Box " + i);
                    dataGridView1.Rows[0].HeaderCell.Value = "test";
                }

                dataGridView1.Rows.Add(treeView1.Nodes[0].Nodes[0].Text);
                

            }
            
        }

        public void SetComboboxValues(string table, string param, string value, string cond, ComboBox pepCombobox)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            Console.WriteLine("Getting Connection ...");
            toolStripStatusLabel1.Text = "Getting Connection ...";

            var reader = DBMethods.DataBaseMethods.SqlSearch(table, param, "'" + value + "'", conn);

            while (reader.Read())
            {
                if (pepCombobox.Items.Contains(reader.GetString(cond)) == false)
                {
                    pepCombobox.Items.Add(reader.GetString(cond));
                }
            }
            reader.Close();
            conn.Close();
        }
    }
}

