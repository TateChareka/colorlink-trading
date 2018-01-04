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

namespace ColorlinkTrading.Backend.WinForms.Customer
{
    public partial class Statements : Form
    {
        private CustomerListResultModel customers;
        private PaymentListResultModel payments;
        private VatInvoiceListResultModel Invoices;
        private decimal AmountDue = 0, Debit = 0, Credit = 0;
        private int DebitTotal = 0, CreditTotal = 0;
        public Statements()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Statements_Load(object sender, EventArgs e)
        {
            Width = 614; Height = 647;
            custList.Items.Clear();
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
            payments = PaymentLogic.PaymentList(new GenericSearchRequestModel() { });
            Invoices = VatInvoiceLogic.VATInvoiceList(new GenericSearchRequestModel() { });
        }

        private void custList_SelectedIndexChanged(object sender, EventArgs e)
        {
            custid.Text = "";
            custid.Text = customers.Customers.Where(b => b.CustomerName == custList.SelectedItem.ToString()).FirstOrDefault().CustomerId + "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (custList.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Customer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                custList.Focus();
                return;
            }

            if (dateFrom.Value == null)
            {
                MessageBox.Show("Select a Start Date", "MIssing Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateFrom.Focus();
                return;
            }

            if (dateTo.Value == null)
            {
                MessageBox.Show("Select an End Date", "MIssing Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTo.Focus();
                return;
            }

            if (dateTo.Value < dateFrom.Value)
            {
                MessageBox.Show("End Date must be later than Start Date", "Input Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dateFrom.Focus();
                return;
            }

            displayView.Items.Clear();
            hiddenView.Items.Clear();

            var custId = Int32.Parse(custid.Text);

            var statementInvoices = Invoices.VatInvoices.Where(b => b.CustomerId == custId && b.InvoiceDate >= dateFrom.Value && b.InvoiceDate <= dateTo.Value).ToList();
            foreach (var invoice in statementInvoices)
            {
                hiddenView.Items.Add(new ListViewItem(new[] { String.Format("{0:dd/MM/yyyy}", invoice.InvoiceDate), invoice.InvoiceNumber + "", "INVOICE", invoice.TotalAmount + "", "", "" }));
            }

            var statementPayments = payments.Payments.Where(b => b.CustomerId == custId && b.PaymentDate >= dateFrom.Value && b.PaymentDate <= dateTo.Value).ToList();
            foreach (var payment in statementPayments)
            {
                hiddenView.Items.Add(new ListViewItem(new[] { String.Format("{0:dd/MM/yyyy}", payment.PaymentDate), payment.PaymentDescription, "PAYMENT", "", payment.PaymentAmount + "", "" }));
            }
            balanceSheet();
        }
        private void balanceSheet()
        {
            AmountDue = 0; Debit = 0; Credit = 0;
            DebitTotal = 0; CreditTotal = 0;

            foreach (ListViewItem item in hiddenView.Items)
            {
                if (item.SubItems[2].Text == "INVOICE")
                {
                    AmountDue += decimal.Parse(item.SubItems[3].Text);
                    Debit += decimal.Parse(item.SubItems[3].Text);
                    DebitTotal += 1;
                    displayView.Items.Add(new ListViewItem(new[] { (item.SubItems[0].Text), (item.SubItems[1].Text), "INVOICE", (item.SubItems[3].Text), "", Math.Round(1 * AmountDue, 2) + "" }));
                }
                else
                {
                    AmountDue -= decimal.Parse(item.SubItems[4].Text);
                    Credit += decimal.Parse(item.SubItems[4].Text);
                    CreditTotal += 1;
                    displayView.Items.Add(new ListViewItem(new[] { item.SubItems[0].Text, (item.SubItems[1].Text), "PAYMENT", "", (item.SubItems[4].Text), Math.Round(1 * AmountDue, 2) + "" }));
                }
            }
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            TextBox4.Clear();
            TextBox5.Clear();
            TextBox1.Text = Math.Round(1 * AmountDue, 2) + "";
            TextBox2.Text = Math.Round(1 * Credit, 2) + "";
            TextBox3.Text = Math.Round(1 * Debit, 2) + "";
            TextBox4.Text = CreditTotal + "";
            TextBox5.Text = DebitTotal + "";
        }
    }
}
