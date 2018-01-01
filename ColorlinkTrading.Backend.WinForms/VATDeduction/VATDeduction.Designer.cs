﻿namespace ColorlinkTrading.Backend.WinForms.VATDeduction
{
    partial class VATDeduction
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.paymentDate = new System.Windows.Forms.DateTimePicker();
            this.GroupBox1.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.GroupBox6);
            this.GroupBox1.Controls.Add(this.GroupBox5);
            this.GroupBox1.Controls.Add(this.GroupBox4);
            this.GroupBox1.Controls.Add(this.GroupBox2);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(389, 175);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.Button2);
            this.GroupBox6.Controls.Add(this.Button1);
            this.GroupBox6.Location = new System.Drawing.Point(104, 123);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(168, 49);
            this.GroupBox6.TabIndex = 5;
            this.GroupBox6.TabStop = false;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(87, 9);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 34);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "&Cancel";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(6, 9);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 34);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "&Add Payment";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.txtReference);
            this.GroupBox5.Location = new System.Drawing.Point(7, 71);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(369, 46);
            this.GroupBox5.TabIndex = 4;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Reference";
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(7, 20);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(356, 20);
            this.txtReference.TabIndex = 0;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.txtAmount);
            this.GroupBox4.Location = new System.Drawing.Point(12, 19);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(171, 46);
            this.GroupBox4.TabIndex = 3;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "VAT Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(7, 20);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(159, 20);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.paymentDate);
            this.GroupBox2.Location = new System.Drawing.Point(227, 19);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(149, 46);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "VAT Deduction Date";
            // 
            // paymentDate
            // 
            this.paymentDate.CustomFormat = "dd-MMMM-yyyy";
            this.paymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.paymentDate.Location = new System.Drawing.Point(6, 19);
            this.paymentDate.Name = "paymentDate";
            this.paymentDate.Size = new System.Drawing.Size(137, 20);
            this.paymentDate.TabIndex = 0;
            this.paymentDate.Value = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            // 
            // VATDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 175);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VATDeduction";
            this.Text = "VATDeduction";
            this.Load += new System.EventHandler(this.VATDeduction_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.TextBox txtReference;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.TextBox txtAmount;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.DateTimePicker paymentDate;
    }
}