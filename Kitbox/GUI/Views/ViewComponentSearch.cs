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
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            this.order = order;
            AddChat(string.Format("Loading order n° {0} ...", this.order.OrderNumber), Color.Yellow);
            label1.Text = order.Name;
            AddChat("Loading components ...", Color.Yellow);
            loadComponents();
            AddChat("Done", Color.Green);
        }

        private void ViewComponentSearch_Load(object sender, EventArgs e)
        {
            
        }

        private void loadComponents()
        {

        }

        private void AddChat(string message, Color color)
        {
            string hours = DateTime.Now.ToString("[HH:mm:ss] ");
            RichTextBox_console.RT.AppendText(hours + message + Environment.NewLine);
            RichTextBox_console.RT.SelectionStart = RichTextBox_console.RT.Find(hours + message, RichTextBoxFinds.Reverse);
            RichTextBox_console.RT.SelectionColor = color;
            RichTextBox_console.RT.DeselectAll();
            RichTextBox_console.RT.ScrollToCaret();
        }
    }
}
