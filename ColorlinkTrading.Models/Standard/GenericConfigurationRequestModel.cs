using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models

{
    public class GenericConfigurationRequestModel : GenericItemRequestModel
    {
        public string ConfigurationKey { get; set; }
        public string BrandName {
            get {
                return "SchoolDays";
            }
        }
    }
}
