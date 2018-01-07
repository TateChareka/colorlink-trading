using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorlinkTrading.Models;
using ColorlinkTrading.Logic;

namespace ColorlinkTrading.Backend.WinForms
{
    public partial class ColorlinkTrading : Form
    {
        public ColorlinkTrading()
        {
            InitializeComponent();
        }

        private void AddCustomerToolStripMenuItem_ClickOLD(object sender, EventArgs e)
        {
            AddCustomer addCust = new AddCustomer();
            addCust.Show();
        }

        private void ColorlinkTrading_Load(object sender, EventArgs e)
        {
        }
        public GenericRequestModel userLoggedIn = new GenericRequestModel()
        {
            SessionUserName = "Administrator",
            SessionPersonId = 1,
            SessionUserId = 1
        };

        private void EditToolStripMenuItem1_ClickOLD(object sender, EventArgs e)
        {

        }

        private void ViewToolStripMenuItem_ClickOLD(object sender, EventArgs e)
        {

        }

        private void AddToolStripMenuItem_ClickOLD(object sender, EventArgs e)
        {

        }

        private void ViewToolStripMenuItem1_ClickOLD(object sender, EventArgs e)
        {

        }

        private void EditToolStripMenuItem_ClickOLD(object sender, EventArgs e)
        {
            if (ProductLogic.ProductCount(userLoggedIn) != 0)
            {
                Product.EditProduct editProd = new Product.EditProduct();
                editProd.Show();
            }
            else
            {
                MessageBox.Show("No Products Exist on the current system", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CreateToolStripMenuItem_ClickOLD(object sender, EventArgs e)
        {

        }

        private void PaymentToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void NewToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void ViewToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void SearchToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void PrintToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void EditInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void VatCalculationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void EditToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void NewFormatPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NewToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void EditToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void ViewToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void ConvertToInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CreateToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void NewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditToolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void ShowNewForm(object sender, EventArgs e)
        {

        }

        private void OpenFile(object sender, EventArgs e)
        {

        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddCustomerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void AddCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddCustomerToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            AddCustomer addCust = new AddCustomer();
            addCust.Show();
        }

        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CustomerLogic.CustomerCount(userLoggedIn) != 0)
            {
                EditCustomer editCust = new EditCustomer();
                editCust.Text = "View Customers";
                editCust.txtaddress.Enabled = false;
                editCust.txtContactNo.Enabled = false;
                editCust.txtcustId.Enabled = false;
                editCust.txtdetails.Enabled = false;
                editCust.txtemail.Enabled = false;
                editCust.txtname.Enabled = false;
                editCust.txtvagregNo.Enabled = false;
                editCust.editbtn.Visible = false;
                editCust.Show();
            }
            else
            {
                MessageBox.Show("No Customers Exist on the current system", "View Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void EditToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (CustomerLogic.CustomerCount(userLoggedIn) != 0)
            {
                EditCustomer editCust = new EditCustomer();
                editCust.Show();
            }
            else
            {
                MessageBox.Show("No Customers Exist on the current system", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PaymentToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            Payments newPayment = new Payments();
            newPayment.Show();
        }

        private void AddToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NewProduct addProd = new NewProduct();
            addProd.Show();
        }

        private void ViewToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (ProductLogic.ProductCount(userLoggedIn) != 0)
            {
                Product.EditProduct editProd = new Product.EditProduct();
                editProd.txtAfter15pcVatUS.Enabled = false;
                editProd.txtComments.Enabled = false;
                editProd.txtCompetitorDetails.Enabled = false;
                editProd.txtCompetitorPrice.Enabled = false;
                editProd.txtExchangeRate.Enabled = false;
                editProd.txtFinalPrice.Enabled = false;
                editProd.txtmarkupPc.Enabled = false;
                editProd.txtName.Enabled = false;
                editProd.txtPriceAfter14Vat.Enabled = false;
                editProd.txtPriceAfterMarkup.Enabled = false;
                editProd.txtRand.Enabled = false;
                editProd.txtUSValue.Enabled = false;
                editProd.btnAdd.Visible = false;
                editProd.Text = "View Product";
                editProd.Show();
            }
            else
            {
                MessageBox.Show("No Products Exist on the current system", "View Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void EditToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Product.EditProduct editProd = new Product.EditProduct();
            editProd.Show();
        }

        private void CreateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            VATInvoice.NewInvoice newInv = new VATInvoice.NewInvoice();
            newInv.Show();
        }

        private void vATDeductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VATDeduction.VATDeduction newVAT = new VATDeduction.VATDeduction();
            newVAT.Show();
        }

        private void NewToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            Customer.Statements newStatement = new Customer.Statements();
            newStatement.Show();
        }

        private void ViewToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {

        }

        private void ConvertToInvoiceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void PrintToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VATInvoice.PrintVatInvoice printInvoice = new VATInvoice.PrintVatInvoice();
            printInvoice.Show();
        }

        private void EditInvoiceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            VATInvoice.editInvoice editInvoice = new VATInvoice.editInvoice();
            editInvoice.Show();
        }

        private void VatCalculationsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            VATDeduction.VATStatement vatStatement = new VATDeduction.VATStatement();
            vatStatement.Show();
        }

        private void NewToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            Qoutation.NewQoutation newQoute = new Qoutation.NewQoutation();
            newQoute.Show();
        }

        private void EditToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            Qoutation.editQoutation editQoute = new Qoutation.editQoutation();
            editQoute.Show();
        }

        private void ViewToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            Qoutation.PrintQoutation printQoute = new Qoutation.PrintQoutation();
            printQoute.Show();
        }
    }
}
