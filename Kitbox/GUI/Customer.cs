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

		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About obj = new About();
			obj.Show(this);

		}

		#region function
		DataTable MakeDataTable(Order order)
		{
			DataTable bill = new DataTable();

			//Define columns
			bill.Columns.Add("Code");
			bill.Columns.Add("Pièce");
			bill.Columns.Add("Dimension");
			bill.Columns.Add("Quantité");

			//Remplissage des colonnes (valeurs arbitraitre pour le moment mais à récupérer de Order)
			bill.Rows.Add("1", "Cornières", "32", "2");
			bill.Rows.Add("1", "Porte", "32*10", "5");
			bill.Rows.Add("1", "Traverse", "28*14", "6");
			bill.Rows.Add("1", "Coupelles", "", "5");

			return bill;

		}
		#endregion

		#region Events

		void ExportDataTableToPDF(DataTable dtblTable, string strPdfPath, string strHeader)
		{
			System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
			Document document = new Document();
			document.SetPageSize(iTextSharp.text.PageSize.A4);
			PdfWriter writer = PdfWriter.GetInstance(document, fs);
			document.Open();

			//Report Header
			BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			Font fntHead = new Font(bfntHead, 16, 1, BaseColor.GRAY);
			Paragraph prgHeading = new Paragraph();
			prgHeading.Alignment = Element.ALIGN_CENTER;
			prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
			document.Add(prgHeading);

			//Auteur
			BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			Font fntAuthor = new Font(btnAuthor, 16, 1, BaseColor.GRAY);
			Paragraph prgAuthor = new Paragraph();
			prgAuthor.Alignment = Element.ALIGN_RIGHT;
			prgAuthor.Add(new Chunk("Author : KitBox Company", fntAuthor));
			prgAuthor.Add(new Chunk("\nDate de la facture : " + DateTime.Now.ToShortDateString(), fntAuthor));
			document.Add(prgAuthor);

			//Ajout d'un ligne de séparation
			Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

			//Ajout d'un espace
			document.Add(new Chunk("\n", fntHead));

			//Ajout de la table
			PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
			//En-tête du tableau
			BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, BaseColor.WHITE);
			for (int i = 0; i < dtblTable.Columns.Count; i++)
			{
				PdfPCell cell = new PdfPCell();
				cell.BackgroundColor = BaseColor.GRAY;
				cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
				table.AddCell(cell);
			}

			//Tableau de données
			for (int i = 0; i < dtblTable.Rows.Count; i++)
			{
				for (int j = 0; j < dtblTable.Columns.Count; j++)
				{
					table.AddCell(dtblTable.Rows[i][j].ToString());
				}
			}

			document.Add(table);
			document.Close();
			writer.Close();
			fs.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				Console.WriteLine("Bouton cliqué");
				DataTable dtbl = MakeDataTable(OurOrder);
				ExportDataTableToPDF(dtbl, @"bill.pdf", "Facture client");
				System.Diagnostics.Process.Start(@"bill.pdf");
				this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error Message");
			}
		}
		#endregion
	}
}
