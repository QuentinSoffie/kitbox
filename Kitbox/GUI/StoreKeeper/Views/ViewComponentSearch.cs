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
        public ViewComponentSearch(StoreKeeperComponent component, MySqlConnection dataBase)
        {
            InitializeComponent();
        }
    }
}
