using GUI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Kitbox.GUI.StoreKeeper.Views;

namespace Kitbox.GUI.StoreKeeper
{
    /// <summary>
    /// This is the main form for the store keeper
    /// </summary>
    public partial class StoreKeeper : Form
    {
        public MySqlConnection DataBase { get; set; }
        public Authentication Authentification { get; set; }
        public Dictionary<string, UserControl> ViewDictionary { get; set; }
        public SearchInfo searchOrderView { get; set; }
        public SearchComponent searchComponentView { get; set; }
        public CreateComponent createComponentView { get; set; }
        public OrderSuppliers OrderSuppliersView { get; set; }
        private readonly string _username;
        private readonly string _password;

        public StoreKeeper(MySqlConnection database, Authentication authentification, string username, string password)
        {
            InitializeComponent();
            ViewDictionary = new Dictionary<string, UserControl>();
            DataBase = database;
            Authentification = authentification;
            _username = username;
            _password = password;

            LoadViews();
            searchOrderView.Show();
            ViewDictionary["SearchOrder"].BringToFront();
        }

        public void LoadViews()
        {
            searchOrderView = new SearchInfo(DataBase, this);
            ViewDictionary.Add("SearchOrder", searchOrderView);
            searchOrderView.Dock = DockStyle.Fill;
            panel1.Controls.Add(searchOrderView);
            searchOrderView.Hide();

            searchComponentView = new SearchComponent(DataBase, this);
            ViewDictionary.Add("SearchComponent", searchComponentView);
            searchComponentView.Dock = DockStyle.Fill;
            panel1.Controls.Add(searchComponentView);
            searchComponentView.Hide();

            createComponentView = new CreateComponent(DataBase, this);
            ViewDictionary.Add("CreateComponent", createComponentView);
            createComponentView.Dock = DockStyle.Fill;
            panel1.Controls.Add(createComponentView);
            createComponentView.Hide();

            OrderSuppliersView = new OrderSuppliers(DataBase, this);
            ViewDictionary.Add("OrderSuppliersView", OrderSuppliersView);
            OrderSuppliersView.Dock = DockStyle.Fill;
            panel1.Controls.Add(OrderSuppliersView);
            OrderSuppliersView.Hide();

        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error !");
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchOrderView.Show();
            ViewDictionary["SearchOrder"].BringToFront();
        }

        private void componentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchComponentView.Show();
            ViewDictionary["SearchComponent"].BringToFront();
        }

        private void createNewComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createComponentView.Show();
            ViewDictionary["CreateComponent"].BringToFront();
        }

        private void orderForSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderSuppliersView.Show();
            ViewDictionary["OrderSuppliersView"].BringToFront();
        }
    }
}
