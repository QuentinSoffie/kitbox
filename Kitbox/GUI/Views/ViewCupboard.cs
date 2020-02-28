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
using Kitbox.Components;
using Kitbox;
using DBMethods;
using MySql.Data.MySqlClient;

namespace Kitbox.GUI
{
    public partial class ViewCupboard : UserControl
    {
        public int Uid { get; set; }
        private TreeView tree;
        private Cupboard cupboard;

        public ViewCupboard(TreeView tree, Cupboard cupboard, int uid)
        {
            InitializeComponent();
            this.Uid = uid;
            this.tree = tree;
            this.cupboard = cupboard;
            label4.Text = (uid-1).ToString();

        }

        private void ViewCupboard_Load(object sender, EventArgs e)
        {
            SetComboboxValues("Piece", "Ref", "Panneau HB", "Couleur", pepCombobox4);
            SetComboboxValues("Piece", "Ref", "Porte", "Couleur", pepCombobox3);

            SetComboboxValues("Piece", "Ref", "Panneau GD", "hauteur", pepCombobox5);
            SetComboboxValues("Piece", "Ref", "Panneau GD", "profondeur", pepCombobox2);
            SetComboboxValues("Piece", "Ref", "Panneau Ar", "largeur", pepCombobox1);
            //test
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {


        }

        public void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("testr");
            RemoveCupboard();

        }
        public void RemoveCupboard()
        {
            Console.WriteLine("suppr");
            tree.Nodes.RemoveAt(Uid-1);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        public void SetComboboxValues(string table, string param, string value, string cond, ComboBox pepCombobox)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            Console.WriteLine("Getting Connection ...");
            //toolStripStatusLabel1.Text = "Getting Connection ...";

            var reader = DBMethods.DataBaseMethods.SqlSearch(table, param, "'" + value + "'", conn);

            while (reader.Read())
            {
                if (pepCombobox.Items.Contains(reader.GetString(cond)) == false)
                {
                    if (cond == "hauteur")
                    {
                        var height = int.Parse(reader.GetString("hauteur"));
                        height += 4;
                        height.ToString();

                        if (pepCombobox.Items.Contains(height) == false)
                        {
                            pepCombobox.Items.Add(height);
                        }
                    }
                    else
                    {
                        pepCombobox.Items.Add(reader.GetString(cond));
                    }
                }
            }

            reader.Close();
            conn.Close();
        }



    }
}
