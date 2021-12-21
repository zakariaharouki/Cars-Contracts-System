using System.Data;
using System.Data.SqlClient;

namespace Cars_System
{
    public class RolesClass
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public bool Enabled { get; set; }
        public DataTable getallroles()
        {
            string query = "Select * from Role";
            SqlDataAdapter da = new SqlDataAdapter(query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getsomeroles()
        {
            string query = "Select * from Role Where RoleID=2 OR RoleID=3 OR RoleID=4";
            SqlDataAdapter da = new SqlDataAdapter(query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public void GetRoleName(int RoleId)
        {
            string query = "Select * from Role where RoleID=@RoleID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@RoleID", RoleId);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                RoleID = int.Parse(reader["RoleID"].ToString());
                RoleName = reader["Rolename"].ToString();
            }
            connection.Close();
        }

    }
}
