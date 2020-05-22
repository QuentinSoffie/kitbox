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
        SearchComponent View;
        int Value;
        public ViewComponentSearch(SearchComponent view, StoreKeeperComponent component, MySqlConnection dataBase)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            DataBase = dataBase;
            Component = component;
            View = view;
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
        }

        public void DeleteComponent()
        {
            StockDB.StockMethod.DeleteComponent(Component.Code, DataBase);
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            Value = int.Parse(pepNumericUpDown1.Value.ToString());
            pepGroupBox1.Visible = true;
            label2.Text = (Component.Stock + Value).ToString();
            label2.ForeColor = Color.Green;
            pepButton4.Visible = true;
        }


        private void pepButton2_Click(object sender, EventArgs e)
        {
            Value = -int.Parse(pepNumericUpDown1.Value.ToString());

            if (Component.Stock + Value < 0)
            {
                MessageBox.Show("Error can't get a negative stock", "Error !");
            }
            else
            {
                pepGroupBox1.Visible = true;
                label2.Text = (Component.Stock + Value).ToString();
                label2.ForeColor = Color.Red;
                pepButton4.Visible = true;
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
                View.ClearWindow();
                View.GetComponents();
                Console.WriteLine("Done");
            }
        }

        private void pepButton5_Click(object sender, EventArgs e)
        {
            DeleteComponent();
            View.ClearWindow();
        }
    }
}
