using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB_PresentationLayer.EntityClass;
using System.Data.SqlClient;
using System.Data;

namespace DB_PresentationLayer.DataAccessLayer
{
    public class DALBookingHandler
    {
        public Booking FindRoute(Booking obj, string username="")
        {
            SqlConnection con = DBConnection.Instance.GetDBConnection();
            SqlDataAdapter sda1 = new SqlDataAdapter("Select * from Location where LocationName='" + obj.Source + "'", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            int pickupId = (int) dt1.Rows[0][0];

            SqlDataAdapter sda2 = new SqlDataAdapter("Select * from Location where LocationName='" + obj.Destination + "'", con);
            DataTable dt2 = new DataTable();
            sda1.Fill(dt2);
            int dropId = (int)dt2.Rows[0][0];

            SqlDataAdapter sda3 = new SqlDataAdapter("Select * from TripTable where PickUpId='" + pickupId + "' and DropId='" +dropId+ "'", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            foreach(DataRow row in dt3.Rows)
            {
                int vid = (int)row["VendorId"];
                switch (vid)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    default:
                        break;
                }
            }
            return obj;
        }
    }
}