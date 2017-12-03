using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DB_PresentationLayer.DataAccessLayer
{
    public sealed class DBConnection
    {
        private static readonly DBConnection instance = new DBConnection();
<<<<<<< HEAD
        //private readonly SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anusha\Documents\Projects\DB_PresentationLayer\App_Data\Database1.mdf;Integrated Security=True");
        private readonly SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\baner\source\repos\DB_PresentationLayer\DB_PresentationLayer\App_Data\Database1.mdf;Integrated Security=True");

=======
        private readonly SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anusha\Documents\Projects\DB_PresentationLayer\App_Data\Database1.mdf;Integrated Security=True");

        static DBConnection()
        {

        }
        private DBConnection()
        {

        }
>>>>>>> 21032bfb1440ddb4ecfe232d1a0e4cec5e3311de
        public static DBConnection Instance
        {
            get
            {
                return instance;
            }
        }
        public SqlConnection GetDBConnection()
        {
            return con;
        }

    }
}