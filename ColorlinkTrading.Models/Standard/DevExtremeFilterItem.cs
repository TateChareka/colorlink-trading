using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models

{
    public class DevExtremeFilterItem
    {
        public string FieldName { get; set; }
        public string OperatorName { get; set; }
        public object CriteriaValue { get; set; }

        public string SQLStatement
        {
            get
            {
                if (OperatorName == "startswith")
                {
                    return FieldName + " LIKE \'" + CriteriaValue + "%\'";
                }               
                if (OperatorName == "endswith")
                {
                    return FieldName + " LIKE \'%" + CriteriaValue + "\'";
                }
                if (OperatorName == "contains")
                {
                    return FieldName + " LIKE \'%" + CriteriaValue + "%\'";
                }
                if (OperatorName == "notcontains")
                {
                    return FieldName + " NOT LIKE \'%" + CriteriaValue + "%\'";
                }
                if (
                    (OperatorName != "startswith") ||
                    (OperatorName != "endswith") ||
                    (OperatorName != "contains") ||
                    (OperatorName != "notcontains")
                   )
                {
                    
                    return FieldName + " " + OperatorName + " \'" + CriteriaValue + "\'";
                }    
                return "";
            }
            set { }
        }       
    }
}
