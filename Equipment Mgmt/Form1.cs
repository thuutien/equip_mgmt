using System;
using System.Drawing;
using System.Linq;
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
                            Utils.passSound.Play();
                            pic_profile.Image = Properties.Resources.user;
                            lbl_employeeName.Text = person.FirstName + " " + person.LastName;
                            lbl_employeeName.ForeColor = System.Drawing.Color.DarkGreen;
                            txt_equipID.Clear();
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
            txt_equipID.Clear();
           
        }




        private void txt_equipID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_employeeName_Click(object sender, EventArgs e)
        {

        }
    }
}
