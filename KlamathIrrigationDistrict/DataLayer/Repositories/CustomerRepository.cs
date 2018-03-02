using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace KlamathIrrigationDistrict.DataLayer.Repositories
{
    //Actual body for the header file -> ICustomerRepository
    public class CustomerRepository : ICustomerRepository
    {        
        public virtual Customers Get(int CustomerID)
        {
            Customers s = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Customers";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            s = new Customers();
                            s.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            s.TrackingID = int.Parse(reader["TrackingID"].ToString());
                            s.Name = reader["Name"].ToString();
                            s.Address1 = reader["Address1"].ToString();
                            s.Address2 = reader["Address2"].ToString();
                            s.City = reader["City"].ToString();
                            s.State = reader["State"].ToString();
                            s.Zip = int.Parse(reader["Zip"].ToString());
                            s.TotalAllotment = decimal.Parse(reader["TotalAllotment"].ToString());
                        }
                    }
                }
            }
            return (s);
        }
        public virtual Customers GetRequestID(int RequestID)
        {
            //List<Customers> RequestList = new List<Customers>();
            Customers p = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    //command.CommandText = "SELECT * FROM Requests";
                    command.CommandText = "SELECT * FROM Requests";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.TimeStampCustomer1 = DateTime.Parse(reader["TimeStampCustomer1"].ToString());
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            p.Name = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerCFS_1 = int.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments_1 = reader["CustomerComments1"].ToString();
                            p.TimeStampStaff1 = DateTime.Parse(reader["TimeStampStaff1"].ToString());
                            p.StaffName_1 = reader["Staff1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.StaffCFS1 = int.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.TimeStampCustomer2 = DateTime.Parse(reader["TimeStampCustomer2"].ToString());
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS_2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments_2 = reader["CustomerComments2"].ToString();
                            p.TimeStampStaff2 = DateTime.Parse(reader["TimeStampStaff2"].ToString());
                            p.StaffName_2 = reader["Staff2"].ToString();
                            p.StaffDate2 = DateTime.Parse(reader["StaffDate2"].ToString());
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.StaffCFS2 = int.Parse(reader["StaffCFS2"].ToString());
                            p.StaffComments2 = reader["StaffComments2"].ToString();
                        }
                    }
                }
            }
            return (p);

        }

        public virtual List<Customers> ViewCustomers()
        {
            List<Customers> vc = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM CustomerInfo ORDER BY Name";
                    //command.CommandText = "SELECT * FROM CustomerInfo WHERE CustomerID = @CustomerID";
                    //command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers s = new Customers();
                            s.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            s.TrackingID = int.Parse(reader["TrackingID"].ToString());
                            s.Name = reader["Name"].ToString();
                            s.Email = reader["Email"].ToString();
                            s.Address1 = reader["Address1"].ToString();
                            s.Address2 = reader["Address2"].ToString();
                            s.City = reader["City"].ToString();
                            s.State = reader["State"].ToString();
                            s.Zip = int.Parse(reader["Zip"].ToString());
                            s.TotalAllotment = decimal.Parse(reader["TotalAllotment"].ToString());
                            s.Password = reader["Password"].ToString();
                            vc.Add(s);
                        }
                    }
                }
            }
            return (vc);
        }


        public virtual List<Customers> ViewCustomers(int CustomerID)
        {            
            List<Customers> vc = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    //command.CommandText = "SELECT * FROM CustomerInfo ORDER BY Name";
                    command.CommandText = "SELECT * FROM CustomerInfo WHERE CustomerID = @CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers s = new Customers();
                            s.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            s.Name = reader["Name"].ToString();
                            s.Address1 = reader["StreetName"].ToString();
                            //s.Address2 = reader["Address2"].ToString();
                            s.City = reader["City"].ToString();
                            s.State = reader["State"].ToString();
                            s.Zip = int.Parse(reader["Zip"].ToString());
                            s.Phone = reader["Phone"].ToString();
                            vc.Add(s);
                        }
                    }
                }
            }
            return (vc);
        }


        public List<Customers> ViewStaff()
        {
            List<Customers> StaffContacts = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Position, FirstName, LastName, Email, PhoneNumber FROM KIDStaff WHERE StaffStatus = 1";
                    //command.CommandText = "SELECT Positions.Position, StaffID, FirstName, LastName, Password, Email, PhoneNumber,StaffStatus, StartDate, EndDate, ModifiedDateTime, ModifiedUser FROM KIDStaff, Positions WHERE Positions.PositionID = KIDStaff.Position ORDER BY  KIDStaff.StaffStatus DESC,KIDStaff.StaffID ASC  ";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers StaffInfo = new Customers();
                            StaffInfo.Staff_Position = reader["Position"].ToString();
                            StaffInfo.Staff_FirstName = reader["FirstName"].ToString();                            
                            StaffInfo.Staff_LastName = reader["LastName"].ToString();                        
                            StaffInfo.Staff_Email = reader["Email"].ToString();
                            StaffInfo.Staff_PhoneNumber = reader["PhoneNumber"].ToString();
                            StaffContacts.Add(StaffInfo);
                        }
                    }
                }
            }
            return (StaffContacts);

        }


        public List<Customers> ViewCustomerRequests(int CustomerID)
        {
            List<Customers> RequestList = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    //command.CommandText = "SELECT * FROM Requests";
                    command.CommandText = "SELECT * FROM Requests WHERE CustomerID = @CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers p = new Customers();
                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.TimeStampCustomer1 = DateTime.Parse(reader["TimeStampCustomer1"].ToString());
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            p.Name = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerCFS_1 = int.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments_1 = reader["CustomerComments1"].ToString();
                            p.TimeStampStaff1 = DateTime.Parse(reader["TimeStampStaff1"].ToString());
                            p.StaffName_1 = reader["Staff1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.StaffCFS1 = int.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.TimeStampCustomer2 = DateTime.Parse(reader["TimeStampCustomer2"].ToString());
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS_2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments_2 = reader["CustomerComments2"].ToString();
                            p.TimeStampStaff2 = DateTime.Parse(reader["TimeStampStaff2"].ToString());
                            p.StaffName_2 = reader["Staff2"].ToString();
                            p.StaffDate2 = DateTime.Parse(reader["StaffDate2"].ToString());
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.StaffCFS2 = int.Parse(reader["StaffCFS2"].ToString());
                            p.StaffComments2 = reader["StaffComments2"].ToString();
                            //populate the 'RequestList' -> return to allow view
                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }

        //use the stored procedure to display the customer's water history
        //parameter need to be customerID? Not customers?
        //public virtual void ViewTotalAllotment (int CustomerID)
        //{
        //    //Customers C_CustomerID = CustomerID;
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.CommandText = "sp_TotalAllotment_Update";
        //            command.Parameters.AddWithValue("@CustomerID", CustomerID);
        //            connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //    //return (CustomerID)
        //}

        //apply the stored procedure of updating or entering in new customer data
        public virtual void Save(Customers customers)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_Customer_Insert_Update";
                    //if (customers.CustomerID != null)
                    //{
                    //    command.Parameters.AddWithValue("@CustomerID", customers.CustomerID);
                    //}
                    command.Parameters.AddWithValue("@CustomerID", customers.CustomerID);
                    command.Parameters.AddWithValue("@TrackingID", customers.TrackingID);
                    command.Parameters.AddWithValue("@Name", customers.Name);
                    command.Parameters.AddWithValue("@Address1", customers.Address1);
                    command.Parameters.AddWithValue("@Address2", customers.Address2);
                    command.Parameters.AddWithValue("@City", customers.City);
                    command.Parameters.AddWithValue("@State", customers.State);
                    command.Parameters.AddWithValue("@Zip", customers.Zip);
                    command.Parameters.AddWithValue("@TotalAllotment", customers.TotalAllotment);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public virtual void AddWaterOrderRequest(Customers NewWaterOrder)
        {
            //find a better way to Apply request for Water Order
            //WaterOrderRequest NewOrder = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_Customer_AddRequest";
                    //command.CommandType = CommandType.Text;
                    //command.CommandText = 
                    //    "INSERT INTO Requests" + 
                    //    "(CustomerID, CustomerName, Structure, CustomerCFS1, TimeStampCustomer1, " +
                    //    "CustomerDate1, CustomerComments1" +
                    //    "VALUES (@CustomerID, @CustomerName, @Structure, @TimeStampCustomer1, @CustomerDate1, @CustomerCFS1, @CustomerComments1";
                    command.Parameters.AddWithValue("@CustomerID", NewWaterOrder.CustomerID);
                    command.Parameters.AddWithValue("@CustomerName", NewWaterOrder.Name);
                    command.Parameters.AddWithValue("@Structure", NewWaterOrder.Structure);
                    //use getdate parameter to fulfill the customerdate
                    //command.Parameters.AddWithValue("@TimeStampCustomer1", NewWaterOrder.TimeStampCustomer1);
                    command.Parameters.AddWithValue("@CustomerDate1", NewWaterOrder._GetCustomerDate);
                    command.Parameters.AddWithValue("@CustomerCFS1", NewWaterOrder.CustomerCFS_1);
                    command.Parameters.AddWithValue("@CustomerComments1", NewWaterOrder.CustomerComments_1);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        

    }
}
