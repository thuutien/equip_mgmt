using Equipment_Mgmt;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;





namespace Equipment_Mgmt
{
    internal class Utils
    {
        static string DB_PATH= @"C:\db\db.xlsx";

        public static Person[] persons = new Person[250];
        public static System.Media.SoundPlayer errorSound = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Critical Stop.wav");
        public static System.Media.SoundPlayer passSound = new System.Media.SoundPlayer(@"C:\Windows\Media\tada.wav");

        public static void loadDatabase()
        {
            if (!File.Exists(DB_PATH))
            {
                MessageBox.Show("Database not found: C:\\db\\db.xlsx \nPlease contact IT.");
                return;
            }

            Excel.Application MyApp = new Excel.Application();
            MyApp.Visible = false; 
            Excel.Workbook MyBook = MyApp.Workbooks.Open(Utils.DB_PATH);
            Excel.Worksheet MySheet = (Excel.Worksheet)MyBook.Sheets[1];
            int lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            for (int index = 2; index <= lastRow; index++)
            {
                System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "G" + index.ToString()).Cells.Value;
                string[] devicelist = new String[5];
                if (MyValues.GetValue(1, 1) == null)
                {
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
                    devicelist[3] = MyValues.GetValue(1, 7).ToString();
                }

                Utils.persons[index - 2] = new Person(firstName, lastName, devicelist);
                Console.WriteLine("User added: " + Utils.persons[index-2].FirstName);
                Console.WriteLine("phone added: " + devicelist[0]);
            }

            Console.WriteLine("Last Row: " + lastRow);
        }
    }
}
