using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TSPLibrary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();
            Book book = new Book("1","The dark side","010101","1","1975");
            Genre genre = new Genre("Comedy");
            Visitor visitor = new Visitor("Nikolay", "Nikolaev", "Panev", "2345678");
            Rent rental = new Rent(visitor, dateTimePicker1.Value, dateTimePicker2.Value, book);
            db.RentBook(rental);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
