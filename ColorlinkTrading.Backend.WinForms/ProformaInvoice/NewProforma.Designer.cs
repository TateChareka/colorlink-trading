namespace ColorlinkTrading.Backend.WinForms.ProformaInvoice
{
    partial class NewProforma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.custid = new System.Windows.Forms.TextBox();
            this.custList = new System.Windows.Forms.ListBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.procinvbtn = new System.Windows.Forms.Button();
            this.rmvbtn = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.proddescr = new System.Windows.Forms.TextBox();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.txtponumber = new System.Windows.Forms.TextBox();
            this.invoiceProducts = new System.Windows.Forms.ListView();
            this.ColQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColProdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColUnitPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productVatInvoice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.prodid = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.prodList = new System.Windows.Forms.ListBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox10 = new System.Windows.Forms.GroupBox();
            this.INVnO = new System.Windows.Forms.TextBox();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.GroupBox15 = new System.Windows.Forms.GroupBox();
            this.discotxt = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txttotam = new System.Windows.Forms.TextBox();
            this.txtvat = new System.Windows.Forms.TextBox();
            this.txtsubtot = new System.Windows.Forms.TextBox();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.invdate = new System.Windows.Forms.DateTimePicker();
            this.cancbtn = new System.Windows.Forms.Button();
            this.GroupBox6.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox10.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox15.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.custid);
            this.GroupBox6.Controls.Add(this.custList);
            this.GroupBox6.Location = new System.Drawing.Point(6, 19);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(221, 215);
            this.GroupBox6.TabIndex = 49;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Select Customer";
            // 
            // custid
            // 
            this.custid.Location = new System.Drawing.Point(95, 97);
            this.custid.Name = "custid";
            this.custid.ReadOnly = true;
            this.custid.Size = new System.Drawing.Size(30, 20);
            this.custid.TabIndex = 2;
            this.custid.Visible = false;
            // 
            // custList
            // 
            this.custList.FormattingEnabled = true;
            this.custList.Location = new System.Drawing.Point(6, 19);
            this.custList.Name = "custList";
            this.custList.Size = new System.Drawing.Size(209, 186);
            this.custList.Sorted = true;
            this.custList.TabIndex = 0;
            this.custList.SelectedIndexChanged += new System.EventHandler(this.custlist_SelectedIndexChanged);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(645, 149);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(75, 49);
            this.addbtn.TabIndex = 41;
            this.addbtn.Text = "&Add to Invoice";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // procinvbtn
            // 
            this.procinvbtn.Location = new System.Drawing.Point(512, 449);
            this.procinvbtn.Name = "procinvbtn";
            this.procinvbtn.Size = new System.Drawing.Size(75, 51);
            this.procinvbtn.TabIndex = 46;
            this.procinvbtn.Text = "&Process Invoice";
            this.procinvbtn.UseVisualStyleBackColor = true;
            this.procinvbtn.Click += new System.EventHandler(this.procinvbtn_Click);
            // 
            // rmvbtn
            // 
            this.rmvbtn.Location = new System.Drawing.Point(880, 267);
            this.rmvbtn.Name = "rmvbtn";
            this.rmvbtn.Size = new System.Drawing.Size(75, 50);
            this.rmvbtn.TabIndex = 45;
            this.rmvbtn.Text = "&Remove from Invoice";
            this.rmvbtn.UseVisualStyleBackColor = true;
            this.rmvbtn.Click += new System.EventHandler(this.rmvbtn_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.proddescr);
            this.GroupBox3.Location = new System.Drawing.Point(745, 19);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(200, 215);
            this.GroupBox3.TabIndex = 44;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Product Description";
            // 
            // proddescr
            // 
            this.proddescr.Enabled = false;
            this.proddescr.Location = new System.Drawing.Point(7, 19);
            this.proddescr.Multiline = true;
            this.proddescr.Name = "proddescr";
            this.proddescr.Size = new System.Drawing.Size(187, 186);
            this.proddescr.TabIndex = 0;
            // 
            // txtqty
            // 
            this.txtqty.Location = new System.Drawing.Point(7, 20);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(92, 20);
            this.txtqty.TabIndex = 0;
            this.txtqty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtqty_KeyUp);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.txtponumber);
            this.GroupBox4.Location = new System.Drawing.Point(254, 434);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(200, 74);
            this.GroupBox4.TabIndex = 47;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Reference";
            // 
            // txtponumber
            // 
            this.txtponumber.Location = new System.Drawing.Point(6, 19);
            this.txtponumber.Multiline = true;
            this.txtponumber.Name = "txtponumber";
            this.txtponumber.Size = new System.Drawing.Size(188, 49);
            this.txtponumber.TabIndex = 0;
            // 
            // invoiceProducts
            // 
            this.invoiceProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColQuantity,
            this.ColProdName,
            this.ColUnitPrice,
            this.ColAmount,
            this.ProductId,
            this.productVatInvoice});
            this.invoiceProducts.FullRowSelect = true;
            this.invoiceProducts.GridLines = true;
            this.invoiceProducts.Location = new System.Drawing.Point(233, 240);
            this.invoiceProducts.MultiSelect = false;
            this.invoiceProducts.Name = "invoiceProducts";
            this.invoiceProducts.Size = new System.Drawing.Size(640, 188);
            this.invoiceProducts.TabIndex = 42;
            this.invoiceProducts.UseCompatibleStateImageBehavior = false;
            this.invoiceProducts.View = System.Windows.Forms.View.Details;
            // 
            // ColQuantity
            // 
            this.ColQuantity.Text = "Quantity";
            // 
            // ColProdName
            // 
            this.ColProdName.Text = "Product Name";
            this.ColProdName.Width = 350;
            // 
            // ColUnitPrice
            // 
            this.ColUnitPrice.Text = "Unit Price ($)";
            this.ColUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColUnitPrice.Width = 100;
            // 
            // ColAmount
            // 
            this.ColAmount.Text = "Amount ($)";
            this.ColAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColAmount.Width = 100;
            // 
            // ProductId
            // 
            this.ProductId.Width = 0;
            // 
            // productVatInvoice
            // 
            this.productVatInvoice.Width = 0;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.prodid);
            this.GroupBox2.Controls.Add(this.txtSearch);
            this.GroupBox2.Controls.Add(this.prodList);
            this.GroupBox2.Location = new System.Drawing.Point(233, 19);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(392, 215);
            this.GroupBox2.TabIndex = 39;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Select Product";
            // 
            // prodid
            // 
            this.prodid.Location = new System.Drawing.Point(181, 97);
            this.prodid.Name = "prodid";
            this.prodid.Size = new System.Drawing.Size(30, 20);
            this.prodid.TabIndex = 3;
            this.prodid.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtSearch.Location = new System.Drawing.Point(6, 189);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(380, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Click += new System.EventHandler(this.TextBox1_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // prodList
            // 
            this.prodList.FormattingEnabled = true;
            this.prodList.Location = new System.Drawing.Point(6, 19);
            this.prodList.Name = "prodList";
            this.prodList.Size = new System.Drawing.Size(380, 160);
            this.prodList.Sorted = true;
            this.prodList.TabIndex = 0;
            this.prodList.SelectedIndexChanged += new System.EventHandler(this.prodlist_SelectedIndexChanged);
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.txtprice);
            this.GroupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox5.Location = new System.Drawing.Point(631, 31);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(108, 53);
            this.GroupBox5.TabIndex = 48;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Product Price ($)";
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(6, 27);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(93, 20);
            this.txtprice.TabIndex = 2;
            this.txtprice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtprice_KeyUp);
            // 
            // GroupBox9
            // 
            this.GroupBox9.Controls.Add(this.txtqty);
            this.GroupBox9.Location = new System.Drawing.Point(631, 90);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Size = new System.Drawing.Size(108, 53);
            this.GroupBox9.TabIndex = 40;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "Enter Quantity";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Button5);
            this.GroupBox1.Controls.Add(this.Button4);
            this.GroupBox1.Controls.Add(this.Button3);
            this.GroupBox1.Controls.Add(this.Button2);
            this.GroupBox1.Controls.Add(this.Button1);
            this.GroupBox1.Controls.Add(this.GroupBox10);
            this.GroupBox1.Controls.Add(this.GroupBox8);
            this.GroupBox1.Controls.Add(this.GroupBox7);
            this.GroupBox1.Controls.Add(this.cancbtn);
            this.GroupBox1.Controls.Add(this.GroupBox6);
            this.GroupBox1.Controls.Add(this.GroupBox2);
            this.GroupBox1.Controls.Add(this.GroupBox5);
            this.GroupBox1.Controls.Add(this.GroupBox4);
            this.GroupBox1.Controls.Add(this.procinvbtn);
            this.GroupBox1.Controls.Add(this.rmvbtn);
            this.GroupBox1.Controls.Add(this.GroupBox3);
            this.GroupBox1.Controls.Add(this.GroupBox9);
            this.GroupBox1.Controls.Add(this.invoiceProducts);
            this.GroupBox1.Controls.Add(this.addbtn);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(958, 593);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            // 
            // Button5
            // 
            this.Button5.Enabled = false;
            this.Button5.Location = new System.Drawing.Point(512, 521);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(75, 51);
            this.Button5.TabIndex = 59;
            this.Button5.Text = "P&rint Invoice";
            this.Button5.UseVisualStyleBackColor = true;
            this.Button5.Visible = false;
            // 
            // Button4
            // 
            this.Button4.Location = new System.Drawing.Point(239, 534);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(97, 39);
            this.Button4.TabIndex = 58;
            this.Button4.Text = "PRODUCT PRICE FORMAT";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Visible = false;
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(136, 534);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(97, 39);
            this.Button3.TabIndex = 57;
            this.Button3.Text = "PRODUCT NAME UPPER";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Visible = false;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(46, 534);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(84, 39);
            this.Button2.TabIndex = 56;
            this.Button2.Text = "AUTOMATED INVOICES";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Visible = false;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(61, 463);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 39);
            this.Button1.TabIndex = 55;
            this.Button1.Text = "&Reset Invoice";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // GroupBox10
            // 
            this.GroupBox10.Controls.Add(this.INVnO);
            this.GroupBox10.Location = new System.Drawing.Point(12, 323);
            this.GroupBox10.Name = "GroupBox10";
            this.GroupBox10.Size = new System.Drawing.Size(112, 46);
            this.GroupBox10.TabIndex = 54;
            this.GroupBox10.TabStop = false;
            this.GroupBox10.Text = "INVOICE No";
            // 
            // INVnO
            // 
            this.INVnO.Location = new System.Drawing.Point(6, 19);
            this.INVnO.Name = "INVnO";
            this.INVnO.ReadOnly = true;
            this.INVnO.Size = new System.Drawing.Size(100, 20);
            this.INVnO.TabIndex = 0;
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.GroupBox15);
            this.GroupBox8.Controls.Add(this.Label4);
            this.GroupBox8.Controls.Add(this.txtdiscount);
            this.GroupBox8.Controls.Add(this.Label3);
            this.GroupBox8.Controls.Add(this.Label2);
            this.GroupBox8.Controls.Add(this.Label1);
            this.GroupBox8.Controls.Add(this.txttotam);
            this.GroupBox8.Controls.Add(this.txtvat);
            this.GroupBox8.Controls.Add(this.txtsubtot);
            this.GroupBox8.Location = new System.Drawing.Point(628, 444);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(317, 143);
            this.GroupBox8.TabIndex = 53;
            this.GroupBox8.TabStop = false;
            // 
            // GroupBox15
            // 
            this.GroupBox15.Controls.Add(this.discotxt);
            this.GroupBox15.Location = new System.Drawing.Point(84, 45);
            this.GroupBox15.Name = "GroupBox15";
            this.GroupBox15.Size = new System.Drawing.Size(81, 35);
            this.GroupBox15.TabIndex = 41;
            this.GroupBox15.TabStop = false;
            this.GroupBox15.Text = "Percentage";
            // 
            // discotxt
            // 
            this.discotxt.Location = new System.Drawing.Point(6, 12);
            this.discotxt.Name = "discotxt";
            this.discotxt.Size = new System.Drawing.Size(69, 20);
            this.discotxt.TabIndex = 0;
            this.discotxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.discotxt_KeyUp_1);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(6, 54);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(72, 20);
            this.Label4.TabIndex = 40;
            this.Label4.Text = "Discount";
            // 
            // txtdiscount
            // 
            this.txtdiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtdiscount.Enabled = false;
            this.txtdiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiscount.ForeColor = System.Drawing.Color.Blue;
            this.txtdiscount.Location = new System.Drawing.Point(171, 51);
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.ReadOnly = true;
            this.txtdiscount.Size = new System.Drawing.Size(140, 26);
            this.txtdiscount.TabIndex = 39;
            this.txtdiscount.Text = "Discount";
            this.txtdiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(6, 109);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(104, 20);
            this.Label3.TabIndex = 35;
            this.Label3.Text = "Total Amount";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(6, 80);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(34, 20);
            this.Label2.TabIndex = 34;
            this.Label2.Text = "Vat";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 22);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 20);
            this.Label1.TabIndex = 33;
            this.Label1.Text = "Sub Total";
            // 
            // txttotam
            // 
            this.txttotam.BackColor = System.Drawing.Color.Blue;
            this.txttotam.Enabled = false;
            this.txttotam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotam.ForeColor = System.Drawing.Color.White;
            this.txttotam.Location = new System.Drawing.Point(171, 103);
            this.txttotam.Name = "txttotam";
            this.txttotam.ReadOnly = true;
            this.txttotam.Size = new System.Drawing.Size(140, 26);
            this.txttotam.TabIndex = 32;
            this.txttotam.Text = "Total";
            this.txttotam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtvat
            // 
            this.txtvat.BackColor = System.Drawing.Color.Black;
            this.txtvat.Enabled = false;
            this.txtvat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtvat.Location = new System.Drawing.Point(171, 77);
            this.txtvat.Name = "txtvat";
            this.txtvat.ReadOnly = true;
            this.txtvat.Size = new System.Drawing.Size(140, 26);
            this.txtvat.TabIndex = 31;
            this.txtvat.Text = "Vat";
            this.txtvat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtsubtot
            // 
            this.txtsubtot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtsubtot.Enabled = false;
            this.txtsubtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsubtot.ForeColor = System.Drawing.Color.Red;
            this.txtsubtot.Location = new System.Drawing.Point(171, 19);
            this.txtsubtot.Name = "txtsubtot";
            this.txtsubtot.ReadOnly = true;
            this.txtsubtot.Size = new System.Drawing.Size(140, 26);
            this.txtsubtot.TabIndex = 30;
            this.txtsubtot.Text = "Sub total";
            this.txtsubtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.invdate);
            this.GroupBox7.Location = new System.Drawing.Point(12, 257);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(163, 46);
            this.GroupBox7.TabIndex = 51;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Select Date";
            // 
            // invdate
            // 
            this.invdate.CustomFormat = "dd MMMM yyyy";
            this.invdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.invdate.Location = new System.Drawing.Point(6, 19);
            this.invdate.Name = "invdate";
            this.invdate.Size = new System.Drawing.Size(150, 20);
            this.invdate.TabIndex = 36;
            // 
            // cancbtn
            // 
            this.cancbtn.Location = new System.Drawing.Point(61, 403);
            this.cancbtn.Name = "cancbtn";
            this.cancbtn.Size = new System.Drawing.Size(75, 23);
            this.cancbtn.TabIndex = 50;
            this.cancbtn.Text = "&Cancel";
            this.cancbtn.UseVisualStyleBackColor = true;
            this.cancbtn.Click += new System.EventHandler(this.cancbtn_Click);
            // 
            // NewProforma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 606);
            this.Controls.Add(this.GroupBox1);
            this.Name = "NewProforma";
            this.Text = "NewProforma";
            this.Load += new System.EventHandler(this.NewProforma_Load);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox10.ResumeLayout(false);
            this.GroupBox10.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            this.GroupBox15.ResumeLayout(false);
            this.GroupBox15.PerformLayout();
            this.GroupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.TextBox custid;
        internal System.Windows.Forms.ListBox custList;
        internal System.Windows.Forms.Button addbtn;
        internal System.Windows.Forms.Button procinvbtn;
        internal System.Windows.Forms.Button rmvbtn;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.TextBox proddescr;
        internal System.Windows.Forms.TextBox txtqty;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.TextBox txtponumber;
        internal System.Windows.Forms.ListView invoiceProducts;
        internal System.Windows.Forms.ColumnHeader ColQuantity;
        internal System.Windows.Forms.ColumnHeader ColProdName;
        internal System.Windows.Forms.ColumnHeader ColUnitPrice;
        internal System.Windows.Forms.ColumnHeader ColAmount;
        private System.Windows.Forms.ColumnHeader ProductId;
        private System.Windows.Forms.ColumnHeader productVatInvoice;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox prodid;
        internal System.Windows.Forms.TextBox txtSearch;
        internal System.Windows.Forms.ListBox prodList;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.TextBox txtprice;
        internal System.Windows.Forms.GroupBox GroupBox9;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.GroupBox GroupBox10;
        internal System.Windows.Forms.TextBox INVnO;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.GroupBox GroupBox15;
        internal System.Windows.Forms.TextBox discotxt;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtdiscount;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txttotam;
        internal System.Windows.Forms.TextBox txtvat;
        internal System.Windows.Forms.TextBox txtsubtot;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.DateTimePicker invdate;
        internal System.Windows.Forms.Button cancbtn;
    }
}