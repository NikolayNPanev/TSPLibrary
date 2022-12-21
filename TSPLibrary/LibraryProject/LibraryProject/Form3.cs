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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Connection db = new Connection();

            Book[] books = db.Books();

            var source = new BindingSource();

            //source.DataSource = books;

            //dataGridView1.DataSource = source;
        }
        ////////////////
        ///          ///
        /// ADD BOOK ///
        ///          ///
        ////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();

            Book addBook = new Book(textBox1.Text, textBox2.Text, Int32.Parse(textBox3.Text), textBox4.Text, textBox5.Text);

            db.InsertBook(addBook);
        }

        ///////////////////
        ///             ///
        /// UPDATE BOOK ///
        ///             ///
        ///////////////////
        private void button2_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();

            db.UpdateBook(textBox1.Text, textBox2.Text);//, textBox3.Text, textBox4.Text, textBox5.Text
        }
        ///////////////////
        ///             ///
        /// DELETE BOOK ///
        ///             ///
        ///////////////////
        private void button3_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();
            String ISBN = textBox1.Text;

            db.DeleteBook(ISBN);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet2.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter1.Fill(this.database1DataSet2.Books);
            // TODO: This line of code loads data into the 'database1DataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.database1DataSet.Books);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }
    }
}
