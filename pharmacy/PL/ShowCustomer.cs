using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using pharmacy.BLL.Servecies;
using pharmacy.DAL.Entities;
using pharmacy.DAL.Rrposatory;

namespace pharmacy
{
    public partial class ShowCustomer : Form
    {
        List<CustomerEntityDto> _customers;

        public ShowCustomer()
        {
            InitializeComponent();

            // Attach the event handler
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

        }

        private CustomerServecies CustomersSr = new CustomerServecies();


        private async void ShowCustomer_Load(object sender, EventArgs e)
        {
            _customers = CustomersSr.GetCustomers();

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id", // Matches the property name in CustomerEntity
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
                DataPropertyName = "Address",
                HeaderText = "Address",
                Name = "Address"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Phone",
                Name = "Phone"
            });

            DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Update",
                Text = "Update",
                UseColumnTextForButtonValue = true,
                Name = "UpdateButton",

            };

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Name = "DeleteButton"
            };
            dataGridView1.Columns.Add(updateButtonColumn);
            dataGridView1.Columns.Add(deleteButtonColumn);

            dataGridView1.DataSource = _customers;

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // ✅ **Fix the issue with resizing (ensure columns fit)**
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = true;

            // ✅ **Force redraw to apply styles**
            dataGridView1.Refresh();
        }

        private void OpenUpdateCustomerForm(int customerId)
        {
            this.Hide();

            UpdateCustomer updateForm = new UpdateCustomer(customerId);

            updateForm.ShowDialog();

            this.Show();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int customerId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;

            // Handle "Update" button click
            if (e.ColumnIndex == dataGridView1.Columns["UpdateButton"].Index)
            {
                OpenUpdateCustomerForm(customerId);
            }

            // Handle "Delete" button click
            if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index)
            {
                // Confirm deletion with the user
                var result = MessageBox.Show(
                    $"Are you sure you want to delete the customer with ID = {customerId}?",
                    "Confirm Delete",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.OK)
                {
                    //To refresh the data in the DataGridView

                    CustomersSr.DeleteCustomer(customerId);

                    var customers = CustomersSr.GetCustomers();
                    dataGridView1.DataSource = _customers;
                }
            }


        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the current cell is in the "UpdateButton" column
            if (dataGridView1.Columns[e.ColumnIndex].Name == "UpdateButton" || dataGridView1.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                // Customize the button appearance
                e.CellStyle.BackColor = Color.Black; // Change background color
                e.CellStyle.SelectionBackColor = Color.CadetBlue; // Change text color
                e.CellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Change font
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Check if there is data in the DataGridView
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set the EPPlus license context
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Open a SaveFileDialog to let the user choose the file destination and name
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save Excel File";
                saveFileDialog.FileName = "ExportedData.xlsx"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Create a new Excel package
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        // Add a worksheet to the Excel package
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("ExportedData");

                        // Write the column headers to the Excel sheet, excluding the last two columns
                        for (int i = 0; i < dataGridView1.Columns.Count - 2; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = dataGridView1.Columns[i].HeaderText;
                        }

                        // Write the data rows to the Excel sheet, excluding the last two columns
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count - 2; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        // Auto-fit columns for better readability
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        // Save the Excel file
                        FileInfo excelFile = new FileInfo(filePath);
                        excelPackage.SaveAs(excelFile);

                        MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}