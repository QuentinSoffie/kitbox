using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Kitbox.StoreKeeper.Models;

namespace Kitbox.StoreKeeper.Views
{
    /// <summary>
    /// This is the view for searching order 
    /// </summary>
    public partial class SearchInfo : UserControl
    {
        public MySqlConnection DataBase { get; set; }
        public new StoreKeeperWindow Parent { get; set; }
        public Dictionary<StoreKeeperOrder, ViewInfo> OrderViewDictionary {get;set;}
        
        public SearchInfo(MySqlConnection database, StoreKeeperWindow parent)
        {
            InitializeComponent();
            OrderViewDictionary = new Dictionary<StoreKeeperOrder, ViewInfo>();
            DataBase = database;
            Parent = parent;
            pepCombobox1.SelectedIndex = 0;
        }

        public void AddItems(List<Object> orders)
        {
            foreach (Dictionary<String, Object> item in orders)
            {
                StoreKeeperOrder newOrder = new StoreKeeperOrder(item);
                ViewInfo newView = new ViewInfo(newOrder, DataBase, this);

                OrderViewDictionary.Add(newOrder, newView);

                splitContainer1.Panel2.Controls.Add(newView);
                newView.Hide();
            }

            ReloadTreeView();
        }

        public void ClearWindow()
        {
            OrderViewDictionary.Clear();
            ReloadTreeView();
            splitContainer1.Panel2.Controls.Clear();
        }

        public void ReloadTreeView()
        {
            pepTreeView1.Nodes.Clear();
            int i = 0;

            foreach (KeyValuePair<StoreKeeperOrder, ViewInfo> order in OrderViewDictionary)
            {
                pepTreeView1.Nodes.Add(order.Key.Name);
                pepTreeView1.Nodes[i].Tag = order.Key.State.Replace('V', '✓');
                i++;
            }
        }

        public void RemoveItem(TreeNode node)
        {
            foreach (KeyValuePair<StoreKeeperOrder, ViewInfo> order in OrderViewDictionary)
            {
                if (order.Key.Name == node.Text)
                {
                    order.Value.Hide();
                    OrderViewDictionary.Remove(order.Key);
                    break;
                }
            }

            ReloadTreeView();
        }

        public void GetOrder()
        {
            Cursor.Current = Cursors.WaitCursor;
            OrderViewDictionary.Clear();
            DataBase.Open();

            MySqlDataReader reader;
            List<Object> resp = new List<Object>();

            if (pepCombobox1.GetItemText(pepCombobox1.SelectedItem) == "Order number")
            {
                reader = StockDB.StockMethod.SearchOrderByNum(pepTextbox1.Text, DataBase);
            }
            else if (pepCombobox1.GetItemText(pepCombobox1.SelectedItem) == "Customer Id")
            {
                reader = StockDB.StockMethod.SearchOrderById(pepTextbox1.Text, DataBase);
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
                    { "IdClient", reader["IdClient"].ToString() },
                    { "Customer", reader["Customer"].ToString() },
                    { "Components", reader["ItemsCode"].ToString() },
                    { "State", reader["State"].ToString() }
                };

                resp.Add(order);
            }

            DataBase.Close();

            if (resp.Count == 0)
            {
                Parent.ShowError(String.Format("Error, no value found for \"{0}\"", pepTextbox1.Text));
            }
            else
            {
                AddItems(resp);
            }

            Cursor.Current = Cursors.Default;

        }

        private void pepButton1_Click_1(object sender, EventArgs e)
        {
            Search();
        }

        public void Search()
        {
            ClearWindow();
            if (pepTextbox1.Text == "")
            {
                Parent.ShowError("Please enter an order number or a customer name");
                return;
            }
            if (pepCombobox1.SelectedItem == null)
            {
                Parent.ShowError("Please choose a searching method");
                return;
            }
            else
            {
                GetOrder();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RemoveItem(pepTreeView1.SelectedNode);
        }

        private void pepTreeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

            foreach (KeyValuePair<StoreKeeperOrder, ViewInfo> order in OrderViewDictionary)
            {
                if (order.Key.Name == e.Node.Text)
                {
                    order.Value.Show();
                    order.Value.BringToFront();
                }
            }
        }

        private void pepCombobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pepTextbox1.Text = "";
        }

        private void pepTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
    }
}
