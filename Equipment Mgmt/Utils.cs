
using System;
using System.IO;
using System.Management.Automation;
using System.Data.OleDb;
using System.Windows.Forms;





namespace Equipment_Mgmt
{
    internal class Utils
    {

        static string LOG_PATH = @"C:\database\logs\";

        public static System.Media.SoundPlayer errorSound = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Critical Stop.wav");
        public static System.Media.SoundPlayer passSound = new System.Media.SoundPlayer(@"C:\Windows\Media\tada.wav");

        public static void logging(string name, string deviceID)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString();
            string logFile = LOG_PATH + "EquiptVerify-" + date + ".txt";
            //check file exists?
            if (!File.Exists(logFile))
            {
                Directory.CreateDirectory(LOG_PATH);
                File.Create(logFile).Close();
            }

            //get info mation
            string message = "[" + time + "]" + " -- [Name:" + name + "]  -- [ID:" + deviceID + "]";
            //write to log file
            File.AppendAllText(logFile, Environment.NewLine + message);

        }

        public static void GetProfilesImages()
        {
            Cursor.Current = Cursors.WaitCursor;
            string folder = @"C:\database\profiles";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            try
            {
                PowerShell ps = PowerShell.Create();

                string script = @"$secPassword = ConvertTo-SecureString ""G00dm@stertronic"" -AsPlainText -Force
$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist Administrator, $secPassword
New-PSDrive -Name Z -PSProvider FileSystem -Root \\192.168.64.2\security$ -Credential $cred -Persist";

                ps.AddScript(script);
                ps.Invoke();
                ps.AddScript(@"robocopy Z:\database\profiles C:\database\profiles /e");
                ps.Invoke();
                ps.AddScript(@"net use Z: /delete");
                ps.Invoke();
                ps.Dispose();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            Cursor.Current = Cursors.Default;

        }

    }
}
