using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using GUI;
using Kitbox.Order;

namespace Kitbox.GUI.StoreKeeper.Views
{
    /// <summary>
    /// This is the view for searching order 
    /// </summary>
    public partial class SearchOrder : UserControl
    {

        public MySqlConnection DataBase { get; set; }
        public new StoreKeeper Parent { get; set; }
        public Dictionary<StoreKeeperOrder, ViewComponentSearch> OrderViewDictionary {get;set;}
        
        /// <summary>
        /// Constructor of the view, it takes 2 required arguments
        /// </summary>
        /// <param name="database"></param>
        /// <param name="parent"></param>
        public SearchOrder(MySqlConnection database, StoreKeeper parent)
        {
            InitializeComponent();
            OrderViewDictionary = new Dictionary<StoreKeeperOrder, ViewComponentSearch>();
            DataBase = database;
            Parent = parent;
            pepCombobox1.SelectedIndex = 0;
        }

        /// <summary>
        /// Add a list of orders in the OrderViewDictionary (A dictionary with all the views)
        /// </summary>
        /// <param name="orders"></param>
        public void AddItems(List<Object> orders)
        {

            foreach (Dictionary<String, Object> item in orders)
            {
                StoreKeeperOrder newOrder = new StoreKeeperOrder(item);
                ViewComponentSearch newView = new ViewComponentSearch(newOrder);

                OrderViewDictionary.Add(newOrder, newView);

                splitContainer1.Panel2.Controls.Add(newView);
                newView.Hide();

                Console.WriteLine(newOrder);
            }

            ReloadTreeView();
        }

        /// <summary>
        /// It reads the OrderViewDictionary and load orders into the treeview
        /// </summary>
        public void ReloadTreeView()
        {
            pepTreeView1.Nodes.Clear();
            int i = 0;

            foreach (KeyValuePair<StoreKeeperOrder, ViewComponentSearch> order in OrderViewDictionary)
            {
                pepTreeView1.Nodes.Add(order.Key.Name);
                pepTreeView1.Nodes[i].Tag = order.Key.State;

                i++;
            }
        }

        /// <summary>
        /// Remove the order in the viewList
        /// </summary>
        /// <param name="node"></param>
        public void RemoveItem(TreeNode node)
        {
            foreach (KeyValuePair<StoreKeeperOrder, ViewComponentSearch> order in OrderViewDictionary)
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

        /// <summary>
        /// Get order from db send to AddItems()
        /// </summary>
        private void GetOrder()
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
                Parent.ShowError(String.Format("Error, no value found for \"{0}\"", pepTextbox1.Text));
            }
            else
            {
                AddItems(resp);
            }

            Cursor.Current = Cursors.Default;

        }

        /// <summary>
        /// Actions when the search button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pepButton1_Click_1(object sender, EventArgs e)
        {
            OrderViewDictionary.Clear();

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

        /// <summary>
        /// Actions when the cross button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            RemoveItem(pepTreeView1.SelectedNode);
        }

        /// <summary>
        /// Actions when a node in the treeview is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pepTreeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

            foreach (KeyValuePair<StoreKeeperOrder, ViewComponentSearch> order in OrderViewDictionary)
            {
                if (order.Key.Name == e.Node.Text)
                {
                    order.Value.Show();
                    order.Value.BringToFront();
                }
            }

        }

        /// <summary>
        /// Actions when the combobox is updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pepCombobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pepTextbox1.Text = "";
        }
    }
}
