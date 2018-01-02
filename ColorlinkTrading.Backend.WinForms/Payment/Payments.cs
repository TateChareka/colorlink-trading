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
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }
        private CustomerListResultModel customers;
        private void Payments_Load(object sender, EventArgs e)
        {
            custList.Items.Clear();
            paymentDate.Value = DateTime.Today;
            customers = CustomerLogic.SearchCustomerList(
                new GenericSearchRequestModel()
                {
                    OrderDirection = "ASC",
                    OrderField = "CustomerId",
                    PageNumber = 1,
                    PageSize = 1000
                });
            foreach (var item in customers.Customers)
            {
                custList.Items.Add(item.CustomerName);
            }
            paymentDate.MaxDate = DateTime.Today;
        }

        private void custList_SelectedIndexChanged(object sender, EventArgs e)
        {
            custid.Text = "";
            custid.Text = customers.Customers.Where(b => b.CustomerName == custList.SelectedItem.ToString()).FirstOrDefault().CustomerId + "";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void paymentDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtAmount.Text != "")
            {
                try
                {
                    Double r = Double.Parse(txtAmount.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Only Digits are allowed", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmount.Clear();
                    txtAmount.Focus();
                    return;
                }
            }
        }

        private void GroupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (custList.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Customer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                custList.Focus();
                return;
            }

            if (txtAmount.Text == "")
            {
                MessageBox.Show("Enter Payment Amount", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }

            if (txtReference.Text == "")
            {
                MessageBox.Show("Enter Payment Payment Reference", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReference.Focus();
                return;
            }

            if (ProcessPayment())
            {
                DialogResult d = MessageBox.Show("Payment Successfully Added." + Environment.NewLine + "Do you want to add another payment?", "Payment Added", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    txtAmount.Text = "";
                    txtReference.Text = "";
                    custList.Items.Clear();
                    paymentDate.Value = DateTime.Today;
                    customers = CustomerLogic.SearchCustomerList(
                        new GenericSearchRequestModel()
                        {
                            OrderDirection = "ASC",
                            OrderField = "CustomerId",
                            PageNumber = 1,
                            PageSize = 1000
                        });
                    foreach (var item in customers.Customers)
                    {
                        custList.Items.Add(item.CustomerName);
                    }

                }
                else
                {
                    Close();
                }
            }



        }

        private bool ProcessPayment()
        {
            PaymentRequestModel newPayment = new PaymentRequestModel()
            {
                PaymentAmount = decimal.Parse(txtAmount.Text),
                PaymentDescription = txtReference.Text,
                PaymentDate = paymentDate.Value,
                CustomerId = Int32.Parse(custid.Text)
            };

            GenericItemResultModel state = PaymentLogic.WritePayment(newPayment);
            if (state.Feedback == "Payment Successfully Added")
            {
                return true;
            }
            return false;
        }

    }
}
