using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofticeMailFetcher
{
    public class EmailItemResultModel
    {
        public int ImapUid { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public string EmailDate { get; set; }
        public string EmailSubject { get; set; }
    }
}
