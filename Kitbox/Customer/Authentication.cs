using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MethodsDB;
using Kitbox.StoreKeeper;

namespace Kitbox.Customer
{
    /// <summary>
    /// This is the auth window. It connects the storekeeper to the admin panel.
    /// </summary>
    public partial class Authentication : Form
    {
        private bool Connecting = false;

        public Authentication()
        {
            InitializeComponent();
        }

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
                    StoreKeeperWindow obj = new StoreKeeperWindow(myDataBase, this, pepTextbox1.Text, pepTextbox2.Text);
                    obj.Show();
                    this.Visible = false;
                    this.Close();
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
