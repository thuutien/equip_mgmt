using Microsoft.Office.Interop.Access;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Runtime.InteropServices;

namespace Equipment_Mgmt
{
    internal class ADatabaseLibary
    {
        static string RP_PATH = @"X:\";
        public static OleDbConnection con;
        public static OleDbDataAdapter da;
        public static OleDbCommand cmd;
        public static DataSet ds;

        public static void CreateDB()
        {
            PowerShell ps = PowerShell.Create();
            if (!Directory.Exists(RP_PATH))
            {
                string script = @"$secPassword = ConvertTo-SecureString ""G00dm@stertronic"" -AsPlainText -Force
$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist Administrator, $secPassword
New-PSDrive -Name X -PSProvider FileSystem -Root \\192.168.64.2\reports$ -Credential $cred -Persist";

                ps.AddScript(script);
                ps.Invoke();
            }
            

            if (File.Exists(reportFile())) {
                Console.WriteLine("Datbase file is exist!");
                return;
            }

            try
            {
                Application app = null;
                app = new Application();
                app.NewCurrentDatabase(reportFile(), AcNewDatabaseFormat.acNewDatabaseFormatAccess2007);

                app.CloseCurrentDatabase();
                Marshal.FinalReleaseComObject(app);
                app = null;

                //create table
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + reportFile());
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = $"CREATE TABLE Report([Name] text, [ClockIn] Time, [ClockOut] Time)";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Datbase file is created");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Error when creaeting db file or table");
            }         
        }// End CreateDB 


        


        public static void findRecord(string name)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + reportFile());
            con.Open();
            Console.WriteLine("Updating for: " + name);
            using (var command = new OleDbCommand("UPDATE Report SET ClockOut = @clockout WHERE Name = @name", con))
            {
                command.Parameters.AddWithValue("@clockout", time);
                command.Parameters.AddWithValue("@name", name);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    command.Parameters.Clear();
                    command.CommandText = "INSERT INTO Report (Name, ClockIn) VALUES (@name,@clockin)";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@clockin", time);
                    command.ExecuteNonQuery();
                }

            }
            con.Close();
        }// End findrecord2


        public static string reportFile()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd-dddd");
           return  @"X:\" + "AttendanceReport-" + date + ".accdb";
        }


    }
}
