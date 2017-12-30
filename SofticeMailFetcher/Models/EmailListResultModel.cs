using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofticeMailFetcher
{
    public class EmailListResultModel
    {
        public List<EmailItemResultModel> Emails { get; set; }
        public int NumberOfEmails { get; set; }
    }
}
