using ColorlinkTrading.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorlinkTrading.Logic
{
    public class TestLogic
    {
        public static string TestFunction()
        {
            string result = "OK";
            try
            {
                using (DataModelEntities dm = new DataModelEntities(null))
                {

                }
            }
            catch(Exception error)
            {
                result = error.Message;
            }
            return result;
        }
    }
}
