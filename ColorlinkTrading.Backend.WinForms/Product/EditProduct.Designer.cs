namespace ColorlinkTrading.Backend.WinForms.Product
{
    partial class EditProduct
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
            this.backg = new System.Windows.Forms.GroupBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.txtprodid = new System.Windows.Forms.TextBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.txtmarkupPc = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.GroupBox10 = new System.Windows.Forms.GroupBox();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.txtCompetitorPrice = new System.Windows.Forms.TextBox();
            this.txtCompetitorDetails = new System.Windows.Forms.TextBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GroupBox12 = new System.Windows.Forms.GroupBox();
            this.txtFinalPrice = new System.Windows.Forms.TextBox();
            this.GroupBox11 = new System.Windows.Forms.GroupBox();
            this.txtAfter15pcVatUS = new System.Windows.Forms.TextBox();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.txtUSValue = new System.Windows.Forms.TextBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.txtPriceAfterMarkup = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPriceAfter14Vat = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRand = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.prodList = new System.Windows.Forms.ListBox();
            this.backg.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox10.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox12.SuspendLayout();
            this.GroupBox11.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.SuspendLayout();
            // 
            // backg
            // 
            this.backg.Controls.Add(this.groupBox16);
            this.backg.Controls.Add(this.groupBox14);
            this.backg.Controls.Add(this.groupBox13);
            this.backg.Controls.Add(this.GroupBox9);
            this.backg.Controls.Add(this.GroupBox8);
            this.backg.Controls.Add(this.GroupBox10);
            this.backg.Controls.Add(this.GroupBox3);
            this.backg.Controls.Add(this.GroupBox2);
            this.backg.Controls.Add(this.GroupBox1);
            this.backg.Location = new System.Drawing.Point(241, 12);
            this.backg.Name = "backg";
            this.backg.Size = new System.Drawing.Size(569, 386);
            this.backg.TabIndex = 2;
            this.backg.TabStop = false;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.txtprodid);
            this.groupBox16.Location = new System.Drawing.Point(152, 77);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(133, 52);
            this.groupBox16.TabIndex = 42;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Product Number";
            // 
            // txtprodid
            // 
            this.txtprodid.Location = new System.Drawing.Point(11, 20);
            this.txtprodid.Name = "txtprodid";
            this.txtprodid.ReadOnly = true;
            this.txtprodid.Size = new System.Drawing.Size(111, 20);
            this.txtprodid.TabIndex = 41;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.txtmarkupPc);
            this.groupBox14.Location = new System.Drawing.Point(431, 331);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(124, 52);
            this.groupBox14.TabIndex = 13;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "MarkUp Percentage";
            // 
            // txtmarkupPc
            // 
            this.txtmarkupPc.Location = new System.Drawing.Point(7, 20);
            this.txtmarkupPc.Name = "txtmarkupPc";
            this.txtmarkupPc.Size = new System.Drawing.Size(111, 20);
            this.txtmarkupPc.TabIndex = 0;
            this.txtmarkupPc.Text = "35";
            this.txtmarkupPc.TextChanged += new System.EventHandler(this.txtmarkupPc_TextChanged);
            this.txtmarkupPc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtmarkupPc_KeyUp);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.txtExchangeRate);
            this.groupBox13.Location = new System.Drawing.Point(291, 331);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(134, 52);
            this.groupBox13.TabIndex = 12;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Exchange Rate";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Location = new System.Drawing.Point(7, 20);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(121, 20);
            this.txtExchangeRate.TabIndex = 0;
            this.txtExchangeRate.Text = "13.06";
            this.txtExchangeRate.TextChanged += new System.EventHandler(this.txtExchangeRate_TextChanged);
            this.txtExchangeRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtExchangeRate_KeyUp);
            // 
            // GroupBox9
            // 
            this.GroupBox9.Controls.Add(this.txtComments);
            this.GroupBox9.Location = new System.Drawing.Point(291, 19);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Size = new System.Drawing.Size(264, 119);
            this.GroupBox9.TabIndex = 10;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(7, 20);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(251, 90);
            this.txtComments.TabIndex = 0;
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.btnCancel);
            this.GroupBox8.Controls.Add(this.btnClear);
            this.GroupBox8.Controls.Add(this.btnAdd);
            this.GroupBox8.Location = new System.Drawing.Point(39, 334);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(200, 41);
            this.GroupBox8.TabIndex = 9;
            this.GroupBox8.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(135, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(58, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Ca&ncel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(71, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(58, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(7, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Update";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // GroupBox10
            // 
            this.GroupBox10.Controls.Add(this.GroupBox7);
            this.GroupBox10.Controls.Add(this.txtCompetitorDetails);
            this.GroupBox10.Location = new System.Drawing.Point(291, 149);
            this.GroupBox10.Name = "GroupBox10";
            this.GroupBox10.Size = new System.Drawing.Size(264, 179);
            this.GroupBox10.TabIndex = 11;
            this.GroupBox10.TabStop = false;
            this.GroupBox10.Text = "Competitor Details";
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.txtCompetitorPrice);
            this.GroupBox7.Location = new System.Drawing.Point(83, 125);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(132, 47);
            this.GroupBox7.TabIndex = 6;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Competitior\'s Price";
            // 
            // txtCompetitorPrice
            // 
            this.txtCompetitorPrice.Location = new System.Drawing.Point(6, 19);
            this.txtCompetitorPrice.Name = "txtCompetitorPrice";
            this.txtCompetitorPrice.Size = new System.Drawing.Size(116, 20);
            this.txtCompetitorPrice.TabIndex = 1;
            // 
            // txtCompetitorDetails
            // 
            this.txtCompetitorDetails.Location = new System.Drawing.Point(7, 20);
            this.txtCompetitorDetails.Multiline = true;
            this.txtCompetitorDetails.Name = "txtCompetitorDetails";
            this.txtCompetitorDetails.Size = new System.Drawing.Size(251, 99);
            this.txtCompetitorDetails.TabIndex = 0;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.GroupBox12);
            this.GroupBox3.Controls.Add(this.GroupBox11);
            this.GroupBox3.Controls.Add(this.GroupBox6);
            this.GroupBox3.Controls.Add(this.GroupBox5);
            this.GroupBox3.Controls.Add(this.GroupBox4);
            this.GroupBox3.Location = new System.Drawing.Point(6, 149);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(279, 179);
            this.GroupBox3.TabIndex = 8;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Price before VAT";
            // 
            // GroupBox12
            // 
            this.GroupBox12.Controls.Add(this.txtFinalPrice);
            this.GroupBox12.Location = new System.Drawing.Point(79, 125);
            this.GroupBox12.Name = "GroupBox12";
            this.GroupBox12.Size = new System.Drawing.Size(128, 47);
            this.GroupBox12.TabIndex = 7;
            this.GroupBox12.TabStop = false;
            this.GroupBox12.Text = "Final Price (US)";
            // 
            // txtFinalPrice
            // 
            this.txtFinalPrice.Location = new System.Drawing.Point(6, 19);
            this.txtFinalPrice.Name = "txtFinalPrice";
            this.txtFinalPrice.ReadOnly = true;
            this.txtFinalPrice.Size = new System.Drawing.Size(116, 20);
            this.txtFinalPrice.TabIndex = 1;
            // 
            // GroupBox11
            // 
            this.GroupBox11.Controls.Add(this.txtAfter15pcVatUS);
            this.GroupBox11.Location = new System.Drawing.Point(140, 72);
            this.GroupBox11.Name = "GroupBox11";
            this.GroupBox11.Size = new System.Drawing.Size(128, 47);
            this.GroupBox11.TabIndex = 6;
            this.GroupBox11.TabStop = false;
            this.GroupBox11.Text = "VAT 15% (US)";
            // 
            // txtAfter15pcVatUS
            // 
            this.txtAfter15pcVatUS.Location = new System.Drawing.Point(6, 19);
            this.txtAfter15pcVatUS.Name = "txtAfter15pcVatUS";
            this.txtAfter15pcVatUS.ReadOnly = true;
            this.txtAfter15pcVatUS.Size = new System.Drawing.Size(116, 20);
            this.txtAfter15pcVatUS.TabIndex = 1;
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.txtUSValue);
            this.GroupBox6.Location = new System.Drawing.Point(6, 72);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(128, 47);
            this.GroupBox6.TabIndex = 5;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "US dollar Value";
            // 
            // txtUSValue
            // 
            this.txtUSValue.Location = new System.Drawing.Point(6, 19);
            this.txtUSValue.Name = "txtUSValue";
            this.txtUSValue.Size = new System.Drawing.Size(116, 20);
            this.txtUSValue.TabIndex = 1;
            this.txtUSValue.TextChanged += new System.EventHandler(this.txtUSValue_TextChanged);
            this.txtUSValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUSValue_KeyUp);
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.txtPriceAfterMarkup);
            this.GroupBox5.Location = new System.Drawing.Point(140, 19);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(132, 47);
            this.GroupBox5.TabIndex = 4;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Price After Markup";
            // 
            // txtPriceAfterMarkup
            // 
            this.txtPriceAfterMarkup.Location = new System.Drawing.Point(6, 19);
            this.txtPriceAfterMarkup.Name = "txtPriceAfterMarkup";
            this.txtPriceAfterMarkup.ReadOnly = true;
            this.txtPriceAfterMarkup.Size = new System.Drawing.Size(116, 20);
            this.txtPriceAfterMarkup.TabIndex = 1;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.txtPriceAfter14Vat);
            this.GroupBox4.Location = new System.Drawing.Point(6, 19);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(128, 47);
            this.GroupBox4.TabIndex = 3;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Price After 14% VAT";
            // 
            // txtPriceAfter14Vat
            // 
            this.txtPriceAfter14Vat.Location = new System.Drawing.Point(6, 19);
            this.txtPriceAfter14Vat.Name = "txtPriceAfter14Vat";
            this.txtPriceAfter14Vat.ReadOnly = true;
            this.txtPriceAfter14Vat.Size = new System.Drawing.Size(116, 20);
            this.txtPriceAfter14Vat.TabIndex = 1;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtRand);
            this.GroupBox2.Location = new System.Drawing.Point(6, 77);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(134, 52);
            this.GroupBox2.TabIndex = 7;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Rand Value";
            // 
            // txtRand
            // 
            this.txtRand.Location = new System.Drawing.Point(7, 20);
            this.txtRand.Name = "txtRand";
            this.txtRand.Size = new System.Drawing.Size(121, 20);
            this.txtRand.TabIndex = 0;
            this.txtRand.TextChanged += new System.EventHandler(this.txtRand_TextChanged);
            this.txtRand.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRand_KeyUp);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtName);
            this.GroupBox1.Location = new System.Drawing.Point(6, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(279, 71);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Item Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(7, 19);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(265, 46);
            this.txtName.TabIndex = 0;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.prodList);
            this.groupBox15.Location = new System.Drawing.Point(14, 12);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(221, 386);
            this.groupBox15.TabIndex = 3;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Product Name";
            // 
            // prodList
            // 
            this.prodList.FormattingEnabled = true;
            this.prodList.Location = new System.Drawing.Point(7, 20);
            this.prodList.Name = "prodList";
            this.prodList.Size = new System.Drawing.Size(208, 355);
            this.prodList.Sorted = true;
            this.prodList.TabIndex = 0;
            this.prodList.SelectedIndexChanged += new System.EventHandler(this.prodList_SelectedIndexChanged);
            // 
            // EditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 402);
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.backg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "EditProduct";
            this.Text = "EditProduct";
            this.Load += new System.EventHandler(this.EditProduct_Load);
            this.backg.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox10.ResumeLayout(false);
            this.GroupBox10.PerformLayout();
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox12.ResumeLayout(false);
            this.GroupBox12.PerformLayout();
            this.GroupBox11.ResumeLayout(false);
            this.GroupBox11.PerformLayout();
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox backg;
        internal System.Windows.Forms.GroupBox groupBox14;
        internal System.Windows.Forms.TextBox txtmarkupPc;
        internal System.Windows.Forms.GroupBox groupBox13;
        internal System.Windows.Forms.TextBox txtExchangeRate;
        internal System.Windows.Forms.GroupBox GroupBox9;
        internal System.Windows.Forms.TextBox txtComments;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.GroupBox GroupBox10;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.TextBox txtCompetitorPrice;
        internal System.Windows.Forms.TextBox txtCompetitorDetails;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.GroupBox GroupBox12;
        internal System.Windows.Forms.TextBox txtFinalPrice;
        internal System.Windows.Forms.GroupBox GroupBox11;
        internal System.Windows.Forms.TextBox txtAfter15pcVatUS;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.TextBox txtUSValue;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.TextBox txtPriceAfterMarkup;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.TextBox txtPriceAfter14Vat;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtRand;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.GroupBox groupBox15;
        internal System.Windows.Forms.ListBox prodList;
        internal System.Windows.Forms.GroupBox groupBox16;
        internal System.Windows.Forms.TextBox txtprodid;
    }
}