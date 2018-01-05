using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorlinkTrading.Models;
using ColorlinkTrading.DataAccess;

namespace ColorlinkTrading.Models
{
    public class ZimraStatementItemResultModel : GenericItemResultModel
    {
        public int? StatementId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? AmountDue { get; set; }
        public decimal? BalanceBroughtForward { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }
        public List<ZimraStateDetailsItemResultModel> ZimraStatementDetails { get; set; }
    }
}
