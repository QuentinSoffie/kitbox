using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Kitbox.Customer.Views
{
    /// <summary>
    /// This is the view used to create or select a customer after checking the command. 
    /// </summary>
    public partial class CreateCustomer : UserControl
    {
        new CustomerWindow Parent;
        MySqlConnection DataBase;
        List<Dictionary<string, string>> Customers;
        string Customer;
        string Id;

        public CreateCustomer(MySqlConnection dataBase, CustomerWindow parent)
        {
            InitializeComponent();
            Parent = parent;
            DataBase = dataBase;
        }

        private void pepButton3_Click(object sender, EventArgs e)
        {
            Search();
        }

        public void Search()
        {
            Cursor.Current = Cursors.WaitCursor;
            pepTreeView1.Nodes.Clear();
            SearchCustomer();
            Cursor.Current = Cursors.Default;
        }

        public void SearchCustomer()
        {
            Customers = MethodsDB.DataBaseMethods.SqlSearchCustomerByName(pepTextbox6.Text, DataBase);
            if (Customers.Count == 0)
            {
                MessageBox.Show($"No result for \"{pepTextbox6.Text}\" !", "Error");
            }
            int i = 0;
            foreach(Dictionary<string, string> customer in Customers)
            {
                pepTreeView1.Nodes.Add($"{customer["surname"].ToUpper()} - {customer["firstname"]}");
                pepTreeView1.Nodes[i].Tag = customer["id"];
                i++;
            }
        }

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            label4.Text = Customers[pepTreeView1.SelectedNode.Index]["surname"].ToUpper();
            label5.Text = Customers[pepTreeView1.SelectedNode.Index]["firstname"];
            label28.Text = Customers[pepTreeView1.SelectedNode.Index]["id"];
        }

        private void pepButton2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (pepTreeView1.SelectedNode != null)
            {
                Customer = Customers[pepTreeView1.SelectedNode.Index]["surname"];
                Id = Customers[pepTreeView1.SelectedNode.Index]["id"];
                Console.WriteLine(Customer);
                Console.WriteLine(Id);

                Parent.ExportPDF(Customer, Id, Parent.OurOrder.CheckState());
            }
            else
            {
                MessageBox.Show("Please select or create a customer", "Error");
            }

            Parent.CustomerView.Hide();
            Parent.ClearWindow();

            Cursor.Current = Cursors.Default;
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string surname = pepTextbox1.Text;
            string firsname = pepTextbox2.Text;
            string phone = pepTextbox3.Text;
            string email = pepTextbox4.Text;
            string address = pepTextbox5.Text;
            Customer = pepTextbox1.Text;

            if (surname != "" && firsname != "" && phone != "" && email != "" && address != "")
            {
                MethodsDB.DataBaseMethods.SqlAddCustomer(surname, firsname, phone, email, address, DataBase);
                DataBase.Open();
                MySqlDataReader reader = MethodsDB.DataBaseMethods.SqlSearch("users", "surname", String.Format("'{0}'", Customer), DataBase);
                

                while(reader.Read())
                {
                    Id = reader["id"].ToString();
                }
                reader.Close();
                DataBase.Close();
                Parent.ExportPDF(Customer, Id, Parent.OurOrder.CheckState());
            }
            else
            {
                MessageBox.Show("Please complete all the fields.", "Error");
            }

            Parent.CustomerView.Hide();
            Parent.ClearWindow();

            Cursor.Current = Cursors.Default;
        }

        private void pepTextbox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("Enter pressed");
                Search();
            }
        }
    }
}
