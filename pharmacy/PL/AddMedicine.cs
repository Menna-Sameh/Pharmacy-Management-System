using pharmacy.BLL.Services;
using pharmacy.DAL.Entities;
using pharmacy.DAL.Repository;

namespace pharmacy
{
    public partial class AddMedicine : Form
    {
        public AddMedicine()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var newMedicine = new MedicineEntity
            {
                Name = textBox1.Text,
                Quantity = int.TryParse(textBox2.Text, out int quantity) ? quantity : 0,
                Type = textBox3.Text,
                Price = decimal.TryParse(textBox4.Text, out decimal price) ? price : 0
            };

            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    throw new ArgumentException("All medicine data are required and cannot be empty or whitespace.");
                }

                if (quantity <= 0 || price <= 0)
                {
                    throw new ArgumentException("Quantity and Price must be valid positive numbers.");
                }

                var medicineService = new MedicineServices();
                medicineService.AddMedicine(newMedicine);

                MessageBox.Show("Medicine added successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewMedicine_Load(object sender, EventArgs e)
        {

        }
    }
}
