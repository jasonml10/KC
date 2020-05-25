using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KC
{
    class Controller
    {

        SqlConnection conn;
        public void Connect()
        {
            conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\Karate.mdf';Integrated Security=True;Connect Timeout=30");

            conn.Open();
        }

        public DataTable ViewGrid()
        {
            string selectSQL = "Select CONCAT(First_Name,' ', Last_Name) As FullName From Members";
            Connect();
            SqlDataAdapter da = new SqlDataAdapter(selectSQL, conn);
            DataSet ds = new DataSet("Members");
            da.Fill(ds, "Members");
            DataTable dt = ds.Tables["Members"];
            conn.Close();
            return dt;
        }

        public SqlDataReader ViewOne(string searchkey)
        {
            string searchSQL = "Select * From Members  INNER JOIN Payments On Members.ID = Payments.Member_Id Where Last_Name=@lastname";
            Connect();
            SqlCommand cmd = new SqlCommand(searchSQL, conn);
            cmd.Parameters.AddWithValue("@lastname", searchkey);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                dr.Read();
            }
            return dr;
        }

        public AutoCompleteStringCollection Autocomplete()
        { // this method is used for creating the autocomplete textbox
          // on the SearchOne form
            string searchSQL = "SELECT Last_Name From Members";
            Connect();
            SqlCommand cmd = new SqlCommand(searchSQL, conn);
            AutoCompleteStringCollection autocoll = new AutoCompleteStringCollection();
            SqlDataReader dr = cmd.ExecuteReader();
            
            while(dr.Read()) // retrieve all the names into the completestring collection
            {
                autocoll.Add(dr.GetString(0));
            }
            return autocoll;
        }

        public DataTable RetrieveInstructors()
        {
            Connect();
            string sql = "SELECT * FROM Instructors";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public SqlDataReader Signin(string email_addr, string password)
        {
            // bool success=false;
            Connect();

            string sql = "SELECT * FROM Credentials WHERE Email=@email AND Password=@pwd";

            SqlCommand cmd = new SqlCommand(sql, conn);
            // define parameters
            cmd.Parameters.AddWithValue("@email", email_addr);
            cmd.Parameters.AddWithValue("@pwd", password);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
            }

            return dr;
        }
    }
}
