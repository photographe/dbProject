using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB_PresentationLayer.EntityClass;
using System.Data.SqlClient;
using System.Data;
using DB_PresentationLayer.Models;

namespace DB_PresentationLayer.DataAccessLayer
{
    public class DALBookingHandler
    {
        public DataObjectList FindRouteDetails(Booking obj, string username="")
        {
            SqlConnection con = DBConnection.Instance.GetDBConnection();
            SqlDataAdapter sda1 = new SqlDataAdapter("Select * from Location where LocationName LIKE '%" + obj.Source + "%'", con);
            DataObjectList dol = new DataObjectList();
            dol.dataObjList = new List<DataObject>();
            dol.isRequestSuccess = true;

            try
            {
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                int pickupLocationId = (int)dt1.Rows[0][0];

                SqlDataAdapter sda2 = new SqlDataAdapter("Select * from Location where LocationName LIKE '%" + obj.Destination + "%'", con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                int dropLocationId = (int)dt2.Rows[0][0];

                SqlDataAdapter sda3 = new SqlDataAdapter("Select * from TripTable where PickUpLocationId='" + pickupLocationId + "' and DropLocationId='" + dropLocationId + "'", con);
                DataTable dt3 = new DataTable();
                sda3.Fill(dt3);
                

                foreach (DataRow row in dt3.Rows)
                {
                        DataObject d = new DataObject();
                        int vid = (int)row["VendorId"];
                        int tripid = (int)row["TripId"];
                        SqlDataAdapter sda4 = new SqlDataAdapter("Select * from Vendor where VendorId='" + vid + "'", con);
                        DataTable dt4 = new DataTable();
                        sda4.Fill(dt4);
                        d.vendorName = dt4.Rows[0][1].ToString();
                        SqlDataAdapter sda5 = new SqlDataAdapter("Select * from DropOffDetail where TripId='" + tripid + "'", con);
                        DataTable dt5 = new DataTable();
                        sda5.Fill(dt5);
                        DateTime dropT = (DateTime)dt5.Rows[0][1];
                        SqlDataAdapter sda6 = new SqlDataAdapter("Select * from PickUpDetail where TripId='" + tripid + "'", con);
                        DataTable dt6 = new DataTable();
                        sda6.Fill(dt6);
                        DateTime pickT = (DateTime)dt6.Rows[0][1];
                        var min = (dropT - pickT).TotalMinutes;
                        d.travelTime = min.ToString() + " min";
                        SqlDataAdapter sda7 = new SqlDataAdapter("Select * from CostDetailTable where TripId='" + tripid + "'", con);
                        DataTable dt7 = new DataTable();
                        sda7.Fill(dt7);
                        d.travelcost = dt7.Rows[0][1].ToString();
                        d.isRequestSuccess = true;
                        dol.dataObjList.Add(d);
                }
            }catch(Exception e)
            {
                dol.isRequestSuccess = false;

            }
            return dol;
        }
        public DataObject Book(Booking obj, string username)
        {
            DataObject d = new DataObject();
            d.isRequestSuccess = true;
            return d;
        }
    }
}