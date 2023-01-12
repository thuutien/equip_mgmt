using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Equipment_Mgmt
{
    public partial class Form1 : Form
    {
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
            //load database
            Utils.loadDatabase();
               
        }

        private void locateUser(string eqiptID)
        {
            Cursor.Current = Cursors.WaitCursor;
            lbl_scanned.Text = eqiptID;
            Person[] persons = Utils.persons;
            foreach (Person person in persons)
            {
                if (person != null)
                {
                    
                    foreach (string id in person.Devices)
                    {
                        
                        if (id == eqiptID)
                        {
                            //Passed
                            Utils.updateClock(person.FirstName + " " + person.LastName, person.Title);
                            checkTitles(person);
                            Utils.passSound.Play();
                            txt_equipID.Clear();
                            if (File.Exists(@"C:\database\profile\" + person.FirstName + ".jpg"))
                            {
                                pic_profile.Image = System.Drawing.Image.FromFile(@"C:\database\profile\" + person.FirstName + ".jpg");
                            }else
                            {
                                pic_profile.Image = Properties.Resources.user;
                            }
                            lbl_employeeName.Text = person.FirstName + " " + person.LastName;
                            lbl_employeeName.ForeColor = System.Drawing.Color.DarkGreen;
                            //Utils.recordTime(person.FirstName + " " + person.LastName);
                            Cursor.Current = Cursors.Default;
                            return;
                        }           
                    }

                }
            }
            

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

        private void checkTitles(Person person)
        {
            if (person.Title != null && person.Title != "" && person.Title != "Manager" && person.Title != "Supervisor")
            {
                lbl_title.Text = "EXECUTIVE: " + person.Title;
                lbl_bypass.Text = "SECURITY BYPASS";
                lbl_title.ForeColor = Color.Blue;
                lbl_bypass.ForeColor = Color.Red;

            }
            else
            {
                lbl_title.Text = "Employee";
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
            Utils.updateDB();
            Utils.loadDatabase();
            


        }
    }
}
