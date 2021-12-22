using System;
using System.Data;
using System.Data.SqlClient;

namespace Cars_System.App_Code
{
    public class UserController
    {
        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string email { get; set; }
        public string responsemessage { get; set; }
        public int roleid { get; set; }
        public string Dob { get; set; }
        public int AttemptsCount { get; set; }
        public string IsLocked { get; set; }
        public int CompanyID { get; set; }
        public string Notification { get; set; }
        /// <summary>
        /// this function is used to get all users and their data to bind to a repeater in a table using data adapter and datatable extracted from database
        /// </summary>
        /// <returns></returns>
        public DataTable getUsers()
        {

            string Query = "SELECT * FROM Users";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable getRuknUsers()
        {

            string Query = "SELECT * FROM Users Where CompanyID=4";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable getLuxuryUsers()
        {

            string Query = "SELECT * FROM Users Where CompanyID=3";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable getGoldenUsers()
        {

            string Query = "SELECT * FROM Users WHERE CompanyID=2";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable getMuhanadUsers()
        {

            string Query = "SELECT * FROM Users WHERE CompanyID=1";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        /// <summary>
        /// This Func is used to get all data of a certain user to view on ViewMore page 
        /// </summary>
        /// <param name="UserId"></param>
        public void getuserdetails(int id)
        {
            string Query = "SELECT * FROM [Users] WHERE UserId = @UserId";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(Query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@UserId", id);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                UserId = int.Parse(reader["UserId"].ToString());
                Fname = reader["Fname"].ToString();
                Lname = reader["Lname"].ToString();
                Email = reader["Email"].ToString();
                PhoneNumber = reader["PhoneNumber"].ToString();
                roleid = int.Parse(reader["RoleID"].ToString());
                Dob = reader["DateofBirth"].ToString();
                //Notification = reader["Notifications"].ToString();

            }
            connection.Close();
        }
        /// <summary>
        /// This Func deletes a cerain user using his ID 
        /// </summary>
        /// <param name="UserId"></param>
        public void deleteuser(int UserId)
        {
            string query = "delete from Users Where UserID=@UserId";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@UserId", UserId);
            Cmd.CommandText = query;
            Cmd.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// This Func Updates a user's password using his Id in a stored procedure since there is a salting, hashing , and encryption procedure.
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="PasswordHash"></param>
        public void Updatepassword(int UserId, string PasswordHash)
        {
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand command = new SqlCommand("Proc_ChangePassword", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@PasswordHash", PasswordHash);
            command.Parameters.Add("@responsemessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            string responsemessage = Convert.ToString(command.Parameters["@responsemessage"].Value);
            connection.Close();
        }
        /// <summary>
        /// This Func Unlocks a user account by setting the islocked value to 0 and attempts to 0.
        /// </summary>
        /// <param name="UserId"></param>
        public void UnlockAccount(int UserId)
        {
            string query = "Update Users set IsLocked='0',AttemptsCount='0' Where UserId=@UserId";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@UserId", UserId);
            Cmd.ExecuteNonQuery();
            connection.Close();

        }
        public void checkiflocked(string usremail)
        {
            string query = "Select * from Users where Email=@Email";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@Email", usremail);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                IsLocked = reader["IsLocked"].ToString();
                UserId = int.Parse(reader["UserId"].ToString());
                email = reader["Email"].ToString();
            }
            connection.Close();
        }
        public void GetUserInfoUsingEmail(string email)
        {
            string query = "Select * from Users where Email=@Email";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@Email", email);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                UserId = int.Parse(reader["UserId"].ToString());
                roleid = int.Parse(reader["RoleID"].ToString());
                Fname = reader["Fname"].ToString();
                Lname = reader["Lname"].ToString();
                Email = reader["Email"].ToString();
                PhoneNumber = reader["PhoneNumber"].ToString();
            }
            connection.Close();

        }
        public void GetUserInfoUsingUserId(string Userid)
        {
            string query = "Select * from Users where UserID=@Userid";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@Userid", Userid);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                UserId = int.Parse(reader["UserId"].ToString());
                roleid = int.Parse(reader["RoleID"].ToString());
                Fname = reader["Fname"].ToString();
                Lname = reader["Lname"].ToString();
                Email = reader["Email"].ToString();
                PhoneNumber = reader["PhoneNumber"].ToString();
                CompanyID = int.Parse(reader["CompanyID"].ToString());
            }
            connection.Close();

        }
        public void UpdateUser(string fname, string lname, string Phone,string email, int roleid, string dateofbirth, int Userid)
        {
            string query = "Update Users set Fname=@Fname,Lname=@Lname,PhoneNumber=@PhoneNumber,Email=@Email,RoleID=@RoleID,DateofBirth=@DateofBirth Where UserId=@UserId";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@Fname", fname);
            Cmd.Parameters.AddWithValue("@Lname", lname);
            Cmd.Parameters.AddWithValue("@Email", email);
            Cmd.Parameters.AddWithValue("@PhoneNumber", Phone);
            Cmd.Parameters.AddWithValue("@RoleID", roleid);
            Cmd.Parameters.AddWithValue("@DateofBirth", dateofbirth);
            Cmd.Parameters.AddWithValue("@UserID", Userid);
            Cmd.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable getCollaborators()
        {
            string Query = "SELECT * FROM Users Where RoleID=2 AND Notifications=1 ";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getTeamMembers()
        {
            string Query = "SELECT * FROM Users Where RoleID=4 OR RoleID=1 AND Notifications=1";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }


    }
}