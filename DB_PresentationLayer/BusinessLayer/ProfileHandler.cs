using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB_PresentationLayer.EntityClass;
using DB_PresentationLayer.Models;
using DB_PresentationLayer.DataAccessLayer;

namespace DB_PresentationLayer.BusinessLayer
{
    public class ProfileHandler
    {
        public bool UpdateProfile(Profile obj, String username)
        {
            DALProfileHandler dalObjectInstance = new DALProfileHandler();
            return dalObjectInstance.UpdateProfile(obj, username).isRequestSuccess;

        }
        public bool NewProfile(Profile obj, String username)
        {
            DALProfileHandler dalObjectInstance = new DALProfileHandler();
            return dalObjectInstance.NewProfile(obj, username).isRequestSuccess;
        }
    }
}