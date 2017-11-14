using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB_PresentationLayer.DataAccessLayer;

namespace DB_PresentationLayer.BusinessLayer
{
    public class LoginHandler
    {
        public bool IsLoginValid(string userName, string password)
        {
            DataAccessLayer.DALLoginHandler dalObjectInstance = new DALLoginHandler();
            return dalObjectInstance.IsLoginValid(userName, password);
        }
    }
}