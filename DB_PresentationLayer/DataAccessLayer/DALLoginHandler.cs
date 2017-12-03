using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
<<<<<<< HEAD
=======
using DB_PresentationLayer.Models;
>>>>>>> 21032bfb1440ddb4ecfe232d1a0e4cec5e3311de

namespace DB_PresentationLayer.DataAccessLayer
{
    public class DALLoginHandler
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anusha\Documents\Projects\DB_PresentationLayer\App_Data\Database1.mdf;Integrated Security=True");

<<<<<<< HEAD
        public bool IsLoginValid(string userName, string password)
=======
        public DataObject IsLoginValid(string userName, string password)
>>>>>>> 21032bfb1440ddb4ecfe232d1a0e4cec5e3311de
        {
            SqlConnection con = DBConnection.Instance.GetDBConnection();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from Users where UserName='"+userName +"' and Password='"+password+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
<<<<<<< HEAD
            if(dt.Rows[0][0].ToString() == "1")
            {
                return true;
            }
            return false;
=======
            DataObject d = new DataObject();
            d.isRequestSuccess = false;
            if (dt.Rows[0][0].ToString() == "1")
            {
                d.isRequestSuccess = true;
            }
            return d;
>>>>>>> 21032bfb1440ddb4ecfe232d1a0e4cec5e3311de
        }
    }
}