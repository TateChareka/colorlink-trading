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

namespace ColorlinkTrading.Backend.WinForms.VATDeduction
{
    public partial class VATStatement : Form
    {
        private VATDeductionListResultModel vatDeductions;
        private VatInvoiceListResultModel Invoices;
        private decimal AmountDue = 0, Debit = 0, Credit = 0;
        private int DebitTotal = 0, CreditTotal = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
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

            var statementInvoices = Invoices.VatInvoices.Where(b => b.InvoiceDate >= dateFrom.Value && b.InvoiceDate <= dateTo.Value).ToList();
            foreach (var invoice in statementInvoices)
            {
                hiddenView.Items.Add(new ListViewItem(new[] { String.Format("{0:dd/MM/yyyy}", invoice.InvoiceDate), invoice.InvoiceNumber + "", "INVOICE", invoice.VatAmount + "", "", "" }));
            }

            var statementVATDeductions = vatDeductions.VATDeductions.Where(b => b.TransactionDate >= dateFrom.Value && b.TransactionDate <= dateTo.Value).ToList();
            foreach (var vatded in statementVATDeductions)
            {
                hiddenView.Items.Add(new ListViewItem(new[] { String.Format("{0:dd/MM/yyyy}", vatded.TransactionDate), vatded.VATDeductionDescription, "DEDUCTION", "", vatded.VatAmount + "", "" }));
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
        public VATStatement()
        {
            InitializeComponent();
        }

        private void VATStatement_Load(object sender, EventArgs e)
        {
            Width = 614; Height = 647;

            vatDeductions = VatDeductionLogic.VatDeductionList(new GenericSearchRequestModel() { });
            Invoices = VatInvoiceLogic.VATInvoiceList(new GenericSearchRequestModel() { });

        }
    }
}
