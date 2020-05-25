using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KC
{
    public partial class SearchOne : Form
    {
        //SqlConnection conn;
        //SqlDataReader dr;
        //SqlCommand cmd;
        public SearchOne()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\Karate.mdf';Integrated Security=True;Connect Timeout=30");

            //string searchSQL = "Select * From Members  INNER JOIN Payments On Members.ID = Payments.Member_Id Where Last_Name=@lastname";

            //conn.Open();
            //cmd = new SqlCommand(searchSQL, conn);
            //cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
            //dr = cmd.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    dr.Read();
            //    txtFirstName.Text = dr["Last_Name"].ToString ();
            //    txtPhone.Text = dr["Phone"].ToString();
            //    txtJoin.Text = DateTime.Parse (dr["Date_Joined"].ToString()).ToString ("dd MMM yyyy");
            //    txtPaymentDate.Text = DateTime.Parse(dr["Payment_Date"].ToString ()).ToString ("dd MMM yyyy");
            //   txtAmountPaid.Text = double.Parse (dr["Amount"].ToString ()).ToString ("c");
            //}
            //else
            //{
            //     MessageBox.Show("Member Name not found");
            //}
            Display();
           
        }
        private void Display()
        {
            //call to the ViewOne method in the Controller class
            SqlDataReader dr = new Controller().ViewOne(txtLastName.Text);

            if (dr.HasRows)
            {
                txtFirstName.Text = dr["Last_Name"].ToString();
                txtPhone.Text = dr["Phone"].ToString();
                txtJoin.Text = DateTime.Parse(dr["Date_Joined"].ToString()).ToString("dd MMM yyyy");
                txtPaymentDate.Text = DateTime.Parse(dr["Payment_Date"].ToString()).ToString("dd MMM yyyy");
                txtAmountPaid.Text = double.Parse(dr["Amount"].ToString()).ToString("c");
            }
        }

        private void SearchOne_Load(object sender, EventArgs e)
        {
           
            txtLastName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtLastName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtLastName.AutoCompleteCustomSource = new Controller().Autocomplete();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
