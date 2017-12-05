using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB_PresentationLayer.EntityClass;
using System.Data.SqlClient;
using System.Data;
using DB_PresentationLayer.Models;
using System.Globalization;
using System.Threading;

namespace DB_PresentationLayer.DataAccessLayer
{
    public class DALBookingHandler
    {
        public DataObjectList FindRouteDetails(Booking obj, string username="")
        {
            SqlConnection con = DBConnection.Instance.GetDBConnection();
            DataObjectList dol = new DataObjectList();
            dol.dataObjList = new List<DataObject>();
            dol.isRequestSuccess = true;

            try
            {             
                SqlDataAdapter sda1 = new SqlDataAdapter("Select * from Location where LocationName LIKE '%" + obj.Source + "%'", con);
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

            SqlConnection con = DBConnection.Instance.GetDBConnection();
            Mutex m = new Mutex();
            m.WaitOne();
            try
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("Select * from Location where LocationName LIKE '%" + obj.Source + "%'", con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                int pickupLocationId = (int)dt1.Rows[0][0];

                SqlDataAdapter sda2 = new SqlDataAdapter("Select * from Location where LocationName LIKE '%" + obj.Destination + "%'", con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                int dropLocationId = (int)dt2.Rows[0][0];

                int vendorId = 0;
                double cost = 0;
     
                DateTime pTime = DateTime.Now;
                DateTime dTime = pTime;
                if(obj.UberPrice != "" && obj.UberTime != "")
                {
                    vendorId = 0;
                    cost = double.Parse(obj.UberPrice, CultureInfo.InvariantCulture.NumberFormat);
                    dTime = pTime.AddMinutes(double.Parse(obj.UberTime, CultureInfo.InvariantCulture.NumberFormat));
                }else if (obj.LyftPrice != "" && obj.LyftTime != "")
                {
                    vendorId = 1;
                    cost = double.Parse(obj.LyftPrice, CultureInfo.InvariantCulture.NumberFormat);
                    dTime = pTime.AddMinutes(double.Parse(obj.LyftTime, CultureInfo.InvariantCulture.NumberFormat));

                }else if(obj.YellowPrice != "" && obj.YellowTime != "")
                {
                    vendorId = 2;
                    cost = double.Parse(obj.YellowPrice, CultureInfo.InvariantCulture.NumberFormat);
                    dTime = pTime.AddMinutes(double.Parse(obj.YellowTime, CultureInfo.InvariantCulture.NumberFormat));

                }

                SqlDataAdapter sda3 = new SqlDataAdapter("Select count(*) from TripTable", con);
                DataTable dt3 = new DataTable();
                sda3.Fill(dt3);

                int tripId = (int)dt3.Rows[0][0] + 6;

                double tip = 0.2 * cost;
                double totalcost = tip + cost;

                SqlDataAdapter sda31 = new SqlDataAdapter("Select UserId from Users where UserName='"+username+"'", con);
                DataTable dt31 = new DataTable();
                sda31.Fill(dt31);
                int userid = (int)dt31.Rows[0][0];
                SqlDataAdapter sda4 = new SqlDataAdapter();
                string sql4 = "INSERT INTO Users VALUES (@tripId, @vendorId)";
                sda4.InsertCommand = new SqlCommand(sql4, con);
                sda4.InsertCommand.Parameters.AddWithValue("@tripId", tripId);
                sda4.InsertCommand.Parameters.AddWithValue("@vendorId", vendorId);
                sda4.InsertCommand.ExecuteNonQuery();

                SqlDataAdapter sda5 = new SqlDataAdapter();
                string sql5 = "INSERT INTO TripDetail VALUES ("+tripId+","+pickupLocationId+","+dropLocationId+")";
                sda5.InsertCommand = new SqlCommand(sql5, con);
                sda5.InsertCommand.ExecuteNonQuery();

                SqlDataAdapter sda6 = new SqlDataAdapter();
                string sql6 = "INSERT INTO UserTrip VALUES (" +tripId+","+ userid+")";
                sda6.InsertCommand = new SqlCommand(sql6, con);
                sda6.InsertCommand.ExecuteNonQuery();

                SqlDataAdapter sda7 = new SqlDataAdapter();
                string sql7 = "INSERT INTO PickUpDetail VALUES ('" + pTime + "'," + pickupLocationId + ","+tripId+")";
                sda7.InsertCommand = new SqlCommand(sql7, con);
                sda7.InsertCommand.ExecuteNonQuery();

                SqlDataAdapter sda8 = new SqlDataAdapter();
                string sql8 = "INSERT INTO DropOffDetail VALUES ('" + dTime + "'," + dropLocationId + "," + tripId + ")";
                sda8.InsertCommand = new SqlCommand(sql8, con);
                sda8.InsertCommand.ExecuteNonQuery();

                SqlDataAdapter sda9 = new SqlDataAdapter();
                string sql9 = "INSERT INTO CostDetailTable VALUES (" + tripId + "," + cost + "," + tip + ","+totalcost+")";
                sda9.InsertCommand = new SqlCommand(sql9, con);
                sda9.InsertCommand.ExecuteNonQuery();

                SqlDataAdapter sda10 = new SqlDataAdapter("Select * from Cabs where VendorId='"+vendorId+"' and IsAvailable='1'", con);
                DataTable dt10 = new DataTable();
                sda10.Fill(dt10);
                string cabId = dt10.Rows[0][0].ToString();
                d.cabBooked = cabId;

                SqlDataAdapter adapter1 = new SqlDataAdapter();
                SqlCommand command1 = new SqlCommand(
            "UPDATE Cabs SET IsAvailable = '0' WHERE CabId = @cabId", con);
                command1.Parameters.AddWithValue("@cabId", cabId);
                adapter1.UpdateCommand = command1;
                adapter1.UpdateCommand.ExecuteNonQuery();

                SqlDataAdapter sda11 = new SqlDataAdapter("Select PopularityScore from PopularLocation where PickUpId='" + pickupLocationId + "' and DropId='"+dropLocationId+"')", con);
                DataTable dt11 = new DataTable();
                sda11.Fill(dt11);
                int score = (int)dt11.Rows[0][0];

                SqlDataAdapter adapter2 = new SqlDataAdapter();
                SqlCommand command2 = new SqlCommand(
            "UPDATE PopularLocation SET PopularityScore=@popsc where PickUpId = '" + pickupLocationId + "' and DropId = '"+dropLocationId+"')", con);
                command2.Parameters.AddWithValue("@popsc", score);
                adapter2.UpdateCommand = command2;
                adapter2.UpdateCommand.ExecuteNonQuery();


                SqlDataAdapter sda12 = new SqlDataAdapter("Select RewardPoints from RewardsTable where UserId='" + userid + "')", con);
                DataTable dt12 = new DataTable();
                sda12.Fill(dt12);
                int rewards = (int)dt12.Rows[0][0];

                SqlDataAdapter adapter3 = new SqlDataAdapter();
                SqlCommand command3 = new SqlCommand(
            "UPDATE RewardsTable SET RewardPoints=@rewards where UserId = '" + userid +"')", con);
                command3.Parameters.AddWithValue("@rewards", rewards);
                adapter3.UpdateCommand = command3;
                adapter3.UpdateCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                d.isRequestSuccess = false;

            }
            m.ReleaseMutex();
            return d;
        }
    }
}