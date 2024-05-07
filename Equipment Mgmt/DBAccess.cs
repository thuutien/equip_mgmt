using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Equipment_Mgmt
{
    internal class DBAccess
    {
        public static DBAccess instance = new DBAccess();

        public List<EmployeeDetails> employees = new List<EmployeeDetails>();


        public static void GetAllEmployees()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("DataConn")))
                {
                    var es = connection.Query<Employee>("dbo.properties_GetAllEmployees").ToList();
                    instance.employees.Clear();
                    foreach (var e in es)
                    {
                        instance.employees.Add(new EmployeeDetails(e)); 
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static EmployeeDetails ReturnEmployeeFromScan (string serialNumber)
        {
            EmployeeDetails scanEmployee = null;
            foreach (var ed in instance.employees)
            {
                foreach (var p in ed.Properties)
                {
                    if (p == serialNumber)
                    {
                        scanEmployee = ed;
                        break;
                    }

                }

            }
            return scanEmployee;
        }

        public async static void UpdateRecord(EmployeeDetails ed)
        {


            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");
            string timeNow = DateTime.Now.ToString("HH:mm:ss");

            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("DataConn")))
                {
                     
                     await connection.ExecuteAsync("dbo.records_Update @eid, @name, @role, @date, @time",
                        new {
                            eid = ed.EID,
                            name =  ed.Name,
                            role = ed.Role,
                            date = todayDate,
                            time = timeNow                
                        });
                }
            }
            catch (Exception e) 
            { 
            
                Console.WriteLine(e.Message);
            }
        }




    }
}
