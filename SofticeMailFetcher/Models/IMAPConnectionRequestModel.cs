using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofticeMailFetcher
{
    public class IMAPConnectionRequestModel
    {
        public int ServerPort { get; set; }
        public string ServerName { get; set; }
        public string EmailAddress { get; set; }
        public string EmailPassword { get; set; }
        public bool UseSSL { get; set; }
        public string Mailbox { get; set; }
    }
}
