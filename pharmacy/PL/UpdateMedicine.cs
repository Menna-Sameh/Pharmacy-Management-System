using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using pharmacy.BLL.Services;
using pharmacy.DAL.Entities;
using pharmacy.DAL.Repository;

namespace pharmacy
{
    public partial class UpdateMedicine : Form
    {
        private int _Id;
        private MedicineEntity _Medicine;

        public UpdateMedicine()
        {
            InitializeComponent();
        }

        public UpdateMedicine(int Id)
        {
            InitializeComponent();
            _Id = Id;
        }

        private MedicineServices MedicineSr = new MedicineServices();

        private async Task LoadMedicineDetails()
        {
            _Medicine = MedicineSr.GetMedicineById(_Id);

            if (_Medicine != null)
            {
                textBox1.Text = _Medicine.Name;
                textBox2.Text = _Medicine.Quantity.ToString();
                textBox3.Text = _Medicine.Type;
                textBox4.Text = _Medicine.Price.ToString();
            }
        }

        private async void UpdateMedicine_Load(object sender, EventArgs e)
        {
            await LoadMedicineDetails();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ShowMedicine MedicineForm = new ShowMedicine();

            try
            {
                EditMedicineProperties(ref _Medicine);
                MedicineSr.UpdateMedicine(_Medicine);

                MessageBox.Show("Medicine updated successfully",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error updating medicine!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditMedicineProperties(ref MedicineEntity medicine)
        {
            medicine.Name = textBox1.Text;
            medicine.Quantity = int.Parse(textBox2.Text);
            medicine.Type = textBox3.Text;
            medicine.Price = decimal.Parse(textBox4.Text);
        }
    }
}
