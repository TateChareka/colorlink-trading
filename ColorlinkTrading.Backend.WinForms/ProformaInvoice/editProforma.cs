﻿using ColorlinkTrading.Logic;
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

namespace ColorlinkTrading.Backend.WinForms.ProformaInvoice
{
    public partial class editProforma : Form
    {
        public editProforma()
        {
            InitializeComponent();
        }
        private CustomerListResultModel customers;
        private ProductListResultModel products;
        private int prodID;

        private int invoiceCount = 0;
        private void editProforma_Load(object sender, EventArgs e)
        {
            Width = 486; Height = 104;
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
            products = ProductLogic.SearchProductList(
                new GenericSearchRequestModel()
                {
                    OrderDirection = "ASC",
                    OrderField = "ProductId",
                    PageNumber = 1,
                    PageSize = 1000
                });

            foreach (var item in products.Products)
            {
                prodList.Items.Add(item.ProductName);
            }
            invoiceCount = (ProformaInvoiceLogic.ProformaInvoiceCount(
                new GenericSearchRequestModel()
                {
                }) + 102);
        }

        private void cancbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void custList_SelectedIndexChanged(object sender, EventArgs e)
        {
            custid.Text = "";
            custid.Text = customers.Customers.Where(b => b.CustomerName == custList.SelectedItem.ToString()).FirstOrDefault().CustomerId + "";
        }

        private void prodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prodList.SelectedIndex != -1)
            {
                prodid.Text = "";
                txtprice.Text = "";
                proddescr.Text = "";
                var product = products.Products.Where(b => b.ProductName == prodList.SelectedItem.ToString()).FirstOrDefault();
                prodid.Text = product.ProductId + "";
                txtprice.Text = product.CashPrice + "";
                proddescr.Text = product.ProductName;
            }
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Focus();
            txtqty.Text = "";
            txtprice.Text = "";
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            prodList.Items.Clear();

