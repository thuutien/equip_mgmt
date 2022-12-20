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
            lbl_scanned.Text = eqiptID;
            Person[] persons = Utils.persons;
            foreach (Person person in persons)
            {
                if (person != null)
                {
                    Console.WriteLine("loop person: " + person.FirstName);
                    foreach (string id in person.Devices)
                    {
                        Console.WriteLine("loop ID: " + id);
                        if (id == eqiptID)
                        {
                            //Passed
                            checkTitles(person);
                            Utils.passSound.Play();
                            if (File.Exists(@"C:\database\profile\" + person.FirstName + ".jpg"))
                            {
                                pic_profile.Image = System.Drawing.Image.FromFile(@"C:\database\profile\" + person.FirstName + ".jpg");
                            }else
                            {
                                pic_profile.Image = Properties.Resources.user;
                            }
                            lbl_employeeName.Text = person.FirstName + " " + person.LastName;
                            lbl_employeeName.ForeColor = System.Drawing.Color.DarkGreen;
                            txt_equipID.Clear();
                            Utils.logging(person.FirstName, eqiptID);
                            return;
                        }           
                    }

                }
            }

            //Failed
            Utils.errorSound.Play();
            pic_profile.Image = Properties.Resources.error;
            lbl_employeeName.Text = "WARNING! No User Found!!";
            lbl_employeeName.ForeColor = System.Drawing.Color.Red;
            Utils.logging("USER FAILED", eqiptID);
            lbl_title.Text = "";
            lbl_bypass.Text = "";
            txt_equipID.Clear();
        }

        private void checkTitles(Person person)
        {
            if (person.Title != null && person.Title != "")
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
