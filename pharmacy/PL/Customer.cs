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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewCustomer newForm = new NewCustomer();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateCustomer newForm = new UpdateCustomer();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteCustomer newForm = new DeleteCustomer();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowCustomer newForm = new ShowCustomer();
            newForm.Show();
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
