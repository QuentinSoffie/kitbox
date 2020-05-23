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
using Kitbox.GUI.Views;
using System.Runtime.InteropServices;

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
		public CreateCustomer CustomerView;

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

		public void SetTreeviewSelectedIndex()
		{
			pepTreeView1.SelectedNode = null;
		}

		private void BeforeFormClosing(object sender, FormClosingEventArgs e)
		{
			Authentification.Visible = true;
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
            if (MainTreeview.CheckIfAllCupboardAreVerified())
            {
				CustomerView = new CreateCustomer(DataBase, this);
				CustomerView.Dock = DockStyle.Fill;
				splitContainer1.Panel2.Controls.Add(CustomerView);
				CustomerView.BringToFront();
			}
            else
            {
                CustomPopup obj = new CustomPopup("Please check each cupboard before confirming your order");
                obj.Show(this);
            }
		}
      
        public void ExportPDF(string customer, string id)
        {
            try
            {
                Kitbox.Database.Json.Order orderJson = new Kitbox.Database.Json.Order();
                DataTable dtbl = Kitbox.PDF.PDFUtils.MakeBill(OurOrder, orderJson);

				UpdateStock(customer, id, orderJson.Command);

				float cost = Kitbox.PDF.PDFUtils.CalculateCost(OurOrder, orderJson);
				CreateAndOpenPDF(dtbl, customer, id, cost);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

		public void UpdateStock(string customer, string id, Dictionary<string, int> order)
		{
			string orderJsonString = JsonConvert.SerializeObject(order);
			DBMethods.DataBaseMethods.SqlAddOrder(customer, id, orderJsonString, "Complete", DataBase);

			foreach(KeyValuePair<string, int> component in order)
			{
				StockDB.StockMethod.AddQtty(component.Key, -(component.Value), DataBase);
			}
		}

		public void CreateAndOpenPDF(DataTable dtbl, string customer, string id, float cost)
		{
			Kitbox.PDF.PDFUtils.ExportDataTableToPDF(dtbl, @"bill.pdf", "Facture : " + customer, id, cost);
			System.Diagnostics.Process.Start(@"bill.pdf");
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About obj = new About();
			obj.Show(this);
		}

		private void storeKeeperToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Authentication auth = new Authentication();
			auth.Show();
		}
	}
}
