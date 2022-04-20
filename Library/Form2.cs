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
    public partial class Form2 : Form
    {
        Entity context;
        public Form2()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form2_FormClosed);

        }
        private void Form2_FormClosed(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            context = new Entity();

            String bookName = textBox1.Text;
            String authorName = textBox2.Text;
            String publisherName = textBox3.Text;

            var query = from b in context.Books
                        where b.name == bookName
                        select b;
            
            var bookM = query.FirstOrDefault();
            
            if (bookM != null)
            {
                MessageBox.Show("Book already exists in the database");
                clear();
                return;
            }
            
            Books book = new Books();
            book.name = bookName;
            //
            var query2 = from a in context.Author
                    where a.name == authorName
                    select a;

            var authorM = query2.FirstOrDefault();

            if (authorM != null)
            {
                book.Author = authorM;
            }
            else
            {
                Author author = new Author();
                author.name = authorName;
                book.Author = author;
            }
            
            //
            var query3 = from p in context.Publisher
                         where p.name == publisherName
                         select p;

            var publisherM = query3.FirstOrDefault();

            if (publisherM != null)
            {
                book.Publisher = publisherM;
            }
            else
            {
                Publisher publisher = new Publisher();
                publisher.name = publisherName;
                book.Publisher = publisher;
            }
            
            context.Books.Add(book);   
            context.SaveChanges();

            MessageBox.Show("Book:" + bookName + " added succesfully");
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form form = new Form1();
            form.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            return;
        }
    }
    
}
