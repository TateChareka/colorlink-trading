using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofticeMailFetcher
{
    public class EmailItemRequestModel: IMAPConnectionRequestModel
    {
        public int ImapUid { get; set; }
       
    }
}
