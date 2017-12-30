using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorlinkTrading.DataAccess;
using System.Linq.Expressions;
using ColorlinkTrading.Models;
using ColorlinkTrading.Logic;

namespace ColorlinkTrading.Backend.WinForms
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void cancbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("Enter Name of Customer", "Missing Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                return;
            }

            if (txtaddress.Text == "")
            {
                MessageBox.Show("Enter Customer Address", "Missing Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtaddress.Focus();
                return;
            }

            if (txtContactNo.Text == "")
            {
                MessageBox.Show("Enter Customer Contact", "Missing Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNo.Focus();
                return;
            }

            CustomerRequestModel newCust = new CustomerRequestModel()
            {
                CustomerId = null,
                CustomerAddress = txtaddress.Text,
                CustomerName = txtname.Text,
                EmailAddress = txtemail.Text,
                OtherDetails = txtdetails.Text,
                PhoneNumber = txtContactNo.Text,
                VatRegistrationNumber = txtvagregNo.Text,
            };

            CustomerItemResultModel validationCheck = CustomerLogic.ValidateCustomer(newCust);

            if (validationCheck.CustomerId != null)
            {
                MessageBox.Show(validationCheck.CustomerName + " has the same details with this new customer. Cannot proceed", "Duplicate Entries", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GenericItemResultModel CustomerNew = CustomerLogic.WriteCustomer(newCust);

            if (CustomerNew.Feedback == "Customer Successfully Added")
            {
                DialogResult d = MessageBox.Show(CustomerNew.Feedback + Environment.NewLine + "Do you want to add another new Customer?", "Customer Added", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    txtaddress.Text = "";
                    txtdetails.Text = "";
                    txtemail.Text = "";
                    txtvagregNo.Text = "";
                    txtname.Text = "";
                    txtContactNo.Text = "";
                    txtname.Focus();
                }
                else
                {
                    Close();
                }
            }
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
