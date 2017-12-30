using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorlinkTrading.Logic;
using ColorlinkTrading.Models;

namespace ColorlinkTrading.Backend.WinForms.CashReciept
{
    public partial class CashReciept : Form
    {
        public CashReciept()
        {
            InitializeComponent();
        }

        private void CashReciept_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //if (Int32.Parse(TextBox1.Text) <= 100 || Int32.Parse(TextBox1.Text) > ((ds1.InvoicesVat.Count) + 100))
            //{
            //    MessageBox.Show("Invoice Number should be between 101 and " + ((ds1.InvoicesVat.Count) + 100), "Duplicate Entries", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    TextBox1.Text = "";
            //    TextBox1.Focus();
            //    return;
            //}
            //else
            //{
            //    cashSaleRep1.SetParameterValue("InvNo", (Int32.Parse(TextBox1.Text) - 100));
            //    CrystalReportViewer1.ReportSource = cashSaleRep1;
            //    CrystalReportViewer1.Refresh();
            //}
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if ((TextBox1.Text != "")) {
                try {
                    int r = Int32.Parse(TextBox1.Text);
                } catch (Exception ex) {
                    MessageBox.Show("Only Digits are allowed", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBox1.Text = "";
                    TextBox1.Focus();
                    return;
                }               
            }  
        }
    }
}
