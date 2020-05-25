using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KC
{
    public partial class View_Instructors : Form
    {
        Controller ctlr = new Controller();
        public View_Instructors()
        {
            InitializeComponent();
        }

        private void lstInstructors_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = ctlr.RetrieveInstructors();
            lblDescription.Text = dt.Rows[lstInstructors.SelectedIndex].ItemArray[2].ToString();
            lblDateJoin.Text = DateTime.Parse(dt.Rows[lstInstructors.SelectedIndex].ItemArray[3].ToString()).ToString("dd MMM yyyy");
        }

        private void View_Instructors_Load(object sender, EventArgs e)
        {
            lstInstructors.DataSource = ctlr.RetrieveInstructors();
            lstInstructors.DisplayMember = "Full_Name";           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
