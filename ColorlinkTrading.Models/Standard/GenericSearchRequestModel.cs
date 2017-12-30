using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class GenericSearchRequestModel : GenericPageRequestModel
    {
        public string SearchCriteria { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

    }
}
