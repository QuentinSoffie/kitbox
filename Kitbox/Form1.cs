using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Kitbox.DB;


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

                MySqlConnection conn = DBUtils.GetDBConnection();

                try
                {
                    Console.WriteLine("Openning Connection ...");
                    toolStripStatusLabel1.Text = "Openning Connection ...";

                    conn.Open();
                    Console.WriteLine("Connection successful!");
                    toolStripStatusLabel1.Text = "Connection successful!";
                    toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;

                    DBMethods.SqlAddCustomer(firstname, surname, adress, email, phonenumber, conn);

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

            listPanel[index].BringToFront();
        }

        private void createNewCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listPanel[1].BringToFront();
        }

        private void createNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listPanel[0].BringToFront();
        }
    }
}
