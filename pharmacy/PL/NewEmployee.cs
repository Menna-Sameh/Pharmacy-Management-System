using pharmacy.BLL.Servecies;
using pharmacy.DAL.Entities;
using pharmacy.DAL.Rrposatory;
using System.Windows.Forms;

namespace pharmacy
{
    public partial class NewEmployee : Form
    {
        public NewEmployee()
        {
            InitializeComponent();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            var newEmployee = new EmployeeEntity
            {
                Name = textBox1.Text,
                HireDate = DateTime.TryParse(textBox2.Text, out DateTime hireDate) ? hireDate : DateTime.MinValue,
                Salary = decimal.TryParse(textBox3.Text, out decimal salary) ? salary : 0,
            };

            try
            {
                if (string.IsNullOrWhiteSpace(newEmployee.Name) || salary <= 0 || hireDate == DateTime.MinValue)
                {
                    throw new ArgumentException("Employee name, salary, and a valid hire date are required.");
                }

                // Convert EmployeeEntity to EmployeeEntityDto
                var employeeDto = new BLL.Servecies.EmployeeEntityDto
                {
                    Name = newEmployee.Name,
                    Salary = newEmployee.Salary,
                    HireDate = newEmployee.HireDate
                };

                var employeeService = new EmployeeServiesces();
                employeeService.AddEmployee(employeeDto); // Pass DTO instead of entity

                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void NewEmployee_Load(object sender, EventArgs e)
        {

        }

        
    }
}
