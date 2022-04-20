using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        Entity context;
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }
        private void Form1_FormClosed(object sender, EventArgs e)
        {

            Application.Exit();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Form form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form form4 = new Form4();
            this.Hide();
            form4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            context = new Entity();

            Books book = new Books();
            Author author = new Author();
            Publisher publisher = new Publisher();

            book.name = "First Book";
            author.name = "Writer";
            publisher.name = "Publisher";

            book.Author = author;
            book.Publisher = publisher;

            context.Books.Add(book);
            context.SaveChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form5 = new Form5();
            this.Hide();
            form5.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form6 = new Form6();
            this.Hide();
            form6.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            this.Hide();
            form7.ShowDialog();
        }
    }
}
