using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;

namespace KlamathIrrigationDistrict.DataLayer.Repositories
{
    public class DitchRidersRepository : IDitchRidersRepository
    {

        /*-------------------------Drop Downs ---------------------------------------------------*/

        /* Request Status Drop Down as Status()
         * SQL: SELECT * FROM RequestStatusList
         * GET: RequestStatusID, RequestStatusName
         */
        public List<DitchRiderRequests> Status()
        {
            List<DitchRiderRequests> list = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM RequestStatusList";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests r = new DitchRiderRequests();
                            r.RequestStatusID = int.Parse(reader["RequestStatusID"].ToString());
                            r.RequestStatusName = reader["RequestStatusName"].ToString();
                            list.Add(r);
                        }
                    }
                }
            }
            return (list);
        }
        /* Comment Drop Down List as Comments()
         * SQL: SELECT * FROM Comments ORDER BY CommentID
         * GET: CommentID, Comment
         */
        public List<DitchRiderRequests> Comments()
        {
            List<DitchRiderRequests> list = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Comments ORDER BY CommentID";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests r = new DitchRiderRequests();
                            r.CommentID = int.Parse(reader["CommentID"].ToString());
                            r.Comment = reader["Comment"].ToString();
                            list.Add(r);
                        }
                    }
                }
            }
            return (list);
        }
        /* Violations Drop Down as Violations()
         * SQL: SELECT * FROM ViolationList
         * GET: ViolationID, Violation
         */
        public List<DitchRiderRequests> Violations()
        {
            List<DitchRiderRequests> list = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM ViolationList";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            DitchRiderRequests r = new DitchRiderRequests();
                            r.ViolationID = int.Parse(reader["ViolationListID"].ToString());
                            r.Violation = reader["Violation"].ToString();
                            list.Add(r);
                        }
                    }
                }
            }
            return (list);
        }
        /*Canals Drop Down as Canals()
         * SQL: SELECT Lateral FROM Canals ORDER BY Lateral
         * GET: Lateral
         */
        public List<DitchRiderRequests> Canals()
        {
            List<DitchRiderRequests> list = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Lateral FROM Canals ORDER BY Lateral";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests r = new DitchRiderRequests();
                            r.Lateral = reader["Lateral"].ToString();
                            list.Add(r);
                        }
                    }
                }
            }
            return (list);
        }

        /*-------------------------Views ---------------------------------------------------*/

        /* Ditch Rider Customers as Customers(id)
         * SQL: SELECT * FROM [DitchRiderCustomers] WHERE Ride = @RideNum ORDER BY Lateral";
                    command.CommandText = "SELECT [DitchRiderCustomers].*, (SELECT COUNT(CustomerName) FROM [Customers With Water On] WHERE [Customers With Water On].CustomerID = [DitchRiderCustomers].CustomerID AND [Customers With Water On].Structure = [DitchRiderCustomers].StructureID) AS WOn  FROM [DitchRiderCustomers] WHERE [DitchRiderCustomers].Ride = @RideNum ORDER BY [DitchRiderCustomers].Lateral
         * GET: CustomerID, CustomerName, Structure, Lateral, TOtalAllotment, Ride, ViolationID, ON
         * View: Customers, AddRequestOn
         */
        public List<DitchRiderRequests> Customers(int id)
        {
            List<DitchRiderRequests> CustomerList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = connection;
                    //command.CommandText = "SELECT * FROM [DitchRiderCustomers] WHERE Ride = @RideNum ORDER BY Lateral";
                    command.CommandText = "SELECT [DitchRiderCustomers].*, (SELECT COUNT(CustomerName) FROM [Customers With Water On] WHERE [Customers With Water On].CustomerID = [DitchRiderCustomers].CustomerID AND [Customers With Water On].Structure = [DitchRiderCustomers].StructureID) AS WOn  FROM [DitchRiderCustomers] WHERE [DitchRiderCustomers].Ride = @RideNum ORDER BY [DitchRiderCustomers].Lateral";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests c = new DitchRiderRequests();

                            c.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            c.CustomerName = reader["Name"].ToString();
                            c.Structure = reader["StructureID"].ToString();
                            c.Lateral = reader["Lateral"].ToString();
                            c.TotalAllotment = float.Parse(reader["CurrentAllotment"].ToString());
                            c.Ride = int.Parse(reader["Ride"].ToString());
                            c.ViolationID = int.Parse(reader["Violation"].ToString());
                            c.On = int.Parse(reader["WOn"].ToString());
                           
                            CustomerList.Add(c);
                        }
                    }
                }
            }
            return (CustomerList);
        }
        /* View Customers With Water On as ViewCustomersWithWater_On(id)
         * SQL: SELECT * FROM [Customers With Water On] WHERE Ride = @RideNum ORDER BY Lateral
         * GET: RequestID, CustomerID, CustomerName, Structure, Lateral, TotalAllotment, Ride, StaffCFS1, StaffDate1
         * View: Customer_On, _AddRequestOff
         */
        public List<DitchRiderRequests> ViewCustomersWithWater_On(int id)
        {
            List<DitchRiderRequests> CustomerList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [Customers With Water On] WHERE Ride = @RideNum ORDER BY Lateral";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests c = new DitchRiderRequests();

                            c.RequestID = int.Parse(reader["RequestID"].ToString());
                            c.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            c.CustomerName = reader["CustomerName"].ToString();
                            c.Structure = reader["Structure"].ToString();
                            c.Lateral = reader["Lateral"].ToString();
                            c.TotalAllotment = float.Parse(reader["CurrentAllotment"].ToString());
                            c.Ride = int.Parse(reader["Ride"].ToString());
                            c.StaffCFS1 = float.Parse(reader["StaffCFS1"].ToString());
                            c.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            
                            CustomerList.Add(c);
                        }
                    }
                }
            }
            return (CustomerList);
        }      
        /* View Customers History as ViewCustomerHistory(id)
         * SQL: SELECT * FROM [Customer History] WHERE Ride = @RideNum ORDER BY StaffDate1 ASC
         * GET: CustomerID, CustomerName, Structure, CustomerDate1, CustomerCFS1, REquestStatus1, Staff1, StaffDate1, StaffCFS1, StaffComments1, CustomerDate2, CustomerCFS2, CustomerComments2, RequestStatus2, Staff2, StaffDate2, StaffCFS2, StaffComments2, Ride
         * View: CustomerHistory
         */
        public List<DitchRiderRequests> ViewCustomersHistory(int id)
        {
            List<DitchRiderRequests> HistoryList = new List<DitchRiderRequests>();
            using (SqlConnection conneciton = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = conneciton;

                    command.CommandText = "SELECT * FROM [Customer History] WHERE Ride = @RideNum ORDER BY StaffDate1 ASC";
                    command.CommandType = CommandType.Text;
                    conneciton.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();
                            p.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerCFS1 = float.Parse(reader["CustomerCFS1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.Staff1 = reader["Staff1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.StaffCFS1 = float.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS2 = float.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.Staff2 = reader["Staff2"].ToString();
                            p.StaffDate2 = DateTime.Parse(reader["StaffDate2"].ToString());
                            p.StaffCFS2 = float.Parse(reader["StaffCFS2"].ToString());
                            p.StaffComments2 = reader["StaffComments2"].ToString();
                            p.Ride = int.Parse(reader["Ride"].ToString());

                            HistoryList.Add(p);                         
                        }
                    }                    
                }
            }
            return (HistoryList);
        }
        /* View Customer Recent History as ViewCustomersRecentHistory(id)
         * SQL: SELECT * FROM [Customer Recent History] WHERE Ride = @RideNum ORDER BY StaffDate1 ASC
         * GET: CustomerID, CustomerName, Structure, CustomerDate1, CustomerCFS1, RequestStatus1, Staff1, StaffDate1, StaffCFS1, StaffComments1, CustomerDate2, CusotmerCFS2, CustomerComments2, RequestStatus2, Staff2, StaffDate2, StaffCFS2, StaffComments2, Ride, RequestID, Lateral
         * View: CustomerHistory
         */
        public List<DitchRiderRequests> ViewCustomersRecentHistory(int id)
        {
            List<DitchRiderRequests> HistoryList = new List<DitchRiderRequests>();
            using (SqlConnection conneciton = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = conneciton;

                    command.CommandText = "SELECT * FROM [Customer Recent History] WHERE Ride = @RideNum";
                    command.CommandType = CommandType.Text;
                    conneciton.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();
                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerCFS1 = float.Parse(reader["CustomerCFS1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.Staff1 = reader["Staff1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.StaffCFS1 = float.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS2 = float.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.Staff2 = reader["Staff2"].ToString();
                            p.StaffDate2 = DateTime.Parse(reader["StaffDate2"].ToString());
                            p.StaffCFS2 = float.Parse(reader["StaffCFS2"].ToString());
                            p.StaffComments2 = reader["StaffComments2"].ToString();
                            p.Ride = int.Parse(reader["Ride"].ToString());
                            p.Lateral = reader["Lateral"].ToString();

                            HistoryList.Add(p);
                        }
                    }
                }
            }
            return (HistoryList);
        }
        /* View completed Requests as ViewRequests(id)
         * SQL: SELECT * FROM Requests WHERE StaffCFS2 IS NOT NULL AND Ride = @RideNum ORDER BY CustomerDate1 DESC
         * GET: RequestID, TimeStampCustomer1, CustomerName, CustomerID, CusotmerDate1, CustomerCFS1, CustomerComments1, RequestStatsu1, Staff1, TimeStampStaff1, StaffDate1, StafCFS1, StaffComments1, RequestStatus2, CustomerDate2, CustomerCFS2, CustomerComments2, Stataff2, StaffDate2, StaffCFS2, StaffComments2, Ride, Lateral
         * View: CompletedRequests
         */ 
        public List<DitchRiderRequests> ViewRequests(int id)
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Requests WHERE StaffCFS2 IS NOT NULL AND Ride = @RideNum ORDER BY CustomerDate1 DESC";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();

                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.TimeStampCustomer1 = DateTime.Parse(reader["TimeStampCustomer1"].ToString());
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerCFS1 = float.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments1 = reader["CustomerComments1"].ToString();
                            p.TimeStampStaff1 = DateTime.Parse(reader["TimeStampStaff1"].ToString());
                            p.Staff1 = reader["Staff1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.StaffCFS1 = float.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS2 = float.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();
                            p.TimeStampStaff2 = DateTime.Parse(reader["TimeStampStaff2"].ToString());
                            p.Staff2 = reader["Staff2"].ToString();
                            p.StaffDate2 = DateTime.Parse(reader["StaffDate2"].ToString());
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.StaffCFS2 = float.Parse(reader["StaffCFS2"].ToString());
                            p.StaffComments2 = reader["StaffComments2"].ToString();
                            p.Ride = int.Parse(reader["Ride"].ToString());
                            p.Lateral = reader["Lateral"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }      
        /* View Active Requests On as ViewActiveRequestsOn(id)
         * SQL: SELECT * FROM Requests WHERE Ride = @RideNum AND StaffCFS1 IS NULL AND CustomerDate1 IS NOT NULL AND RequestStatsu1 = 'Confirm'
         * GET: RequestID, CustomerDate1, CustoemrName, Structure, Lateral, REquestStatus1, CustomerCFS1, CustomerCommetns1
         * View: CompletedRequests, _ActiveRequestsOn, EditRequestsOn
         */
        public List<DitchRiderRequests> ViewActiveRequestOn(int id)
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE Ride = @RideNum AND StaffCFS1 IS NULL AND CustomerDate1 IS NOT NULL AND RequestStatus1 = 'Confirm' ";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();
                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.Lateral = reader["Lateral"].ToString();
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.CustomerCFS1 = float.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments1 = reader["CustomerComments1"].ToString();
                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }
        /* View Active Requests Off as ViewActiveRequestOff(id)
         * SQL: SELECT * FROM Requests WHERE Ride = @RideNum AND StaffCFS2 IS NULL AND CustomerDate2 IS NOT NULL AND RequestStatus2 = 'Confirm'
         * GET: REquestID, CustomerDate2, CustomerName, Structure, Lateral, RequestStatus2, CustomerCFS2, CustomerComments2
         * View: _ActiveREquestOff, EditRequestOff
         */
        public List<DitchRiderRequests> ViewActiveRequestOff(int id)
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE Ride = @RideNum AND StaffCFS2 IS NULL AND CustomerDate2 IS NOT NULL AND RequestStatus2 = 'Confirm'";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();

                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.Lateral = reader["Lateral"].ToString();
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.CustomerCFS2 = float.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }
        /* View Pending Requests as ViewPending_On(id)
         * SQL: SELECT * FROM Requests WHERE RequestStatus1 != 'Confirm' AND RequestStatus1 != 'Wait List' AND Ride = @RideNum ORDER BY CustomerDate1
         * GET: RequestID, CustomerDate1, CustomerName, Structure, Lateral, RequestStatus1, CustomerCFS1, CustomerComments1
         * View: EditRequestStatus_On, Appending_On
         */
        public List<DitchRiderRequests> ViewPending_On(int id)
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE RequestStatus1 != 'Confirm' AND RequestStatus1 != 'Wait List' AND Ride = @RideNum ORDER BY CustomerDate1 ";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();

                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.Lateral = reader["Lateral"].ToString();
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.CustomerCFS1 = float.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments1 = reader["CustomerComments1"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }
        /* View Pending Off Requests as ViewPending_Off(id)
         * SQL: SELECT * FROM Requests WHERE Ride = @RideNum AND RequestStatus2 != 'Confirm' AND RequestStatus2 != 'Wait List' AND CustomerDate2 IS NOT NULL ORDER BY CustomerDate2 
         * GET: RequestID, CustomerDate2, CustomerName, Structure, Lateral, RequestStatus2, CustomerCFS2, CustomerComments2
         * View: Appending_Off, EditRequestStatus_Off
         */
        public List<DitchRiderRequests> ViewPending_Off(int id)
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE Ride = @RideNum AND RequestStatus2 != 'Confirm' AND RequestStatus2 != 'Wait List' AND CustomerDate2 IS NOT NULL ORDER BY CustomerDate2 ";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();

                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.Lateral = reader["Lateral"].ToString();
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.CustomerCFS2 = float.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }
        /* View Wait List On Requests as ViewWaitlist_On(id)
         * SQL: SELECT * FROM Requests WHERE RequestStatus1 = 'Wait list' AND Ride = @RideNum
         * GET: RequestID, CustomerDate1, CustomerName, Structure, Lateral, REquestStatus1, CustomerCFS1, CustomerComments1
         * Views: WaitList_On, EditWaitList_On
         */
        public List<DitchRiderRequests> ViewWaitlist_On(int id)
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE RequestStatus1 = 'Wait list' AND Ride = @RideNum ";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();

                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.Lateral = reader["Lateral"].ToString();
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.CustomerCFS1 = float.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments1 = reader["CustomerComments1"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }
        /* View Wait List Off Requests as ViewWaitlist_Off(id)
         * SQL: SELECT * FROM Requests WHERE RequestStatus2 = 'Wait list' AND Ride = @RideNum
         * GET: RequestID, CustomerDate2, CustomerName, Structure, Lateral, REquestStatus2, CustomerCFS2, CustomerComments2
         * Views: WaitList_Off, EditWaitList_Off
         */
        public List<DitchRiderRequests> ViewWaitlist_Off(int id)
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE RequestStatus2 = 'Wait list' AND Ride = @RideNum ";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();

                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.Lateral = reader["Lateral"].ToString();
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.CustomerCFS2 = float.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }
        /* Get RequestID as Get(ID)
         * SQL: sp_DitchRider_Get
         * RequestID, TimeStampCustomer1, CustomerDate1, CustomerID, CustomerName, Structure, CustomerCFS1, TimeStampStaff1, Staff1, StaffDate1, RequestStatus1, StaffCFS1, StaffComments1, CustomerDate2, CustomerCFS2, TimeStampStaff2, Staff2, StaffDate2, RequestStatus2, StaffCFS2, StaffComments2
         * View: ViewRequests
         */
        public DitchRiderRequests Get(int ID)
        {
            DitchRiderRequests p = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DitchRider_Get";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new DitchRiderRequests();
                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.TimeStampCustomer1 = DateTime.Parse(reader["TimeStampCustomer1"].ToString());
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerCFS1 = int.Parse(reader["CustomerCFS1"].ToString());
                            p.TimeStampStaff1 = DateTime.Parse(reader["TimeStampStaff1"].ToString());
                            p.Staff1 = reader["Staff1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.StaffCFS1 = int.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.TimeStampStaff2 = DateTime.Parse(reader["TimeStampStaff2"].ToString());
                            p.Staff2 = reader["Staff2"].ToString();
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
        
        /*-------------------------Stored Procedures---------------------------------------*/

        /* Delete Recent History as DeleterRHistory(int RequestID)
         * SQL: sp_DitchRider_DeleteRHistory
         * Give: @RequestID
         * View: DeleteRHistory */
        public virtual void DeleteRHistory(int RequestID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_DeleteRHistory";

                    DitchRiderRequests dr = new DitchRiderRequests();
                    command.Parameters.AddWithValue("@RequestID", dr.RequestID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /* Add Customer Call Request for Water On as AddREquest_On(ditchriderrequests)
         * SQL: sp_DitchRider_AddRequestOn
         * GIVE: TimeStampCustomer1, CustomerDate1, CusotmerID, CustomerName, Structure, Lateral, CustomerCFS1, CustomerComments1, RequestStatsu1, Ride
         * View: AddRequestOn
         */
        public virtual void AddRequest_On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_AddRequestsOn";
                   
                    command.Parameters.AddWithValue("@TimeStampCustomer1", ditchriderrequests.TimeStampCustomer1);
                    command.Parameters.AddWithValue("@CustomerDate1", ditchriderrequests.CustomerDate1);
                    command.Parameters.AddWithValue("@CustomerID", ditchriderrequests.CustomerID);
                    command.Parameters.AddWithValue("@CustomerName", ditchriderrequests.CustomerName);
                    command.Parameters.AddWithValue("@Structure", ditchriderrequests.Structure);
                    command.Parameters.AddWithValue("@Lateral", ditchriderrequests.Lateral);
                    command.Parameters.AddWithValue("@CustomerCFS1", ditchriderrequests.CustomerCFS1);
                    command.Parameters.AddWithValue("@CustomerComments1", ditchriderrequests.CustomerComments1);
                    command.Parameters.AddWithValue("@RequestStatus1", ditchriderrequests.RequestStatus1);
                    command.Parameters.AddWithValue("@Ride", ditchriderrequests.Ride);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /* Add Customer Call Request for Water Off as AddREquest_Off(ditchriderrequests)
         * SQL: sp_DitchRider_AddREquestsOff
         * GIVE: RequestID, TimeStampCustomer2, CustomerDate2, CustomerComments2, CusotmerCFS2, RequestStatus2, Staff2, Lateral
         * View: _AddREquestOff
         */
        public virtual void AddRequest_Off(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_AddRequestsOff";

                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@TimeStampCustomer2", ditchriderrequests.TimeStampCustomer2);
                    command.Parameters.AddWithValue("@CustomerDate2", ditchriderrequests.CustomerDate2);
                    command.Parameters.AddWithValue("@CustomerCFS2", ditchriderrequests.CustomerCFS2);
                    command.Parameters.AddWithValue("@CustomerComments2", ditchriderrequests.CustomerComments2);
                    command.Parameters.AddWithValue("@RequestStatus2", ditchriderrequests.RequestStatus2);
                    command.Parameters.AddWithValue("@Staff2", ditchriderrequests.Staff2);
                    command.Parameters.AddWithValue("@Lateral", ditchriderrequests.Lateral);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /* Edit Water Request On as EditRequestOn(ditchriderrequests)
         * SQL: sp_DitchRider_EditRequestsOn
         * GIVE: RequestID, TimeStampStaff1, Staff1, StaffDate1, RequestStatus1, StaffCFS1, StaffComments1
         * View: EditRequestsOn, EditWaitListOn
         */
        public virtual void EditRequestOn(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_EditRequestsOn";

                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@TimeStampStaff1", ditchriderrequests.TimeStampCustomer1);
                    command.Parameters.AddWithValue("@Staff1", ditchriderrequests.Staff1);
                    command.Parameters.AddWithValue("@StaffDate1", ditchriderrequests.StaffDate1);
                    command.Parameters.AddWithValue("@RequestStatus1", ditchriderrequests.RequestStatus1);
                    command.Parameters.AddWithValue("@StaffCFS1", ditchriderrequests.StaffCFS1);
                    command.Parameters.AddWithValue("@StaffComments1", ditchriderrequests.StaffComments1);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /* Edit Water Request Off as EditRequestOff(ditchriderrequests)
         * SQL: sp_DitchRider_EditRequestsOff
         * GIVE: RequestID, TimeStampStaff2, Staff2, StaffDate2, RequestStatus2, StaffCFS2, StaffComments2
         * View: EditRequestsOff, EditWaitListOff
         */
        public virtual void EditRequestOff(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_EditRequestsOff";

                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@TimeStampStaff2", ditchriderrequests.TimeStampCustomer2);
                    command.Parameters.AddWithValue("@Staff2", ditchriderrequests.Staff2);
                    command.Parameters.AddWithValue("@StaffDate2", ditchriderrequests.StaffDate2);
                    command.Parameters.AddWithValue("@RequestStatus2", ditchriderrequests.RequestStatus2);
                    command.Parameters.AddWithValue("@StaffCFS2", ditchriderrequests.StaffCFS2);
                    command.Parameters.AddWithValue("@StaffComments2", ditchriderrequests.StaffComments2);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /* Change Customer Water on Request Status as EditRequestStatus1_On(ditchriderrequests)
         * SQL: sp_DitchRider_EditRequestStatus1_On
         * GIVE: RequestID, TimeStampStaff1, Staff1, RequestStatus1, StaffComments1
         * View: EditRequestStatus_On
         */
        public virtual void EditRequestStatus1_On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_EditRequestStatus1_On";

                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@TimeStampStaff1", ditchriderrequests.TimeStampCustomer1);
                    command.Parameters.AddWithValue("@Staff1", ditchriderrequests.Staff1);
                    command.Parameters.AddWithValue("@RequestStatus1", ditchriderrequests.RequestStatus1);
                    command.Parameters.AddWithValue("@StaffComments1", ditchriderrequests.StaffComments1);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /* Change Customer Water off Request Status as EditRequestStatus2_Off(ditchriderrequests)
         * SQL: sp_DitchRider_EditRequestStatus2_Off
         * GIVE: RequestID, TimeStampStaff2, Staff2, RequestStatus2, StaffComments2
         * View: EditRequestStatus_Off 
         */
        public virtual void EditRequestStatus2_Off(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_EditRequestStatus2_Off";

                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@TimeStampStaff2", ditchriderrequests.TimeStampCustomer2);
                    command.Parameters.AddWithValue("@Staff2", ditchriderrequests.Staff2);
                    command.Parameters.AddWithValue("@RequestStatus2", ditchriderrequests.RequestStatus2);
                    command.Parameters.AddWithValue("@StaffComments2", ditchriderrequests.StaffComments2);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /*  Give a Violation as Violations(ditchriderrequests)
         * SQL: sp_DitchRider_Violations
         * GIVE: Violation, CustomerID, CustomerName, Structure, Lateral, Ride, StaffComments, TImeStampStaff, Staff
         * View: Violations 
         */
        public virtual void Violations(DitchRiderRequests ditchriderrequests)
        {
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_Violations";

                    command.Parameters.AddWithValue("@Violation", ditchriderrequests.Violation);
                    command.Parameters.AddWithValue("@CustomerID", ditchriderrequests.CustomerID);
                    command.Parameters.AddWithValue("@CustomerName", ditchriderrequests.CustomerName);
                    command.Parameters.AddWithValue("@Structure", ditchriderrequests.Structure);
                    command.Parameters.AddWithValue("@Lateral", ditchriderrequests.Lateral);
                    command.Parameters.AddWithValue("@Ride", ditchriderrequests.Ride);
                    command.Parameters.AddWithValue("@StaffComments", ditchriderrequests.StaffComments1);
                    command.Parameters.AddWithValue("@TimeStampStaff", ditchriderrequests.TimeStampStaff1);
                    command.Parameters.AddWithValue("@Staff", ditchriderrequests.Staff1);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /* Edit a Request with restrictions to same date and same Staff as EditRHistory_On(ditchriderrequests)
         * SQL: dbo.EditRHistory_On()
         * GIVE: RequestID, CustomerCFS1, CustomerDate1,  CustomerComments1, Staff1, StaffDate1, StaffCFS1, StaffComments1
         * View: EditRHistory_On*/
         public virtual void EditRHistory_On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_EditRHistoryOn";

                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@CustomerCFS1", ditchriderrequests.CustomerCFS1);
                    command.Parameters.AddWithValue("@CustomerComments", ditchriderrequests.CustomerComments1);
                    command.Parameters.AddWithValue("@CustomerDate1", ditchriderrequests.CustomerDate1);
                    command.Parameters.AddWithValue("@Staff1", ditchriderrequests.Staff1);
                    command.Parameters.AddWithValue("@StaffDate1", ditchriderrequests.StaffDate1);
                    command.Parameters.AddWithValue("@StaffCFS1", ditchriderrequests.StaffCFS1);
                    command.Parameters.AddWithValue("@StaffComments1", ditchriderrequests.StaffComments1);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /*-------------------------Stored Procedures With a Return Value---------------------------------------*/
        
        /* CFS in Tomorrow's Canal as WaterCFS_NextDayByCanal(string lateral) returns a float
         * SQL: dbo.WaterCFS_NextDatByCanal
         * GIVE: @Lateral
         * RETRUN: cfs as float
         * Views: CanalWater, _CanalWater
         */
        public float WaterCFS_NextDayByCanal(string lateral)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.WaterCFS_NextDayByCanal";

                    command.Parameters.AddWithValue("@Lateral", lateral);

                    connection.Open();
                    object returnval = command.ExecuteScalar();
                    float cfs;
                    if (returnval != null)
                    {
                        cfs = float.Parse(returnval.ToString());                                               
                    }
                    else
                    {
                        return (cfs = float.Parse(returnval.ToString()));
                    }
                    return (cfs);
                }                           
            }
            //return (-1);
        }
        /* CFS in Todays's Canal as WaterCFS_TodaybyCanal(string lateral) returns a float
         * SQL: dbo.WaterCFS_TodayByCanal
         * GIVE: @Lateral
         * RETRUN: cfs as float
         * Views: CanalWater, _CanalWater
         */
        public float WaterCFS_TodayByCanal(string lateral)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.WaterCFS_TodayByCanal";

                    command.Parameters.AddWithValue("@Lateral", lateral);

                    connection.Open();
                    object returnval = command.ExecuteScalar();
                    float cfs;
                    if (returnval != null)
                    {
                        cfs = float.Parse(returnval.ToString());
                    }
                    else
                    {
                        return (cfs = float.Parse(returnval.ToString()));
                    }
                    return (cfs);
                }
            }
        }
    }
}