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
            Book book = new Book("1","The shining","2345678","1","1999");

            db.InsertBook(book);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
