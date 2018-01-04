using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorlinkTrading.Models;
using ColorlinkTrading.DataAccess;

namespace ColorlinkTrading.Models
{
    public class DNoteProductItemResultModel : GenericItemResultModel
    {
        public int? ProductDnoteId { get; set; }
        public int? DnoteNo { get; set; }
        public int? Quantity { get; set; }
        public int? ProdId { get; set; }
        public string ProductName { get; set; }
        public string OldNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }

    }
}
