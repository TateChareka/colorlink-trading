using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorlinkTrading.Models;
using ColorlinkTrading.DataAccess;

namespace ColorlinkTrading.Models
{
    public class ZimraStateDetailsItemResultModel : GenericItemResultModel
    {
        public int ZimraStatementId { get; set; }
        public int? StatementId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string StatementDescription { get; set; }
        public decimal? StatementCREDIT { get; set; }
        public decimal? StatementDEBIT { get; set; }
        public decimal? StatementBalance { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }

    }
}
