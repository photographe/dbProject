using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Net.Mail;
using DB_PresentationLayer.EntityClass;
using DB_PresentationLayer.BusinessLayer;
using System.Web.UI.WebControls;

namespace DB_PresentationLayer.PresentationLayer
{
    public partial class Profile : System.Web.UI.Page
    {
        public string USERNAME;
        protected void Page_Load(object sender, EventArgs e)
        {
            USERNAME = (Request.QueryString["userID"] != null) ? Request.QueryString["userID"] : "hello";
        }

        #region Update Profile

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            ProfileHandler profileHandlerObjectInstance = new ProfileHandler();
            string name = string.Empty, email = string.Empty, password = string.Empty, phone = string.Empty, address = string.Empty, review = string.Empty, contribute = string.Empty;
            bool IsValid = true;

            #region Get All Values
            if (string.IsNullOrWhiteSpace(txtName.Text) != true)
            {
                name = txtName.Text;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) != true)
            {
                email = txtEmail.Text;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) != true)
            {
                password = txtPassword.Text;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text) != true)
            {
                phone = txtPhone.Text;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text) != true)
            {
                address = txtAddress.Text;
            }

            if (string.IsNullOrWhiteSpace(txtReview.Text) != true)
            {
                review = txtReview.Text;
            }

            if (string.IsNullOrWhiteSpace(txtContribute.Text) != true)
            {
                contribute = txtContribute.Text;
            }
            #endregion Get All Values

            #region Validate Values

            try
            {
                if(string.IsNullOrWhiteSpace(email) != true)
                {
                    MailAddress m = new MailAddress(email);
                }
            }
            catch (FormatException)
            {
                IsValid = false;
                MsgBox("! Email is not in a valid format !", this.Page, this);
            }

            if (string.IsNullOrWhiteSpace(phone) != true)
            {
                if (IsPhoneNumber(phone) == false)
                {
                    IsValid = false;
                    MsgBox("! Phone number is not in a valid format !", this.Page, this);
                }
            }

            #endregion Validate Values

            if (IsValid)
            {
                EntityClass.Profile ProfileObject = GetProfileObjectFromPage();
                profileHandlerObjectInstance.UpdateProfile(ProfileObject, USERNAME);
                MsgBox("Success!", this.Page, this);
            }
            else
            {
                MsgBox("There is something wrong with your input!", this.Page, this);
            }
        }

        #endregion Update Profile

        #region Helper functions

        protected EntityClass.Profile GetProfileObjectFromPage()
        {
            EntityClass.Profile profileObjectInstance = new EntityClass.Profile();

            profileObjectInstance.Name = txtName.Text;
            profileObjectInstance.Password = txtPassword.Text;
            profileObjectInstance.Address = txtAddress.Text;
            profileObjectInstance.AddReview = txtReview.Text;
            profileObjectInstance.Contribute = txtContribute.Text;
            profileObjectInstance.Email = txtEmail.Text;
            profileObjectInstance.Phone = txtPhone.Text;
            profileObjectInstance.UserName = USERNAME;

            return profileObjectInstance;
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }

        #endregion Helper functions
    }
}