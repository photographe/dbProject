using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DB_PresentationLayer.EntityClass;
<<<<<<< HEAD
=======
using DB_PresentationLayer.Models;
>>>>>>> 21032bfb1440ddb4ecfe232d1a0e4cec5e3311de

namespace DB_PresentationLayer.DataAccessLayer
{
    public class DALProfileHandler
    {
<<<<<<< HEAD
        public bool UpdateProfile(Profile obj, String Username)
        {
            return true;
        }
        public bool NewProfile(Profile obj, String usename)
        {
            return true;
=======
        SqlConnection con = DBConnection.Instance.GetDBConnection();

        public DataObject UpdateProfile(Profile obj, String Username)
        {
            DataObject d = new DataObject();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create the SelectCommand.
                SqlCommand command = new SqlCommand(
            "UPDATE Users SET Name = @name, Phone = @phone, Address = @address WHERE UserName = @username", con);

                // Add the parameters for the UpdateCommand.
                command.Parameters.Add("@name", SqlDbType.NVarChar, 25, obj.Name);
                command.Parameters.Add("@phone", SqlDbType.NVarChar, 25, obj.Phone);
                command.Parameters.Add("@address", SqlDbType.NVarChar, 25, obj.Address);
                command.Parameters.Add("@username", SqlDbType.NVarChar, 25, obj.UserName);
                adapter.UpdateCommand = command;
                d.isRequestSuccess = true;
            }catch(Exception e)
            {
                d.isRequestSuccess = false;
            }
            return d;
        }
        public DataObject NewProfile(Profile obj, String usename)
        {
            DataObject d = new DataObject();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("INSERT INTO Users (UserName, Password, Email, Name, Phone, Address, IsStudent) VALUES (@username, @password, @email, @name, @phone, @address, @isstudent)", con);
                sda.InsertCommand.Parameters.Add("@username", SqlDbType.NVarChar, 25, obj.UserName);
                sda.InsertCommand.Parameters.Add("@password", SqlDbType.NVarChar, 25, obj.Password);
                sda.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 25, obj.Email);
                sda.InsertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 25, obj.Name);
                sda.InsertCommand.Parameters.Add("@phone", SqlDbType.NVarChar, 25, obj.Phone);
                sda.InsertCommand.Parameters.Add("@address", SqlDbType.NVarChar, 50, obj.Address);
                sda.InsertCommand = command;
                d.isRequestSuccess = true;
            }catch(Exception e)
            {
                d.isRequestSuccess = false;
            }
            return d;
>>>>>>> 21032bfb1440ddb4ecfe232d1a0e4cec5e3311de
        }
    }
}