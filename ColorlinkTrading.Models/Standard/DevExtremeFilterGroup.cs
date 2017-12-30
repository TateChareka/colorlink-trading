using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Models
{
    public class DevExtremeFilterGroup
    {
        public List<DevExtremeFilterItem> GroupItems { get; set; }
        public string GroupOperator { get; set; }
        //public List<DevExtremeFilterGroup> GroupGroups { get; set; }

        public string SQLStatement
        {
            get
            {
                String SQL = "(";
                if (GroupOperator.ToUpper() == "NOT OR")
                {
                    SQL = "NOT (";
                    if (GroupItems != null)
                    {
                        for (int i = 0; i < GroupItems.Count; i++)
                        {
                            if (i < (GroupItems.Count - 1))
                            {
                                SQL += "( " + GroupItems[i].SQLStatement + " ) OR ";
                            }
                            else
                            {
                                SQL += " ( " + GroupItems[i].SQLStatement + " )";
                            }
                        }
                    }
                }
                else if (GroupOperator.ToUpper() == "NOT AND")
                {
                    SQL = "NOT (";
                    if (GroupItems != null)
                    {
                        for (int i = 0; i < GroupItems.Count; i++)
                        {
                            if (i < (GroupItems.Count - 1))
                            {
                                SQL += "( " + GroupItems[i].SQLStatement + " ) AND ";
                            }
                            else
                            {
                                SQL += " ( " + GroupItems[i].SQLStatement + " )";
                            }
                        }
                    }
                }
                else
                {
                    SQL = "(";
                    if (GroupItems != null)
                    {
                        for (int i = 0; i < GroupItems.Count; i++)
                        {
                            if (i < (GroupItems.Count - 1))
                            {
                                SQL += "( " + GroupItems[i].SQLStatement + " ) " + GroupOperator;
                            }
                            else
                            {
                                SQL += " ( " + GroupItems[i].SQLStatement + " )";
                            }
                        }
                    }
                }

                SQL += ")";
                return SQL;
            }
            set
            {

            }
        }       
    }
}
