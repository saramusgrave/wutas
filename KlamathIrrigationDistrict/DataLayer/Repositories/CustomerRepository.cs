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
    public class CustomerRepository : ICustomerRepository
    {

        /* Purpose: 
         * SQL:     
         * CHECKS:  
         * GET:     
         * RETURNS: 
         * VIEW:    
         */

        /* Purpose: connects the user's username with their customerID 
        *          through the [CustomerID] table - need to update this in future
        *          to allow other users to login and navigate program.
        *          This is how ASP is retrieving user information from login
        * SQL:     SELECT CustomerID FROM [CustomerID]
        * GET:     UserID
        * RETURNS: UserID of the CutomerID
        */
        public virtual int getCustomerID(string userID)
        {
            Customers s = new Customers();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT CustomerID FROM [CustomerID] WHERE UserID = @UserID";
                    command.Parameters.AddWithValue("@UserID", userID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            s.CustomerID = int.Parse(reader["CustomerID"].ToString());
                        }
                    }
                }
            }
            return (s.CustomerID);
        }

        /* Purpose: will retrieve the currentallotment for user to view as using water
         * SQL:     SELECT CurrentAllotment FROM [CustomerProfile_AllotmentV2] WHERE CustomerID = @CustomerID
         * CHECKS:  cutomerID
         * GET:     
         * RETURNS: int (CurrentAllotment)
         * VIEW:    On the Menu
         */
        public virtual float getCurrentAllotment(int CustomerID)
        {
            Customers s = new Customers();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT CurrentAllotment FROM [CustomerProfile_AllotmentV2] WHERE CustomerID = @CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            s.CurrentAllotment = float.Parse(reader["CurrentAllotment"].ToString());
                        }
                    }
                }
            }
            return (s.CurrentAllotment);
        }

        /*---------------------------------------------------------------------------------------Views ------------------------------------------------------------------------------------------*/

           
        /* Purpose: retrieves the user(customer) information to view their information
         * SQL:     SELECT * FROM [CustomerProfile_AllotmentV2] WHERE CustomerID = @CustomerID; 
         *          (breakdown of CustomerProfile_AllotmentV2)
         *          SELECT          TOP (100) PERCENT klamath1.CustomerProfile_Allotment.CustomerID, klamath1.CustomerProfile_Allotment.Name, klamath1.CustomerProfile_Allotment.Address1, klamath1.CustomerProfile_Allotment.City, 
                                    klamath1.CustomerProfile_Allotment.State, klamath1.CustomerProfile_Allotment.Zip, klamath1.CustomerProfile_Allotment.Phone, klamath1.CustomerProfile_Allotment.TotalAllotment, COUNT(dbo.Violations.ViolationID) 
                                    AS Violation
         * GET:     CustomerID, Name, Address1, City, State, Zip, Phone, TotalAlootment, Violations
         * RETURNS: List<Customers>
         * VIEW:    CustomerProfile(id), StaffEditCustomers(id)
         */
        public virtual List<Customers> ViewCustomers(int CustomerID)
        {
            List<Customers> vc = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KID"].ConnectionString))
            {
                Customers s = new Customers();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    //command.CommandText = "SELECT * FROM CustomerInfo ORDER BY Name";
                    command.CommandText = "SELECT * FROM [CustomerProfile_AllotmentV2] WHERE CustomerID = @CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            s.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            s.Name = reader["Name"].ToString();
                            s.Address1 = reader["Address1"].ToString();
                            s.City = reader["City"].ToString();
                            s.State = reader["State"].ToString();
                            s.Zip = int.Parse(reader["Zip"].ToString());
                            s.Phone = reader["Phone"].ToString();
                            s.TotalAllotment = float.Parse(reader["TotalAllotment"].ToString());
                            s.Violations = int.Parse(reader["Violation"].ToString());
                            s.CurrentAllotment = float.Parse(reader["CurrentAllotment"].ToString());
                            vc.Add(s);
                        }
                    }
                }
            }
            return (vc);
        }

        /* Purpose: Retrieve the staff name and contact information within KID
         * SQL:     SELECT Position, FirstName, LastName, Email, PhoneNumber FROM KIDStaff WHERE StaffStatus = 1
         * GET:     Position, FirstName, LastName, Email, Phone Number
         * RETURNS: List of KID staff
         * VIEW:    ContactsPage()
         */
        public List<Customers> ViewStaff()
        {
            List<Customers> StaffContacts = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Position, FirstName, LastName, Email, PhoneNumber FROM KIDStaff WHERE StaffStatus = 1 AND Position != 'Customer'";
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

        /* Purpose: Retrieve the Customer Requests that have been 'Waitlisted' within the RequestStatus
         * SQL:     SELECT RequestID, CustomerDate1, CustomerName, Structure, CustomerCFS1, CustomerComments1, RequestStatus1, TimeStampStaff1, StaffComments1 FROM Requests WHERE CustomerID = @CustomerID AND RequestStatus1 = 'Wait List'";
         * CHECKS:  RequestStatus1 = 'Wait List'
         * GET:     RequestID, CustomerDate1, CustomerName, Structure, CustomerCFS1, CustomerComments1, RequestStatus1, TimeStampStaff1, StaffComments1
         * RETURNS: List of Requests
         * VIEW:    CustomerWaitList(id)
         */
        public List<Customers> WaitListCustomerRequest(int CustomerID)
        {
            List<Customers> WaitList = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT RequestID, CustomerDate1, CustomerName, Structure, CustomerCFS1, CustomerComments1, RequestStatus1, TimeStampStaff1, StaffComments1 FROM Requests WHERE CustomerID = @CustomerID AND RequestStatus1 = 'Wait List'";
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers p = new Customers();
                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.Name = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerCFS_1 = float.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments_1 = reader["CustomerComments1"].ToString();
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.TimeStampStaff1 = DateTime.Parse(reader["TimeStampStaff1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();

                            WaitList.Add(p);
                        }
                    }
                }
            }
            return (WaitList);
        }

        /* Purpose: Retrieve the Recently applied requests made by the customer (does not have a status - RequestStatus)
         * SQL:     SELECT RequestID, CustomerDate1, CustomerName, Structure, CustomerCFS1, CustomerComments1 FROM Requests WHERE RequestStatus1 IS NULL AND CustomerID = @CustomerID";
         * CHECKS:  RequestStatus1 as 'Pending'
         * GET:     RequestID, CustomerDate1, CustomerName, Structure, CustomerCFS1, CustomerCOmments1
         * RETURNS: List of Requests
         * VIEW:    CustomerRecentRequest(id)
         */
        public List<Customers> RecentRequests(int id)
        {
            List<Customers> Customer_Recent = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT RequestID, CustomerDate1, CustomerName, Structure, CustomerCFS1, CustomerComments1 FROM Requests WHERE RequestStatus1 != 'Confirm' AND RequestStatus1 != 'Wait List' AND CustomerID = @CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", id);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers p = new Customers();
                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.Name = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerCFS_1 = float.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments_1 = reader["CustomerComments1"].ToString();

                            Customer_Recent.Add(p);
                        }
                    }
                }
            }
            return (Customer_Recent);
        }

        /* Purpose: retrieves requests that have the status of confirmed 
         * SQL:     SELECT RequestID, CustomerDate1, CustomerName, Structure, CustomerCFS1, CustomerComments1, Staff1, StaffDate1, StaffComments1 FROM Requests WHERE RequestStatus1 = 'Confirm' AND RequestStatus2 IS NULL AND CustomerID = @CustomerID";
         * CHECKS:  RequestStatus1 = 'Confirm' AND RequestStatus2 IS NULL
         * GET:     RequestID, CustomerDate1, CustomerName, Structure, CustomerCFS1, CustomerComments1, Staff1, StaffDate1, StaffCOmments1
         * RETURNS: List of Requests
         * VIEW:    Index
         */
        public List<Customers> ActiveRequests(int id)
        {
            List<Customers> ActiveRequestList = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT RequestID, CustomerDate1, CustomerName, Structure, CustomerCFS1, CustomerComments1, Staff1, StaffDate1, StaffComments1 FROM Requests WHERE RequestStatus1 = 'Confirm' AND RequestStatus2 IS NULL AND CustomerID = @CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", id);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers p = new Customers();
                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.Name = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerCFS_1 = float.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments_1 = reader["CustomerComments1"].ToString();
                            p.StaffName_1 = reader["Staff1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();

                            ActiveRequestList.Add(p);
                        }
                    }
                }
            }
            return (ActiveRequestList);
        }


        /* Purpose: Retrieves the requests that have been fully completed
         * SQL:     SELECT * FROM [Customer History] WHERE CustomerID = @CustomerID
         * CHECKS:  
         * GET:     CustomerID, CustomerName, Structure, CustomerDate1, CustomerCFS1, CustomerCOmments1, RequestStatus1, StaffDate1, StaffCFS1, StaffComments1, CustomerDate2, 
         *          CustomerCFS2, CustomerComments2, RequestStatus2, Staff2, StaffDate2, StaffCFS2, StaffComments2, Ride
         * RETURNS: list of requests
         * VIEW:    CustomerWaterHistory(id, page)
         */
        public List<Customers> CompleteCustomerRequests(int CustomerID)
        {
            List<Customers> CompleteRequestList = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [Customer History] WHERE CustomerID = @CustomerID";
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers p = new Customers();
                            p.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            p.Name = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerCFS_1 = float.Parse(reader["CustomerCFS1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.StaffName_1 = reader["Staff1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.StaffCFS1 = float.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS_2 = float.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments_2 = reader["CustomerComments2"].ToString();
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.StaffName_2 = reader["Staff2"].ToString();
                            p.StaffDate2 = DateTime.Parse(reader["StaffDate2"].ToString());
                            p.StaffCFS2 = float.Parse(reader["StaffCFS2"].ToString());
                            p.StaffComments2 = reader["StaffComments2"].ToString();
                            p.Ride = int.Parse(reader["Ride"].ToString());

                            CompleteRequestList.Add(p);
                        }
                    }
                }
            }
            return (CompleteRequestList);
        }


        /*--------------------------------------------------------------------------------Stored Procedures-------------------------------------------------------------------------------------*/


        /* Purpose: apply the stored procedure of updating or entering in new customer data
         * SQL:     sp_InsertCustomer
         * CHECKS:  
         * GIVE:    CustomerID, Name, Address1, City, State, Zip, Phone, TotalAllotment
         * RETURNS: 
         * VIEW:    StaffEditCustomer(id)
         */
        public virtual void Save(Customers customers)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_InsertCustomer";

                    command.Parameters.AddWithValue("@CustomerID", customers.CustomerID);
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

        /* Purpose: Add the Customer Request from the input information
         * SQL:     sp_Customer_AddRequest
         * CHECKS:  Set the Request1Status as 'Pending'
         * GIVE:    CustomerID, CustomerName, CustomerCFS1, TimeStampCustomer1, CustomerDate1, CustomerComments1
         * RETURNS: 
         * VIEW:    CustomerAddRequest(Customers)
         */
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

                    command.Parameters.AddWithValue("@CustomerID", NewWaterOrder.CustomerID);
                    command.Parameters.AddWithValue("@CustomerName", NewWaterOrder.Name);
                    command.Parameters.AddWithValue("@Structure", NewWaterOrder.Structure);
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
