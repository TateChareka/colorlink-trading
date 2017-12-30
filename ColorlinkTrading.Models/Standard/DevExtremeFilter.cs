using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class DevExtremeFilter
    {
        public DevExtremeFilterGroup FilterGroup { get; set; }
        public string FilterSQL
        {
            get
            {
                return FilterGroup.SQLStatement;
            }
            set { }
        }        
    }
}
