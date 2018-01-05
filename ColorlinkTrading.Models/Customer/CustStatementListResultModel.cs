﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorlinkTrading.Models;
using ColorlinkTrading.DataAccess;

namespace ColorlinkTrading.Models
{
    public class CustStatementListResultModel : GenericPageResultModel
    {
        public List<CusStatementItemResultModel> CustomerStatement { get; set; }
    }
}