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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            Connection db = new Connection();
            var source = new BindingSource();
            Visitor[] visitors = db.Visitors();
            //source.DataSource = visitors;

            //dataGridView1.DataSource = source;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//register=insert
        {
            Connection db = new Connection();
            Visitor v = new Visitor(textBox1.Text, textBox2.Text, textBox3.Text, 
                textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);

            db.InsertVisitor(v);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet5.Visitors' table. You can move, or remove it, as needed.
            this.visitorsTableAdapter3.Fill(this.database1DataSet5.Visitors);
            // TODO: This line of code loads data into the 'database1DataSet4.Visitors' table. You can move, or remove it, as needed.
            //this.visitorsTableAdapter2.Fill(this.database1DataSet4.Visitors);
            //// TODO: This line of code loads data into the 'database1DataSet3.Visitors' table. You can move, or remove it, as needed.
            //this.visitorsTableAdapter1.Fill(this.database1DataSet3.Visitors);
            //// TODO: This line of code loads data into the 'database1DataSet1.Visitors' table. You can move, or remove it, as needed.
            //this.visitorsTableAdapter.Fill(this.database1DataSet1.Visitors);

        }

        private void button2_Click(object sender, EventArgs e)//unregister=delete
        {
            Connection db = new Connection();
            db.DeleteVisitor(textBox5.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();

            db.UpdateVisitor(textBox1.Text, textBox2.Text, textBox3.Text,
                textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
