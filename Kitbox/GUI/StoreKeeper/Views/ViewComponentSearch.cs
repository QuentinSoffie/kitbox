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
        public ViewComponentSearch(StoreKeeperComponent component, MySqlConnection dataBase)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            DataBase = dataBase;
            Component = component;
        }

        public void Increase(int value)
        {
            Console.WriteLine(Component.Code);
            StockDB.StockMethod.AddQtty(Component.Code, value, DataBase);
        }
        public void Decrease(int value)
        {
            Console.WriteLine(Component.Code);
            StockDB.StockMethod.DeleteQtty(Component.Code, value, DataBase);
        }
        public void DeleteComponent()
        {
            //StockDB.StockMethod.RemoveComponent(Component.Code, DataBase);
        }


        private void pepButton1_Click(object sender, EventArgs e)
        {
            Increase((int)pepNumericUpDown1.Value);
        }


        private void pepButton2_Click(object sender, EventArgs e)
        {
            Decrease((int)pepNumericUpDown1.Value);
        }
    }
}
