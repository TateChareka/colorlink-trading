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

namespace ColorlinkTrading.Backend.WinForms.Delivery_Note
{
    public partial class PrintDeliveryNote : Form
    {
        public PrintDeliveryNote()
        {
            InitializeComponent();
        }
        private int invoiceCount = 0;
        private ConnectionInfo crConnectionInfo;
        private void PrintDeliveryNote_Load(object sender, EventArgs e)
        {
            invoiceCount = (DeliveryNoteLogic.DeliveryNoteCount(
              new GenericSearchRequestModel()
              {

              }) + 100);
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
                MessageBox.Show("Enter an Delivery Note Number to Proceed", "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TextBox1.Focus();
                return;
            }

            int invoiceNumber = Int32.Parse(TextBox1.Text);

            if (invoiceNumber < 100 || invoiceNumber > invoiceCount - 1)
            {
                MessageBox.Show("Delivery Note Number should be between 100 and " + invoiceCount, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBox1.Clear();
                TextBox1.Focus();
                return;
            }
            ReportDocument newReport = new ReportDocument();
            newReport.Load(@"C:\Projects\ColorlinkTrading\ColorlinkTrading.Backend.WinForms\Reports\ReportDNote.rpt");
            //ReportVatInvoice newReport = new ReportVatInvoice();
            newReport.SetParameterValue("InvoiceNumber", invoiceNumber);
            CrystalReportViewer1.ReportSource = newReport;
            CrystalReportViewer1.Refresh();
        }
    }
}
