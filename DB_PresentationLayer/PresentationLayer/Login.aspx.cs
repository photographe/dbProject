using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Diagnostics;
using System.Web.UI.WebControls;
using DB_PresentationLayer.EntityClass;
using DB_PresentationLayer.BusinessLayer;

namespace DB_PresentationLayer.PresentationLayer
{
    public partial class Login : System.Web.UI.Page
    {
        private string UserName;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BusinessLayer.LoginHandler loginHandlerObjectInstance = new LoginHandler();
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            var watch = Stopwatch.StartNew();
            bool IsValid = loginHandlerObjectInstance.IsLoginValid(userName, password);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            string time = string.Concat("Query Run Time:", elapsedMs.ToString(), " milliseconds");
            MsgBox(time, this.Page, this);
            if (IsValid)
            {
                UserName = userName;
                MsgBox("Success!", this.Page, this);
                string callPage = string.Concat("Profile.aspx?userID=", UserName);
                Response.Redirect(callPage);
                // Server.Transfer("Profile.aspx");
            }
            else
            {
                MsgBox("Invalid username/password..please try again!", this.Page, this);
            }
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}