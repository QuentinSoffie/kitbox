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
using Kitbox.GUI.StoreKeeper.Models;

namespace Kitbox.GUI.StoreKeeper.Views
{
    public partial class SearchComponent : UserControl
    {
        public MySqlConnection DataBase { get; set; }
        public new StoreKeeper Parent { get; set; }

        public Dictionary<StoreKeeperComponent, ViewComponentSearch> ComponentViewDictionary { get; set; }
        public SearchComponent(MySqlConnection database, StoreKeeper parent) 
        {
            InitializeComponent();
            ComponentViewDictionary = new Dictionary<StoreKeeperComponent, ViewComponentSearch>();
            DataBase = database;
            Parent = parent;
            pepCombobox1.SelectedIndex = 0;
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            Search();
        }

        public void Search() { 
            if (pepTextbox1.Text == "")
            {
                Parent.ShowError("Please enter a component reference or a component code");
                return;
            }
            if (pepCombobox1.SelectedItem == null)
            {
                Parent.ShowError("Please choose a searching method");
                return;
            }
            else
            {
                GetComponents();
            }
        }

        public void GetComponents()
        {
            ComponentViewDictionary.Clear();
            Cursor.Current = Cursors.WaitCursor;
            DataBase.Open();

            MySqlDataReader reader;
            List<Object> resp = new List<Object>();

            if (pepCombobox1.GetItemText(pepCombobox1.SelectedItem) == "Reference")
            {
                reader = DBMethods.DataBaseMethods.SqlSearch("Piece", "Ref", String.Format("'{0}'", pepTextbox1.Text), DataBase);
            }
            else
            {
                reader = DBMethods.DataBaseMethods.SqlSearch("Piece", "Code", String.Format("'{0}'", pepTextbox1.Text.ToUpper()), DataBase);
            }

            while (reader.Read())
            {
                Dictionary<String, Object> component = new Dictionary<string, object>
                {
                    { "Ref", reader["Ref"].ToString() },
                    { "Code", reader["Code"].ToString() },
                    { "Dimensions", reader["Dimensions(cm)"].ToString() },
                    { "Height", reader["hauteur"].ToString() },
                    { "Width", reader["largeur"].ToString() },
                    { "Depth", reader["profondeur"].ToString() },
                    { "Couleur", reader["Couleur"].ToString() },
                    { "Stock", reader["Enstock"].ToString() },
                    { "StockMin", reader["Stock minimum"].ToString() },
                    { "SupplierOnePrice", reader["Prix-Fourn 1"].ToString() },
                    { "SupplierTwoPrice", reader["Prix-Fourn2"].ToString() },
                    { "SupplierOneDelay", reader["Delai-Fourn 1"].ToString() },
                    { "SupplierTwoDelay", reader["Delai-Fourn2"].ToString() }
                };

                resp.Add(component);
            }


            DataBase.Close();

            if (resp.Count == 0)
            {
                ClearWindow();
                Parent.ShowError(String.Format("Error, no value found for \"{0}\"", pepTextbox1.Text));
            }
            else
            {
                AddItems(resp);
            }

            Cursor.Current = Cursors.Default;
        }

        public void AddItems(List<object> components)
        {
            foreach (Dictionary<String, Object> item in components)
            {
                StoreKeeperComponent newComponent = new StoreKeeperComponent(item);
                ViewComponentSearch newView = new ViewComponentSearch(this, newComponent, DataBase);

                ComponentViewDictionary.Add(newComponent, newView);

                splitContainer1.Panel2.Controls.Add(newView);
                newView.Hide();

                Console.WriteLine(newComponent);
            }

            ReloadTreeView();
        }

        public void ReloadTreeView()
        {

            pepTreeView1.Nodes.Clear();
            int i = 0;

            foreach (KeyValuePair<StoreKeeperComponent, ViewComponentSearch> component in ComponentViewDictionary)
            {
                pepTreeView1.Nodes.Add(component.Key.Code);
                if (component.Key.Stock > component.Key.StockMin)
                {
                    pepTreeView1.Nodes[i].Tag = $"{component.Key.Stock.ToString()} item(s) ✓";
                }
                else
                {
                    pepTreeView1.Nodes[i].Tag = $"{component.Key.Stock.ToString()} item(s)";
                }
                

                i++;
            }
        }

        public void ClearWindow()
        {
            ComponentViewDictionary.Clear();
            pepTreeView1.Nodes.Clear();
            splitContainer1.Panel2.Controls.Clear();
        }

        private void pepCombobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pepTextbox1.Text = "";
        }

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (KeyValuePair<StoreKeeperComponent, ViewComponentSearch> component in ComponentViewDictionary)
            {
                if (component.Key.Code == e.Node.Text)
                {
                    Console.WriteLine(e.Node.Text);
                    component.Value.Show();
                    component.Value.BringToFront();
                }
            }
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
