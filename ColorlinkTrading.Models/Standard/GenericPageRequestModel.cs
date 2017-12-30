using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class GenericPageRequestModel : GenericRequestModel
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string OrderField { get; set; }
        public string OrderDirection { get; set; }

    }
}
