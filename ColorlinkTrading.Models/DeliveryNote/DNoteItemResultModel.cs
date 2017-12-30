using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorlinkTrading.Models;
using ColorlinkTrading.DataAccess;

namespace ColorlinkTrading.Models
{
    public class DNoteItemResultModel : GenericItemResultModel
    {
        public int? DnoteId { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? DnoteDate { get; set; }
        public string ExtraDetails { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }
        public int? NumberOfProducts { get; set; }
        public List<DNoteProductItemResultModel> ProductDnotes { get; set; }

    }
}
