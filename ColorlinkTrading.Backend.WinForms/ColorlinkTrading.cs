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
using ColorlinkTrading.Backend.WinForms.Product;

namespace ColorlinkTrading.Backend.WinForms
{
    public partial class ColorlinkTrading : Form
    {
        public ColorlinkTrading()
        {
            InitializeComponent();
        }

        private void AddCustomerToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProduct addProd = new NewProduct();
            addProd.Show();
        }

        private void ViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ProductLogic.ProductCount(userLoggedIn) != 0)
            {
                EditProduct editProd = new EditProduct();
                editProd.Enabled = false;
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
            }
            else
            {
                MessageBox.Show("No Products Exist on the current system", "View Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProductLogic.ProductCount(userLoggedIn) != 0)
            {
                EditProduct editProd = new EditProduct();
                editProd.Show();
            }
            else
            {
                MessageBox.Show("No Products Exist on the current system", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
