using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DB_PresentationLayer.EntityClass;
using DB_PresentationLayer.Models;

namespace DB_PresentationLayer.DataAccessLayer
{
    public class DALProfileHandler
    {
        SqlConnection con = DBConnection.Instance.GetDBConnection();

        public DataObject UpdateProfile(Profile obj, String Username)
        {
            DataObject d = new DataObject();
            try
            {
<<<<<<< HEAD
                con.Open();
=======
>>>>>>> 21032bfb1440ddb4ecfe232d1a0e4cec5e3311de
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create the SelectCommand.
                SqlCommand command = new SqlCommand(
            "UPDATE Users SET Name = @name, Phone = @phone, Address = @address WHERE UserName = @username", con);

                // Add the parameters for the UpdateCommand.
<<<<<<< HEAD
                command.Parameters.AddWithValue("@name", obj.Name);
                command.Parameters.AddWithValue("@phone", obj.Phone);
                command.Parameters.AddWithValue("@address", obj.Address);
                command.Parameters.AddWithValue("@username", obj.UserName);
                adapter.UpdateCommand = command;
                adapter.UpdateCommand.ExecuteNonQuery();
=======
                command.Parameters.Add("@name", SqlDbType.NVarChar, 25, obj.Name);
                command.Parameters.Add("@phone", SqlDbType.NVarChar, 25, obj.Phone);
                command.Parameters.Add("@address", SqlDbType.NVarChar, 25, obj.Address);
                command.Parameters.Add("@username", SqlDbType.NVarChar, 25, obj.UserName);
                adapter.UpdateCommand = command;
>>>>>>> 21032bfb1440ddb4ecfe232d1a0e4cec5e3311de
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
<<<<<<< HEAD
                string sql = "INSERT INTO Users (UserName, Password, Email, Name, Phone, Address) VALUES (@username, @password, @email, @name, @phone, @address)";
                //SqlCommand command = new SqlCommand("INSERT INTO Users (UserName, Password, Email, Name, Phone, Address, IsStudent) VALUES (@username, @password, @email, @name, @phone, @address, @isstudent)", con);
                con.Open();
                sda.InsertCommand = new SqlCommand(sql, con);
                sda.InsertCommand.Parameters.AddWithValue("@username", obj.Name);
                sda.InsertCommand.Parameters.AddWithValue("@password", obj.Password);
                sda.InsertCommand.Parameters.AddWithValue("@email", obj.Email);
                sda.InsertCommand.Parameters.AddWithValue("@name", obj.Name);
                sda.InsertCommand.Parameters.AddWithValue("@phone", obj.Phone);
                sda.InsertCommand.Parameters.AddWithValue("@address", obj.Address);
                sda.InsertCommand.ExecuteNonQuery();
=======
                SqlCommand command = new SqlCommand("INSERT INTO Users (UserName, Password, Email, Name, Phone, Address, IsStudent) VALUES (@username, @password, @email, @name, @phone, @address, @isstudent)", con);
                sda.InsertCommand.Parameters.Add("@username", SqlDbType.NVarChar, 25, obj.UserName);
                sda.InsertCommand.Parameters.Add("@password", SqlDbType.NVarChar, 25, obj.Password);
                sda.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 25, obj.Email);
                sda.InsertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 25, obj.Name);
                sda.InsertCommand.Parameters.Add("@phone", SqlDbType.NVarChar, 25, obj.Phone);
                sda.InsertCommand.Parameters.Add("@address", SqlDbType.NVarChar, 50, obj.Address);
                sda.InsertCommand = command;
>>>>>>> 21032bfb1440ddb4ecfe232d1a0e4cec5e3311de
                d.isRequestSuccess = true;
            }catch(Exception e)
            {
                d.isRequestSuccess = false;
            }
            return d;
        }
    }
}