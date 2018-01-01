﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ColorlinkTrading.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataModelEntities : DbContext
    {
        public DataModelEntities()
            : base("name=DataModelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryNote> DeliveryNotes { get; set; }
        public virtual DbSet<FileUpload> FileUploads { get; set; }
        public virtual DbSet<InvoiceNonVat> InvoiceNonVats { get; set; }
        public virtual DbSet<InvoicesVat> InvoicesVats { get; set; }
        public virtual DbSet<Letter> Letters { get; set; }
        public virtual DbSet<MediaFile> MediaFiles { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDnote> ProductDnotes { get; set; }
        public virtual DbSet<ProductInvoiceNonVat> ProductInvoiceNonVats { get; set; }
        public virtual DbSet<ProductInvoiceVat> ProductInvoiceVats { get; set; }
        public virtual DbSet<ProductProforma> ProductProformas { get; set; }
        public virtual DbSet<ProductQoute> ProductQoutes { get; set; }
        public virtual DbSet<ProformaInvoice> ProformaInvoices { get; set; }
        public virtual DbSet<Qoutation> Qoutations { get; set; }
        public virtual DbSet<SYSLOGRequestHistory> SYSLOGRequestHistories { get; set; }
        public virtual DbSet<UserLoginGUID> UserLoginGUIDs { get; set; }
        public virtual DbSet<VATDeduction> VATDeductions { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<view_NonVatInvoices> view_NonVatInvoices { get; set; }
    }
}
