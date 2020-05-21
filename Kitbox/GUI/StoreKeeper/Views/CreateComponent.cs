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
    public partial class CreateComponent : UserControl
    {
        public new StoreKeeper Parent { get; set; }
        public MySqlConnection DataBase { get; set; }
        public CreateComponent(MySqlConnection dataBase, StoreKeeper parent)
        {
            InitializeComponent();
            Parent = parent;
            DataBase = dataBase;
            pepCombobox1.SelectedIndex = 0;
        }

        private void pepTextbox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Key pressed");
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch!= 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Key pressed");
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Key pressed");
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Key pressed");
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            string reference = pepCombobox1.Text;
            string code = pepTextbox1.Text.ToUpper();
            string dimensions = pepTextbox2.Text;
            int height = int.Parse(pepNumericUpDown1.Value.ToString());
            int width = int.Parse(pepNumericUpDown2.Value.ToString());
            int depth = int.Parse(pepNumericUpDown3.Value.ToString());
            string color = pepTextbox3.Text;
            int initStock = int.Parse(pepNumericUpDown4.Value.ToString());
            int minStock = int.Parse(pepNumericUpDown5.Value.ToString());
            string price = textBox1.Text;
            int qttyPart = int.Parse(pepNumericUpDown8.Value.ToString());
            string priceFourn1 = textBox2.Text;
            int deleivery1 = int.Parse(pepNumericUpDown6.Value.ToString());
            string priceFourn2 = textBox3.Text;
            int delivery2 = int.Parse(pepNumericUpDown7.Value.ToString());

            Console.WriteLine(dimensions);

            StockDB.StockMethod.AddComponent(reference, code, dimensions, height, width, depth, color, initStock, minStock, price, qttyPart, priceFourn1, deleivery1, priceFourn2, delivery2, DataBase);
        }

    }
}
