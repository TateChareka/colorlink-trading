using ColorlinkTrading.Backend.WinForms.Reports;
using ColorlinkTrading.Logic;
using ColorlinkTrading.Models;
using CrystalDecisions.CrystalReports.Engine;
using System;
using CrystalDecisions.Shared;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorlinkTrading.Backend.WinForms.VATInvoice
{
    public partial class PrintVatInvoice : Form
    {
        private int invoiceCount = 0;
        private ConnectionInfo crConnectionInfo;
        public PrintVatInvoice()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                MessageBox.Show("Enter an Invoice Number to Proceed", "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TextBox1.Focus();
                return;
            }

            int invoiceNumber = Int32.Parse(TextBox1.Text);

            if (invoiceNumber < 100 || invoiceNumber > invoiceCount)
            {
                MessageBox.Show("Invoice Number should be between 101 and " + invoiceCount, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBox1.Clear();
                TextBox1.Focus();
                return;
            }
            ReportDocument newReport = new ReportDocument();
            newReport.Load(@"C:\Projects\ColorlinkTrading\ColorlinkTrading.Backend.WinForms\Reports\ReportVatInvoice.rpt");
            //ReportVatInvoice newReport = new ReportVatInvoice();
            newReport.SetParameterValue("InvoiceNumber", invoiceNumber);
            CrystalReportViewer1.ReportSource = newReport;
            CrystalReportViewer1.Refresh();            
        }

        private void PrintVatInvoice_Load(object sender, EventArgs e)
        {
            invoiceCount = (VatInvoiceLogic.VatInvoiceCount(
                new GenericSearchRequestModel()
                {
                    OrderDirection = "ASC",
                    OrderField = "InvoiceNumber",
                    PageNumber = 1,
                    PageSize = 1000
                }) + 100);
            crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = "(local)";
            crConnectionInfo.DatabaseName = "colorlinkTrading";
            crConnectionInfo.UserID = "sa";
            crConnectionInfo.Password = "Rabbits@2008";
        }
    }
}
