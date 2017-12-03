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
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create the SelectCommand.
                SqlCommand command = new SqlCommand(
            "UPDATE Users SET Name = @name, Phone = @phone, Address = @address WHERE UserName = @username", con);

                // Add the parameters for the UpdateCommand.
                command.Parameters.AddWithValue("@name", obj.Name);
                command.Parameters.AddWithValue("@phone", obj.Phone);
                command.Parameters.AddWithValue("@address", obj.Address);
                command.Parameters.AddWithValue("@username", obj.UserName);
                adapter.UpdateCommand = command;
                adapter.UpdateCommand.ExecuteNonQuery();
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
                d.isRequestSuccess = true;
            }catch(Exception e)
            {
                d.isRequestSuccess = false;
            }
            return d;
        }
    }
}