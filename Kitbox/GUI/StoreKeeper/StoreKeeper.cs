using GUI;
using Kitbox.GUI.StoreKeeper;
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

        public SearchOrder searchOrderView { get; set; }
        public SearchComponent searchComponentView { get; set; }

        public CreateComponent createComponentView { get; set; }

        private readonly string _username;
        private readonly string _password;
    
        /// <summary>
        /// Constructor of StoreKeeper form with 4 required arguments
        /// </summary>
        /// <param name="database"></param>
        /// <param name="authentification"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
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

        /// <summary>
        /// This loads all the view.
        /// </summary>
        public void LoadViews()
        {
            searchOrderView = new SearchOrder(DataBase, this);
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

        }

        /// <summary>
        /// This shows an error on the window
        /// </summary>
        /// <param name="message"></param>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error !");
        }

        /// <summary>
        /// Show the search order view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchOrderView.Show();
            ViewDictionary["SearchOrder"].BringToFront();
        }

        /// <summary>
        /// Show the search component view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void componentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchComponentView.Show();
            ViewDictionary["SearchComponent"].BringToFront();
        }

        /// <summary>
        /// Show the search customer view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void createNewComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createComponentView.Show();
            ViewDictionary["CreateComponent"].BringToFront();
        }
    }
}
