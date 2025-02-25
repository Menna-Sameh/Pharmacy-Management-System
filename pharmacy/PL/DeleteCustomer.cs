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
    public partial class DeleteCustomer : Form
    {
        private int _id;
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        public DeleteCustomer(int Id)
        {
            InitializeComponent();
            this._id = Id;
        }

        private void DeleteCustomer_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
