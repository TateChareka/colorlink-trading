using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorlinkTrading.Models;
using ColorlinkTrading.DataAccess;

namespace ColorlinkTrading.Models
{
    public class PaymentRequestModel : GenericRequestModel
    {
        public int PaymentId { get; set; }
        public string PaymentDescription { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? StartInvoice { get; set; }
        public int? EndInvoice { get; set; }
        public decimal? BalanceAfterPayment { get; set; }
        public decimal? PaymentAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }

    }
}
