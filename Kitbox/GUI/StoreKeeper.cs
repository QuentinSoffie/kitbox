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

        }

        public void addItem(String value)
        {
            pepTreeView1.Nodes.Add(value);
            pepTreeView1.Nodes[0].Tag = "Send";
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            DataBase.Open();
            addItem("201450".ToString());

            List<String> resp = new List<string>();

            if (pepCombobox1.GetItemText(pepCombobox1.SelectedItem) == "Order number"){
                
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
                    resp.Add(reader["Order"].ToString());
                }
            }

            foreach(String item in resp)
            {
                Console.WriteLine(item);
                Dictionary<String, Object> a = JsonConvert.DeserializeObject<Dictionary<String, Object>>(item);
                List<string> keyList = new List<string>(a.Keys);
                Console.WriteLine(keyList[0]);
            }

            splitContainer1.Panel2.Controls.Add(ViewComponentSearch);
            ViewComponentSearch.BringToFront();
            DataBase.Close();
        }
    }
}
