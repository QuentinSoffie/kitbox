using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Kitbox.Customer.Views;
using Kitbox.Models.Order;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Kitbox.Customer
{
	/// <summary>
	/// This is the customer window. It shows all the customer's views.
	/// </summary>
	public partial class CustomerWindow : Form
	{
		private MySqlConnection DataBase;
		private TreeviewManager MainTreeview;
		public Order OurOrder;
		public CreateCustomer CustomerView;

		public CustomerWindow(MySqlConnection database)
		{
			InitializeComponent();
			DataBase = database;
			OurOrder = new Order();
			MainTreeview = new TreeviewManager(pepTreeView1, splitContainer1.Panel2.Controls, OurOrder, DataBase);
			Kitbox.Models.Database.Reader.InitializeComponents(DataBase);
			toolStripStatusLabel1.Text = "Welcome customer!";
		}

		private void RemoveCupboardOrder(int uid)
		{
			OurOrder.RemoveAt(uid);
		}

		public void SetTreeviewSelectedIndex()
		{
			pepTreeView1.SelectedNode = null;
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
      
        public void ExportPDF(string customer, string id, string state)
        {
			Kitbox.Models.Database.Json.Order orderJson = new Kitbox.Models.Database.Json.Order();
            DataTable dtbl = Kitbox.PDF.PDFUtils.MakeBill(OurOrder, orderJson);

			UpdateStock(customer, id, orderJson.Command, state);
				
			float cost = Kitbox.PDF.PDFUtils.CalculateCost(OurOrder, orderJson);
			CreateAndOpenPDF(dtbl, customer, id, cost, state);
		}

		public void UpdateStock(string customer, string id, Dictionary<string, int> order, string state)
		{
			string orderJsonString = JsonConvert.SerializeObject(order);
			MethodsDB.DataBaseMethods.SqlAddOrder(customer, id, orderJsonString, state , DataBase);

			if (state == "Completed ✓")
			{
				foreach (KeyValuePair<string, int> component in order)
				{
					StockDB.StockMethod.AddQtty(component.Key, -(component.Value), DataBase);
				}
			}
		}

		public void CreateAndOpenPDF(DataTable dtbl, string customer, string id, float cost, string state)
		{
			Kitbox.PDF.PDFUtils.ExportDataTableToPDF(dtbl, @"bill.pdf", "Facture : " + customer, id, cost, state);
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

		private void deleteAllCupboardsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClearWindow();
		}

		public void ClearWindow()
		{
			MainTreeview.ClearTreeview();
			splitContainer1.Panel2.Controls.Add(pictureBox1);
			splitContainer1.Panel2.Controls.Add(label1);
		}
	}
}
