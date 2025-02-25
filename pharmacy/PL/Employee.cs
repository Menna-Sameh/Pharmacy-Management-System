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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewEmployee newEmployee = new NewEmployee();
            newEmployee.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowEmployee showEmployee = new ShowEmployee();
            showEmployee.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateEmployee updateEmployee = new UpdateEmployee();
            updateEmployee.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteEmployee deleteEmployee = new DeleteEmployee();
            deleteEmployee.Show();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }
    }
}
