using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB_PresentationLayer.BusinessLayer;

namespace DB_PresentationLayer.PresentationLayer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BusinessLayer.LoginHandler loginHandlerObjectInstance = new LoginHandler();
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            bool IsValid = loginHandlerObjectInstance.IsLoginValid(userName, password);
            if (IsValid)
            {
                cmdLogin.Text = "Success!";
            }
        }
    }
}