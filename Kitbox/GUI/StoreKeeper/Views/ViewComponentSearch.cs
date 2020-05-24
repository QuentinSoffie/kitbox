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
    public partial class ViewComponentSearch : UserControl
    {
        MySqlConnection DataBase;
        StoreKeeperComponent Component;
        new SearchComponent Parent;
        int Value;
        public ViewComponentSearch(SearchComponent parent, StoreKeeperComponent component, MySqlConnection dataBase)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            DataBase = dataBase;
            Component = component;
            Parent = parent;
            LoadData();
        }

        public void LoadData()
        {
            label20.Text = Component.Code;
            label24.Text = Component.Height;
            label25.Text = Component.Width;
            label26.Text = Component.Depth;
            label21.Text = Component.Ref;
            label22.Text = Component.Stock.ToString();
            label23.Text = Component.Color;
            label4.Text = Component.StockMin.ToString();

            label5.Text = Component.SupplierOnePrice;
            label7.Text = Component.SupplierOneDelay;
            label11.Text = Component.SupplierTwoPrice;
            label9.Text = Component.SupplierTwoDelay;
        }

        public void DeleteComponent()
        {
            StockDB.StockMethod.DeleteComponent(Component.Code, DataBase);
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            pepButton5.Visible = false;
            Value = int.Parse(pepNumericUpDown1.Value.ToString());
            label2.Text = (Component.Stock + Value).ToString();
            label2.ForeColor = Color.Green;
        }


        private void pepButton2_Click(object sender, EventArgs e)
        {
            pepButton5.Visible = false;
            Value = -int.Parse(pepNumericUpDown1.Value.ToString());

            if (Component.Stock + Value < 0)
            {
                MessageBox.Show("Error can't get a negative stock", "Error !");
            }
            else
            {
                label2.Text = (Component.Stock + Value).ToString();
                label2.ForeColor = Color.Red;
            }
        }

        private void pepButton3_Click(object sender, EventArgs e)
        {
            pepButton5.Visible = true;
            pepButton5.BringToFront();
        }

        private void pepButton4_Click(object sender, EventArgs e)
        {
            if (Component.Stock + Value < 0)
            {
                MessageBox.Show("Error can't get a negative stock", "Error !");
            }
            else
            {
                StockDB.StockMethod.AddQtty(Component.Code, Value, DataBase);
                Parent.ClearWindow();
                Parent.GetComponents();
                Console.WriteLine("Done");
            }
        }

        private void pepButton5_Click(object sender, EventArgs e)
        {
            DeleteComponent();
            Parent.ClearWindow();
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void pepButton6_Click(object sender, EventArgs e)
        {
            UpdateSuppliers();
        }

        public void UpdateSuppliers()
        {
            if (textBox2.Text != "")
            {
                StockDB.StockMethod.UpdateSupplierInfo(Component.Code, "`Prix-Fourn 1`", textBox2.Text, DataBase);
            }
            if (textBox1.Text != "")
            {
                StockDB.StockMethod.UpdateSupplierInfo(Component.Code, "`Delai-Fourn 1`", textBox1.Text, DataBase);
            }
            if (textBox4.Text != "")
            {
                StockDB.StockMethod.UpdateSupplierInfo(Component.Code, "`Prix-Fourn2`", textBox4.Text, DataBase);
            }
            if (textBox3.Text != "")
            {
                StockDB.StockMethod.UpdateSupplierInfo(Component.Code, "`Delai-Fourn2`", textBox3.Text, DataBase);
            }

            Parent.ClearWindow();
            Parent.GetComponents();
        }
    }
}
