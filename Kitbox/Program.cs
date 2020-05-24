using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MethodsDB;
using Kitbox.Customer;

namespace Kitbox
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MySqlConnection myDataBase = DBUtils.GetDBConnection("customer", "groupe2020");
            Application.Run(new CustomerWindow(myDataBase));

            //MySqlConnection myDataBase = DBUtils.GetDBConnection("storekeep", "groupe2020");
            //Application.Run(new StoreKeeper(myDataBase, new Authentication(), "storekeep", "groupe2020"));
        }
    }
}
