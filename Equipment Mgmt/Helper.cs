using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Mgmt
{
    internal class Helper
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString
                .Replace("zzusernamezz", Helper.Username())
                .Replace("zzpasswordzz", Helper.Password());
        }

        public static string Username()
        {
            return ConfigurationManager.ConnectionStrings["Username"].ConnectionString;
        }
        private static string Password()
        {
            return ConfigurationManager.ConnectionStrings["Password"].ConnectionString;     
        }
    }
}
