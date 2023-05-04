using Invoice;
using Invoice.Model;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Syncfusion.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Net.Http;

namespace MyFirstDeskTopApp
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();

        }
        static string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public DataTable SelectBuyer()
        {
            //Connection Database
            SqlConnection conn = new SqlConnection(ConnString);
            DataTable dt = new DataTable();

            try
            {
                //Writing SQL Query
                string sql = "SELECT * FROM BuyerInfo";

                //Creating Sql Using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Creating SQL DataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }

            return dt;

        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            //InsertDialog d = new InsertDialog();
            //d.ShowDialog();

            // mypdf.SaveAs("FirstPDFDocument.pdf");

            //InvoiceDocument i = new InvoiceDocument();

            //InvoiceModel model = new InvoiceModel();

            // i.GeneratePdf(Stream.Null, model);


            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4);
                    Document pdfDoc = new Document(PageSize.A4, 50, 50, 50, 50);
                    
                    PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));
                    /*doc.Open();
                    doc.AddHeader("Dhairya", "Soni");
                    doc.Add(new iTextSharp.text.Paragraph("HELLO WORLD"));
                    doc.Close();*/


                   // GenerateInvoice("kj", pdfDoc);

                    OrderConfirmation oc = new OrderConfirmation();
                    CommissionInvoice ci = new CommissionInvoice();

                    ci.GenerateInvoice(pdfDoc);


                }
            }






        }


        public void GenerateInvoice(string TransactionID, Document pdfDoc)
        {
            List<string> col1 = new List<string> { "Order Number", "Order Date", "Buyer", "Seller", "Physical Supplier", "Vessel Name", "IMO Number", "Port", "Supply Location", "Supply Mode", "ETA", "Laycan", "Product Grade", "Specification", "Quantity", "Product Price", "Other Cost", "Credit Period", "Agemts", "Remarks" };
            List<string> col2 = new List<string> { "Order Number", "Order Date", "Buyer", "Seller", "Physical Supplier", "Vessel Name", "IMO Number", "Port", "Supply Location", "Supply Mode", "ETA", "Laycan", "Product Grade", "Specification", "Quantity", "Product Price", "Other Cost", "Credit Period", "Agemts", "Remarks" };

            MemoryStream PDFData = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, PDFData);

            var titleFont = FontFactory.GetFont("Arial", 12, BaseColor.BLACK);
            var titleFontBlue = FontFactory.GetFont("Arial", 15,1, WebColors.GetRGBColor("#08529b"));
            var portFontBlue = FontFactory.GetFont("Arial", 12, 1, WebColors.GetRGBColor("#08529b"));
            var boldTableFont = FontFactory.GetFont("Arial", 10,1, BaseColor.BLACK);
            var bodyFont = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
            var bodyFontGray = FontFactory.GetFont("Arial", 11, BaseColor.DARK_GRAY);
            var EmailFont = FontFactory.GetFont("Arial", 8,  BaseColor.BLUE);
            BaseColor TabelHeaderBackGroundColor = WebColors.GetRGBColor("#EEEEEE");

            bool color = false;
            

            iTextSharp.text.Rectangle pageSize = writer.PageSize;
           

            // Open the Document for writing
            pdfDoc.Open();
            //Add elements to the document here

            #region Top table
            // Create the header table 
  

            PdfPTable headerLine = new PdfPTable(1);
            
            PdfPCell headerCell = new PdfPCell();
            headerCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            headerCell.BorderColorBottom = WebColors.GetRGBColor("#08529b");
            headerCell.BorderWidthBottom = 3f;
            headerLine.SpacingAfter = 10;
            headerLine.WidthPercentage = 110;
            headerLine.AddCell(headerCell);
           
            pdfDoc.Add(headerLine);

            PdfPTable headertable = new PdfPTable(3);
            headertable.HorizontalAlignment = 0;
            headertable.WidthPercentage = 100;
            headertable.SetWidths(new float[] { 200f, 320f, 100f });  // then set the column's __relative__ widths
            headertable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
           
            headertable.SpacingAfter = 10;
            headertable.DefaultCell.Border = iTextSharp.text.Rectangle.BOX; //for testing           

           iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(@"../../../Assets/seastar-bunkering.png");
            logo.ScaleToFit(500, 75);

            {
                PdfPTable nested = new PdfPTable(1);
                nested.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                PdfPCell nextPostCell1 = new PdfPCell(new Phrase("SEA STAR BUNKERS", titleFontBlue));
                nextPostCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nested.AddCell(nextPostCell1);
                PdfPCell nextPostCell2 = new PdfPCell(new Phrase("D 707, Jaldeep Icon,", bodyFontGray));
                nextPostCell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nested.AddCell(nextPostCell2);
                PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Opp Torrent Power Station", bodyFontGray));
                nextPostCell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nested.AddCell(nextPostCell3);
                PdfPCell nextPostCell4 = new PdfPCell(new Phrase("Ahmedabad", bodyFontGray));
                nextPostCell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nested.AddCell(nextPostCell4);
               
                PdfPCell nextPostCell5 = new PdfPCell(new Phrase("India", bodyFontGray));
                nextPostCell5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nested.AddCell(nextPostCell5);
                nested.AddCell("");
                PdfPCell nesthousing = new PdfPCell(nested);
                nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nesthousing.Rowspan = 5;
                nesthousing.PaddingBottom = 10f;
                headertable.AddCell(nesthousing);

            }

            {
                PdfPCell middlecell = new PdfPCell();
                middlecell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                headertable.AddCell(middlecell);
            }

            {
                

                PdfPCell pdfCelllogo = new PdfPCell(logo);
                pdfCelllogo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                headertable.AddCell(pdfCelllogo);
            }




            headertable.SpacingBefore = 10;
            pdfDoc.Add(headertable);

            PdfPTable portTable = new PdfPTable(1);
            portTable.WidthPercentage = 100;
            PdfPCell portCell = new PdfPCell(new Phrase("Order Confirmation - 720008102203 - Navimar 3 -Kakinada - 10-11 Oct 2022", portFontBlue));
            portCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            portCell.PaddingBottom = 5f;
            portCell.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
            portCell.BorderWidthBottom = 1f;
            portTable.AddCell(portCell);
            pdfDoc.Add(portTable);
           
            #endregion

            #region Items Table
            //Create body table
            PdfPTable itemTable = new PdfPTable(2);

            itemTable.HorizontalAlignment = 0;
            itemTable.WidthPercentage = 100;
            itemTable.SetWidths(new float[] {25,70 });  // then set the column's __relative__ widths
            itemTable.SpacingAfter = 15;
            itemTable.SpacingBefore = 10;
            itemTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
         

            foreach(var i in col1)
            {
                var c = BaseColor.WHITE;
                if (color)
                {
                    c = WebColors.GetRGBColor("#F3F3F3");
                }
                else {
                    c = BaseColor.WHITE;
                }

                PdfPCell c1 = new PdfPCell(new Phrase(i, boldTableFont));
                c1.BackgroundColor = c;
                c1.HorizontalAlignment = Element.ALIGN_LEFT;
                c1.VerticalAlignment = Element.ALIGN_CENTER;
                c1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                c1.PaddingTop = 2;
                c1.PaddingBottom = 5;
                itemTable.AddCell(c1);

                PdfPCell c2 = new PdfPCell(new Phrase(i, bodyFont));
                c2.BackgroundColor = c;
                c2.HorizontalAlignment = Element.ALIGN_LEFT;
                c2.VerticalAlignment = Element.ALIGN_CENTER;
                c2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                c2.PaddingTop = 2;
                c2.PaddingBottom = 5;
                itemTable.AddCell(c2);

                color = !color;

            }


            // Table footer

            PdfPTable footerTable = new PdfPTable(1);
            footerTable.WidthPercentage = 100;
            PdfPCell footerCell1 = new PdfPCell(new Phrase("Order is subject to Sellers's / Suppliers terms and conditions, copies of which are available on request.Seller, Suppliers, Agents and Vessel to liase closely for smooth supply. ", boldTableFont));
            PdfPCell footerCell2 = new PdfPCell(new Phrase("Sea Star Bunkers acting as brokers without any liability.", boldTableFont));

            footerCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
            footerCell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
            footerCell2.PaddingTop = 10f;

            footerTable.AddCell(footerCell1);
            footerTable.AddCell(footerCell2);


            pdfDoc.Add(itemTable);
            pdfDoc.Add(footerTable);

            #endregion

            PdfContentByte cb = new PdfContentByte(writer);


            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, true);
            cb = new PdfContentByte(writer);
            cb = writer.DirectContent;
            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.SetTextMatrix(pageSize.GetLeft(120), 20);
            cb.ShowText("Invoice was created on a computer and is valid without the signature and seal. ");
            cb.EndText();

            //Move the pointer and draw line to separate footer section from rest of page
            cb.MoveTo(40, pdfDoc.PageSize.GetBottom(50));
            cb.LineTo(pdfDoc.PageSize.Width - 40, pdfDoc.PageSize.GetBottom(50));
            cb.Stroke();

            PdfContentByte content = writer.DirectContent;
            iTextSharp.text.Rectangle rectangle = new iTextSharp.text.Rectangle(pdfDoc.PageSize);
            rectangle.Left += pdfDoc.LeftMargin;
            rectangle.Right -= pdfDoc.RightMargin;
            rectangle.Top -= pdfDoc.TopMargin;
            rectangle.Bottom += pdfDoc.BottomMargin;
            rectangle.BorderWidthLeft = 2;
            rectangle.BorderWidthRight = 2;
            rectangle.BorderWidthTop = 2;
            rectangle.BorderWidthBottom = 2;    
            content.SetColorStroke(BaseColor.BLACK);

            
           
            content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
            content.Stroke();


            pdfDoc.Close();
            


        }


        private void ReloadData_Click(object sender, EventArgs e)
        {
            DataTable dt = this.SelectBuyer();
            Form1DataGrid.DataSource = dt;
            Syncfusion.Pdf.PdfDocument document = new Syncfusion.Pdf.PdfDocument();
        }
    }
}