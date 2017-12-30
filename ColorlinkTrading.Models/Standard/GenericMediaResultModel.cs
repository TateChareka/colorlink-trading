using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class GenericMediaResultModel: GenericResultModel
    {
        public byte[] MediaData { get; set; }
        public string MediaFileName { get; set; }
        public string MediaGUID { get; set; }
    }
}
