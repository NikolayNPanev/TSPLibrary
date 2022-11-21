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
using System.Data.SqlClient;

namespace TSPLibrary
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private DataGridView dataGridView1 = new DataGridView();

        private DataGridView dataGridView2 = new DataGridView();

        
        public Form1()
        {
            InitializeComponent();

            Visitor visitor = new Visitor("Nikolay", "Nikolaev", "Panev", "2345678","22","M");

            Connection db = new Connection();

            var source2 = new BindingSource();
            Visitor[] visitors = db.Visitors();
            source2.DataSource = visitors;
            dataGridView2.DataSource = source2;



        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();
            Book book = new Book("1","The dark side","010101","1","1975");

            //. Book[] books = db.Books();
            

            String barcode = textBox1.Text;

            Rent[] rentals = db.GetVisitorRentals(barcode);

            var source = new BindingSource();
            
            source.DataSource = rentals;
           
            dataGridView1.DataSource = source;
           

            //Genre genre = new Genre("Comedy");

            //Rent rental = new Rent(visitor.barcode, dateTimePicker1.Value, dateTimePicker2.Value, book.ISBN);




            //db.RentBook(rental);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4= new Form4();
            f4.Show();
        }
    }
}
