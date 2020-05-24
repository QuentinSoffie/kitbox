using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMethods;
using MySql.Data.MySqlClient;

namespace Kitbox.PDF
{
    public class PDFUtils
    {
        public static DataTable MakeBill(Kitbox.Order.Order order, Kitbox.Database.Json.Order orderDataBase)
        {
            DataTable bill = new DataTable();
            float TotalBill = 0;

            //Define columns
            bill.Columns.Add("Code");
            bill.Columns.Add("Pièce");
            bill.Columns.Add("Dimension");
            bill.Columns.Add("Quantité");
            bill.Columns.Add("Prix unitaire (€)");
            bill.Columns.Add("Prix total (€)");

            List<List<string>> a = order.MakeOrder();
            foreach (List<string> item in a)
            {
                float cost = 1;
                string price = "";
                MySqlConnection conn = DBMethods.DBUtils.GetDBConnection("customer", "groupe2020");
                conn.Open();

                MySqlDataReader reader = DBMethods.DataBaseMethods.SqlSearch("Piece", "Code", string.Format("'{0}'", item[0]), conn);
                while (reader.Read())
                {
                    price = reader["Prix-Client"].ToString();
                }
                cost *= Int32.Parse(item[3]) * float.Parse(price);
                TotalBill += cost;
                reader.Close();
                conn.Close();
                Console.WriteLine(price);
                item.Add(price);
                item.Add(cost.ToString());
                Console.WriteLine(item[4]);

                bill.Rows.Add(item.ToArray());

                //Création du JSON
                orderDataBase.Command.Add(item[0], Int32.Parse(item[3]));
            }
            return bill;
        }

        public static float CalculateCost(Kitbox.Order.Order order, Kitbox.Database.Json.Order orderDataBase)
        {
            float TotalBill = 0;
            foreach (List<string> item in order.MakeOrder())
            {
                float cost = 1;
                string price = "";

                MySqlConnection conn = DBMethods.DBUtils.GetDBConnection("customer", "groupe2020");
                conn.Open();

                MySqlDataReader reader = DBMethods.DataBaseMethods.SqlSearch("Piece", "Code", string.Format("'{0}'", item[0]), conn);
                while (reader.Read())
                {

                    price = reader["Prix-Client"].ToString();
                }
                cost *= Int32.Parse(item[3]) * float.Parse(price);
                TotalBill += cost;
                reader.Close();
            }

            return TotalBill;
        }


        public static void ExportDataTableToPDF(DataTable dtblTable, string strPdfPath, string strHeader, string id, float cost, string state)
        {
            System.IO.FileStream fs = null;

            int open = 0;
            while (open == 0)
            {
                try
                {
                    fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
                    open = 1;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Please close your pdf file", "Error");
                }
            }

            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 24, 1, BaseColor.GRAY);
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
            prgAuthor.Add(new Chunk("\nClient number : " + id, fntAuthor));
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

            document.Add(new Chunk("\n", fntHead));

            if(state == "Completed ✓")
            {
                BaseFont btnTotal = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font fntTotal = new Font(btnTotal, 16, 1, BaseColor.GRAY);
                Paragraph prgTotal = new Paragraph();
                prgTotal.Alignment = Element.ALIGN_RIGHT;
                prgTotal.Add(new Chunk($"Le coût total de la commande revient à : {cost}€", fntTotal));
                document.Add(prgTotal);
            }
            if(state == "Not completed")
            {
                BaseFont btnTotal = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font fntTotal = new Font(btnTotal, 16, 1, BaseColor.GRAY);
                Paragraph prgTotal = new Paragraph();
                prgTotal.Alignment = Element.ALIGN_RIGHT;
                prgTotal.Add(new Chunk($"Le coût total de la commande revient à : {cost}€", fntTotal));
                prgTotal.Add(new Chunk($"\nAcompte à payer de  : {Math.Round(cost*0.2,2)}€", fntTotal));
                document.Add(prgTotal);
            }
            if (state == "Finished")
            {
                BaseFont btnTotal = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font fntTotal = new Font(btnTotal, 16, 1, BaseColor.GRAY);
                Paragraph prgTotal = new Paragraph();
                prgTotal.Alignment = Element.ALIGN_RIGHT;
                prgTotal.Add(new Chunk($"Le coût total de la commande revient à : {cost}€", fntTotal));
                prgTotal.Add(new Chunk($"\nIl vous reste à payer  : {Math.Round(cost - (cost * 0.2), 2)}€", fntTotal));
                document.Add(prgTotal);
            }

