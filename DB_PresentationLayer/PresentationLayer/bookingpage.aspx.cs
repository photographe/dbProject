using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB_PresentationLayer.EntityClass;
using DB_PresentationLayer.BusinessLayer;

namespace DB_PresentationLayer.PresentationLayer
{
    public partial class bookingpage : System.Web.UI.Page
    {
        public string USERNAME;
        protected void Page_Load(object sender, EventArgs e)
        {
            USERNAME = (Request.QueryString["userID"] != null) ? Request.QueryString["userID"] : "hello";
        }

        #region Book

        protected void cmdUberBook_Click(object sender, EventArgs e)
        {
            Booking bookingObjectInstance = GetBookingObjectFromPage();
            BookingHandler bookingHandlerObjectInstance = new BookingHandler();

            if (bookingHandlerObjectInstance.Book(bookingObjectInstance, USERNAME) != "")
            {
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
            Booking bookingObjectInstance = GetBookingObjectFromPage();
            BookingHandler bookingHandlerObjectInstance = new BookingHandler();

            if (bookingHandlerObjectInstance.Book(bookingObjectInstance, USERNAME) != "")
            {
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
            Booking bookingObjectInstance = GetBookingObjectFromPage();
            BookingHandler bookingHandlerObjectInstance = new BookingHandler();

            if (bookingHandlerObjectInstance.Book(bookingObjectInstance, USERNAME) != "")
            {
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
            Booking bookingObjectInstance = GetBookingObjectFromPage();
            BookingHandler bookingHandlerObjectInstance = new BookingHandler();

            bookingObjectInstance = bookingHandlerObjectInstance.FindRoute(bookingObjectInstance, USERNAME);
            SetBookingObjectToPage(bookingObjectInstance);
        }

        #endregion Find route

        #region Add to Cart



        #endregion Add to Cart

        #region Helper functions

        protected Booking GetBookingObjectFromPage()
        {
            Booking bookingObjetctInstance = new Booking();

            bookingObjetctInstance.Source = txtSource.Text;
            bookingObjetctInstance.Destination = txtDestination.Text;
            bookingObjetctInstance.UberTime = txtUberTime.Text;
            bookingObjetctInstance.LyftTime = txtLyftTime.Text;
            bookingObjetctInstance.YellowTime = txtYellowTime.Text;
            bookingObjetctInstance.UberPrice = txtUberPrice.Text;
            bookingObjetctInstance.LyftPrice = txtLyftPrice.Text;
            bookingObjetctInstance.YellowPrice = txtYellowPrice.Text;

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

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        #endregion Helper Functions
    }
}