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

namespace ColorlinkTrading.Backend.WinForms.Product
{ 
    public partial class EditProduct : Form
    {
        private ProductListResultModel productList;
        public EditProduct()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAfter15pcVatUS.Text = "";
            txtComments.Text = "";
            txtCompetitorDetails.Text = "";
            txtCompetitorPrice.Text = "";
            //txtExchangeRate.Text = "13.05";
            txtFinalPrice.Text = "";
            //txtmarkupPc.Text = "35";
            txtName.Text = "";
            txtPriceAfter14Vat.Text = "";
            txtPriceAfterMarkup.Text = "";
            txtRand.Text = "";
            txtUSValue.Text = "";
            txtName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Enter Product Name to proceed", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Text = "";
                txtName.Focus();
                return;
            }

            if (txtRand.Text == "" || txtUSValue.Text == "")
            {
                MessageBox.Show("Enter Product Value to proceed", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Text = "";
                txtName.Focus();
                return;
            }

            ProductRequestModel newProduct = new ProductRequestModel()
            {
                CashPrice = Decimal.Parse(txtUSValue.Text),
                Comments = txtComments.Text,
                CompetitorDetails = txtCompetitorDetails.Text,
                CompetitorPrice = Decimal.Parse(txtCompetitorPrice.Text),
                ExchangeRate = Decimal.Parse(txtExchangeRate.Text),
                MarkUpPercentage = Decimal.Parse(txtmarkupPc.Text),
                PriceIncVat = Decimal.Parse(txtFinalPrice.Text),
                ProductName = txtName.Text,
                RandPricePostMarkup = Decimal.Parse(txtPriceAfterMarkup.Text),
                RandPricePostVat = Decimal.Parse(txtPriceAfter14Vat.Text),
                RandPricePreVat = Decimal.Parse(txtRand.Text),
                VatAmount = Decimal.Parse(txtAfter15pcVatUS.Text)
            };

            ProductItemResultModel validationCheck = ProductLogic.ValidateProduct(newProduct);

            if (validationCheck.ProductId != null && (validationCheck.ProductId != int.Parse(txtprodid.Text)))
            {
                MessageBox.Show(validationCheck.ProductName + " has the same details but different Product ID with this product. Cannot proceed", "Duplicate Entries", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GenericItemResultModel ProductNew = ProductLogic.WriteProduct(newProduct);

            if (ProductNew.Feedback == "Edit Product Successful")
            {
                DialogResult d = MessageBox.Show(ProductNew.Feedback + Environment.NewLine + "Do you want to add another new Product?", "Product Added", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    btnClear_Click(sender, e);
                }
                else
                {
                    Close();
                }

            }
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            productList = ProductLogic.SearchProductList(
                new GenericSearchRequestModel()
                {
                    OrderDirection = "ASC",
                    OrderField = "ProductId",
                    PageNumber = 1,
                    PageSize = 1000
                });

            foreach (var item in productList.Products)
            {
                prodList.Items.Add(item.ProductName);
            }
        }

        private void prodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = productList.Products.Where(b => b.ProductName == prodList.SelectedItem.ToString()).FirstOrDefault();
            txtName.Text = data.ProductName;
            txtPriceAfter14Vat.Text = string.Format("#,###0.00", data.RandPricePostVat);
            txtPriceAfterMarkup.Text = string.Format("#,###0.00", data.RandPricePostMarkup);
            txtComments.Text = data.Comments;
            txtCompetitorDetails.Text = data.CompetitorDetails;
            txtUSValue.Text = string.Format("#,###0.00", data.CashPrice);
            txtCompetitorPrice.Text = string.Format("#,###0.00", data.CompetitorPrice);
            txtExchangeRate.Text= string.Format("#,###0.00", data.ExchangeRate);
            txtmarkupPc.Text= string.Format("#,###0.00", data.MarkUpPercentage);
            txtFinalPrice.Text= string.Format("#,###0.00", data.PriceIncVat);
            txtRand.Text= string.Format("#,###0.00", data.RandPricePreVat);
            txtAfter15pcVatUS.Text= string.Format("#,###0.00", data.VatAmount);
        }

        private void txtRand_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtUSValue_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtExchangeRate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtmarkupPc_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtExchangeRate_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Double r = Double.Parse(txtExchangeRate.Text);
                txtPriceAfter14Vat.Text = Math.Round((1.14 * r), 2) + "";
                txtPriceAfterMarkup.Text = Math.Round(Double.Parse(txtPriceAfter14Vat.Text) * ((100 + Double.Parse(txtmarkupPc.Text) / 100)), 2) + "";
                txtUSValue.Text = Math.Round((Double.Parse(txtPriceAfterMarkup.Text)) / Double.Parse(txtExchangeRate.Text), 2) + "";
                txtAfter15pcVatUS.Text = Math.Round(0.15 * Double.Parse(txtUSValue.Text), 2) + "";
                txtFinalPrice.Text = Math.Round(1.15 * Double.Parse(txtUSValue.Text), 2) + "";
                txtRand.Text = Math.Round((Double.Parse(txtPriceAfter14Vat.Text) / 1.14), 2) + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Only Digits are allowed", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExchangeRate.Text = "13.05";
                return;
            }
        }

        private void txtmarkupPc_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Double r = Double.Parse(txtmarkupPc.Text);
                if (r > 100 || r < 0)
                {
                    MessageBox.Show("Markup Percentage should be Between 0 and 100", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtmarkupPc.Text = "35";
                    return;
                }
                txtPriceAfter14Vat.Text = Math.Round((1.14 * r), 2) + "";
                txtPriceAfterMarkup.Text = Math.Round(Double.Parse(txtPriceAfter14Vat.Text) * ((100 + Double.Parse(txtmarkupPc.Text) / 100)), 2) + "";
                txtUSValue.Text = Math.Round((Double.Parse(txtPriceAfterMarkup.Text)) / Double.Parse(txtExchangeRate.Text), 2) + "";
                txtAfter15pcVatUS.Text = Math.Round(0.15 * Double.Parse(txtUSValue.Text), 2) + "";
                txtFinalPrice.Text = Math.Round(1.15 * Double.Parse(txtUSValue.Text), 2) + "";
                txtRand.Text = Math.Round((Double.Parse(txtPriceAfter14Vat.Text) / 1.14), 2) + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Only Digits are allowed", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmarkupPc.Text = "35";
                return;
            }
        }

        private void txtRand_KeyUp(object sender, KeyEventArgs e)
        {
            if ((txtRand.Text != ""))
            {
                try
                {
                    Double r = Double.Parse(txtRand.Text);
                    txtPriceAfter14Vat.Text = Math.Round((1.14 * r), 2) + "";
                    txtPriceAfterMarkup.Text = Math.Round(Double.Parse(txtPriceAfter14Vat.Text) * ((100 + Double.Parse(txtmarkupPc.Text) / 100)), 2) + "";
                    txtUSValue.Text = Math.Round((Double.Parse(txtPriceAfterMarkup.Text)) / Double.Parse(txtExchangeRate.Text), 2) + "";
                    txtAfter15pcVatUS.Text = Math.Round(0.15 * Double.Parse(txtUSValue.Text), 2) + "";
                    txtFinalPrice.Text = Math.Round(1.15 * Double.Parse(txtUSValue.Text), 2) + "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Only Digits are allowed", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRand.Text = "";
                    txtRand.Focus();
                    return;
                }
            }
            else
            {
                txtPriceAfter14Vat.Text = "";
                txtPriceAfterMarkup.Text = "";
                txtUSValue.Text = "";
                txtFinalPrice.Text = "";
                txtAfter15pcVatUS.Text = "";
            }
        }

        private void txtUSValue_KeyUp(object sender, KeyEventArgs e)
        {
            if ((txtUSValue.Text != ""))
            {
                try
                {
                    Double r = Double.Parse(txtUSValue.Text);
                    txtAfter15pcVatUS.Text = Math.Round(0.15 * Double.Parse(txtUSValue.Text), 2) + "";
                    txtFinalPrice.Text = Math.Round(1.15 * Double.Parse(txtUSValue.Text), 2) + "";
                    txtPriceAfterMarkup.Text = Math.Round((Double.Parse(txtUSValue.Text)) * Double.Parse(txtExchangeRate.Text), 2) + "";
                    txtPriceAfter14Vat.Text = Math.Round(Double.Parse(txtPriceAfterMarkup.Text) / ((100 + Double.Parse(txtmarkupPc.Text)) / 100), 2) + "";
                    txtRand.Text = Math.Round((Double.Parse(txtPriceAfter14Vat.Text) / 1.14), 2) + "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Only Digits are allowed", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUSValue.Text = "";
                    txtUSValue.Focus();
                    return;
                }
            }
            else
            {
                txtPriceAfter14Vat.Text = "";
                txtPriceAfterMarkup.Text = "";
                txtRand.Text = "";
                txtFinalPrice.Text = "";
                txtAfter15pcVatUS.Text = "";
            }
        }
    }
}
