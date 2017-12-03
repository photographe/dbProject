using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB_PresentationLayer.EntityClass;
using DB_PresentationLayer.DataAccessLayer;
using DB_PresentationLayer.Models;

namespace DB_PresentationLayer.BusinessLayer
{
    public class BookingHandler
    {
        public Booking FindRoute(Booking obj, string username = "")
        {
            DALBookingHandler dalObjectInstance = new DALBookingHandler();
            DataObjectList dol = dalObjectInstance.FindRouteDetails(obj, username);

            foreach (DataObject d in dol.dataObjList)
            {
                if(d.isRequestSuccess)
                switch (d.vendorName)
                {
                    case "Uber":
                        obj.UberPrice = d.travelcost;
                        obj.UberTime = d.travelTime;
                        break;
                    case "Lyft":
                        obj.LyftPrice = d.travelcost;
                        obj.LyftTime = d.travelTime;
                        break;
                    default:
                        obj.YellowPrice = d.travelcost;
                        obj.YellowTime = d.travelTime;
                        break;
                }

            }
            
            return obj;
        }
        public bool Book(Booking obj, string username)
        {
            DALBookingHandler dalObjectInstance = new DALBookingHandler();
            return dalObjectInstance.Book(obj, username).isRequestSuccess;
        }
    }
}