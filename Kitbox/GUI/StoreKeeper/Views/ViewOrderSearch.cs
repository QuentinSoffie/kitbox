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

namespace Kitbox.GUI.StoreKeeper.Views
{
    /// <summary>
    /// This is the order view, that shows the order details
    /// </summary>
    public partial class ViewOrderSearch : UserControl
    {
        StoreKeeperOrder Order;

        MySqlConnection DataBase;

        Dictionary<String, Object> Customer;
        /// <summary>
        /// This is the constructor of the order view. It takes one required argument.
        /// </summary>
        /// <param name="order"></param>
        public ViewOrderSearch(StoreKeeperOrder order, MySqlConnection dataBase)
        {
            this.DataBase = dataBase;
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            this.Order = order;
            AddChat(string.Format("Loading order n° {0} ...", this.Order.OrderNumber), Color.Yellow);
            label1.Text = order.Name;
            AddChat("Loading components ...", Color.Yellow);
            LoadComponents();
            AddChat("Done", Color.Green);
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

        private void SetCustmer()
        {
            label3.Text = Customer["Surname"].ToString().ToUpper();
            label4.Text = Customer["Firstname"].ToString();
            label5.Text = Customer["Phone"].ToString();
            label6.Text = Customer["Email"].ToString();
            label7.Text = Customer["Address"].ToString();
        }

        /// <summary>
        /// This loads all the informations about the order
        /// </summary>
        private void LoadComponents()
        {
            FetchCustomerData();
            SetCustmer();
            //TODO: Load the order details   
        }

        /// <summary>
        /// Add console text in the console in the view
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        private void AddChat(string message, Color color)
        {
            string hours = DateTime.Now.ToString("[HH:mm:ss] ");
            RichTextBox_console.RT.AppendText(hours + message + Environment.NewLine);
            RichTextBox_console.RT.SelectionStart = RichTextBox_console.RT.Find(hours + message, RichTextBoxFinds.Reverse);
            RichTextBox_console.RT.SelectionColor = color;
            RichTextBox_console.RT.DeselectAll();
            RichTextBox_console.RT.ScrollToCaret();
        }
    }
}
