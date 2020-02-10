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
        public Form1()
        {
            InitializeComponent();
        }

        private void personnaliserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pepButton1_Click(object sender, EventArgs e)
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



            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
                toolStripStatusLabel1.Text = "Error: " + exception.Message;
            }
        }

    }
}
