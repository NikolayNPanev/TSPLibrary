using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TSPLibrary
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

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
    }
}
