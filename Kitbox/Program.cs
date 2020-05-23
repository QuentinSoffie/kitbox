using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

using Kitbox.Components;
using GUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using DBMethods;
using Kitbox.GUI;
using Kitbox.GUI.StoreKeeper;

namespace Kitbox
{
    static class Program
    {
        private static Dictionary<string, string> Lang;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadLangFile();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Authentication());

            //MySqlConnection myDataBase = DBUtils.GetDBConnection("customer", "groupe2020");
            //Application.Run(new Customer(myDataBase, new Authentication(), "customer", "groupe2020"));

            MySqlConnection myDataBase = DBUtils.GetDBConnection("storekeep", "groupe2020");
            Application.Run(new StoreKeeper(myDataBase, new Authentication(), "storekeep", "groupe2020"));
        }

        private static void LoadLangFile()
        {
            string sourcePath = Path.GetFullPath(Path.Combine(Path.Combine(Environment.CurrentDirectory, @"..\..\"), @"Langs"));
            try
            {
                CopyDirectory(sourcePath, Path.Combine(Environment.CurrentDirectory, @"Langs"));
            }
            catch
            {

            }
          
            string filestr = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Langs\langEn.json"));
         
            Lang = JsonConvert.DeserializeObject<Dictionary<string, string>>(filestr);
        }

        private static void CopyDirectory(string sourcePath, string destinationPath)
        {
            //Now Create all of the directories
            Directory.CreateDirectory(destinationPath);
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);
        }

    }
}
