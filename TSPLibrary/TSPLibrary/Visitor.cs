
using System;
using System.Collections.Generic;
using System.Text;

namespace TSPLibrary
{
    class Visitor
    {
        public String fname { get; set; }
        public String lname { get; set; }
        public String mname { get; set; }
        public String barcode { get; set; }

        public Visitor( String fname, String mname, String lname, String barcode)
        {
            this.barcode = barcode;
            this.fname = fname;
            this.mname = mname;
            this.lname = lname;
        }
    }
}
