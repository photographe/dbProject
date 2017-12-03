using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB_PresentationLayer.EntityClass;
<<<<<<< HEAD
=======
using DB_PresentationLayer.Models;
using DB_PresentationLayer.DataAccessLayer;
>>>>>>> 21032bfb1440ddb4ecfe232d1a0e4cec5e3311de

namespace DB_PresentationLayer.BusinessLayer
{
    public class ProfileHandler
    {
<<<<<<< HEAD
        public bool UpdateProfile(Profile obj, String Username)
        {
            return true;
        }
        public bool NewProfile(Profile obj, String usename)
        {
            return true;
=======
        public bool UpdateProfile(Profile obj, String username)
        {
            DALProfileHandler dalObjectInstance = new DALProfileHandler();
            return dalObjectInstance.UpdateProfile(obj, username).isRequestSuccess;

        }
        public bool NewProfile(Profile obj, String username)
        {
            DALProfileHandler dalObjectInstance = new DALProfileHandler();
            return dalObjectInstance.NewProfile(obj, username).isRequestSuccess;
>>>>>>> 21032bfb1440ddb4ecfe232d1a0e4cec5e3311de
        }
    }
}