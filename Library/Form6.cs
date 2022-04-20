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
    public partial class Form6 : Form
    {
        Entity context;
        public Form6()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form6_FormClosed);

        }
        private void Form6_FormClosed(object sender, EventArgs e)
        {

            Application.Exit();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            context = new Entity();

            Author[] authors = context.Author.ToArray();

            foreach (Author author in authors)
            {
                comboBox1.Items.Add(author.name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Form1();
            form.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                String authorName = comboBox1.SelectedItem.ToString();

                context = new Entity();

                var query = from a in context.Author
                            where a.name == authorName
                            select a;

                Author author = query.FirstOrDefault();

                textBox1.Text = author.name.TrimEnd();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String authorName = comboBox1.SelectedItem.ToString().TrimEnd();

            context = new Entity();

            var query = from a in context.Author
                        where a.name == authorName
                        select a;

            Author author = query.FirstOrDefault();

            author.name = textBox1.Text.TrimEnd();

            context.SaveChanges();

            MessageBox.Show(authorName + " edited succesfully");

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

            Author[] authors = context.Author.ToArray();

            foreach (Author author in authors)
            {
                comboBox1.Items.Add(author.name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String authorName = comboBox1.SelectedItem.ToString().TrimEnd();

            context = new Entity();

            var query = from a in context.Author
                        where a.name == authorName
                        select a;

            Author author = query.FirstOrDefault();

            if (author.Books.Count > 0)
            {
                MessageBox.Show("First remove the books written by this author");
                clear();
                return;
            }

            context.Author.Remove(author);
            context.SaveChanges();

            MessageBox.Show(authorName + " deleted succesfully");
            clear();
            update();
        }
    }
}
