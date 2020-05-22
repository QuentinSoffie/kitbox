﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitbox.GUI.StoreKeeper.Views;
using GUI;
using MySql.Data.MySqlClient;
using System.Net.Sockets;

namespace Kitbox.GUI.Views
{
    public partial class CreateCustomer : UserControl
    {
        Customer Parent;

        MySqlConnection DataBase;

        List<Dictionary<String, object>> Customers;

        public CreateCustomer(MySqlConnection dataBase, Customer parent)
        {
            InitializeComponent();
            Parent = parent;
            DataBase = dataBase;

        }

        private void pepButton3_Click(object sender, EventArgs e)
        {

            SearchCustomer();
        }

        public void SearchCustomer()
        {
            Customers = DBMethods.DataBaseMethods.SqlSearchCustomerByName(pepTextbox6.Text, DataBase);
            int i = 0;
            foreach(Dictionary<String, object> customer in Customers)
            {
                pepTreeView1.Nodes.Add($"{customer["surname"].ToString().ToUpper()} - {customer["firstname"].ToString()}");
                pepTreeView1.Nodes[i].Tag = customer["id"].ToString();
                i++;
            }
        }

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            label4.Text = Customers[pepTreeView1.SelectedNode.Index]["surname"].ToString().ToUpper();
            label5.Text = Customers[pepTreeView1.SelectedNode.Index]["firstname"].ToString();
            label28.Text = Customers[pepTreeView1.SelectedNode.Index]["id"].ToString();
        }

        private void pepButton2_Click(object sender, EventArgs e)
        {
            //TODO: finish command
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            string surname = pepTextbox1.Text;
            string firsname = pepTextbox2.Text;
            string phone = pepTextbox3.Text;
            string email = pepTextbox4.Text;
            string address = pepTextbox5.Text;

            if (surname != "" && firsname != "" && phone != "" && email != "" && address != "")
            {
                DBMethods.DataBaseMethods.SqlAddCustomer(surname, firsname, phone, email, address, DataBase);
                //TODO: finish command
            }
            else
            {
                MessageBox.Show("Please complete all the fields.", "Error");
            }
        }
    }
}
