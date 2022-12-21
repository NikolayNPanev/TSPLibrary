using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //rent book
        private void button1_Click(object sender, EventArgs e)
        {
            String barcode = textBox1.Text;
            String ISBN = textBox2.Text;
            DateTime start = dateTimePicker1.Value;
            DateTime end = dateTimePicker2.Value;

            Rent r = new Rent(barcode, start, end, ISBN);

            Connection db = new Connection();

            db.RentBook(r);

        }
        
        //return book

        private void button2_Click_1(object sender, EventArgs e)
        {
            Connection db = new Connection();

            db.ReturnBook(textBox1.Text, textBox2.Text);
        }
    }
}
