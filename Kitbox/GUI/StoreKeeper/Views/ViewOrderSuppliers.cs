using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kitbox.GUI.StoreKeeper.Views
{
    /// <summary>
    /// This is the view used to choose wich supplier the company want. 
    /// </summary>
    public partial class ViewOrderSuppliers : UserControl
    {

        new OrderSuppliers Parent;
        Dictionary<string, string> Component;

        public ViewOrderSuppliers(OrderSuppliers parent, Dictionary<string, string> components)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            Parent = parent;
            Component = components;
            LoadComponents();
        }

        public void LoadComponents()
        {
            label20.Text = Component["Code"];
            label24.Text = Component["Height"];
            label25.Text = Component["Width"];
            label26.Text = Component["Depth"];
            label21.Text = Component["Ref"];
            label23.Text = Component["Color"];
            label22.Text = Component["Stock"];
            label4.Text = Component["StockMin"];

            label2.Text = Component["SupplierOnePrice"];
            label6.Text = Component["SupplierOneDelay"];
            label10.Text = Component["SupplierTwoPrice"];
            label8.Text = Component["SupplierTwoDelay"];

        }

        private void pepButton2_Click(object sender, EventArgs e)
        {
            Parent.AddToTreeView1(Component["Code"], Component["Stock"]);
            Parent.ListSupplier1.Add(Component);
        }

        private void pepButton3_Click(object sender, EventArgs e)
        {
            Parent.AddToTreeView2(Component["Code"], Component["Stock"]);
            Parent.ListSupplier2.Add(Component);
        }
    }
}
