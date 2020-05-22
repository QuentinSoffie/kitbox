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
            bill.Columns.Add("Prix unitaire");
            bill.Columns.Add("Prix total");


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


        public static void ExportDataTableToPDF(DataTable dtblTable, string strPdfPath, string strHeader, string id, float cost)
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

            BaseFont btnTotal = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntTotal = new Font(btnTotal, 16, 1, BaseColor.GRAY);
            Paragraph prgTotal = new Paragraph();
            prgTotal.Alignment = Element.ALIGN_LEFT;
            prgTotal.Add(new Chunk("Le coût total de la commande revient à : " + cost, fntTotal));
            document.Add(prgTotal);


            document.Close();
            writer.Close();
            fs.Close();
        }
    }
}
