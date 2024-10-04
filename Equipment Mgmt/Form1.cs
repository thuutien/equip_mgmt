using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Equipment_Mgmt
{
    public partial class Form1 : Form
    {

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }
        public Form1()
        {
            InitializeComponent();
            initialTaks();
        }

        private void initialTaks()
        {   

            //Add enter event for textbox
            txt_equipID.KeyPress += (sndr, ev) =>
            {
                if (ev.KeyChar.Equals((char)13))
                {
                    locateUser(txt_equipID.Text);
                    ev.Handled = true;
                    
                }
            };
            DBAccess.GetAllEmployees();
            Utils.GetProfilesImages();
            StartDispatchTask();
            PreventSleep();
        }

        private void locateUser(string eqiptID)
        {
            Cursor.Current = Cursors.WaitCursor;
            lbl_scanned.Text = eqiptID;

            EmployeeDetails scannedEmployee = DBAccess.ReturnEmployeeFromScan(eqiptID);

            if(scannedEmployee != null )
            {
                //Passed
                DBAccess.UpdateRecord(scannedEmployee);
                Utils.passSound.Play();
                txt_equipID.Clear();

                if (File.Exists(@"C:\database\profiles\" + scannedEmployee.Name + ".jpg"))
                {
                    pic_profile.Image = Image.FromFile(@"C:\database\profiles\" + scannedEmployee.Name + ".jpg");
                }
                else
                {
                    pic_profile.Image = Properties.Resources.user;
                }
                lbl_employeeName.Text = scannedEmployee.Name;
                lbl_employeeName.ForeColor = System.Drawing.Color.DarkGreen;
                checkTitles(scannedEmployee);
                Cursor.Current = Cursors.Default;
                Utils.logging(scannedEmployee.Name, eqiptID);
                //log

            } else
            {
                //Failed
                Utils.errorSound.Play();
                txt_equipID.Clear();
                pic_profile.Image = Properties.Resources.error;
                lbl_employeeName.Text = "WARNING! No User Found!!";
                lbl_employeeName.ForeColor = System.Drawing.Color.Red;
                Utils.logging("USER FAILED", eqiptID);
                lbl_title.Text = "";
                lbl_bypass.Text = "";
                Cursor.Current = Cursors.Default;
            }
        }

        private void checkTitles(EmployeeDetails ed)
        {
            if (ed.Role == "Chief Financial Officer" || ed.Role == "Chief Operating Officer" || ed.Role == "President")
            {
                lbl_title.Text = "EXECUTIVE: " + ed.Role;
                lbl_bypass.Text = "SECURITY BYPASS";
                lbl_title.ForeColor = Color.Blue;
                lbl_bypass.ForeColor = Color.Red;

            }
            else
            {
                lbl_title.Text = ed.Role;
                lbl_title.ForeColor = Color.Black;
                lbl_bypass.Text = "";
            }

        }




        private void txt_equipID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_employeeName_Click(object sender, EventArgs e)
        {

        }

        private void pic_profile_Click(object sender, EventArgs e)
        {

        }

        private void lbl_title_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void ssToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            //TODO: load profilePhotos
            DBAccess.GetAllEmployees();
            Utils.GetProfilesImages();
            MessageBox.Show("Update completed!");
        }


        void intervalTask(object s, EventArgs e)

        {
            DBAccess.GetAllEmployees();
            Utils.GetProfilesImages();
        }

        void StartDispatchTask()
        {
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(intervalTask);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1000);
            dispatcherTimer.Start();
        }

        void PreventSleep()
        {
            // Prevent Idle-to-Sleep (monitor not affected) (see note above) 
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
        }
    }
}
