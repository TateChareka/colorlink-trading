using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class GenericFilterDataRequestModel : GenericSearchRequestModel
    {
        public DevExtremeFilter FilterCriteria { get; set; }
    }
}
