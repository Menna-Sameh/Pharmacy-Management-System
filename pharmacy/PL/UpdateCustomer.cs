using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using pharmacy.BLL.Servecies;
using pharmacy.DAL.Entities;
using pharmacy.DAL.Rrposatory;

namespace pharmacy
{
    public partial class UpdateCustomer : Form
    {

        private int _Id;

        private CustomerEntity _Customer;

        public UpdateCustomer()
        {
            InitializeComponent();
        }

        public UpdateCustomer(int Id)
        {
            InitializeComponent();
            _Id = Id;
        }

        private CustomerServecies CustomersSr = new CustomerServecies();

        private async Task LoadCustomerDetails()
        {
            //_Customer = await CustomersBL.GetCustomerById(_Id);
            var customer=  CustomersSr.GetCustomerById(_Id);

            if (_Customer != null)
            {
                textBox1.Text = _Customer.Name;
                textBox2.Text = _Customer.Address;
                textBox3.Text = _Customer.Phone;
            }
        }



        private async void UpdateCustomer_Load_1(object sender, EventArgs e)
        {
            await LoadCustomerDetails();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ShowCustomer CustomerForm = new ShowCustomer();

            try
            {

                EditCustomerProperties(ref _Customer);
                 CustomersSr.UpdateCustomer(_Customer);

                MessageBox.Show("Customer updated successfully",
                    "Success",MessageBoxButtons.OK ,MessageBoxIcon.Information );
                this.Close();
               
            }
            catch (Exception exception)
            {

                MessageBox.Show("Error to update Customer!!","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);


            }
        }

        private void EditCustomerProperties(ref CustomerEntity customer)
        {
            customer.Name = textBox1.Text;
            customer.Address = textBox2.Text;
            customer.Phone = textBox3.Text;
        }

    }
}