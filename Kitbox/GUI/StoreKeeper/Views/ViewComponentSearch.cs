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

namespace Kitbox.GUI.StoreKeeper.Views
{
    /// <summary>
    /// This is the order view, that shows the order details
    /// </summary>
    public partial class ViewComponentSearch : UserControl
    {
        StoreKeeperOrder order;
        /// <summary>
        /// This is the constructor of the order view. It takes one required argument.
        /// </summary>
        /// <param name="order"></param>
        public ViewComponentSearch(StoreKeeperOrder order)
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            this.order = order;
            AddChat(string.Format("Loading order n° {0} ...", this.order.OrderNumber), Color.Yellow);
            label1.Text = order.Name;
            AddChat("Loading components ...", Color.Yellow);
            LoadComponents();
            AddChat("Done", Color.Green);
        }

        /// <summary>
        /// This loads all the informations about the order
        /// </summary>
        private void LoadComponents()
        {
            //TODO: Load the order details   
        }

        /// <summary>
        /// Add console text in the console in the view
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
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
