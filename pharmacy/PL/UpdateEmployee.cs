using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using pharmacy.BLL.Servecies;
using pharmacy.DAL.Entities;
using pharmacy.DAL.Rrposatory;

namespace pharmacy
{
    public partial class UpdateEmployee : Form
    {
        private int _Id;
        private EmployeeEntity _Employee;

        public UpdateEmployee()
        {
            InitializeComponent();
        }

        public UpdateEmployee(int Id)
        {
            InitializeComponent();
            _Id = Id;
        }

        private EmployeeServiesces EmployeeSr = new EmployeeServiesces();

        private async Task LoadEmployeeDetails()
        {
            // Fetch employee details by ID
            var Employee = EmployeeSr.GetEmployeeById(_Id);

            // Check if the employee exists
            if (_Employee != null)
            {
                // Assign employee properties to text boxes
                textBox1.Text = _Employee.Name;          // Employee Name
                textBox2.Text = _Employee.Salary.ToString(); // Employee Salary
                textBox3.Text = _Employee.HireDate.ToString("yyyy-MM-dd"); // Employee Hire Date
            }
        }

        private async void UpdateEmployee_Load(object sender, EventArgs e)
        {
            await LoadEmployeeDetails();
        }

        private void EditEmployeeProperties(ref EmployeeEntity employee)
        {
            employee.Name = textBox1.Text;
            employee.Salary = decimal.Parse(textBox2.Text);
            employee.HireDate = DateTime.Parse(textBox3.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowEmployee EmployeeForm = new ShowEmployee();
            EditEmployeeProperties(ref _Employee);
            EmployeeSr.UpdateEmployee(_Employee);

            MessageBox.Show("Employee updated successfully",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            //try
            //{
            //    EditEmployeeProperties(ref _Employee);
            //    EmployeeSr.UpdateEmployee(_Employee);

            //    MessageBox.Show("Employee updated successfully",
            //        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show("Error updating employee: " + exception.Message,
            //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}