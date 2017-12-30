using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ColorlinkTrading.Models
{
    public class FileUploadRequestModel : GenericPageRequestModel
    {
        public string FileTypeIdentifier { get; set; }    
    }
}
