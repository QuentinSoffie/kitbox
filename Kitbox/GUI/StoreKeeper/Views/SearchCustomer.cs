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
    public partial class SearchCustomer : UserControl
    {
        public MySqlConnection DataBase { get; set; }
        public new StoreKeeper Parent { get; set; }
        public SearchCustomer(MySqlConnection database, StoreKeeper parent)
        {
            InitializeComponent();
            DataBase = database;
            Parent = parent;

        }
    }
}
