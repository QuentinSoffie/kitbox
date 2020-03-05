using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitbox.GUI;
using Kitbox.Components;
using DBMethods;
using MySql.Data.MySqlClient;

namespace GUI
{
    public partial class Customer : Form
    {

        private MySqlConnection DataBase;
        private Authentication Authentification;
        private TreeviewManager MainTreeview;
        private readonly string Username;
        private readonly string Password;
        private Kitbox.Order.Order OurOrder;
        public Customer(MySqlConnection _database, Authentication _authentification,string _username,string _password)
        {
            InitializeComponent();
            OurOrder = new Kitbox.Order.Order();
            MainTreeview = new TreeviewManager(pepTreeView1, splitContainer1.Panel2.Controls,OurOrder);
            DataBase = _database;
            Authentification = _authentification;
            Username = _username;
            Password = _password;
            Kitbox.Database.Reader.InitializeComponents(DataBase);
             toolStripStatusLabel1.Text = "Welcome " + Username;
            
        }

        private void RemoveCupboardOrder(int uid)
        {
            OurOrder.RemoveAt(uid);
        }

        private void BeforeFormClosing(object sender, FormClosingEventArgs e)
        {
            Authentification.Visible = true;
        }


        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
       
     
        private void button1_Click(object sender, EventArgs e)
        {
          
            MainTreeview.AddCupboard(OurOrder);    
        }

       

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int uidClicked = int.Parse(e.Node.Name);
            MainTreeview.BringToFrontView(uidClicked);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About obj = new About();
            obj.Show(this);
       
        }
    }
}
