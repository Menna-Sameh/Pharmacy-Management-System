using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee newForm = new Employee();
            newForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Medicine newForm = new Medicine();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer newForm = new Customer();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order newForm = new Order();
            newForm.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
