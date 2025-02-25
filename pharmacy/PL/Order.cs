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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrder addOrder = new AddOrder();
            addOrder.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateOrder updateOrder = new UpdateOrder();

            updateOrder.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteOrder deleteOrder = new DeleteOrder();
            deleteOrder.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowOrder showOrder = new ShowOrder();
            showOrder.Show();
        }

        private void Order_Load(object sender, EventArgs e)
        {

        }
    }
}
