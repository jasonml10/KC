using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KC
{
    public partial class Add_Instructor : Form
    {
        public Add_Instructor()
        {
            InitializeComponent();
        }

        private void Add_Instructor_Load(object sender, EventArgs e)
        {

        }

        private void txtSensei_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)|| Char.IsControl(e.KeyChar) || Char.IsWhiteSpace (e.KeyChar))
            {
                e.Handled = false;
            }
            else { e.Handled = true; }
                   
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                txtAbout.Multiline = true;
                txtAbout.Size = new Size (452,106);
                checkBox1.Location = new Point(216, 257);
            }
            else
            {
                txtAbout.Multiline = false;
                txtAbout.Size = new Size(452, 26);
                checkBox1.Location = new Point(216, 169);
            }
            txtAbout.Refresh();
            this.Refresh();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            //define the initial directory (folder)
            string CombinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\images");
            openFile.InitialDirectory = System.IO.Path.GetFullPath(CombinedPath); ;

            // set the file type filter
            openFile.Filter = "jpg files(*.jpg)| *.jpg |png files(*.png)|*.png|All files(*.*) | *.* ";
            openFile.ShowDialog();            
        }
    }
}
