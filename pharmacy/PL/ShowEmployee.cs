using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using pharmacy.BLL.Servecies;
using pharmacy.DAL.Entities;

namespace pharmacy
{
    public partial class ShowEmployee : Form
    {
        private List<BLL.Servecies.EmployeeEntityDto> _employees;
        private readonly EmployeeServiesces _employeeService = new EmployeeServiesces();

        public ShowEmployee()
        {
            InitializeComponent();
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        //private void ShowEmployee_Load(object sender, EventArgs e)
        //{
        //    LoadEmployees();
        //}

        private void LoadEmployees()
        {
            _employees = _employeeService.GetEmployees();

            if (_employees == null || _employees.Count == 0)
            {
                MessageBox.Show("No employees found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "Id"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "Name"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Salary",
                HeaderText = "Salary",
                Name = "Salary"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HireDate",
                HeaderText = "Hire Date",
                Name = "HireDate"
            });

            var updateButton = new DataGridViewButtonColumn
            {
                HeaderText = "Update",
                Text = "Update",
                UseColumnTextForButtonValue = true,
                Name = "UpdateButton"
            };

            var deleteButton = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Name = "DeleteButton"
            };

            dataGridView1.Columns.Add(updateButton);
            dataGridView1.Columns.Add(deleteButton);

            dataGridView1.DataSource = _employees;
            dataGridView1.Refresh();
        }

        private void OpenUpdateEmployeeForm(int employeeId)
        {
            Hide();
            UpdateEmployee updateForm = new UpdateEmployee(employeeId);
            updateForm.ShowDialog();
            Show();
            LoadEmployees(); // Refresh the data after update
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Prevent index errors

            int employeeId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;

            if (e.ColumnIndex == dataGridView1.Columns["UpdateButton"].Index)
            {
                OpenUpdateEmployeeForm(employeeId);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete the employee with ID = {employeeId}?",
                    "Confirm Delete",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.OK)
                {
                    _employeeService.DeleteEmployee(employeeId);
                    LoadEmployees();
                }
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "UpdateButton" || dataGridView1.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.SelectionBackColor = Color.CadetBlue;
                e.CellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ShowEmployee_Load_1(object sender, EventArgs e)
        {
            LoadEmployees();
        }
    }
}
