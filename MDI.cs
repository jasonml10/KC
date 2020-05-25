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
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void searchOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchOne so = new SearchOne();
            so.MdiParent = this;
            so.Show();
        }

        private void dsiplayOnDataGridViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchDGV sgdv = new SearchDGV();
            sgdv.MdiParent = this; // set the current window as parent
            sgdv.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult reply = MessageBox.Show("Do you want to quit the program?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reply.Equals(DialogResult.Yes)) 
                  Application.Exit();            
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd MMM yyyy");
            toolStripStatusLabel3.Spring = true;
            viewToolStripMenuItem.Visible = false;          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToShortTimeString();
        }

        private void viewInstructorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Instructors vwInst = new View_Instructors();
            vwInst.MdiParent = this;
            vwInst.Show();
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(signInToolStripMenuItem.Text.Equals("Sign Out"))
            {
                signInToolStripMenuItem.Text = "Sign In";
            }
            Login login = new Login() ;
            login.MdiParent = this;
            login.Show ();
        }

        internal void enableDisable(bool flag)
        { // enable or disable view of menu options
            viewToolStripMenuItem.Visible = true; //everyone can access
            this.searchOneToolStripMenuItem.Visible = flag; //depend of users login
            this.displayAllMembersToolStripMenuItem.Visible = true; //everyone can access
            this.viewInstructorsToolStripMenuItem.Visible = true; //everyone can access
        }

        private void displayAllMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchDGV searchDGV = new SearchDGV();
            searchDGV.MdiParent = this;
            searchDGV.Show();
        }
    }
}
