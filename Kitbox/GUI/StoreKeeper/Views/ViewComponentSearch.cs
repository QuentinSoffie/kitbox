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

        private void pepButton1_Click(object sender, EventArgs e)
        {
            AddComponent(34);
        }

        public void AddComponent(int value)
        {
            Console.WriteLine(Component.Code);
            StockDB.StockMethod.AddQtty(Component.Code, value, DataBase);
        }
    }
}
