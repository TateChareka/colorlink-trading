using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorlinkTrading.Models;
using ColorlinkTrading.DataAccess;

namespace ColorlinkTrading.Models
{
    public class ProductItemResultModel : GenericItemResultModel
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? RandPricePreVat { get; set; }
        public decimal? RandPricePostVat { get; set; }
        public decimal? RandPricePostMarkup { get; set; }
        public decimal? CashPrice { get; set; }
        public decimal? VatAmount { get; set; }
        public decimal? PriceIncVat { get; set; }
        public decimal? CompetitorPrice { get; set; }
        public string Comments { get; set; }
        public string CompetitorDetails { get; set; }
        public decimal? ExchangeRate { get; set; }
        public decimal? MarkUpPercentage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }

    }
}
