using GUI;
using Kitbox.GUI.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Kitbox.Order;

namespace Kitbox.GUI
{
    public partial class StoreKeeper : Form
    {
        private MySqlConnection DataBase;
        private Authentication Authentification;
        private readonly string Username;
        private readonly string Password;
        private ViewComponentSearch ViewComponentSearch;

        public StoreKeeper(MySqlConnection database, Authentication authentification, string username, string password)
        {
            InitializeComponent();
            DataBase = database;
            Authentification = authentification;
            Username = username;
            Password = password;
            ViewComponentSearch = new ViewComponentSearch();
            Controls.Add(ViewComponentSearch);
            
            
        }

        private void pepCombobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pepCombobox1.SelectedIndex == 0)
            {
                showError("Please choose a searching method");
            }
        }

        private void showError(String message)
        {
            MessageBox.Show(message, "Error !");
        }

        /// <summary>
        /// Add Nodes in the treeview
        /// </summary>
        /// <param name="value"></param>
        public void addItems(List<String> value)
        {
            //pepTreeView1.Nodes.Add(value);
            //pepTreeView1.Nodes[0].Tag = "Send";
            foreach (String item in value)
            {
                Console.WriteLine(item);
                createOrder(item);
            }

        }

        private Order.StoreKeeperOrder createOrder(String item)
        {
            return new Order.StoreKeeperOrder(item);
        }

        public void removeItem(String text)
        {

        }


        private void getOrder()
        {
            Cursor.Current = Cursors.WaitCursor;
            DataBase.Open();

            List<String> resp = new List<string>();

            if (pepCombobox1.GetItemText(pepCombobox1.SelectedItem) == "Order number")
            {

                MySqlDataReader reader = StockDB.StockMethod.SearchOrderByNum(pepTextbox1.Text, DataBase);

                while (reader.Read())
                {
                    resp.Add(reader["ItemsCode"].ToString());

                }
            }
            else
            {
                MySqlDataReader reader = StockDB.StockMethod.SearchOrderByName(pepTextbox1.Text, DataBase);

                while (reader.Read())
                {
                    resp.Add(reader["ItemsCode"].ToString());
                }
            }

            DataBase.Close();

            if (resp.Count == 0)
            {
                showError(String.Format("Error, no value found for \"{0}\"", pepTextbox1.Text));
            }
            else
            {
                addItems(resp);
            }

            Cursor.Current = Cursors.Default;

        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(pepCombobox1.SelectedItem);
            if (pepTextbox1.Text == "")
            {
                showError("Please enter an order number or a customer name");
                return;
            }
            if (pepCombobox1.SelectedIndex == 0 || pepCombobox1.SelectedItem == null)
            {
                showError("Please choose a searching method");
                return;
            }
            else
            {
                getOrder();
            }
            
            //splitContainer1.Panel2.Controls.Add(ViewComponentSearch);
            //ViewComponentSearch.BringToFront();
            
        }

        private Order.Order buildOrder()
        {
            return null;
        }

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Console.WriteLine(e.Node.Text);
        }
    }
}
