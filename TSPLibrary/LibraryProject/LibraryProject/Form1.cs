using BarcodeLib;
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
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            Visitor visitor = new Visitor("Nikolay", "Nikolaev", "Panev", "2345678", "22", "M", "345678543456");

            Connection db = new Connection();

            var source2 = new BindingSource();
            Visitor[] visitors = db.Visitors();
            source2.DataSource = visitors;
            dataGridView1.DataSource = source2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();
            Book book = new Book("1", "The dark side", 1, "1974", "101010");

             //Book[] books = db.Books();


            String barcode = textBox1.Text;

            Rent[] rentals = db.GetVisitorRentals(barcode);

            var source = new BindingSource();

            source.DataSource = rentals;

            dataGridView1.DataSource = source;
            //OleDbConnection connect = conn.connect;
            //string mySelect = "select * from Lightings where StorageID=" + id;
            //connect.Open();
            //OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, connect);
            //DataTable dt = new DataTable();
            //adapt.Fill(dt);
            //dataGridView2.DataSource = dt;
            //connect.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();

            Visitor visitor = new Visitor();
            Visitor[] visitors = db.Visitors();
            try
            {
                foreach (Visitor v in visitors)
                {
                    if (v != null)
                    {
                        if (v.EGN.Equals(textBox2.Text))
                        {
                            String visitorBarcode = textBox2.Text;
                            Barcode barcode = new Barcode();
                            Color foreColor = Color.Black;
                            Color backColor = Color.Transparent;
                            Image img = barcode.Encode(TYPE.CODE128, v.barcode, foreColor, backColor, (int)(pictureBox1.Width * 0.8), (int)(pictureBox1.Height * 0.8));
                            pictureBox1.Image = img;
                            textBox1.Text = v.barcode;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }
    }
}
