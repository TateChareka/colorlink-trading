using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class MemberUserPasswordResetModel : GenericRequestModel
    {
        public string UserAuthenticationGUID { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
