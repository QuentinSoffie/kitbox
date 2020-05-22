using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DBMethods;
using Kitbox.GUI;
using Kitbox.GUI.StoreKeeper;

namespace GUI
{
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private bool Connecting = false; 

        private void Connection(){
            try
            {
                Connecting = true;
                pepButton1.Enabled = false;
                MySqlConnection myDataBase = DBUtils.GetDBConnection(pepTextbox1.Text, pepTextbox2.Text);
                myDataBase.Open();
                myDataBase.Close();

                if(pepTextbox1.Text == "storekeep")
                {
                    StoreKeeper obj = new StoreKeeper(myDataBase, this, pepTextbox1.Text, pepTextbox2.Text);
                    obj.Show();
                    this.Visible = false;
                }

            }
            catch (Exception ex)
            {
                CustomPopup obj = new CustomPopup("Unable to connect to the database : " + ex.Message);
                obj.Show(this);
            }
            pepTextbox1.Text = "";
            pepTextbox2.Text = "";
            pepButton1.Enabled = true;
            Connecting = false;
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            Connection();
        }

        private void pepTextbox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Connecting == false)
            {
                Connection();
            }
        }
    }
}
