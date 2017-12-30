using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class MemberAuthenticationRequestModel : GenericRequestModel
    {
        public string UserIdentifier { get; set; }
        public string UserPassword { get; set; }
        public string UserAuthenticationGUID { get; set; }
        public string SignInEnvironment { get; set; }
    }
}
