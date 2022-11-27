using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TSPLibrary
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            Connection db = new Connection();
            var source = new BindingSource();
            Visitor[] visitors = db.Visitors();
            source.DataSource = visitors;

            dataGridView1.DataSource = source;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        ////////////////////////
        ///                  ///
        /// REGISTER VISITOR ///
        ///                  ///
        ////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();
            Visitor v = new Visitor(textBox1.Text, textBox2.Text, textBox3.Text, textBox6.Text,textBox4.Text,textBox5.Text);

            db.InsertVisitor(v);

        }

        ///////////////////////////
        ///                     ///
        /// UN-REGISTER VISITOR ///
        ///                     ///
        ///////////////////////////
        private void button2_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();
            db.DeleteVisitor(textBox6.Text);
        }

        //////////////////////
        ///                ///
        /// UPDATE VISITOR ///
        ///                ///
        //////////////////////
        private void button3_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();

            db.UpdateVisitor(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);

        }

        ///////////////
        ///         ///
        /// REFRESH ///
        ///         ///
        ///////////////
        private void button4_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();
            var source = new BindingSource();
            Visitor[] visitors = db.Visitors();
            source.DataSource = visitors;

            dataGridView1.DataSource = source;
        }
    }
}
