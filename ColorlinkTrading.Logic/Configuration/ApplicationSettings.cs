using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ColorlinkTrading.Logic
{
    public class ApplicationSettings
    {
        public static bool IsDebugMode()
        {
           return Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["SettingDebugMode"].ToString());
        }
    }
}
