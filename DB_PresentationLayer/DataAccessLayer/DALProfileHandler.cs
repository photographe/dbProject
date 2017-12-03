using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DB_PresentationLayer.EntityClass;

namespace DB_PresentationLayer.DataAccessLayer
{
    public class DALProfileHandler
    {
        public bool UpdateProfile(Profile obj, String Username)
        {
            return true;
        }
        public bool NewProfile(Profile obj, String usename)
        {
            return true;
        }
    }
}