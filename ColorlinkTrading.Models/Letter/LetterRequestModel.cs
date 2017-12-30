using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorlinkTrading.Models;
using ColorlinkTrading.DataAccess;

namespace ColorlinkTrading.Models
{
    public class LetterRequestModel : GenericRequestModel
    {
        public int LetterId { get; set; }
        public string LetterRecipient { get; set; }
        public string LetterContent { get; set; }
        public DateTime? LetterDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }

    }
}
