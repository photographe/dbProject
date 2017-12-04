using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DB_PresentationLayer.DataAccessLayer
{
    public class DALTripDetailHandler
    {
        SqlConnection con = DBConnection.Instance.GetDBConnection();
        public DataSet SelectTripDetailsForUser(string username = "")
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = con.CreateCommand();
            string SQL = "SELECT * FROM TripTable WHERE TripTable.UserId = (SELECT userid FROM users WHERE name = @userName)";
            cmd.CommandText = SQL;
            cmd.Parameters.AddWithValue("@userName", username);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            con.Open();
            da.Fill(ds);
            con.Close();

            return ds;
        }
    }
}