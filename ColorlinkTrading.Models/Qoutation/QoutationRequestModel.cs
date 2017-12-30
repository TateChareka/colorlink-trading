using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorlinkTrading.Models;
using ColorlinkTrading.DataAccess;

namespace ColorlinkTrading.Models
{
    public class QoutationRequestModel : GenericRequestModel
    {
        public int QouteNumber { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Reference { get; set; }
        public decimal? Discount { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? VatAmount { get; set; }
        public string DisplayValue { get; set; }
        public string ExtraDetails { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }
        public int? NumberOfProducts { get; set; }
        public List<QoutationProductItemResultModel> ProductQoutations { get; set; }

    }
}
