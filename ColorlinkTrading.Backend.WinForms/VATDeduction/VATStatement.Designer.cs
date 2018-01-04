namespace ColorlinkTrading.Backend.WinForms.VATDeduction
{
    partial class VATStatement
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
            this.button3 = new System.Windows.Forms.Button();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.displayView = new System.Windows.Forms.ListView();
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox5 = new System.Windows.Forms.TextBox();
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hiddenView = new System.Windows.Forms.ListView();
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(481, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "&Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "dd/MM/yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(6, 19);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(104, 20);
            this.dateFrom.TabIndex = 0;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.dateTo);
            this.GroupBox1.Location = new System.Drawing.Point(143, 10);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(115, 46);
            this.GroupBox1.TabIndex = 22;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "End Date";
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "dd/MM/yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(6, 19);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(104, 20);
            this.dateTo.TabIndex = 0;
            // 
            // displayView
            // 
            this.displayView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader7,
            this.ColumnHeader8,
            this.ColumnHeader9,
            this.ColumnHeader10,
            this.ColumnHeader11,
            this.ColumnHeader12});
            this.displayView.FullRowSelect = true;
            this.displayView.GridLines = true;
            this.displayView.Location = new System.Drawing.Point(6, 12);
            this.displayView.MultiSelect = false;
            this.displayView.Name = "displayView";
            this.displayView.Size = new System.Drawing.Size(563, 400);
            this.displayView.TabIndex = 6;
            this.displayView.UseCompatibleStateImageBehavior = false;
            this.displayView.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Date";
            this.ColumnHeader7.Width = 82;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Reference";
            this.ColumnHeader8.Width = 70;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Description";
            this.ColumnHeader9.Width = 150;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Debit";
            this.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader10.Width = 80;
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Credit";
            this.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader11.Width = 80;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Total Due";
            this.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader12.Width = 85;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(290, 26);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(87, 23);
            this.Button1.TabIndex = 25;
            this.Button1.Text = "&Get Statement";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.Button2);
            this.GroupBox4.Controls.Add(this.Label3);
            this.GroupBox4.Controls.Add(this.Label2);
            this.GroupBox4.Controls.Add(this.Label1);
            this.GroupBox4.Controls.Add(this.TextBox5);
            this.GroupBox4.Controls.Add(this.TextBox4);
            this.GroupBox4.Controls.Add(this.TextBox3);
            this.GroupBox4.Controls.Add(this.TextBox2);
            this.GroupBox4.Controls.Add(this.TextBox1);
            this.GroupBox4.Controls.Add(this.displayView);
            this.GroupBox4.Location = new System.Drawing.Point(12, 62);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(575, 497);
            this.GroupBox4.TabIndex = 24;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Statement Details";
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(50, 442);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(87, 45);
            this.Button2.TabIndex = 15;
            this.Button2.Text = "G&enerate PrintOut";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(216, 474);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(83, 13);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "TOTAL COUNT";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(216, 448);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 13);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "TOTAL VALUE";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(384, 421);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(80, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "AMOUNT DUE";
            // 
            // TextBox5
            // 
            this.TextBox5.BackColor = System.Drawing.SystemColors.Control;
            this.TextBox5.Location = new System.Drawing.Point(309, 471);
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Size = new System.Drawing.Size(78, 20);
            this.TextBox5.TabIndex = 11;
            this.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBox4
            // 
            this.TextBox4.BackColor = System.Drawing.SystemColors.Control;
            this.TextBox4.Location = new System.Drawing.Point(391, 471);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Size = new System.Drawing.Size(78, 20);
            this.TextBox4.TabIndex = 10;
            this.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBox3
            // 
            this.TextBox3.BackColor = System.Drawing.SystemColors.Control;
            this.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox3.Location = new System.Drawing.Point(309, 445);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(78, 20);
            this.TextBox3.TabIndex = 9;
            this.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TextBox2
            // 
            this.TextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.TextBox2.Location = new System.Drawing.Point(391, 445);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(78, 20);
            this.TextBox2.TabIndex = 8;
            this.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TextBox1
            // 
            this.TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox1.Location = new System.Drawing.Point(470, 418);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(86, 20);
            this.TextBox1.TabIndex = 7;
            this.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Total Due";
            this.ColumnHeader6.Width = 122;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.dateFrom);
            this.GroupBox2.Location = new System.Drawing.Point(12, 10);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(115, 46);
            this.GroupBox2.TabIndex = 21;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Start Date";
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Credit";
            this.ColumnHeader5.Width = 80;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Description";
            this.ColumnHeader3.Width = 78;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Reference";
            this.ColumnHeader2.Width = 100;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Date";
            this.ColumnHeader1.Width = 82;
            // 
            // hiddenView
            // 
            this.hiddenView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.ColumnHeader6});
            this.hiddenView.FullRowSelect = true;
            this.hiddenView.GridLines = true;
            this.hiddenView.Location = new System.Drawing.Point(18, 611);
            this.hiddenView.MultiSelect = false;
            this.hiddenView.Name = "hiddenView";
            this.hiddenView.Size = new System.Drawing.Size(563, 400);
            this.hiddenView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.hiddenView.TabIndex = 26;
            this.hiddenView.UseCompatibleStateImageBehavior = false;
            this.hiddenView.View = System.Windows.Forms.View.Details;
            this.hiddenView.Visible = false;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Debit";
            this.ColumnHeader4.Width = 80;
            // 
            // VATStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 572);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.hiddenView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VATStatement";
            this.Text = "VATStatement";
            this.Load += new System.EventHandler(this.VATStatement_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.DateTimePicker dateFrom;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.DateTimePicker dateTo;
        internal System.Windows.Forms.ListView displayView;
        internal System.Windows.Forms.ColumnHeader ColumnHeader7;
        internal System.Windows.Forms.ColumnHeader ColumnHeader8;
        internal System.Windows.Forms.ColumnHeader ColumnHeader9;
        internal System.Windows.Forms.ColumnHeader ColumnHeader10;
        internal System.Windows.Forms.ColumnHeader ColumnHeader11;
        internal System.Windows.Forms.ColumnHeader ColumnHeader12;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBox5;
        internal System.Windows.Forms.TextBox TextBox4;
        internal System.Windows.Forms.TextBox TextBox3;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader6;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader5;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ListView hiddenView;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
    }
}