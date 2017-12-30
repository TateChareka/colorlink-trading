using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class GenericRequestModel
    {
        public int SessionUserId { get; set; }
        public int SessionPersonId { get; set; }
        public string SessionUserName { get; set; }
        public string SessionUserGUID { get; set; }
        public string SessionUserEnvironment { get; set; }
        public string RootWebFolder { get; set; }
    }
}
