using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitbox.GUI;
using Kitbox.Components;
using DBMethods;
using MySql.Data.MySqlClient;
using Kitbox.Order;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Newtonsoft.Json;

namespace GUI
{
	public partial class Customer : Form
	{

		private MySqlConnection DataBase;
		private Authentication Authentification;
		private TreeviewManager MainTreeview;
		private readonly string Username;
		private readonly string Password;
		private Kitbox.Order.Order OurOrder;

		public Customer(MySqlConnection database, Authentication authentification, string username, string password)
		{
			InitializeComponent();
			DataBase = database;
			OurOrder = new Kitbox.Order.Order();
			MainTreeview = new TreeviewManager(pepTreeView1, splitContainer1.Panel2.Controls, OurOrder, DataBase);
			Authentification = authentification;
			Username = username;
			Password = password;
			Kitbox.Database.Reader.InitializeComponents(DataBase);
			toolStripStatusLabel1.Text = "Welcome " + Username;

		}

		private void RemoveCupboardOrder(int uid)
		{
			OurOrder.RemoveAt(uid);
		}

		private void BeforeFormClosing(object sender, FormClosingEventArgs e)
		{
			Authentification.Visible = true;
		}


		private void toolStripStatusLabel1_Click(object sender, EventArgs e)
		{

		}


		private void button1_Click(object sender, EventArgs e)
		{

			MainTreeview.AddCupboard(OurOrder);
		}



		private void pepTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			int uidClicked = int.Parse(e.Node.Name);
			MainTreeview.BringToFrontView(uidClicked);
		}

		private void button2_Click(object sender, EventArgs e)
		{
            exportPDF();
		}

        public void exportPDF()
        {
            try
            {
                Kitbox.Database.Json.Order orderJson = new Kitbox.Database.Json.Order();
                DataTable dtbl = Kitbox.PDF.PDFUtils.MakeBill(OurOrder, orderJson);
                string orderJsonString = JsonConvert.SerializeObject(orderJson);


                Kitbox.PDF.PDFUtils.ExportDataTableToPDF(dtbl, @"bill.pdf", "Facture client");
                System.Diagnostics.Process.Start(@"bill.pdf");
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About obj = new About();
			obj.Show(this);

		}

	
	}
}
