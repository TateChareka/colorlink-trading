//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ProductInvoiceVat
    {
        public int ProductInvoiceVatId { get; set; }
        public Nullable<int> InvoiceNo { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> ProdId { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string OLDNo { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }
    }
}
