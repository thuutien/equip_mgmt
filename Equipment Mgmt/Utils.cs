using System;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;





namespace Equipment_Mgmt
{
    internal class Utils
    {
        static string DB_PATH= @"C:\database\db.xlsx";
        static string LOG_PATH = @"C:\database\logs\";

        public static Person[] persons = new Person[250];
        public static System.Media.SoundPlayer errorSound = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Critical Stop.wav");
        public static System.Media.SoundPlayer passSound = new System.Media.SoundPlayer(@"C:\Windows\Media\tada.wav");

        public static void loadDatabase()
        {
            if (!File.Exists(DB_PATH))
            {
                MessageBox.Show("Database not found: C:\\database\\db.xlsx \nPlease contact IT.");
                return;
            }

            Excel.Application MyApp = new Excel.Application();
            if (MyApp == null)
            {
                Console.WriteLine("Excel is not installed");
                return;
            }

            
            MyApp.Visible = false; 
            Excel.Workbook MyBook = MyApp.Workbooks.Open(Utils.DB_PATH);
            Excel.Worksheet MySheet = (Excel.Worksheet)MyBook.Sheets[1];
            int lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            for (int index = 2; index <= lastRow; index++)
            {
                System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "O" + index.ToString()).Cells.Value;
                string[] devicelist = new String[12];
                if (MyValues.GetValue(1, 1) == null)
                {
                    MyApp.Quit();
                    break;
                }
                string lastName = MyValues.GetValue(1, 1).ToString();
                string firstName = MyValues.GetValue(1, 2).ToString();
                if(MyValues.GetValue(1, 3) != null)
                {
                    devicelist[0] = MyValues.GetValue(1, 3).ToString();
                }
                if (MyValues.GetValue(1, 4) != null)
                {
                    devicelist[1] = MyValues.GetValue(1, 4).ToString();
                }
                if (MyValues.GetValue(1, 5) != null)
                {
                    devicelist[2] = MyValues.GetValue(1, 5).ToString();
                }
                if (MyValues.GetValue(1, 6) != null)
                {
                    devicelist[3] = MyValues.GetValue(1, 6).ToString();
                }
                if (MyValues.GetValue(1, 7) != null)
                {
                    devicelist[4] = MyValues.GetValue(1, 7).ToString();
                }
                if (MyValues.GetValue(1, 8) != null)
                {
                    devicelist[5] = MyValues.GetValue(1, 8).ToString();
                }
                if (MyValues.GetValue(1, 9) != null)
                {
                    devicelist[6] = MyValues.GetValue(1, 9).ToString();
                }
                if (MyValues.GetValue(1, 10) != null)
                {
                    devicelist[7] = MyValues.GetValue(1, 10).ToString();
                }
                if (MyValues.GetValue(1, 11) != null)
                {
                    devicelist[8] = MyValues.GetValue(1, 11).ToString();
                }
                if (MyValues.GetValue(1, 12) != null)
                {
                    devicelist[9] = MyValues.GetValue(1, 12).ToString();
                }
                if (MyValues.GetValue(1, 13) != null)
                {
                    devicelist[10] = MyValues.GetValue(1, 13).ToString();
                }
                if (MyValues.GetValue(1, 14) != null)
                {
                    devicelist[11] = MyValues.GetValue(1, 14).ToString();
                }
                if (MyValues.GetValue(1, 15) != null)
                {
                    devicelist[12] = MyValues.GetValue(1, 15).ToString();
                }


                Utils.persons[index - 2] = new Person(firstName, lastName, devicelist);
                Console.WriteLine("User added: " + Utils.persons[index-2].FirstName);
                Console.WriteLine("phone added: " + devicelist[5]);
            }

            MyApp.Quit();
            Console.WriteLine("Last Row: " + lastRow);
        }

        public static void logging(string name, string deviceID)
        {
            string date = DateTime.Now.ToString("MM-dd-yyyy");
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
    }
}
