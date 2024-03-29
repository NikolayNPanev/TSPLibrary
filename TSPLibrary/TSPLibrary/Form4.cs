﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TSPLibrary
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Connection db = new Connection();

            Book[] books = db.Books();

            var source = new BindingSource();

            source.DataSource = books;

            dataGridView1.DataSource = source;
        }

        ///////////////////
        ///             ///
        /// DELETE BOOK ///
        ///             ///
        ///////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();
            String ISBN = textBox1.Text;

            db.DeleteBook(ISBN);
        }

        ///////////////////
        ///             ///
        /// UPDATE BOOK ///
        ///             ///
        ///////////////////
        private void button2_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();

            db.UpdateBook(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text);

        }

        ////////////////
        ///          ///
        /// ADD BOOK ///
        ///          ///
        ////////////////
        private void button3_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();

            Book addBook = new Book(textBox3.Text,textBox2.Text,textBox1.Text,textBox5.Text,textBox4.Text);

            db.InsertBook(addBook);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
