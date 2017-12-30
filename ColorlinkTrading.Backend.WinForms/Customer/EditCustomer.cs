using ColorlinkTrading.Logic;
using ColorlinkTrading.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorlinkTrading.Backend.WinForms
{
    public partial class EditCustomer : Form
    {
        private CustomerListResultModel customerList;
        public EditCustomer()
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
                CustomerAddress = txtaddress.Text,
                CustomerId = Int32.Parse(txtcustId.Text),
                CustomerName = txtname.Text,
                EmailAddress = txtemail.Text,
                OtherDetails = txtdetails.Text,
                PhoneNumber = txtContactNo.Text,
                VatRegistrationNumber = txtvagregNo.Text,
            };

            CustomerItemResultModel validationCheck = CustomerLogic.ValidateCustomer(newCust);

            if (validationCheck.CustomerId != null && (validationCheck.CustomerId != int.Parse(txtcustId.Text)))
            {
                MessageBox.Show(validationCheck.CustomerName + " has the same details but different Customer ID with this customer. Cannot proceed", "Duplicate Entries", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GenericItemResultModel CustomerNew = CustomerLogic.WriteCustomer(newCust);

            if (CustomerNew.Feedback == "Edit Customer Successful")
            {
                DialogResult d = MessageBox.Show(CustomerNew.Feedback + Environment.NewLine + "Do you want to edit another Customer?", "Customer Edited", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    reloadForm();
                }
                else
                {
                    Close();
                }
            }
        }

        private void reloadForm()
        {
            custlist.Items.Clear();
            customerList = CustomerLogic.SearchCustomerList(
                new GenericSearchRequestModel()
                {
                    OrderDirection = "ASC",
                    OrderField = "CustomerId",
                    PageNumber = 1,
                    PageSize = 1000
                });

            foreach (var item in customerList.Customers)
            {
                custlist.Items.Add(item.CustomerName);
                //custIDList.Items.Add(item.CustomerId);
            }
            txtaddress.Text = "";
            txtdetails.Text = "";
            txtemail.Text = "";
            txtvagregNo.Text = "";
            txtname.Text = "";
            txtContactNo.Text = "";
            custlist.Focus();
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            customerList = CustomerLogic.SearchCustomerList(
                new GenericSearchRequestModel()
                {
                    OrderDirection = "ASC",
                    OrderField = "CustomerId",
                    PageNumber = 1,
                    PageSize = 1000
                });

            foreach (var item in customerList.Customers)
            {
                custlist.Items.Add(item.CustomerName);
                //custIDList.Items.Add(item.CustomerId);
            }

        }

        private void custlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = customerList.Customers.Where(b => b.CustomerName == custlist.SelectedItem.ToString()).FirstOrDefault();
            txtaddress.Text = data.CustomerAddress;
            txtdetails.Text = data.OtherDetails;
            txtemail.Text = data.EmailAddress;
            txtvagregNo.Text = data.VatRegistrationNumber;
            txtname.Text = data.CustomerName;
            txtcustId.Text = data.CustomerId + "";
            txtContactNo.Text = data.PhoneNumber;
        }
    }
}
