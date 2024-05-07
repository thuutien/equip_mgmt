using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Equipment_Mgmt
{
    internal class EmployeeDetails
    {
        public string EID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public List<String> Properties { get; set; }

        public EmployeeDetails(Employee e) {
            this.EID = e.EID;
            this.Name = e.Name;
            this.Role = e.Role;
            var propList = Regex.Replace(e.Properties, @"\t|\n|\r", "");


            char[] delimiterChars = {','};
            this.Properties = propList.Split(delimiterChars).ToList();
            if (this.Properties.Last() == "")
            {
                this.Properties.RemoveAt(this.Properties.Count - 1);
            }

        }
    }
}
