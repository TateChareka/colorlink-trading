using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class GenericItemResultModel : GenericResultModel
    {
        public string ItemGUID { get; set; }
        public int? ItemId { get; set; }
    }
}
