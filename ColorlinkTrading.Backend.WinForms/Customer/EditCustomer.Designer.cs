namespace ColorlinkTrading.Backend.WinForms
{
    partial class EditCustomer
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
            this.custlist = new System.Windows.Forms.ListBox();
            this.txtcustId = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtdetails = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cancbtn = new System.Windows.Forms.Button();
            this.editbtn = new System.Windows.Forms.Button();
            this.txtvagregNo = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox6.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // custlist
            // 
            this.custlist.FormattingEnabled = true;
            this.custlist.Location = new System.Drawing.Point(6, 19);
            this.custlist.Name = "custlist";
            this.custlist.Size = new System.Drawing.Size(209, 290);
            this.custlist.Sorted = true;
            this.custlist.TabIndex = 0;
            this.custlist.SelectedIndexChanged += new System.EventHandler(this.custlist_SelectedIndexChanged);
            // 
            // txtcustId
            // 
            this.txtcustId.Location = new System.Drawing.Point(424, 220);
            this.txtcustId.Name = "txtcustId";
            this.txtcustId.ReadOnly = true;
            this.txtcustId.Size = new System.Drawing.Size(95, 20);
            this.txtcustId.TabIndex = 39;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(353, 223);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(65, 13);
            this.Label7.TabIndex = 38;
            this.Label7.Text = "Customer ID";
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(342, 141);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(177, 20);
            this.txtemail.TabIndex = 37;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(388, 125);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(73, 13);
            this.Label6.TabIndex = 36;
            this.Label6.Text = "Email Address";
            // 
            // txtdetails
            // 
            this.txtdetails.Location = new System.Drawing.Point(342, 37);
            this.txtdetails.Multiline = true;
            this.txtdetails.Name = "txtdetails";
            this.txtdetails.Size = new System.Drawing.Size(177, 76);
            this.txtdetails.TabIndex = 35;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(388, 21);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(68, 13);
            this.Label5.TabIndex = 34;
            this.Label5.Text = "Other Details";
            // 
            // cancbtn
            // 
            this.cancbtn.Location = new System.Drawing.Point(426, 272);
            this.cancbtn.Name = "cancbtn";
            this.cancbtn.Size = new System.Drawing.Size(75, 23);
            this.cancbtn.TabIndex = 33;
            this.cancbtn.Text = "&Cancel";
            this.cancbtn.UseVisualStyleBackColor = true;
            this.cancbtn.Click += new System.EventHandler(this.cancbtn_Click);
            // 
            // editbtn
            // 
            this.editbtn.Location = new System.Drawing.Point(23, 272);
            this.editbtn.Name = "editbtn";
            this.editbtn.Size = new System.Drawing.Size(75, 23);
            this.editbtn.TabIndex = 32;
            this.editbtn.Text = "&Update";
            this.editbtn.UseVisualStyleBackColor = true;
            this.editbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // txtvagregNo
            // 
            this.txtvagregNo.Location = new System.Drawing.Point(144, 224);
            this.txtvagregNo.Name = "txtvagregNo";
            this.txtvagregNo.Size = new System.Drawing.Size(164, 20);
            this.txtvagregNo.TabIndex = 31;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(7, 227);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(110, 13);
            this.Label4.TabIndex = 30;
            this.Label4.Text = "Customer Vat Reg No";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(144, 178);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(164, 20);
            this.txtContactNo.TabIndex = 29;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 181);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(131, 13);
            this.Label3.TabIndex = 28;
            this.Label3.Text = "Customer Contact Number";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(144, 86);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(164, 75);
            this.txtaddress.TabIndex = 27;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(7, 110);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(92, 13);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Customer Address";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(144, 19);
            this.txtname.Multiline = true;
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(164, 51);
            this.txtname.TabIndex = 25;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(7, 41);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(82, 13);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Customer Name";
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.custlist);
            this.GroupBox6.Location = new System.Drawing.Point(12, 12);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(221, 314);
            this.GroupBox6.TabIndex = 52;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Select Customer";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtcustId);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.txtemail);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txtdetails);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.cancbtn);
            this.GroupBox1.Controls.Add(this.editbtn);
            this.GroupBox1.Controls.Add(this.txtvagregNo);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txtContactNo);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtaddress);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtname);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(266, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(534, 314);
            this.GroupBox1.TabIndex = 51;
            this.GroupBox1.TabStop = false;
            // 
            // EditCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 339);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditCustomer";
            this.Load += new System.EventHandler(this.EditCustomer_Load);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox custlist;
        internal System.Windows.Forms.TextBox txtcustId;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtemail;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtdetails;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button cancbtn;
        internal System.Windows.Forms.Button editbtn;
        internal System.Windows.Forms.TextBox txtvagregNo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtContactNo;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtaddress;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtname;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.GroupBox GroupBox1;
    }
}