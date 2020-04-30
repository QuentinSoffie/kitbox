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
        private List<ViewComponentSearch> ViewComponentSearchList;
        private List<StoreKeeperOrder> orderList = new List<StoreKeeperOrder>();
        private Dictionary<StoreKeeperOrder, ViewComponentSearch> viewDict = new Dictionary<StoreKeeperOrder, ViewComponentSearch>();

        public StoreKeeper(MySqlConnection database, Authentication authentification, string username, string password)
        {
            InitializeComponent();
            DataBase = database;
            Authentification = authentification;
            Username = username;
            Password = password;

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
        /// <param name="orders"></param>
        public void addItems(List<Object> orders)
        {

            foreach (Dictionary<String, Object> item in orders)
            {
                StoreKeeperOrder newOrder = new StoreKeeperOrder(item);
                ViewComponentSearch newView = new ViewComponentSearch(newOrder);

                viewDict.Add(newOrder, newView);

                splitContainer1.Panel2.Controls.Add(newView);
                newView.Hide();

                Console.WriteLine(newOrder);
            }

            reloadTreeView();
        }

        public void reloadTreeView()
        {
            pepTreeView1.Nodes.Clear();
            int i = 0;

            foreach(KeyValuePair<StoreKeeperOrder, ViewComponentSearch> order in viewDict)
            {
                pepTreeView1.Nodes.Add(order.Key.Name);
                pepTreeView1.Nodes[i].Tag = order.Key.State;

                i++;
            }
        }

 
        public void removeItem(TreeNode node)
        {
            foreach(KeyValuePair<StoreKeeperOrder, ViewComponentSearch> order in viewDict)
            {
                if (order.Key.Name == node.Text)
                {
                    order.Value.Hide();
                    viewDict.Remove(order.Key);
                    break;
                }
            }

            reloadTreeView();
        }


        private void getOrder()
        {
            Cursor.Current = Cursors.WaitCursor;
            DataBase.Open();

            MySqlDataReader reader;
            List<Object> resp = new List<Object>();

            if (pepCombobox1.GetItemText(pepCombobox1.SelectedItem) == "Order number")
            {

                reader = StockDB.StockMethod.SearchOrderByNum(pepTextbox1.Text, DataBase);

            }
            else
            {

                reader = StockDB.StockMethod.SearchOrderByName(pepTextbox1.Text, DataBase);

            }

            while (reader.Read())
            {
                Dictionary<String, Object> order = new Dictionary<string, object>
                {
                    { "OrderNumber", reader["NumOrder"].ToString() },
                    { "Customer", reader["Customer"].ToString() },
                    { "Components", reader["ItemsCode"].ToString() },
                    { "State", reader["State"].ToString() }
                };

                resp.Add(order);
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
            viewDict.Clear();

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
        }

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            foreach (KeyValuePair<StoreKeeperOrder, ViewComponentSearch> order in viewDict)
            {
                if (order.Key.Name == e.Node.Text)
                {
                    order.Value.Show();
                    order.Value.BringToFront();
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            removeItem(pepTreeView1.SelectedNode);
        }
    }
}
