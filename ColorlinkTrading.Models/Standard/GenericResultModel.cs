using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class GenericResultModel
    {
        public bool HasError { get; set; }
        public bool IsValidationError { get; set; }
        public string Feedback { get; set; }
    }
}
