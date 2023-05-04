using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Model
{
    public class orderConfirmation
    {
        public string orderNumber { get; set; }
        public string orderDate { get; set; }
        public string buyerName { get; set; }
        public string buyerAddress1 { get; set; }
        public string buyerAddress2 { get; set; }
        public string sellerName { get; set; }
        public string sellerAddress1 { get; set; }
        public string sellerAddress2 { get; set; }
        public string physicalSupplier { get; set; }
        public string vesselName { get; set; }
        public BigInteger IMONumber { get; set; }
        public string portName { get; set; }
        public string supplyLocation { get; set; }
        public string supplyMode { get; set; }
        public DateTime ETA { get; set; }
        public DateTime Laycan_StartDate { get; set; }
        public DateTime Laycan_EndDate { get; set; }
        public string specification { get; set; }
        public string qty { get; set; }
        public string productPrice { get; set; }
        public string otherCost { get; set; }
        public string creditPeriod { get; set; }
        public string agent { get; set; }
        public string remarks { get; set; }
    }
}
