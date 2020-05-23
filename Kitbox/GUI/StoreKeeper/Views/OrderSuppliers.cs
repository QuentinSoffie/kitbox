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

namespace Kitbox.GUI.StoreKeeper.Views
{
    public partial class OrderSuppliers : UserControl
    {
        MySqlConnection DataBase;
        StoreKeeper Parent;

        public OrderSuppliers(MySqlConnection dataBase, StoreKeeper parent)
        {
            InitializeComponent();
            DataBase = dataBase;
            Parent = parent;
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            List<Dictionary<string, string>> stockMin = StockDB.StockMethod.CheckStockForSupplier(DataBase);
            if (stockMin.Count == 0)
            {
                MessageBox.Show("Nothing to order", "Empty");
            }
            else
            {
                int i = 0;
                foreach (Dictionary<string, string> component in stockMin)
                {
                    pepTreeView1.Nodes.Add(component["Code"]);
                    pepTreeView1.Nodes[i].Tag = $"{component["Ref"]} - {component["Stock"]} item(s) left";
                    i++;
                }
            }
        }

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void pepButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
