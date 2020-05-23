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
        new StoreKeeper Parent;

        int Index1 = 0;
        int Index2 = 0;

        public List<Dictionary<string, string>> ListSupplier1 = new List<Dictionary<string, string>>(); 
        public List<Dictionary<string, string>> ListSupplier2 = new List<Dictionary<string, string>>();

        public Dictionary<string, ViewOrderSuppliers> ViewsDictionary = new Dictionary<string, ViewOrderSuppliers>();

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

                    ViewOrderSuppliers view = new ViewOrderSuppliers(this, component);
                    splitContainer2.Panel1.Controls.Add(view);
                    view.Hide();
                    ViewsDictionary.Add(component["Code"], view);
                }
            }
        }

        private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ViewsDictionary[pepTreeView1.SelectedNode.Text].BringToFront();
            ViewsDictionary[pepTreeView1.SelectedNode.Text].Show();
        }

        public void RemoveTreeViewAt(int index)
        {
            pepTreeView1.Nodes.RemoveAt(index);

            if (pepTreeView1.Nodes.Count != 0)
            {
                pepTreeView1.SelectedNode = pepTreeView1.Nodes[0];
            }
            else
            {
                pepButton4.Visible = true;
            }
        }

        public void AddToTreeView1(string text, string tag)
        {
            pepTreeView2.Nodes.Add($"{text}");
            pepTreeView2.Nodes[Index1].Tag = $"{tag} ✓";
            RemoveTreeViewAt(pepTreeView1.SelectedNode.Index);
 
            Index1++;
        }

        public void AddToTreeView2(string text, string tag)
        {
            pepTreeView3.Nodes.Add($"{text}");
            pepTreeView3.Nodes[Index2].Tag = $"{tag} ✓";
            RemoveTreeViewAt(pepTreeView1.SelectedNode.Index);

            Index2++;
        }

        private void pepButton4_Click(object sender, EventArgs e)
        {

            Kitbox.PDF.PDFUtils.ExportOrderSupplierToPDF(ListSupplier1, @"bill1.pdf", "Bon de commande : Fournisseur 1", "1");
            System.Diagnostics.Process.Start(@"bill1.pdf");

            Kitbox.PDF.PDFUtils.ExportOrderSupplierToPDF(ListSupplier2, @"bill2.pdf", "Bon de commande : Fournisseur 2", "2");
            System.Diagnostics.Process.Start(@"bill2.pdf");
        }
    }
}
