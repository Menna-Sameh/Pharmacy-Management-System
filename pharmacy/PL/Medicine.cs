﻿using System;
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
    public partial class Medicine : Form
    {
        public Medicine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMedicine newForm = new AddMedicine();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateMedicine newForm = new UpdateMedicine();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteMedicine newForm = new DeleteMedicine();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowMedicine newForm = new ShowMedicine();
            newForm.Show();
        }

        private void Medicine_Load(object sender, EventArgs e)
        {

        }
    }
}
