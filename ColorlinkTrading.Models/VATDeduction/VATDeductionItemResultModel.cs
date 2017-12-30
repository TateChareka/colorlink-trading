using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorlinkTrading.Models;
using ColorlinkTrading.DataAccess;

namespace ColorlinkTrading.Models
{
    public class VATDeductionItemResultModel : GenericItemResultModel
    {
        public int? VATDeductionId { get; set; }
        public string VATDeductionDescription { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? VatAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }

    }
}
