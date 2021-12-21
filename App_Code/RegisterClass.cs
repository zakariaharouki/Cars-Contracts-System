
using System;
using System.Data;
using System.Data.SqlClient;

namespace Cars_System
{
    public class RegisterClass
    {
        public string message { get; set; }
        /// <summary>
        /// This Func uses a stored procedure to register an account and most important it uses a sha256 hashing for the passwords and salting 
        /// </summary>
        /// <param name="txtFname"></param>
        /// <param name="txtLname"></param>
        /// <param name="txtPass"></param>
        /// <param name="txtEmail"></param>
        /// <param name="txtPhone"></param>
        /// <returns></returns>
        public string RegisterMethod(string txtFname, string txtLname, string txtPass, string txtEmail, string txtPhone)
        {

            SqlConnection con = new SqlConnection(Global.MyConn);
            SqlCommand command = new SqlCommand("Proc_AddUser", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            command.Parameters.AddWithValue("@Fname", txtFname);
            command.Parameters.AddWithValue("@Lname", txtLname);
            command.Parameters.AddWithValue("@Email", txtEmail);
            command.Parameters.AddWithValue("@PasswordHash", txtPass);
            command.Parameters.AddWithValue("@PhoneNumber", txtPhone);

            command.Parameters.Add("@responsemessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            //SqlDataReader rd = com.ExecuteReader();
            //con.Open();
            //command.ExecuteNonQuery();
            con.Close();
            String responsemessage = (string)command.Parameters["@responsemessage"].Value;
            return responsemessage;
        }
        public string AddUser(string firstname, string lastname, int role, string email, string password, string phonenumber, string dateofbirth, int CompanyID, int Attempts, bool Islocked)
        {

            SqlConnection con = new SqlConnection(Global.MyConn);
            SqlCommand command = new SqlCommand("Proc_AddUser", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            command.Parameters.AddWithValue("@Fname", firstname);
            command.Parameters.AddWithValue("@Lname", lastname);
            command.Parameters.AddWithValue("@RoleID", role);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@PhoneNumber", phonenumber);
            command.Parameters.AddWithValue("@DateofBirth", dateofbirth);
            command.Parameters.AddWithValue("@CompanyID", CompanyID);
            command.Parameters.AddWithValue("@AttemptsCount", Attempts);
            command.Parameters.AddWithValue("@IsLocked", Islocked);
            //command.Parameters.AddWithValue("@Notifications", Notifications);
            command.Parameters.Add("@responsemessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            //SqlDataReader rd = com.ExecuteReader();
            //con.Open();
            //command.ExecuteNonQuery();
            con.Close();
            String responsemessage = (string)command.Parameters["@responsemessage"].Value;
            return responsemessage;

        }
        public string AddMe(string firstname, string lastname, int role, string email, string password, string phonenumber, string dateofbirth, string Notifications, Boolean IsLocked)
        {

            SqlConnection con = new SqlConnection(Global.MyConn);
            SqlCommand command = new SqlCommand("Proc_Addme", con);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            command.Parameters.AddWithValue("@Fname", firstname);
            command.Parameters.AddWithValue("@Lname", lastname);
            command.Parameters.AddWithValue("@RoleID", role);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@PasswordHash", password);
            command.Parameters.AddWithValue("@PhoneNumber", phonenumber);
            command.Parameters.AddWithValue("@DateofBirth", dateofbirth);
            command.Parameters.AddWithValue("@Notifications", Notifications);
            command.Parameters.AddWithValue("IsLocked", IsLocked);
            command.Parameters.Add("@responsemessage", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            //SqlDataReader rd = com.ExecuteReader();
            //con.Open();
            //command.ExecuteNonQuery();
            con.Close();
            String responsemessage = (string)command.Parameters["@responsemessage"].Value;
            return responsemessage;

        }

        /// <summary>
        /// This Func checks if any account is associated with the email that the user is trying to register with
        /// if it exists it returns a message : duplicate
        /// if not message :No duplicate
        /// </summary>
        /// <param name="txtEmail"></param>
        /// <returns></returns>
        public string checkifExists(string txtEmail)
        {
            string query = "Select 1 from Users Where Email=@Email";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@Email", txtEmail);
            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                string message = "Duplicate";

                return message;
            }
            else
            {
                string message = "No Duplicate";

                return message;

            }
        }
    }
}