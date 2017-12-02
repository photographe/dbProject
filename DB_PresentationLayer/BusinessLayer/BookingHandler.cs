using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB_PresentationLayer.EntityClass;

namespace DB_PresentationLayer.BusinessLayer
{
    public class BookingHandler
    {
        public Booking FindRoute(Booking obj, string username = "")
        {
            return obj;
        }
        public bool Book(Booking obj, string username)
        {
            return true;
        }
    }
}