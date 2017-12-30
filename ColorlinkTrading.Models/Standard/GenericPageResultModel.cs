using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class GenericPageResultModel : GenericResultModel    
    {
        public int NumberOfPages { get; set; }
        public int NumberOfRecords { get; set; }
    }
}
