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
    
    public partial class ZimraStatementsDetail
    {
        public int ZimraStatementId { get; set; }
        public Nullable<int> StatementId { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string StatementDescription { get; set; }
        public Nullable<decimal> StatementAmount { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }
    }
}