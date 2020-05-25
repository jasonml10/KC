using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KC
{
    public partial class Login : Form
    {
        public string fullname;
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llblForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Lost_Password lostpwd = new Lost_Password();           
            lostpwd.MdiParent =  this.MdiParent;
            lostpwd.Show();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader dr;
            Controller ctlr = new Controller();

            dr = ctlr.Signin(txtEmail.Text, txtPassword.Text);
            
            if (dr.HasRows)
            {
                fullname = dr["Fullname"].ToString();
                MessageBox.Show("Welcome " + fullname, "Sign In Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MDI mdi = (MDI)this.MdiParent;
                var v = mdi.toolStripStatusLabel3.Text = "You\'re logged in as " + fullname;
                var y = mdi.signInToolStripMenuItem.Text = "Sign Out";

                //hide the SearchOneOption from the menu
                if (dr["Role"].Equals ("Member"))
                { //method call to mdi to enable or disable menuitems
                   mdi.enableDisable (false);                   
                }
                else if (dr["Role"].Equals("Admin"))
                {                   
                    mdi.enableDisable(true);                    
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Unable to sign in. Ensure that the email address OR password is correct", "Sign In Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
    }

