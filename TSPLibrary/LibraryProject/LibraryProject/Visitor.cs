using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Visitor
    {
        public String EGN { get; set; }
        public String fname { get; set; }
        public String mname { get; set; }
        public String lname { get; set; }
        public String barcode { get; set; }
        public String gender { get; set; }

        public String age { get; set; }

        public Visitor(String EGN,String fname, String mname, String lname, String barcode, String gender, String age )
        {
            this.EGN = EGN;
            this.fname = fname;
            this.mname = mname;
            this.lname = lname;
            this.barcode = barcode;
            this.gender = gender;
            this.age = age;

        }
        public Visitor()
        {
        }

    }
}
