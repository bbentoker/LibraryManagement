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
    public partial class Form4 : Form
    {
        Entity context;

        public Form4()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form4_FormClosed);    
        }
        private void Form4_FormClosed(object sender, EventArgs e)
        {

            Application.Exit();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String publisherName = comboBox1.SelectedItem.ToString();


            context = new Entity();

            var query = from p in context.Publisher
                        where p.name == publisherName
                        select p;
            Publisher publisher = query.FirstOrDefault();

            //MessageBox.Show(author.Books.Count.ToString());

            String disp = "";

            foreach (Books book in publisher.Books)
            {
                disp += book.name + "Author: " + book.Author.name + "\n";
            }

            label2.Text = "Books published by the Publisher:\n--------------------------------------------------------------\n" + disp;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form form = new Form1();
            form.ShowDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            context = new Entity();

            Publisher[] publishers = context.Publisher.ToArray();

            foreach (Publisher publisher in publishers)
            {
                comboBox1.Items.Add(publisher.name);
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