            document.Close();
            writer.Close();
            fs.Close();
        }

        public static DataTable MakePurchase(List<Dictionary<string,string>> order)
        {
            DataTable bill = new DataTable();

            //Define columns
            bill.Columns.Add("Code");
            bill.Columns.Add("Pièce");
            bill.Columns.Add("Dimension");
            bill.Columns.Add("Quantité");
            bill.Columns.Add("Prix unitaire (€)");
            bill.Columns.Add("Prix total (€)");

            foreach (Dictionary<string,string> component in order)
            {
                List<string> Row = new List<string>();

                float price = float.Parse(component["CustomerPrice"].ToString());
                int stockmin = int.Parse(component["StockMin"].ToString());
                int qtty = int.Parse(component["Stock"].ToString());

                int toOrder = ((stockmin * 2) - qtty);
                float cost = toOrder * price;

                Row.Add(component["Ref"]);
                Row.Add(component["Code"]);
                Row.Add(component["Dimensions"]);
                Row.Add(toOrder.ToString());
                Row.Add(price.ToString());
                Row.Add(cost.ToString());

                bill.Rows.Add(Row.ToArray());

            }
            return bill;
        }

        public static DataTable MakeTable(List<Dictionary<string, string>> order)
        {
            DataTable bill = new DataTable();

            //Define columns
            bill.Columns.Add("Code");
            bill.Columns.Add("Pièce");
            bill.Columns.Add("Dimension");
            bill.Columns.Add("Quantité");
            bill.Columns.Add("Prix unitaire");
            bill.Columns.Add("Prix total");

            foreach (Dictionary<string, string> component in order)
            {
                List<string> Row = new List<string>();

                float price = float.Parse(component["CustomerPrice"].ToString());
                int qtty = int.Parse(component["Quantity"].ToString());

   
                float cost = qtty * price;

                Row.Add(component["Ref"]);
                Row.Add(component["Code"]);
                Row.Add(component["Dimensions"]);
                Row.Add(qtty.ToString());
                Row.Add(price.ToString());
                Row.Add(cost.ToString());

                bill.Rows.Add(Row.ToArray());

            }
            return bill;
        }



        public static string TotalCost(List<Dictionary<string, string>> order)
        {
            float totalBill = 0;
            foreach (Dictionary<string, string> component in order)
            {
                List<string> Row = new List<string>();

                float price = float.Parse(component["CustomerPrice"].ToString());

                int qtty = int.Parse(component["Quantity"].ToString());
                float cost = qtty * price;

                totalBill += cost;
            }

            return totalBill.ToString();
        }

        public static string ComputeCost(List<Dictionary<string, string>> order)
        {
            float totalBill = 0;
            foreach (Dictionary<string, string> component in order)
            {
                List<string> Row = new List<string>();

                float price = float.Parse(component["CustomerPrice"].ToString());
                int stockmin = int.Parse(component["StockMin"].ToString());
                int qtty = int.Parse(component["Stock"].ToString());

                int toOrder = ((stockmin * 2) - qtty);
                float cost = toOrder * price;

                totalBill += cost;
            }

            return totalBill.ToString();
        }

        public static void ExportOrderSupplierToPDF(List<Dictionary<string, string>> order, string strPdfPath, string strHeader, string name)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 24, 1, BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Auteur
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 16, 1, BaseColor.GRAY);
            Paragraph prgAuthor = new Paragraph();
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Author : Fournisseur " + name, fntAuthor));
            prgAuthor.Add(new Chunk("\nClient : KitBox Company ", fntAuthor));
            prgAuthor.Add(new Chunk("\nDate de la facture : " + DateTime.Now.ToShortDateString(), fntAuthor));
            document.Add(prgAuthor);

            //Ajout d'un ligne de séparation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

            //Ajout d'un espace
            document.Add(new Chunk("\n", fntHead));

            //Ajout de la table
            DataTable dtblTable = MakePurchase(order);

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
            document.Add(new Chunk("\n", fntHead));

            BaseFont btnTotal = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntTotal = new Font(btnTotal, 16, 1, BaseColor.GRAY);
            Paragraph prgTotal = new Paragraph();
            prgTotal.Alignment = Element.ALIGN_RIGHT;
            prgTotal.Add(new Chunk($"Le coût total de la commande revient à : {ComputeCost(order)}€", fntTotal));
            document.Add(prgTotal);

            document.Add(new Chunk("\n", fntHead));

            document.Close();
            writer.Close();
            fs.Close();
        }
    }
}