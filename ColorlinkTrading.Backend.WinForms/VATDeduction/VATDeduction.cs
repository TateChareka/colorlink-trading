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
    public partial class VATDeduction : Form
    {
        public VATDeduction()
        {
            InitializeComponent();
        }

        private void VATDeduction_Load(object sender, EventArgs e)
        {
            paymentDate.Value = DateTime.Today;
            paymentDate.MaxDate = DateTime.Today;
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
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

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
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

            if (ProcessDeduction())
            {
                DialogResult d = MessageBox.Show("VAT Deduction Successfully Added." + Environment.NewLine + "Do you want to add another VAT deduction?", "VAT Deduction Added", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    txtAmount.Text = "";
                    txtReference.Text = "";
                    paymentDate.Value = DateTime.Today;
                }
                else
                {
                    Close();
                }
            }

        }
        private bool ProcessDeduction()
        {
            VATDeductionRequestModel newDeduction = new VATDeductionRequestModel()
            {
                VatAmount = decimal.Parse(txtAmount.Text),
                VATDeductionDescription = txtReference.Text,
                TransactionDate = paymentDate.Value
            };

            GenericItemResultModel state = VatDeductionLogic.WriteVatDeduction(newDeduction);
            if (state.Feedback == "Deduction Successfully Added")
            {
                return true;
            }
            return false;
        }

    }
}
