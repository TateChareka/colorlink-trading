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

namespace ColorlinkTrading.Backend.WinForms.ProformaInvoice
{
    public partial class PrintProforma : Form
    {
        public PrintProforma()
        {
            InitializeComponent();
        }
        private int invoiceCount = 0;
        private ConnectionInfo crConnectionInfo;
        private void PrintProforma_Load(object sender, EventArgs e)
        {
            invoiceCount = (QoutationLogic.QoutationCount(
              new GenericSearchRequestModel()
              {

              }) + 102);
            crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = "(local)";
            crConnectionInfo.DatabaseName = "colorlinkTrading";
            crConnectionInfo.UserID = "sa";
            crConnectionInfo.Password = "Rabbits@2008";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                MessageBox.Show("Enter an Proforma Number to Proceed", "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TextBox1.Focus();
                return;
            }

            int invoiceNumber = Int32.Parse(TextBox1.Text);

            if (invoiceNumber < 100 || invoiceNumber > invoiceCount - 1)
            {
                MessageBox.Show("Proforma Number should be between 100 and " + invoiceCount, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBox1.Clear();
                TextBox1.Focus();
                return;
            }
            var invNo = (ProformaInvoiceLogic.GetProforma(
                new ProformaRequestModel()
                {
                     ProformaNumber = invoiceNumber
                }).ProformaNumber);
            ReportDocument newReport = new ReportDocument();
            newReport.Load(@"C:\Projects\ColorlinkTrading\ColorlinkTrading.Backend.WinForms\Reports\ReportProformaInvoice.rpt");
            //ReportVatInvoice newReport = new ReportVatInvoice();
            newReport.SetParameterValue("InvoiceNumber", invNo);
            CrystalReportViewer1.ReportSource = newReport;
            CrystalReportViewer1.Refresh();
        }
    }
}
