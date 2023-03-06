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
using BarcodeLib;
using System.Web.Helpers;
using System.Drawing;
using System.IO;

namespace TSPLibrary
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        ///////////////////////////////
        ///                         ///
        ///  INITIALIZE DATA GRIDS  ///
        ///                         ///
        ///////////////////////////////
        private DataGridView dataGridView1 = new DataGridView();

        //////////////////////////
        ///                    ///
        /// FORM1 CONSTRUCTOR  ///
        ///                    ///
        //////////////////////////
        public Form1()
        {
            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        //////////////////////////////
        ///                        ///
        ///  SHOW VISITOR RENTALS  ///
        ///                        ///
        //////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();

            String barcode = textBox1.Text;

            Rent[] rentals = db.GetVisitorRentals(barcode);

            var source = new BindingSource();
            
            source.DataSource = rentals;
           
            dataGridView1.DataSource = source;
  
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell isReturned = row.Cells[4] as DataGridViewCheckBoxCell;
                if(isReturned.Value!=null)
                if ((Boolean)isReturned.Value==false&& (DateTime)row.Cells[2].Value <    DateTime.Now)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        /////////////////////
        ///               ///
        ///  RENT A BOOK  ///
        ///               ///
        /////////////////////
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        ////////////////////////////
        ///                      ///
        ///  VISITOR OPERATIONS  ///
        ///                      ///
        ////////////////////////////
        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        /////////////////////////
        ///                   ///
        ///  BOOK OPERATIONS  ///
        ///                   ///
        /////////////////////////
        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4= new Form4();
            f4.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();
            Visitor visitor = new Visitor();
            Visitor[] visitors = db.Visitors();

            List<int> array1 = new List<int> { };
            foreach (Visitor v in visitors) {
                if(v!=null)
                array1.Add(int.Parse(v.age));
            }

            var sr = Historgram.ToHistogram(array1);
            Bitmap h1 = Historgram.ToBitmap(sr);

            int[] ages = new int[100];
            int i = 0;
            try
            {
                foreach (Visitor v in visitors)
                {
                    if (v!=null) {
                        if (v.EGN.Equals(textBox2.Text) && v != null)
                        {
                            String visitorBarcode = textBox2.Text;
                            Barcode barcode = new Barcode();
                            Color foreColor = Color.Black;
                            Color backColor = Color.Transparent;
                            Image img = barcode.Encode(TYPE.CODE128, v.barcode, foreColor, backColor, (int)(pictureBox1.Width * 0.8), (int)(pictureBox1.Height * 0.8));
                            pictureBox1.Image = img;
                            label2.Text = v.barcode;
                            ages[i] = int.Parse(v.age);
                            break;
                        }
                    }
                }

                pictureBox1.Image = h1;


                /*var c1 = new Chart(100, 300);
                c1.AddSeries(ages.ToString());
                c1.ToWebImage("D:/TSPLibrary/TSPLibrary/TSPLibrary/img.jpg");*/
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();

            String barcode = textBox1.Text;

            Rent[] rentals = db.GetVisitorRentals(barcode);

            String[] fileText = new String[10000];
            int i = 0;
            foreach (Rent r in rentals) {
                if (r != null)
                {
                    fileText[i] = r.ToString() + ",\n";
                    i++;
                }
            }
            await File.WriteAllLinesAsync(barcode+"-rentals.txt", fileText);
        }
    }
}
