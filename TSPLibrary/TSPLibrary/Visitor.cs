
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
        public String age { get; set; }
        public String gender { get; set; }

        public Visitor( String fname, String mname, String lname, String barcode,String age, string gender)
        {
            this.barcode = barcode;
            this.fname = fname;
            this.mname = mname;
            this.lname = lname;
            this.age = age;
            this.gender = gender;

        }
    }
}
