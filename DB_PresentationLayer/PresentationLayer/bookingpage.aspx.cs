﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using DB_PresentationLayer.EntityClass;
using DB_PresentationLayer.BusinessLayer;

namespace DB_PresentationLayer.PresentationLayer
{
    public partial class bookingpage : System.Web.UI.Page
    {
        public string USERNAME;
        protected void Page_Load(object sender, EventArgs e)
        {
            USERNAME = (Request.QueryString["userID"] != null) ? Request.QueryString["userID"] : Session["USERNAME"].ToString();
        }

        #region Book

        protected void cmdUberBook_Click(object sender, EventArgs e)
        {
            string vendor = "uber";
            Booking bookingObjectInstance = GetBookingObjectFromPage(vendor);
            BookingHandler bookingHandlerObjectInstance = new BookingHandler();

            var watch = Stopwatch.StartNew();
            if (bookingHandlerObjectInstance.Book(bookingObjectInstance, USERNAME))
            {
                watch.Stop();
                var elapsedMs = (watch.ElapsedMilliseconds);
                string time = string.Concat("Query Run Time:", elapsedMs.ToString(), " milliseconds");
                MsgBox(time, this.Page, this);
                MsgBox("Your booking has been made! Bon Voyage!", this.Page, this);
                string callPage = string.Concat("Profile.aspx?userID=", USERNAME);
                Response.Redirect(callPage);
            }
            else
            {
                MsgBox("Oops!", this.Page, this);
            }
        }

        protected void cmdLyftBook_Click(object sender, EventArgs e)
        {
            string vendor = "lyft";
            Booking bookingObjectInstance = GetBookingObjectFromPage(vendor);
            BookingHandler bookingHandlerObjectInstance = new BookingHandler();

            var watch = Stopwatch.StartNew();
            if (bookingHandlerObjectInstance.Book(bookingObjectInstance, USERNAME))
            {
                watch.Stop();
                var elapsedMs = (watch.ElapsedMilliseconds);
                string time = string.Concat("Query Run Time:", elapsedMs.ToString(), " milliseconds");
                MsgBox(time, this.Page, this);
                MsgBox("Your booking has been made! Bon Voyage!", this.Page, this);
                string callPage = string.Concat("Profile.aspx?userID=", USERNAME);
                Response.Redirect(callPage);
            }
            else
            {
                MsgBox("Oops!", this.Page, this);
            }
        }

        protected void cmdYellowBook_Click(object sender, EventArgs e)
        {
            string vendor = "yellow";
            Booking bookingObjectInstance = GetBookingObjectFromPage(vendor);
            BookingHandler bookingHandlerObjectInstance = new BookingHandler();

            var watch = Stopwatch.StartNew();
            if (bookingHandlerObjectInstance.Book(bookingObjectInstance, USERNAME))
            {
                watch.Stop();
                var elapsedMs = (watch.ElapsedMilliseconds);
                string time = string.Concat("Query Run Time:", elapsedMs.ToString(), " milliseconds");
                MsgBox(time, this.Page, this);
                MsgBox("Your booking has been made! Bon Voyage!", this.Page, this);
                string callPage = string.Concat("Profile.aspx?userID=", USERNAME);
                Response.Redirect(callPage);
            }
            else
            {
                MsgBox("Oops!", this.Page, this);
            }
        }

        #endregion Book

        #region Find route

        protected void cmdFindRoute_Click(object sender, EventArgs e)
        {
            Booking bookingObjectInstance = GetBookingObjectFromPage("uber");
            BookingHandler bookingHandlerObjectInstance = new BookingHandler();
            var watch = Stopwatch.StartNew();
            bookingObjectInstance = bookingHandlerObjectInstance.FindRoute(bookingObjectInstance, USERNAME);
            watch.Stop();
            var elapsedMs = (watch.ElapsedMilliseconds);
            string time = string.Concat("Query Run Time:", elapsedMs.ToString(), " milliseconds");
            MsgBox(time, this.Page, this);

            checkValueReturned(bookingObjectInstance);
            SetBookingObjectToPage(bookingObjectInstance);
        }

        #endregion Find route

        #region Add to Cart



        #endregion Add to Cart

        #region Helper functions

        protected Booking GetBookingObjectFromPage(string vendor)
        {
            Booking bookingObjetctInstance = new Booking();

            bookingObjetctInstance.Source = txtSource.Text;
            bookingObjetctInstance.Destination = txtDestination.Text;
            if (vendor == "uber")
            {
                bookingObjetctInstance.UberTime = txtUberTime.Text;
                bookingObjetctInstance.UberPrice = txtUberPrice.Text;
            }
            else
            {
                bookingObjetctInstance.UberTime = string.Empty;
                bookingObjetctInstance.UberPrice = string.Empty;
            }

            if (vendor == "lyft")
            {
                bookingObjetctInstance.LyftTime = txtLyftTime.Text;
                bookingObjetctInstance.LyftPrice = txtLyftPrice.Text;
            }
            else
            {
                bookingObjetctInstance.LyftTime = string.Empty;
                bookingObjetctInstance.LyftPrice = string.Empty;
            }
            
            if(vendor == "yellow")
            {
                bookingObjetctInstance.YellowTime = txtYellowTime.Text;
                bookingObjetctInstance.YellowPrice = txtYellowPrice.Text;
            }
            else
            {
                bookingObjetctInstance.YellowTime = string.Empty;
                bookingObjetctInstance.YellowPrice = string.Empty;
            }
            return bookingObjetctInstance;
        }

        protected void SetBookingObjectToPage(Booking bookingObjectInstance)
        {
            txtSource.Text = bookingObjectInstance.Source;
            txtDestination.Text = bookingObjectInstance.Destination;
            txtUberTime.Text = bookingObjectInstance.UberTime;
            txtUberPrice.Text = bookingObjectInstance.UberPrice;
            txtLyftTime.Text = bookingObjectInstance.LyftTime;
            txtLyftPrice.Text = bookingObjectInstance.LyftPrice;
            txtYellowTime.Text = bookingObjectInstance.YellowTime;
            txtYellowPrice.Text = bookingObjectInstance.YellowPrice;
        }

        private void checkValueReturned(Booking bookingObjectInstance)
        {
            if(string.IsNullOrWhiteSpace(bookingObjectInstance.LyftPrice) && string.IsNullOrWhiteSpace(bookingObjectInstance.LyftTime) 
                && string.IsNullOrWhiteSpace(bookingObjectInstance.UberPrice) && string.IsNullOrWhiteSpace(bookingObjectInstance.UberTime)
                && string.IsNullOrWhiteSpace(bookingObjectInstance.YellowPrice) && string.IsNullOrWhiteSpace(bookingObjectInstance.YellowTime))
            {
                MsgBox("None of the operators cover that area currently..sorry for the inconvenience" , this.Page, this);
            }
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>confirm('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        #endregion Helper Functions
    }
}