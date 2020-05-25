using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace KC
{
    public partial class SearchDGV : Form
    {
        //SqlConnection conn;
        //SqlDataAdapter da;
        //DataSet ds;
        public SearchDGV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\Karate.mdf';Integrated Security=True;Connect Timeout=30");
            //string selectSQL = "Select * From Members";
            //conn.Open();
            //da = new SqlDataAdapter(selectSQL, conn);
            //ds = new DataSet("Members");
            //da.Fill(ds, "Members");
            //dataGridView1.DataSource = ds.Tables[0];
            //conn.Close();

            Controller c = new Controller();
            dataGridView1.DataSource = c.ViewGrid();
            AutosizeGrid();
        }

        private void SearchDGV_Resize(object sender, EventArgs e)
        {
            //reposition the gridview to center when form is resized
            int x = (this.Width - dataGridView1.Width) / 4;
            int y = (this.Height - dataGridView1.Height) / 4;
            dataGridView1.Location = new Point(x, y);
        }

        private void AutosizeGrid()
        { 
            /*
             This method will auto resize the datagridview rows and columns 
             based on data retrieved
            */
            for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                int colw = dataGridView1.Columns[i].Width;
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[i].Width = colw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
