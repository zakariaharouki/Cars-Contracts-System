using System;
using System.Data;
using System.Data.SqlClient;

namespace Cars_System.App_Code
{
    public class Cars
    {
        public string CarName { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyID { get; set; }
        public string Date { get; set; }
        public string BuyerName { get; set; }
        public string ContractNumber { get; set; }
        public string VIN { get; set; }
        public string TempCarNumber { get; set; }
        public int LatestContract { get; set; }
        public void InsertCar(string Carname, string VIN, string TempCarNumber, string BuyerName, string EmployeeName, string ContractNumber, int CompanyID, string date)
        {

            string query = "Insert into Cars (CarName,VIN,TempCarNumber,BuyerName,EmployeeName,ContractNumber,CompanyID,Date)" + "VALUES (@CarName,@VIN,@TempCarNumber,@BuyerName,@EmployeeName,@ContractNumber,@CompanyID,@Date)";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CarName", Carname);
            cmd.Parameters.AddWithValue("@VIN", VIN);
            cmd.Parameters.AddWithValue("@TempCarNumber", TempCarNumber);
            cmd.Parameters.AddWithValue("@BuyerName", BuyerName);
            cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmd.Parameters.AddWithValue("@ContractNumber", ContractNumber);
            cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
            cmd.Parameters.AddWithValue("@Date", date);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public DataTable getCarsMuhanad()
        {
            string Query = "SELECT * FROM Cars WHERE CompanyID=1";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getCarsGolden()
        {
            string Query = "SELECT * FROM Cars WHERE CompanyID=2";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getCarsLuxury()
        {
            string Query = "SELECT * FROM Cars WHERE CompanyID=3";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getCarsRukn()
        {
            string Query = "SELECT * FROM Cars WHERE CompanyID=4";
            SqlDataAdapter da = new SqlDataAdapter(Query, Global.MyConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void deletecar(int CarID)
        {
            string query = "delete from Cars Where CarID=@CarID";
            var connection = new SqlConnection(Global.MyConn);
            SqlCommand Cmd = new SqlCommand(query, connection);
            connection.Open();
            Cmd.Parameters.AddWithValue("@CarID", CarID);
            Cmd.CommandText = query;
            Cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void getCarDeatils(string CarID)
        {
            string query = "Select * from Cars WHERE CarID=@CarID";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                CarName = reader["CarName"].ToString();
                BuyerName = reader["BuyerName"].ToString();
                CompanyID = reader["CompanyID"].ToString();
                Date = reader["Date"].ToString();
                EmployeeName = reader["EmployeeName"].ToString();
                ContractNumber = reader["ContractNumber"].ToString();
                VIN = reader["VIN"].ToString();
                TempCarNumber = reader["TempCarNumber"].ToString();
            }
            connection.Close();
        }
        public void getcontractnumber(int CompanyID)
        {

            string query = "SELECT MAX(ContractNumber) AS LatestContract FROM Cars WHERE CompanyID = @CompanyID";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                LatestContract = int.Parse(reader["LatestContract"].ToString());
            }
            connection.Close();
        }
        public void UpdateCar(string CarID,string Carname, string VIN, string TempCarNumber, string BuyerName, string EmployeeName, string date)
        {
            string query = "Update Cars set Carname=@Carname,VIN=@VIN,TempCarNumber=@TempCarNumber,BuyerName=@BuyerName,EmployeeName=@EmployeeName,date=@date Where CarID=@CarID";
            var connection = new SqlConnection(Global.MyConn);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Carname", Carname);
            cmd.Parameters.AddWithValue("@VIN", VIN);
            cmd.Parameters.AddWithValue("@TempCarNumber", TempCarNumber);
            cmd.Parameters.AddWithValue("@BuyerName", BuyerName);
            cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@CarID", CarID);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close();

        }

    }
}