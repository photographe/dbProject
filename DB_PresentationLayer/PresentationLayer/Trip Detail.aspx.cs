using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using DB_PresentationLayer.BusinessLayer;
using System.Web.UI.WebControls;

namespace DB_PresentationLayer.PresentationLayer
{
    public partial class Trip_Detail : System.Web.UI.Page
    {
        public string USERNAME;
        protected void Page_Load(object sender, EventArgs e)
        {
            USERNAME = (Request.QueryString["userID"] != null) ? Request.QueryString["userID"] : Session["USERNAME"].ToString();
            TripDetailHandler tripDetailHandlerInstance = new TripDetailHandler();
            DataSet TripDetailDataSet = tripDetailHandlerInstance.GetTripDetail(USERNAME);
            dlstTripDetail.DataSource = TripDetailDataSet;
            dlstTripDetail.DataBind();
        }
    }
}