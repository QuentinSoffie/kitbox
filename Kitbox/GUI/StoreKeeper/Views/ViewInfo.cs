using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Kitbox.Order;
using MySql.Data.MySqlClient;
using Kitbox.PDF;

namespace Kitbox.GUI.StoreKeeper.Views
{
    /// <summary>
    /// This is the order view, that shows the order details
    /// </summary>
    public partial class ViewInfo : UserControl
    {
        StoreKeeperOrder Order;
        MySqlConnection DataBase;
        Dictionary<string, string> Customer;
        Dictionary<string, string> Component;
        List<Dictionary<string, string>> ListComponents;
        new SearchInfo Parent;

        public ViewInfo(StoreKeeperOrder order, MySqlConnection dataBase, SearchInfo parent)
        {
            this.Parent = parent;
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
                Customer = new Dictionary<string, string>
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
            label28.Text = Customer["IdClient"].ToString();
        }

        private void SetOrder()
        {
            int i = 0;
            foreach(KeyValuePair<String, object> component in Order.Components)
            {
                pepTreeView1.Nodes.Add(component.Key);
                pepTreeView1.Nodes[i].Tag = component.Value.ToString() + " item(s)";
                i++;
            }
            if (Order.State == "Not completed")
            {
                pepButton2.Visible = true;
            }
        }

        private void LoadComponents()
        {
            Console.WriteLine(Order.State);
            FetchCustomerData();
            SetCustomer();
            SetOrder();
            GetDetailsFromDB(Order.KeyList);
        }

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetDetails(ListComponents[pepTreeView1.SelectedNode.Index]);
        }

        public void SetDetails(Dictionary<string, string> component)
        {
            label20.Text = Order.KeyList[pepTreeView1.SelectedNode.Index];
            label24.Text = component["Height"].ToString();
            label25.Text = component["Width"].ToString();
            label26.Text = component["Depth"].ToString();
            label21.Text = component["Ref"].ToString();
            label22.Text = component["CustomerPrice"].ToString();
            label29.Text = Order.Components[label20.Text].ToString();
            label23.Text = component["Color"].ToString();
        }

        private void GetDetailsFromDB(List<string> ListCode)
        {
            ListComponents = new List<Dictionary<string, string>>();
            foreach (string code in ListCode)
            {
                DataBase.Open();
                MySqlDataReader reader = DBMethods.DataBaseMethods.SqlSearch("Piece", "Code", string.Format("'{0}'", code), DataBase);
                while (reader.Read())
                {
                    Component = new Dictionary<string, string>
                    {
                        {"Ref", reader["Ref"].ToString() },
                        {"Code", reader["Code"].ToString() },
                        {"Color", reader["Couleur"].ToString() },
                        {"Dimensions", reader["Dimensions(cm)"].ToString() },
                        {"Height", reader["hauteur"].ToString() },
                        {"Width", reader["largeur"].ToString() },
                        {"Depth", reader["profondeur"].ToString() },
                        {"CustomerPrice", reader["Prix-Client"].ToString() },
                        {"Quantity", this.Order.Components[code].ToString() },
                    };
                }

                reader.Close();
                DataBase.Close();
                ListComponents.Add(Component);
            }
        }

        public void UpdateCustomer()
        {
            if (pepTextbox1.Text != "")
            {
                DBMethods.DataBaseMethods.SqlUpdateCustomer("surname", pepTextbox1.Text, int.Parse(Order.CustomerId), DataBase);
                DBMethods.DataBaseMethods.SqlUpdateCustomerOrder("Customer", pepTextbox1.Text, int.Parse(Order.CustomerId), DataBase);

            }
            if (pepTextbox2.Text != "")
            {
                DBMethods.DataBaseMethods.SqlUpdateCustomer("firstname", pepTextbox2.Text, int.Parse(Order.CustomerId), DataBase);
            }
            if (pepTextbox3.Text != "")
            {
                DBMethods.DataBaseMethods.SqlUpdateCustomer("phone", pepTextbox3.Text, int.Parse(Order.CustomerId), DataBase);
            }
            if (pepTextbox4.Text != "")
            {
                DBMethods.DataBaseMethods.SqlUpdateCustomer("email", pepTextbox4.Text, int.Parse(Order.CustomerId), DataBase);
            }
            if (pepTextbox5.Text != "")
            {
                DBMethods.DataBaseMethods.SqlUpdateCustomer("address", pepTextbox5.Text, int.Parse(Order.CustomerId), DataBase);
            }

            Parent.ClearWindow();
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
        }

        private void pepButton2_Click(object sender, EventArgs e)
        {
            StockDB.StockMethod.UpdateOrderState(Order.OrderNumber, "Completed ✓", DataBase);

            DataTable dtbl = PDFUtils.MakeTable(ListComponents);
            Kitbox.PDF.PDFUtils.ExportDataTableToPDF(dtbl, @"bill.pdf", "Facture : " + Customer["Surname"], Customer["IdClient"], float.Parse(PDFUtils.TotalCost(ListComponents)), "Finished");
            System.Diagnostics.Process.Start(@"bill.pdf");


            Parent.ClearWindow();
            Parent.Search();
        }
    }
}
