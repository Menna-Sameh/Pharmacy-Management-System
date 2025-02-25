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
    public partial class DeleteMedicine : Form
    {
        private int _id;
        public DeleteMedicine()
        {
            InitializeComponent();
        }

        public DeleteMedicine(int Id)
        {
            InitializeComponent();
            this._id = Id;
        }

        private void DeleteMedicine_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
