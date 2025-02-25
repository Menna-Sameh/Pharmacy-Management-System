using pharmacy.BLL.Servecies;
using pharmacy.DAL.Entities;
using pharmacy.DAL.Rrposatory;

namespace pharmacy
{
    public partial class NewCustomer : Form
    {

        public NewCustomer()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e)
        {

            var newCustomer = new CustomerEntity
            {
                Name = textBox1.Text,
                Address = textBox2.Text,
                Phone = textBox3.Text
            };

            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    throw new ArgumentException("All customer data are required and cannot be empty or whitespace.");
                }

                var customer = new CustomerServecies();

                 customer.AddCustomer(newCustomer);


                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {

                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private object CustomerServecies()
        {
            throw new NotImplementedException();
        }

        private void NewCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
    

