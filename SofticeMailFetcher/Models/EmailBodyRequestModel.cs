using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofticeMailFetcher
{
    public class EmailBodyRequestModel : IMAPConnectionRequestModel
    {
        public int ImapUid { get; set; }
        public string FilePath { get; set; }
        public string RootURL { get; set; }
    }
}
