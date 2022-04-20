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
    public partial class Form3 : Form
    {
        Entity context;
        Dictionary<Books,String[]> data = new Dictionary<Books,String[]>();
        public Form3()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form3_FormClosed);

        }
        private void Form3_FormClosed(object sender, EventArgs e)
        {

            Application.Exit();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            String authorName = comboBox1.SelectedItem.ToString();

            context = new Entity();

            var query = from a in context.Author
                            where a.name == authorName
                            select a;
            Author author = query.FirstOrDefault();

            //MessageBox.Show(author.Books.Count.ToString());

            String disp = "";

            foreach(Books book in author.Books)
            {   
                disp += book.name + "Publisher: " + book.Publisher.name + "\n";
            }

            label3.Text = "Books of the Author:\n--------------------------------\n" + disp;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form form = new Form1();
            form.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            

            context = new Entity();

            Author[] authors = context.Author.ToArray();

            foreach(Author author in authors)
            {
                comboBox1.Items.Add(author.name);
            }
        }
       
        

        
    }
}
