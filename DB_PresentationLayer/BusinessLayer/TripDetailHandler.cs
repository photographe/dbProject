using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DB_PresentationLayer.DataAccessLayer;

namespace DB_PresentationLayer.BusinessLayer
{
    public class TripDetailHandler
    {
        public DataSet GetTripDetail(string username = "")
        {
            DALTripDetailHandler dalObjectInstance = new DALTripDetailHandler();
            DataSet returnDS = dalObjectInstance.SelectTripDetailsForUser(username);
            
            return returnDS;
        }
    }
}