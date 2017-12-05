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
                System.Diagnostics.Debug.WriteLine(d.vendorName + " " + d.travelcost + " " + d.travelTime);
                if (d.isRequestSuccess)
                switch (d.vendorName.Trim())
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
        public string Book(Booking obj, string username)
        {
            DALBookingHandler dalObjectInstance = new DALBookingHandler();
             return dalObjectInstance.Book(obj, username).cabBooked;
        }
    }
}