            if (txtSearch.Text != "")
            {
                var SearchProducts = products.Products.Where(b => b.ProductName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

                foreach (var item in SearchProducts)
                {
                    prodList.Items.Add(item.ProductName);
                }
            }
            else
            {
                products = ProductLogic.SearchProductList(
                new GenericSearchRequestModel()
                {
                    OrderDirection = "ASC",
                    OrderField = "ProductId",
                    PageNumber = 1,
                    PageSize = 1000
                });
                foreach (var item in products.Products)
                {
                    prodList.Items.Add(item.ProductName);
                }
            }

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (prodList.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Product to Proceed", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                prodList.Focus();
                return;
            }

            if (txtqty.Text == "")
            {
                MessageBox.Show("Enter Product Quantity to Proceed", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtqty.Focus();
                return;
            }
            foreach (ListViewItem item in invoiceProducts.Items)
            {
                if (item.SubItems[1].Text == prodList.Text)
                {
                    prodList.Items.Remove(prodList.Text);
                    return;
                }
            }
            invoiceProducts.Items.Add(new ListViewItem(new[] { txtqty.Text, prodList.Text, Math.Round(Decimal.Parse(txtprice.Text), 2) + "", Math.Round((Decimal.Parse(txtprice.Text) * Decimal.Parse(txtqty.Text)), 2) + "", prodid.Text, 0 + "" }));
            prodList.Items.Remove(prodList.Text);
            prodid.Clear();
            txtprice.Clear();
            proddescr.Clear();
            txtqty.Clear();
            txtsubtot.Clear();
            txttotam.Clear();
            txtvat.Clear();
            txtSearch.Clear();
            calculate();
        }

        private void calculate()
        {
            txtsubtot.Clear();
            txttotam.Clear();
            txtvat.Clear();
            txtdiscount.Clear();

            double subtot = 0;
            double discount = 0;
            double discountPc = 0;
            double totam = 0;
            double vat = 0;

            foreach (ListViewItem item in invoiceProducts.Items)
            {
                subtot += double.Parse(item.SubItems[3].Text);
            }
            txtsubtot.Text = subtot + "";

            if (discotxt.Text == "")
            {
                discotxt.Text = "0.00";
                discountPc = 0;
            }
            else
            {
                discountPc = double.Parse(discotxt.Text);
            }
            discount = Math.Round(subtot * (discountPc / 100), 2);
            txtdiscount.Text = discount + "";
            subtot = Math.Round(subtot - discount, 2);
            vat = Math.Round(subtot * 0.15, 2);
            txtvat.Text = vat + "";
            totam = Math.Round(subtot + vat, 2);
            txttotam.Text = totam + "";
        }

        private void rmvbtn_Click(object sender, EventArgs e)
        {
            if (invoiceProducts.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in invoiceProducts.Items)
                {
                    if (item.SubItems[1].Text == invoiceProducts.SelectedItems[0].SubItems[1].Text)
                    {
                        invoiceProducts.Items.Remove(item);
                        var prod = ProductLogic.GetProduct(
                            new ProductRequestModel()
                            {
                                ProductId = Int32.Parse(item.SubItems[4].Text)
                            });
                        prodList.Items.Add(prod.ProductName);
                    }
                }
                prodid.Clear();
                txtprice.Clear();
                proddescr.Clear();
                txtqty.Clear();
                calculate();
            }
            else
            {
                MessageBox.Show("No Product to Remove Selected", "Removing Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            custList.Items.Clear();
            prodList.Items.Clear();
            invoiceProducts.Items.Clear();
            txtsubtot.Clear();
            txttotam.Clear();
            txtvat.Clear();
            txtdiscount.Clear();
            txtponumber.Clear();
            editProforma_Load(sender, e);
        }

        private void procinvbtn_Click(object sender, EventArgs e)
        {
            if (custList.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Customer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                custList.Focus();
                return;
            }

            if (invoiceProducts.Items.Count > 0)
            {
                if (invdate.Value > DateTime.Today || invdate.Value < DateTime.Today)
                {
                    DialogResult dateAsk = MessageBox.Show("Date is not equal to todays date, Are you sure you want to continue?", "Proforma Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dateAsk == DialogResult.No)
                    {
                        invdate.Focus();
                        return;
                    }
                }

                DialogResult a = MessageBox.Show("Are you sure you want to edit this proforma?", "Proforma Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (a == DialogResult.Yes)
                {
                    if (creatInvoice())
                    {
                        DialogResult d = MessageBox.Show("Proforma Successfully Created." + Environment.NewLine + "Do you want to add another proforma?", "Proforma Created", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (d == DialogResult.Yes)
                        {
                            Button1_Click(sender, e);
                        }
                        else
                        {
                            Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Products added to create invoice", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private bool creatInvoice()
        {
            ProformaRequestModel invoiceNew = new ProformaRequestModel()
            {
                CustomerId = Int32.Parse(custid.Text),
                CustomerName = custList.Text,
                ProformaNumber = prodID,
                Discount = decimal.Parse(txtdiscount.Text),
                DisplayValue = INVnO.Text,
                ExtraDetails = "",
                ProformaDate = invdate.Value,
                NumberOfProducts = invoiceProducts.Items.Count,
                Reference = txtponumber.Text,
                VATAmount = decimal.Parse(txtvat.Text),
                SubTotal = decimal.Parse(txtsubtot.Text),
                TotalAmount = decimal.Parse(txttotam.Text),
                ProductProforma = new List<ProformaProductItemResultModel>()
            };

            foreach (ListViewItem item in invoiceProducts.Items)
            {
                ProformaProductItemResultModel invoiceProduct = new ProformaProductItemResultModel()
                {
                    ProformaNo = invoiceNew.ProformaNumber,
                    Quantity = Int32.Parse(item.SubItems[0].Text),
                    ProductName = item.SubItems[1].Text,
                    UnitPrice = decimal.Parse(item.SubItems[2].Text),
                    Amount = decimal.Parse(item.SubItems[3].Text),
                    ProdId = Int32.Parse(item.SubItems[4].Text),
                };
                invoiceNew.ProductProforma.Add(invoiceProduct);
            }

            GenericItemResultModel state = ProformaInvoiceLogic.WriteProforma(invoiceNew);
            if (state.Feedback == "Edit Proforma Successful")
            {
                return true;
            }
            return false;
        }

        private void txtprice_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtprice.Text != "")
            {
                try
                {
                    Double r = Double.Parse(txtprice.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Only Digits are allowed", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtprice.Clear();
                    txtprice.Focus();
                    return;
                }
            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text != "")
            {
                Int32 r = Int32.Parse(TextBox1.Text);
                if (r < 100 || r > invoiceCount - 1)
                {
                    MessageBox.Show("Qoutation Number should be between 100 and " + invoiceCount, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBox1.Clear();
                    TextBox1.Focus();
                    return;
                }
                int invNo = Int32.Parse(TextBox1.Text);

                var qoutation = ProformaInvoiceLogic.GetProforma(
                    new ProformaRequestModel()
                    {
                        ProformaNumber = invNo
                    });
                prodID = qoutation.ProformaNumber;
                if (qoutation == null)
                {
                    MessageBox.Show("Proforma not found" + Environment.NewLine + "Please ensure you have entered the correct Proforma number", "Invalid Proforma Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBox1.Clear();
                    TextBox1.Focus();
                    return;
                }

                Width = 991;
                Height = 735;
                invoiceProducts.Items.Clear();
                txtsubtot.Clear();
                txttotam.Clear();
                txtvat.Clear();
                txtdiscount.Clear();
                txtponumber.Clear();
                custid.Text = qoutation.CustomerId + "";
                custList.SelectedItem = (qoutation.CustomerName);
                DateTime d;
                if (qoutation.ProformaDate != null)
                {
                    d = DateTime.Parse(qoutation.ProformaDate + "");
                }
                else
                {
                    d = DateTime.Now;
                }
                INVnO.Text = TextBox1.Text;
                invdate.Value = d;
                txtponumber.Text = qoutation.Reference;
                foreach (var item in qoutation.ProductProforma)
                {
                    invoiceProducts.Items.Add(new ListViewItem(new[] { item.Quantity + "", item.ProductName, item.UnitPrice + "", item.Amount + "", item.ProdId + "", item.ProductProformaId + "" }));
                }
                prodList.Items.Remove(prodList.Text);
                prodid.Clear();
                txtprice.Clear();
                proddescr.Clear();
                txtqty.Clear();
                txtsubtot.Clear();
                txttotam.Clear();
                txtvat.Clear();
                txtSearch.Clear();
                calculate();
            }
        }
        private void txtqty_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtqty.Text != "")
            {
                try
                {
                    Double r = Double.Parse(txtqty.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Only Digits are allowed", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtqty.Clear();
                    txtqty.Focus();
                    return;
                }
            }
        }

        private void discotxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (discotxt.Text != "")
            {
                try
                {
                    Double r = Double.Parse(discotxt.Text);
                    if (r > 50 || r < 0)
                    {
                        MessageBox.Show("Discount Percentage should be Between 0 and 50", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        discotxt.Text = "0";
                        return;
                    }
                    else
                    {
                        calculate();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Only Digits are allowed", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    discotxt.Text = "0";
                    return;
                }
            }
        }
    }
}
