using System;
using System.Collections.Generic;
using System.Text;

namespace TSPLibrary
{
    class Rent
    {
        public String visitorBarcode { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String BookID { get; set; }

        public Rent(String visitorBarcode, DateTime startDate, DateTime endDate, String BookID)
        {
            this.visitorBarcode = visitorBarcode;
            this.startDate = startDate;
            this.endDate = endDate;
            this.BookID = BookID;
        }
    }
}
