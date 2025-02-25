using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using pharmacy.BLL.Services;
using pharmacy.DAL.Entities;

namespace pharmacy
{
    public partial class ShowMedicine : Form
    {
        private List<MedicineEntityDto> _medicines;
        private readonly MedicineServices _medicineService = new MedicineServices();

        public ShowMedicine()
        {
            InitializeComponent();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_2;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void LoadMedicines()
        {
            _medicines = _medicineService.GetMedicines();

            if (_medicines == null || _medicines.Count == 0)
            {
                MessageBox.Show("No medicines found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DataPropertyName = "Quantity",
                HeaderText = "Quantity",
                Name = "Quantity"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Type",
                Name = "Type"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Price",
                Name = "Price"
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

            dataGridView1.DataSource = _medicines;
            dataGridView1.Refresh();
        }

        private void OpenUpdateMedicineForm(int medicineId)
        {
            Hide();
            UpdateMedicine updateForm = new UpdateMedicine(medicineId);
            updateForm.ShowDialog();
            Show();
            LoadMedicines(); // Refresh the data after update
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Prevent index errors

            int medicineId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;

            if (e.ColumnIndex == dataGridView1.Columns["UpdateButton"].Index)
            {
                OpenUpdateMedicineForm(medicineId);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete the medicine with ID = {medicineId}?",
                    "Confirm Delete",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.OK)
                {
                    _medicineService.DeleteMedicine(medicineId);
                    LoadMedicines();
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

        private void ShowMedicine_Load(object sender, EventArgs e)
        {
            LoadMedicines();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
