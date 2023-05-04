using iTextSharp.text.html;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstDeskTopApp
{
    internal class CommissionInvoice
    {
        public void GenerateInvoice(Document pdfDoc)
        {
            List<string> product = new List<string> { "Order Number"};
            List<int> qtyList = new List<int> { 5 };
            List<int> rateList = new List<int> { 200 };
            List<int> priceList = new List<int> { 1000 };

            MemoryStream PDFData = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, PDFData);

            var titleFont = FontFactory.GetFont("Arial", 12, BaseColor.BLACK);
            var titleFontBlue = FontFactory.GetFont("Arial", 15, 1, WebColors.GetRGBColor("#08529b"));
            var portFontBlue = FontFactory.GetFont("Arial", 13, 1, WebColors.GetRGBColor("#08529b"));
            var boldTableFont = FontFactory.GetFont("Arial", 9, 1, BaseColor.BLACK);
            var boldTableFontGray = FontFactory.GetFont("Arial", 9, 1, BaseColor.GRAY);
            var bodyFont = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
            var bodyFontGray = FontFactory.GetFont("Arial", 9, BaseColor.DARK_GRAY);
            var bodyFontBlue = FontFactory.GetFont("Arial", 9, WebColors.GetRGBColor("#08529b"));
            var EmailFont = FontFactory.GetFont("Arial", 8, BaseColor.BLUE);
            var dateFont = FontFactory.GetFont("Arial", 12,1, BaseColor.PINK);
            var balanceDueFont = FontFactory.GetFont("Arial", 8, 1, BaseColor.PINK);
            var footerFont = FontFactory.GetFont("Arial", 5, BaseColor.BLACK);
            var footerFontBold = FontFactory.GetFont("Arial", 6, 1, BaseColor.BLACK);
            BaseColor TabelHeaderBackGroundColor = WebColors.GetRGBColor("#EEEEEE");

            bool color = true;


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

            PdfPTable textTable = new PdfPTable(1);
            textTable.WidthPercentage = 100;
            PdfPCell textCell = new PdfPCell(new Phrase("Commission Invoice", portFontBlue));
            textCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            textCell.PaddingBottom = 5f;

            PdfPCell dateCell = new PdfPCell(new Phrase("Invoice Date", dateFont));
            dateCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            textTable.AddCell(textCell);
            textTable.AddCell(dateCell);
            pdfDoc.Add(textTable);

            #endregion

            #region Items Table
            //Create body table
            PdfPTable invoiceDetailsTable = new PdfPTable(4);

            invoiceDetailsTable.HorizontalAlignment = 0;
            invoiceDetailsTable.WidthPercentage = 100;
            invoiceDetailsTable.SetWidths(new float[] { 40, 40, 20,30 });  // then set the column's __relative__ widths
            invoiceDetailsTable.SpacingAfter = 15;
            invoiceDetailsTable.SpacingBefore = 10;
            invoiceDetailsTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;


            {
                PdfPTable nested = new PdfPTable(1);

                PdfPCell invoiceFor = new PdfPCell(new Phrase("Invoice For", boldTableFont));
                PdfPCell invoiceName = new PdfPCell(new Phrase("ABC", bodyFontGray));
                PdfPCell invoiceAdd1 = new PdfPCell(new Phrase("Address line 1", bodyFontGray));
                PdfPCell invoiceAdd2 = new PdfPCell(new Phrase("Address line 2", bodyFontGray));
                PdfPCell invoicecountry = new PdfPCell(new Phrase("Country", bodyFontGray));

                invoiceFor.HorizontalAlignment = Element.ALIGN_LEFT;
                invoiceFor.VerticalAlignment = Element.ALIGN_CENTER;
                invoiceFor.Border = iTextSharp.text.Rectangle.NO_BORDER;
                invoiceFor.PaddingTop = 3;

                invoiceName.HorizontalAlignment = Element.ALIGN_LEFT;
                invoiceName.VerticalAlignment = Element.ALIGN_CENTER;
                invoiceName.Border = iTextSharp.text.Rectangle.NO_BORDER;
                invoiceName.PaddingTop = 3;

                invoiceAdd1.HorizontalAlignment = Element.ALIGN_LEFT;
                invoiceAdd1.VerticalAlignment = Element.ALIGN_CENTER;
                invoiceAdd1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                invoiceAdd1.PaddingTop = 3;

                invoiceAdd2.HorizontalAlignment = Element.ALIGN_LEFT;
                invoiceAdd2.VerticalAlignment = Element.ALIGN_CENTER;
                invoiceAdd2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                invoiceAdd2.PaddingTop = 3;

                invoicecountry.HorizontalAlignment = Element.ALIGN_LEFT;
                invoicecountry.VerticalAlignment = Element.ALIGN_CENTER;
                invoicecountry.Border = iTextSharp.text.Rectangle.NO_BORDER;
                invoicecountry.PaddingTop = 3;
                invoicecountry.PaddingBottom = 5;
                
                nested.AddCell(invoiceFor);
                nested.AddCell(invoiceName);
                nested.AddCell(invoiceAdd1);
                nested.AddCell(invoiceAdd2);
                nested.AddCell(invoicecountry);

                PdfPCell nesthousing = new PdfPCell(nested);
                nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nesthousing.Rowspan = 5;
                nesthousing.PaddingBottom = 10f;
                invoiceDetailsTable.AddCell(nesthousing);
            }

            {
                PdfPTable nested = new PdfPTable(1);

                PdfPCell payableTo = new PdfPCell(new Phrase("Payable To", boldTableFont));
                PdfPCell payableName = new PdfPCell(new Phrase("SEA STAR BUNKERS", bodyFontGray));
                

                payableTo.HorizontalAlignment = Element.ALIGN_LEFT;
                payableTo.VerticalAlignment = Element.ALIGN_CENTER;
                payableTo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                payableTo.PaddingTop = 3;

                payableName.HorizontalAlignment = Element.ALIGN_LEFT;
                payableName.VerticalAlignment = Element.ALIGN_CENTER;
                payableName.Border = iTextSharp.text.Rectangle.NO_BORDER;
                payableName.PaddingTop = 3;

                nested.AddCell(payableTo);
                nested.AddCell(payableName);

                PdfPCell nesthousing = new PdfPCell(nested);
                nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nesthousing.Rowspan = 5;
                nesthousing.PaddingBottom = 10f;
                invoiceDetailsTable.AddCell(nesthousing);
            }

            {
                PdfPTable nested = new PdfPTable(1);

                PdfPCell invoiceNo = new PdfPCell(new Phrase("Invoice #", bodyFontGray));
                PdfPCell buyer = new PdfPCell(new Phrase("Buyer", bodyFontGray));
                PdfPCell dueDate = new PdfPCell(new Phrase("Due Date", bodyFontGray));
                PdfPCell orderNo = new PdfPCell(new Phrase("Order Number", bodyFontGray));
                PdfPCell vesselName = new PdfPCell(new Phrase("Vessel Name", bodyFontGray));
                PdfPCell vesselType = new PdfPCell(new Phrase("Vessel Type", bodyFontGray));
                PdfPCell port = new PdfPCell(new Phrase("Port", bodyFontGray));
                PdfPCell deliveryDate = new PdfPCell(new Phrase("Delivery Date", bodyFontGray));
                PdfPCell LUT = new PdfPCell(new Phrase("LUT ARN", bodyFontGray));

                invoiceNo.HorizontalAlignment = Element.ALIGN_LEFT;
                invoiceNo.VerticalAlignment = Element.ALIGN_CENTER;
                invoiceNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                invoiceNo.PaddingTop = 3;

                buyer.HorizontalAlignment = Element.ALIGN_LEFT;
                buyer.VerticalAlignment = Element.ALIGN_CENTER;
                buyer.Border = iTextSharp.text.Rectangle.NO_BORDER;
                buyer.PaddingTop = 3;

                dueDate.HorizontalAlignment = Element.ALIGN_LEFT;
                dueDate.VerticalAlignment = Element.ALIGN_CENTER;
                dueDate.Border = iTextSharp.text.Rectangle.NO_BORDER;
                dueDate.PaddingTop = 3;

                orderNo.HorizontalAlignment = Element.ALIGN_LEFT;
                orderNo.VerticalAlignment = Element.ALIGN_CENTER;
                orderNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                orderNo.PaddingTop = 3;

                vesselName.HorizontalAlignment = Element.ALIGN_LEFT;
                vesselName.VerticalAlignment = Element.ALIGN_CENTER;
                vesselName.Border = iTextSharp.text.Rectangle.NO_BORDER;
                vesselName.PaddingTop = 3;

                vesselType.HorizontalAlignment = Element.ALIGN_LEFT;
                vesselType.VerticalAlignment = Element.ALIGN_CENTER;
                vesselType.Border = iTextSharp.text.Rectangle.NO_BORDER;
                vesselType.PaddingTop = 3;

                port.HorizontalAlignment = Element.ALIGN_LEFT;
                port.VerticalAlignment = Element.ALIGN_CENTER;
                port.Border = iTextSharp.text.Rectangle.NO_BORDER;
                port.PaddingTop = 3;

                deliveryDate.HorizontalAlignment = Element.ALIGN_LEFT;
                deliveryDate.VerticalAlignment = Element.ALIGN_CENTER;
                deliveryDate.Border = iTextSharp.text.Rectangle.NO_BORDER;
                deliveryDate.PaddingTop = 3;

                LUT.HorizontalAlignment = Element.ALIGN_LEFT;
                LUT.VerticalAlignment = Element.ALIGN_CENTER;
                LUT.Border = iTextSharp.text.Rectangle.NO_BORDER;
                LUT.PaddingTop = 3;

                nested.AddCell(invoiceNo);
                nested.AddCell(buyer);
                nested.AddCell(dueDate);
                nested.AddCell(orderNo);
                nested.AddCell(vesselName);
                nested.AddCell(vesselType);
                nested.AddCell(port);
                nested.AddCell(deliveryDate);
                nested.AddCell(LUT);

                PdfPCell nesthousing = new PdfPCell(nested);
                nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nesthousing.Rowspan = 5;
                nesthousing.PaddingBottom = 10f;
                invoiceDetailsTable.AddCell(nesthousing);
            }

            {
                PdfPTable nested = new PdfPTable(1);

                PdfPCell invoiceNo = new PdfPCell(new Phrase("Invoice #", bodyFontGray));
                PdfPCell buyer = new PdfPCell(new Phrase("Buyer", bodyFontGray));
                PdfPCell dueDate = new PdfPCell(new Phrase("Due Date", bodyFontGray));
                PdfPCell orderNo = new PdfPCell(new Phrase("Order Number", bodyFontGray));
                PdfPCell vesselName = new PdfPCell(new Phrase("Vessel Name", bodyFontGray));
                PdfPCell vesselType = new PdfPCell(new Phrase("Vessel Type", bodyFontGray));
                PdfPCell port = new PdfPCell(new Phrase("Port", bodyFontGray));
                PdfPCell deliveryDate = new PdfPCell(new Phrase("Delivery Date", bodyFontGray));
                PdfPCell LUT = new PdfPCell(new Phrase("LUT ARN", bodyFontGray));

                invoiceNo.HorizontalAlignment = Element.ALIGN_LEFT;
                invoiceNo.VerticalAlignment = Element.ALIGN_CENTER;
                invoiceNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                invoiceNo.PaddingTop = 3;

                buyer.HorizontalAlignment = Element.ALIGN_LEFT;
                buyer.VerticalAlignment = Element.ALIGN_CENTER;
                buyer.Border = iTextSharp.text.Rectangle.NO_BORDER;
                buyer.PaddingTop = 3;

                dueDate.HorizontalAlignment = Element.ALIGN_LEFT;
                dueDate.VerticalAlignment = Element.ALIGN_CENTER;
                dueDate.Border = iTextSharp.text.Rectangle.NO_BORDER;
                dueDate.PaddingTop = 3;

                orderNo.HorizontalAlignment = Element.ALIGN_LEFT;
                orderNo.VerticalAlignment = Element.ALIGN_CENTER;
                orderNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                orderNo.PaddingTop = 3;

                vesselName.HorizontalAlignment = Element.ALIGN_LEFT;
                vesselName.VerticalAlignment = Element.ALIGN_CENTER;
                vesselName.Border = iTextSharp.text.Rectangle.NO_BORDER;
                vesselName.PaddingTop = 3;

                vesselType.HorizontalAlignment = Element.ALIGN_LEFT;
                vesselType.VerticalAlignment = Element.ALIGN_CENTER;
                vesselType.Border = iTextSharp.text.Rectangle.NO_BORDER;
                vesselType.PaddingTop = 3;

                port.HorizontalAlignment = Element.ALIGN_LEFT;
                port.VerticalAlignment = Element.ALIGN_CENTER;
                port.Border = iTextSharp.text.Rectangle.NO_BORDER;
                port.PaddingTop = 3;

                deliveryDate.HorizontalAlignment = Element.ALIGN_LEFT;
                deliveryDate.VerticalAlignment = Element.ALIGN_CENTER;
                deliveryDate.Border = iTextSharp.text.Rectangle.NO_BORDER;
                deliveryDate.PaddingTop = 3;

                LUT.HorizontalAlignment = Element.ALIGN_LEFT;
                LUT.VerticalAlignment = Element.ALIGN_CENTER;
                LUT.Border = iTextSharp.text.Rectangle.NO_BORDER;
                LUT.PaddingTop = 3;

                nested.AddCell(invoiceNo);
                nested.AddCell(buyer);
                nested.AddCell(dueDate);
                nested.AddCell(orderNo);
                nested.AddCell(vesselName);
                nested.AddCell(vesselType);
                nested.AddCell(port);
                nested.AddCell(deliveryDate);
                nested.AddCell(LUT);

                PdfPCell nesthousing = new PdfPCell(nested);
                nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nesthousing.Rowspan = 5;
                nesthousing.PaddingBottom = 10f;
                invoiceDetailsTable.AddCell(nesthousing);
            }

            PdfPTable dividerLine = new PdfPTable(1);
            PdfPCell dividerCell = new PdfPCell();
            dividerCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dividerCell.BorderColorBottom = BaseColor.BLACK;
            dividerCell.BorderWidthBottom = 1f;
            dividerLine.SpacingAfter = 10;
            dividerLine.WidthPercentage = 100;
            dividerLine.AddCell(dividerCell);

            

            PdfPTable invoiceitemsTable = new PdfPTable(4);
            invoiceitemsTable.HorizontalAlignment = 0;
            invoiceitemsTable.WidthPercentage = 100;
            invoiceitemsTable.SetWidths(new float[] { 40, 40, 20, 30 });  // then set the column's __relative__ widths
            invoiceitemsTable.SpacingAfter = 15;
            invoiceitemsTable.SpacingBefore = 10;
            invoiceitemsTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            PdfPTable itemTable = new PdfPTable(4);

            itemTable.HorizontalAlignment = 0;
            itemTable.WidthPercentage = 100;
            itemTable.SetWidths(new float[] { 120, 30, 30, 40 });  // then set the column's __relative__ widths
            itemTable.SpacingAfter = 15;
            itemTable.SpacingBefore = 10;
            itemTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            PdfPCell product_Description = new PdfPCell(new Phrase("Product Description", bodyFontBlue));
            product_Description.BackgroundColor = BaseColor.WHITE;
            product_Description.HorizontalAlignment = Element.ALIGN_LEFT;
            product_Description.VerticalAlignment = Element.ALIGN_CENTER;
            product_Description.Border = iTextSharp.text.Rectangle.NO_BORDER;
            product_Description.PaddingTop = 2;
            product_Description.PaddingBottom = 5;
            itemTable.AddCell(product_Description);

            PdfPCell qty = new PdfPCell(new Phrase("Qty", bodyFontBlue));
            qty.BackgroundColor = BaseColor.WHITE;
            qty.HorizontalAlignment = Element.ALIGN_LEFT;
            qty.VerticalAlignment = Element.ALIGN_CENTER;
            qty.Border = iTextSharp.text.Rectangle.NO_BORDER;
            qty.PaddingTop = 2;
            qty.PaddingBottom = 5;
            itemTable.AddCell(qty);

            PdfPCell rate = new PdfPCell(new Phrase("Rate", bodyFontBlue));
            rate.BackgroundColor = BaseColor.WHITE;
            rate.HorizontalAlignment = Element.ALIGN_LEFT;
            rate.VerticalAlignment = Element.ALIGN_CENTER;
            rate.Border = iTextSharp.text.Rectangle.NO_BORDER;
            rate.PaddingTop = 2;
            rate.PaddingBottom = 5;
            itemTable.AddCell(rate);

            PdfPCell price = new PdfPCell(new Phrase("Total Price", bodyFontBlue));
            price.BackgroundColor = BaseColor.WHITE;
            price.HorizontalAlignment = Element.ALIGN_RIGHT;
            price.VerticalAlignment = Element.ALIGN_CENTER;
            price.Border = iTextSharp.text.Rectangle.NO_BORDER;
            price.PaddingTop = 2;
            price.PaddingBottom = 5;
            itemTable.AddCell(price);

            for(var i= 0; i<product.Count; i++)
            {
                var c = BaseColor.WHITE;
                if (color)
                {
                    c = WebColors.GetRGBColor("#F3F3F3");
                }
                else
                {
                    c = BaseColor.WHITE;
                }

                PdfPCell c1 = new PdfPCell(new Phrase(product[i], boldTableFont));
                c1.BackgroundColor = c;
                c1.HorizontalAlignment = Element.ALIGN_LEFT;
                c1.VerticalAlignment = Element.ALIGN_CENTER;
                c1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                c1.PaddingTop = 2;
                c1.PaddingBottom = 5;
                itemTable.AddCell(c1);

                PdfPCell c2 = new PdfPCell(new Phrase(qtyList[i].ToString(), bodyFont));
                c2.BackgroundColor = c;
                c2.HorizontalAlignment = Element.ALIGN_LEFT;
                c2.VerticalAlignment = Element.ALIGN_CENTER;
                c2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                c2.PaddingTop = 2;
                c2.PaddingBottom = 5;

                PdfPCell c3 = new PdfPCell(new Phrase(rateList[i].ToString(), bodyFont));
                c3.BackgroundColor = c;
                c3.HorizontalAlignment = Element.ALIGN_LEFT;
                c3.VerticalAlignment = Element.ALIGN_CENTER;
                c3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                c3.PaddingTop = 2;
                c3.PaddingBottom = 5;

                PdfPCell c4 = new PdfPCell(new Phrase(priceList[i].ToString(), bodyFont));
                c4.BackgroundColor = c;
                c4.HorizontalAlignment = Element.ALIGN_RIGHT;
                c4.VerticalAlignment = Element.ALIGN_CENTER;
                c4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                c4.PaddingTop = 2;
                c4.PaddingBottom = 5;
                itemTable.AddCell(c2);
                itemTable.AddCell(c3);
                itemTable.AddCell(c4);

                color = !color;

            }

            PdfPTable dividerLine1 = new PdfPTable(1);
            PdfPCell dividerCell1 = new PdfPCell();
            dividerCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dividerCell1.BorderColorBottom = BaseColor.BLACK;
            dividerCell1.BorderWidthBottom = 1f;
            dividerLine1.SpacingAfter = 10;
            dividerLine1.WidthPercentage = 100;
            dividerLine1.AddCell(dividerCell1);


            PdfPTable totalTable = new PdfPTable(4);

            totalTable.HorizontalAlignment = 0;
            totalTable.WidthPercentage = 100;
            totalTable.SetWidths(new float[] { 120, 30, 30, 40 });  // then set the column's __relative__ widths
            totalTable.SpacingAfter = 15;
            totalTable.SpacingBefore = 5;
            totalTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            totalTable.AddCell("");
            totalTable.AddCell("");


            {
                PdfPTable nested = new PdfPTable(1);

                PdfPCell subtotal = new PdfPCell(new Phrase("Subtotal", bodyFontBlue));
                PdfPCell balanceDue = new PdfPCell(new Phrase("Balance Due", balanceDueFont ));
                PdfPCell total = new PdfPCell(new Phrase("Total in Words", boldTableFont));
               
                subtotal.HorizontalAlignment = Element.ALIGN_LEFT;
                subtotal.VerticalAlignment = Element.ALIGN_CENTER;
                subtotal.Border = iTextSharp.text.Rectangle.NO_BORDER;
                subtotal.PaddingTop = 3;
                subtotal.PaddingBottom = 10;

                balanceDue.HorizontalAlignment = Element.ALIGN_LEFT;
                balanceDue.VerticalAlignment = Element.ALIGN_CENTER;
                balanceDue.Border = iTextSharp.text.Rectangle.NO_BORDER;
                balanceDue.PaddingTop = 3;

                total.HorizontalAlignment = Element.ALIGN_LEFT;
                total.VerticalAlignment = Element.ALIGN_CENTER;
                total.Border = iTextSharp.text.Rectangle.NO_BORDER;
                total.PaddingTop = 3;


                nested.AddCell(subtotal);
                nested.AddCell(balanceDue);
                nested.AddCell(total);
               
                PdfPCell nesthousing = new PdfPCell(nested);
                nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nesthousing.Rowspan = 5;
                nesthousing.PaddingBottom = 10f;
                totalTable.AddCell(nesthousing);
            }

            {
                PdfPTable nested = new PdfPTable(1);

                PdfPCell subtotal = new PdfPCell(new Phrase("xx", bodyFontBlue));
                PdfPCell balanceDue = new PdfPCell(new Phrase("xx", balanceDueFont));
                PdfPCell total = new PdfPCell(new Phrase("xxx", boldTableFont));
                
                subtotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                subtotal.VerticalAlignment = Element.ALIGN_CENTER;
                subtotal.Border = iTextSharp.text.Rectangle.NO_BORDER;
                subtotal.PaddingTop = 3;
                subtotal.PaddingBottom = 10;

                balanceDue.HorizontalAlignment = Element.ALIGN_RIGHT;
                balanceDue.VerticalAlignment = Element.ALIGN_CENTER;
                balanceDue.Border = iTextSharp.text.Rectangle.NO_BORDER;
                balanceDue.PaddingTop = 3;

                total.HorizontalAlignment = Element.ALIGN_RIGHT;
                total.VerticalAlignment = Element.ALIGN_CENTER;
                total.Border = iTextSharp.text.Rectangle.NO_BORDER;
                total.PaddingTop = 3;

                
                nested.AddCell(subtotal);
                nested.AddCell(balanceDue);
                nested.AddCell(total);
                
                PdfPCell nesthousing = new PdfPCell(nested);
                nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nesthousing.Rowspan = 5;
                nesthousing.PaddingBottom = 10f;
                totalTable.AddCell(nesthousing);
            }


            PdfPTable bankTable = new PdfPTable(2);

            bankTable.HorizontalAlignment = 0;
            bankTable.WidthPercentage = 100;
            bankTable.SetWidths(new float[] { 10, 20});  // then set the column's __relative__ widths
            bankTable.SpacingAfter = 15;
            bankTable.SpacingBefore = 5;
            bankTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            {
                PdfPTable nested = new PdfPTable(1);

                PdfPCell beneficiaryName = new PdfPCell(new Phrase("Beneficiary Name", boldTableFontGray));
                PdfPCell accountNo = new PdfPCell(new Phrase("Account Number", boldTableFontGray));
                PdfPCell swiftCode = new PdfPCell(new Phrase("Swift Code", boldTableFontGray));
                PdfPCell ifscCode = new PdfPCell(new Phrase("IFSC Code", boldTableFontGray));
                PdfPCell bankName = new PdfPCell(new Phrase("Bank Name", boldTableFontGray));
                PdfPCell branchName = new PdfPCell(new Phrase("Branch Name", boldTableFontGray));
                PdfPCell accountType = new PdfPCell(new Phrase("Account Type", boldTableFontGray));
                PdfPCell signature = new PdfPCell(new Phrase("Signature", boldTableFontGray));
                PdfPCell authorisedSignatory = new PdfPCell(new Phrase("Authorised Signatory", boldTableFontGray));

                beneficiaryName.HorizontalAlignment = Element.ALIGN_LEFT;
                beneficiaryName.VerticalAlignment = Element.ALIGN_CENTER;
                beneficiaryName.Border = iTextSharp.text.Rectangle.NO_BORDER;
                beneficiaryName.PaddingTop = 3;

                accountNo.HorizontalAlignment = Element.ALIGN_LEFT;
                accountNo.VerticalAlignment = Element.ALIGN_CENTER;
                accountNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                accountNo.PaddingTop = 3;

                swiftCode.HorizontalAlignment = Element.ALIGN_LEFT;
                swiftCode.VerticalAlignment = Element.ALIGN_CENTER;
                swiftCode.Border = iTextSharp.text.Rectangle.NO_BORDER;
                swiftCode.PaddingTop = 3;

                ifscCode.HorizontalAlignment = Element.ALIGN_LEFT;
                ifscCode.VerticalAlignment = Element.ALIGN_CENTER;
                ifscCode.Border = iTextSharp.text.Rectangle.NO_BORDER;
                ifscCode.PaddingTop = 3;

                bankName.HorizontalAlignment = Element.ALIGN_LEFT;
                bankName.VerticalAlignment = Element.ALIGN_CENTER;
                bankName.Border = iTextSharp.text.Rectangle.NO_BORDER;
                bankName.PaddingTop = 3;

                branchName.HorizontalAlignment = Element.ALIGN_LEFT;
                branchName.VerticalAlignment = Element.ALIGN_CENTER;
                branchName.Border = iTextSharp.text.Rectangle.NO_BORDER;
                branchName.PaddingTop = 3;

                accountType.HorizontalAlignment = Element.ALIGN_LEFT;
                accountType.VerticalAlignment = Element.ALIGN_CENTER;
                accountType.Border = iTextSharp.text.Rectangle.NO_BORDER;
                accountType.PaddingTop = 3;

                signature.HorizontalAlignment = Element.ALIGN_LEFT;
                signature.VerticalAlignment = Element.ALIGN_CENTER;
                signature.Border = iTextSharp.text.Rectangle.NO_BORDER;
                signature.PaddingTop = 3;

                authorisedSignatory.HorizontalAlignment = Element.ALIGN_LEFT;
                authorisedSignatory.VerticalAlignment = Element.ALIGN_CENTER;
                authorisedSignatory.Border = iTextSharp.text.Rectangle.NO_BORDER;
                authorisedSignatory.PaddingTop = 3;
                
                nested.AddCell(beneficiaryName);
                nested.AddCell(accountNo);
                nested.AddCell(swiftCode);
                nested.AddCell(ifscCode);
                nested.AddCell(bankName);
                nested.AddCell(branchName);
                nested.AddCell(accountType);
                nested.AddCell(signature);
                nested.AddCell(authorisedSignatory);
                

                PdfPCell nesthousing = new PdfPCell(nested);
                nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nesthousing.Rowspan = 5;
                nesthousing.PaddingBottom = 10f;
                bankTable.AddCell(nesthousing);
            }

            {
                PdfPTable nested = new PdfPTable(1);

                PdfPCell beneficiaryName = new PdfPCell(new Phrase("SEA STAR BUNKERS", boldTableFontGray));
                PdfPCell accountNo = new PdfPCell(new Phrase("231105000530", boldTableFontGray));
                PdfPCell swiftCode = new PdfPCell(new Phrase("ICICINBBCTS", boldTableFontGray));
                PdfPCell ifscCode = new PdfPCell(new Phrase("ICIC0002311", boldTableFontGray));
                PdfPCell bankName = new PdfPCell(new Phrase("ICICI", boldTableFontGray));
                PdfPCell branchName = new PdfPCell(new Phrase("Paldi, Ahmedabad", boldTableFontGray));
                PdfPCell accountType = new PdfPCell(new Phrase("Current", boldTableFontGray));
                PdfPCell signature = new PdfPCell(new Phrase("Signature", boldTableFontGray));
                PdfPCell authorisedSignatory = new PdfPCell(new Phrase("Hiren Shah", boldTableFontGray));

                beneficiaryName.HorizontalAlignment = Element.ALIGN_LEFT;
                beneficiaryName.VerticalAlignment = Element.ALIGN_CENTER;
                beneficiaryName.Border = iTextSharp.text.Rectangle.NO_BORDER;
                beneficiaryName.PaddingTop = 3;

                accountNo.HorizontalAlignment = Element.ALIGN_LEFT;
                accountNo.VerticalAlignment = Element.ALIGN_CENTER;
                accountNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                accountNo.PaddingTop = 3;

                swiftCode.HorizontalAlignment = Element.ALIGN_LEFT;
                swiftCode.VerticalAlignment = Element.ALIGN_CENTER;
                swiftCode.Border = iTextSharp.text.Rectangle.NO_BORDER;
                swiftCode.PaddingTop = 3;

                ifscCode.HorizontalAlignment = Element.ALIGN_LEFT;
                ifscCode.VerticalAlignment = Element.ALIGN_CENTER;
                ifscCode.Border = iTextSharp.text.Rectangle.NO_BORDER;
                ifscCode.PaddingTop = 3;

                bankName.HorizontalAlignment = Element.ALIGN_LEFT;
                bankName.VerticalAlignment = Element.ALIGN_CENTER;
                bankName.Border = iTextSharp.text.Rectangle.NO_BORDER;
                bankName.PaddingTop = 3;

                branchName.HorizontalAlignment = Element.ALIGN_LEFT;
                branchName.VerticalAlignment = Element.ALIGN_CENTER;
                branchName.Border = iTextSharp.text.Rectangle.NO_BORDER;
                branchName.PaddingTop = 3;

                accountType.HorizontalAlignment = Element.ALIGN_LEFT;
                accountType.VerticalAlignment = Element.ALIGN_CENTER;
                accountType.Border = iTextSharp.text.Rectangle.NO_BORDER;
                accountType.PaddingTop = 3;

                signature.HorizontalAlignment = Element.ALIGN_LEFT;
                signature.VerticalAlignment = Element.ALIGN_CENTER;
                signature.Border = iTextSharp.text.Rectangle.NO_BORDER;
                signature.PaddingTop = 3;

                authorisedSignatory.HorizontalAlignment = Element.ALIGN_LEFT;
                authorisedSignatory.VerticalAlignment = Element.ALIGN_CENTER;
                authorisedSignatory.Border = iTextSharp.text.Rectangle.NO_BORDER;
                authorisedSignatory.PaddingTop = 3;

                nested.AddCell(beneficiaryName);
                nested.AddCell(accountNo);
                nested.AddCell(swiftCode);
                nested.AddCell(ifscCode);
                nested.AddCell(bankName);
                nested.AddCell(branchName);
                nested.AddCell(accountType);
                nested.AddCell(signature);
                nested.AddCell(authorisedSignatory);

                PdfPCell nesthousing = new PdfPCell(nested);
                nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
                nesthousing.Rowspan = 5;
                nesthousing.PaddingBottom = 10f;
                bankTable.AddCell(nesthousing);
            }
            // Table footer

            PdfPTable footerTable = new PdfPTable(1);
            footerTable.WidthPercentage = 100;
            PdfPCell footerCell1 = new PdfPCell(new Phrase("Payment Terms", footerFontBold));
            PdfPCell footerCell2 = new PdfPCell(new Phrase("Payments to be made in full without any deductions by telegraphic transfer. Cheques not accepted\nAll bank charges to Remitter's Account\nLate payment is subject to Interest charges at 2% per month pro-rated daily\nPlease mention our Invoice Number in Remittance reference.", footerFont));

            footerCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
            footerCell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
            footerCell2.PaddingTop = 10f;

            footerTable.AddCell(footerCell1);
            footerTable.AddCell(footerCell2);


            pdfDoc.Add(invoiceDetailsTable);
            pdfDoc.Add(dividerLine);
            pdfDoc.Add(itemTable);
            pdfDoc.Add(dividerLine);
            pdfDoc.Add(totalTable);
            pdfDoc.Add(dividerLine);
            pdfDoc.Add(bankTable);
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
    }
}
