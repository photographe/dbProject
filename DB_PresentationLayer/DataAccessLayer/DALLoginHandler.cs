using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
//using DB_PresentationLayer.DataAccessLayer.DBConnection;

namespace DB_PresentationLayer.DataAccessLayer
{
    public class DALLoginHandler
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anusha\Documents\Projects\DB_PresentationLayer\App_Data\Database1.mdf;Integrated Security=True");

        public bool IsLoginValid(string userName, string password)
        {
            SqlConnection con = DBConnection.Instance.GetDBConnection();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from Users where UserName='"+userName +"' and Password='"+password+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString() == "1")
            {
                return true;
            }
            return false;
        }
    }
}