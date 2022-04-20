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
    public partial class Form5 : Form
    {
        Entity context;
        public Form5()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form5_FormClosed);

        }
        private void Form5_FormClosed(object sender, EventArgs e)
        {

            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Form1();
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1)
            {
                String bookName = comboBox1.SelectedItem.ToString();

                context = new Entity();

                var query = from b in context.Books
                            where b.name == bookName
                            select b;

                Books book = query.FirstOrDefault();

                textBox1.Text = book.name.TrimEnd();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            context = new Entity();

            Books[] books = context.Books.ToArray();

            foreach(Books book in books)
            {
                comboBox1.Items.Add(book.name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String bookName = comboBox1.SelectedItem.ToString().TrimEnd();

            context = new Entity();

            var query = from b in context.Books
                        where b.name == bookName
                        select b;

            Books book = query.FirstOrDefault();

            book.name = textBox1.Text.TrimEnd();

            context.SaveChanges();

            MessageBox.Show(bookName + " edited succesfully");

            clear();
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String bookName = comboBox1.SelectedItem.ToString().TrimEnd();

            context = new Entity();

            var query = from b in context.Books
                        where b.name == bookName
                        select b;

            Books book = query.FirstOrDefault();

            context.Books.Remove(book);
            context.SaveChanges();

            MessageBox.Show(bookName + " deleted succesfully");
            clear();
            update();
        }
        public void clear()
        {
            comboBox1.SelectedIndex = -1;

            textBox1.Text = "";
        }
        public void update()
        {
            comboBox1.Items.Clear();

            context = new Entity();

            Books[] books = context.Books.ToArray();

            foreach (Books book in books)
            {
                comboBox1.Items.Add(book.name);
            }
        }
    }
}
