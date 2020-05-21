using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitbox.Order;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace Kitbox.GUI.StoreKeeper.Views
{
    /// <summary>
    /// This is the order view, that shows the order details
    /// </summary>
    public partial class ViewInfo : UserControl
    {
        StoreKeeperOrder Order;

        MySqlConnection DataBase;

        Dictionary<String, Object> Customer;

        Dictionary<String, Object> component;

        List<Dictionary<string, object>> ListComponent;

        /// <summary>
        /// This is the constructor of the order view. It takes one required argument.
        /// </summary>
        /// <param name="order"></param>
        public ViewInfo(StoreKeeperOrder order, MySqlConnection dataBase)
        {
            this.DataBase = dataBase;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            this.Order = order;
            LoadComponents();
        }


        private void FetchCustomerData()
        {
            DataBase.Open();
            MySqlDataReader reader = DBMethods.DataBaseMethods.SqlSearchCustomer(this.Order.CustomerId, DataBase);
            while (reader.Read())
            {
                Customer = new Dictionary<string, object>
                {
                    { "Email", reader["email"].ToString() },
                    { "Phone", reader["phone"].ToString() },
                    { "Surname", reader["surname"].ToString() },
                    { "Firstname", reader["firstname"].ToString() },
                    { "Address", reader["address"].ToString() },
                    { "IdClient", this.Order.CustomerId }
                };
            }
            DataBase.Close();
        }

        private void SetCustomer()
        {
            label3.Text = Customer["Surname"].ToString().ToUpper();
            label4.Text = Customer["Firstname"].ToString();
            label5.Text = Customer["Phone"].ToString();
            label6.Text = Customer["Email"].ToString();
            label7.Text = Customer["Address"].ToString();
        }

        private void SetOrder()
        {
            foreach(KeyValuePair<String, object> component in Order.Components)
            {
                pepTreeView1.Nodes.Add(component.Key);
            }
        }

        /// <summary>
        /// This loads all the informations about the order
        /// </summary>
        private void LoadComponents()
        {
            FetchCustomerData();
            SetCustomer();
            SetOrder();
            GetDetailsFromDB(Order.KeyList);
        }

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetDetails(ListComponent[pepTreeView1.SelectedNode.Index]);
        }

        public void SetDetails(Dictionary<String, object> component)
        {
            label20.Text = Order.KeyList[pepTreeView1.SelectedNode.Index];
            label24.Text = component["Height"].ToString();
            label25.Text = component["Width"].ToString();
            label26.Text = component["Depth"].ToString();
            label21.Text = component["Ref"].ToString();
            label22.Text = Order.Components[label20.Text].ToString();
            label23.Text = component["Color"].ToString();
        }

        private void GetDetailsFromDB(List<string> ListCode)
        {
            ListComponent = new List<Dictionary<string, object>>();
            foreach (string code in ListCode)
            {
                DataBase.Open();
                MySqlDataReader reader = DBMethods.DataBaseMethods.SqlSearch("Piece", "Code", string.Format("'{0}'", code), DataBase);
                while (reader.Read())
                {
                    component = new Dictionary<string, object>
                    {
                        {"Ref", reader["Ref"].ToString() },
                        {"Color", reader["Couleur"].ToString() },
                        {"Dimensions", reader["Dimensions(cm)"].ToString() },
                        {"Height", reader["hauteur"].ToString() },
                        {"Width", reader["largeur"].ToString() },
                        {"Depth", reader["profondeur"].ToString() },
                    };
                }
                reader.Close();
                DataBase.Close();
                ListComponent.Add(component);
            }


        }
    }
}
