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

namespace GUI
{
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myDataBase = DBUtils.GetDBConnection(pepTextbox1.Text, pepTextbox2.Text);
                myDataBase.Open();
                Customer obj = new Customer(myDataBase,this, pepTextbox1.Text, pepTextbox2.Text);
                obj.Show();
                this.Visible = false;
            }
            catch(Exception ex)
            {
                CustomPopup obj = new CustomPopup("Unable to connect to the database : " + ex.Message );
                obj.Show(this);
            }
            pepTextbox1.Text = "";
            pepTextbox2.Text = "";
                
          
        }
    }
}
