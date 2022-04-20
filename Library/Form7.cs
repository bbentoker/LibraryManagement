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
    public partial class Form7 : Form
    {
        Entity context;
        public Form7()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form7_FormClosed);

        }
        private void Form7_FormClosed(object sender, EventArgs e)
        {

            Application.Exit();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            context = new Entity();

            Publisher[] publishers = context.Publisher.ToArray();

            foreach (Publisher publisher in publishers)
            {
                comboBox1.Items.Add(publisher.name);
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
                String publisherName = comboBox1.SelectedItem.ToString();

                context = new Entity();

                var query = from p in context.Publisher
                            where p.name == publisherName
                            select p;

                Publisher publisher = query.FirstOrDefault();

                textBox1.Text = publisher.name.TrimEnd();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String publisherName = comboBox1.SelectedItem.ToString().TrimEnd();

            context = new Entity();

            var query = from p in context.Publisher
                        where p.name == publisherName
                        select p;

            Publisher publisher = query.FirstOrDefault();

            publisher.name = textBox1.Text.TrimEnd();

            context.SaveChanges();

            MessageBox.Show(publisherName + " edited succesfully");

            clear();
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String publisherName = comboBox1.SelectedItem.ToString().TrimEnd();


            context = new Entity();

            var query = from p in context.Publisher
                        where p.name == publisherName
                        select p;


            Publisher publisher = query.FirstOrDefault();

            if(publisher.Books.Count > 0)
            {
                MessageBox.Show("First remove the books published by this publisher");
                clear();
                return;
            }

            context.Publisher.Remove(publisher);
            context.SaveChanges();

            MessageBox.Show(publisherName + " deleted succesfully");
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

            Publisher[] publishers = context.Publisher.ToArray();

            foreach (Publisher publisher in publishers)
            {
                comboBox1.Items.Add(publisher.name);
            }
        }
    }
}
