using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Management.Automation;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;





namespace Equipment_Mgmt
{
    internal class Utils
    {
        static string DB_PATH= @"C:\database\db.xlsx";
        static string LOG_PATH = @"C:\database\logs\";
        static string RP_PATH = @"X:\";


        static public Excel.Application excel = new Excel.Application();
        public static Person[] persons = new Person[1000];
        public static System.Media.SoundPlayer errorSound = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Critical Stop.wav");
        public static System.Media.SoundPlayer passSound = new System.Media.SoundPlayer(@"C:\Windows\Media\tada.wav");

        public static void loadDatabase()
        {
            if (!File.Exists(DB_PATH))
            {
                MessageBox.Show("Database not found: C:\\database\\db.xlsx \nPlease Update database or contact IT.");
                return;
            }

            
            if (excel == null)
            {
                Console.WriteLine("Excel is not installed");
                return;
            }

            
            excel.Visible = false; 
            Excel.Workbook MyBook = excel.Workbooks.Open(Utils.DB_PATH);
            Excel.Worksheet MySheet = (Excel.Worksheet)MyBook.Sheets[1];
            int lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            for (int index = 2; index <= lastRow; index++)
            {
                System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "P" + index.ToString()).Cells.Value;
                string[] devicelist = new String[12];
                if (MyValues.GetValue(1, 1) == null)
                {
                    break;
                }
                string lastName = MyValues.GetValue(1, 1).ToString();
                string firstName = MyValues.GetValue(1, 2).ToString();
                string title = "";
                if (MyValues.GetValue(1, 3) != null)
                {
                    title = MyValues.GetValue(1, 3).ToString();
                }

                if (MyValues.GetValue(1, 4) != null)
                {
                    devicelist[0] = MyValues.GetValue(1, 4).ToString();
                }
                if (MyValues.GetValue(1, 5) != null)
                {
                    devicelist[1] = MyValues.GetValue(1, 5).ToString();
                }
                if (MyValues.GetValue(1, 6) != null)
                {
                    devicelist[2] = MyValues.GetValue(1, 6).ToString();
                }
                if (MyValues.GetValue(1, 7) != null)
                {
                    devicelist[3] = MyValues.GetValue(1, 7).ToString();
                }
                if (MyValues.GetValue(1, 8) != null)
                {
                    devicelist[4] = MyValues.GetValue(1, 8).ToString();
                }
                if (MyValues.GetValue(1, 9) != null)
                {
                    devicelist[5] = MyValues.GetValue(1, 9).ToString();
                }
                if (MyValues.GetValue(1, 10) != null)
                {
                    devicelist[6] = MyValues.GetValue(1, 10).ToString();
                }
                if (MyValues.GetValue(1, 11) != null)
                {
                    devicelist[7] = MyValues.GetValue(1, 11).ToString();
                }
                if (MyValues.GetValue(1, 12) != null)
                {
                    devicelist[8] = MyValues.GetValue(1, 12).ToString();
                }
                if (MyValues.GetValue(1, 13) != null)
                {
                    devicelist[9] = MyValues.GetValue(1, 13).ToString();
                }
                if (MyValues.GetValue(1, 14) != null)
                {
                    devicelist[10] = MyValues.GetValue(1, 14).ToString();
                }
                if (MyValues.GetValue(1, 15) != null)
                {
                    devicelist[11] = MyValues.GetValue(1, 15).ToString();
                }
                if (MyValues.GetValue(1, 16) != null)
                {
                    devicelist[12] = MyValues.GetValue(1, 16).ToString();
                }


                Utils.persons[index - 2] = new Person(firstName, lastName, title, devicelist);
                Console.WriteLine("User added: " + Utils.persons[index-2].FirstName);
                Console.WriteLine("phone added: " + devicelist[5]);
            }

            Console.WriteLine("Last Row: " + lastRow);
            Utils.logging("Users loaded:" + (lastRow - 1), "System Operation");
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

        public static void updateDB()
        {
            Cursor.Current = Cursors.WaitCursor;
            string script = @"$secPassword = ConvertTo-SecureString ""G00dm@stertronic"" -AsPlainText -Force
$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist Administrator, $secPassword
New-PSDrive -Name Z -PSProvider FileSystem -Root \\192.168.64.2\security$ -Credential $cred -Persist";


            PowerShell ps = PowerShell.Create();

            ps.AddScript(script);
            ps.Invoke();
            ps.AddScript(@"robocopy Z:\database C:\database /e");
            ps.Invoke();
            ps.AddScript(@"net use Z: /delete");
            ps.Invoke();
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Update completed!");
        }

        public static void recordTime(string name)
        {
            bool isExcelInstalled = Type.GetTypeFromProgID("Excel.Application") != null ? true : false;
            if(!isExcelInstalled)
            {
                MessageBox.Show("Excel is not installed!");
                return;
            }

            //Connect to file server
            string script = @"$secPassword = ConvertTo-SecureString ""G00dm@stertronic"" -AsPlainText -Force
$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist Administrator, $secPassword
New-PSDrive -Name X -PSProvider FileSystem -Root \\192.168.64.2\reports$ -Credential $cred -Persist";

            PowerShell ps = PowerShell.Create();
            ps.AddScript(script);
            ps.Invoke();

            // If the report exists for today? create!
            string date = DateTime.Now.ToString("yyyy-MM-dd-dddd");
            string reportFile = @"X:\" + "AttendanceReport-" + date + ".xlsx";
            

            if (!File.Exists(reportFile))
            {
                // Create new file here
                Workbook wbook = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet wsheet = wbook.Worksheets.get_Item(1);
                wsheet.Name = "Report";
                wsheet.Cells[1, 1] = "Name";
                wsheet.Cells[1, 2] = "Clock In";
                wsheet.Cells[1, 3] = "Clock Out";
                wsheet.Columns["A:A"].ColumnWidth = 30;
                wsheet.Columns["B:C"].ColumnWidth = 10;

                FormatCondition condIn = wsheet.get_Range("B2:B500", Type.Missing).FormatConditions.Add(XlFormatConditionType.xlCellValue, XlFormatConditionOperator.xlGreater, "0.333333333333333");
                FormatCondition condOut = wsheet.get_Range("C2:C500", Type.Missing).FormatConditions.Add(XlFormatConditionType.xlCellValue, XlFormatConditionOperator.xlLess, "0.708333333333333");
                condIn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                condOut.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);


                wbook.SaveAs(reportFile);
                Console.WriteLine("File created");
                
            }

            Console.WriteLine("loading file...");
            Workbook wb = excel.Workbooks.Open(reportFile);
            Worksheet ws = wb.Worksheets[1];
            var range = (Excel.Range)ws.Columns["A:A"];
            var result = range.Find(name, LookAt: Excel.XlLookAt.xlWhole);

            if (result != null)
            {
                var row = result.Row;
                ws.Cells[row,3].Value = DateTime.Now.ToString("HH:mm:ss:");
                wb.Save();
                wb.Close();



            } else
            {
                // cannot find the name
                //add to last row with clock in
                int lastRow = ws.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row + 1;
                Console.WriteLine("last Row: " + lastRow);
                ws.Cells[lastRow,1].Value = name;
                ws.Cells[lastRow,2].Value = DateTime.Now.ToString("HH:mm:ss");
                
                wb.Save();
                wb.Close();

            }

            ps.AddScript(@"net use X: /delete");
            ps.Invoke();
            ps.Dispose();
        }


    }
}
