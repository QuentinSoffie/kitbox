using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitbox.Order;

namespace Kitbox.GUI.Views
{
    public partial class ViewComponentSearch : UserControl
    {
        StoreKeeperOrder order;
        public ViewComponentSearch(StoreKeeperOrder order)
        {
            this.order = order;
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            label1.Text = order.Name;
        }

        private void ViewComponentSearch_Load(object sender, EventArgs e)
        {
            
        }
    }
}
