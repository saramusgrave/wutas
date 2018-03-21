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

        /*-------------------------Views ---------------------------------------------------*/

        //Status Drop Down
        //SELECT * FORM RequestStatusList
        //RequestStatusID, RequestStatusName
        //Use for EditRequest4On, EditRequest4Off, EditWaitlist_4On, EditWaitList_4Off, EditRequestStatus_On, EditRequestStatus_Off
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

        //Comments Drop Down
        //SELECT * FROM Comments
        //CommentID, Comment
        //Use for EditRequest4On.cshtml, EditRequest4Off.cshtml, EditWaitlist_4On.cshtml, EditWaitList_4Off.cshtml, EditRequestStatus_On.cshtml, EditRequestStatus_Off.cshtml
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

        /*-------------------------Stored Procedures---------------------------------------*/

        //Get RequestID
        //sp_DitchRider_Get
        //RequestID, TimeStampCustomer1, CustomerDate1, CustomerID, CustomerName, Structure, CustomerCFS1, TimeStampStaff1, Staff1, StaffDate1, RequestStatus1, StaffCFS1, StaffComments1, CustomerDate2, CustomerCFS2, TimeStampStaff2, Staff2, StaffDate2, RequestStatus2, StaffCFS2, StaffComments2
        //Use in ViewRequests4.cshtml
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
        
        /*-------------------------Views ---------------------------------------------------*/

        //View Customers on Ride 4
        //SELECT * FROM [Ride Customer List TotalAllotment] WHERE Ride = '4' ORDER BY Lateral ASC
        //StructureID, Lateral, Ride, CustomerMTLHisID, Name, CustomerID, TotalAllotment
        //Use for Customers4.cshtml, AddRequest4On.cshtml 
        public List<DitchRiderRequests> Customers(int id)
        {
            List<DitchRiderRequests> CustomerList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [CustomerCurrentAllotment] WHERE RidesListID = @RideNum ORDER BY Lateral ASC";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests c = new DitchRiderRequests();

                            c.Structure = reader["StructureID"].ToString();
                            c.Lateral = reader["Lateral"].ToString();
                            c.Ride = int.Parse(reader["RidesListID"].ToString());
                            //c.CustomerMTLHisID = int.Parse(reader["CustomerMTLHisID"].ToString());
                            c.CustomerName = reader["Name"].ToString();
                            c.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            c.TotalAllotment = float.Parse(reader["TotalAllotment"].ToString());
                            c.CurrentAllotment = float.Parse(reader["CurrentAllotment"].ToString());

                            CustomerList.Add(c);
                        }
                    }
                }
            }
            return (CustomerList);
        }

        //View Customers with water On
        //SELECT * FROM [Customers With Water On] WHERE Ride = @RideNum ORDER BY Lateral
        //RequestID, CustomerID, CustomerName, Structure, Lateral, TotalAllotment, Ride, StaffCFS1, StaffDate1
        //Use for Customers_4On.cshtml, _AddRequest4Off.cshtml
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
                            c.TotalAllotment = float.Parse(reader["TotalAllotment"].ToString());
                            c.Ride = int.Parse(reader["Ride"].ToString());
                            c.StaffCFS1 = int.Parse(reader["StaffCFS1"].ToString());
                            c.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());

                            CustomerList.Add(c);
                        }
                    }
                }
            }
            return (CustomerList);
        }
        
        //View Customer History
        //SELECT * FROM [Customer History] WHERE Ride = @RideNum AND CustomerID = @CustomerID
        //CustomerID, 
        //Used for CustomerHistory.cshtml
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
                            p.CustomerCFS1 = int.Parse(reader["CustomerCFS1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.Staff1 = reader["Staff1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.StaffCFS1 = int.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.Staff2 = reader["Staff2"].ToString();
                            p.StaffDate2 = DateTime.Parse(reader["StaffDate2"].ToString());
                            p.StaffCFS2 = int.Parse(reader["StaffCFS2"].ToString());
                            p.StaffComments2 = reader["StaffComments2"].ToString();
                            p.Ride = int.Parse(reader["Ride"].ToString());

                            HistoryList.Add(p);                         
                        }
                    }
                    
                }
            }
            return (HistoryList);
        }

        //View Customer Recent History
        public List<DitchRiderRequests> ViewCustomersRecentHistory(int id)
        {
            List<DitchRiderRequests> HistoryList = new List<DitchRiderRequests>();
            using (SqlConnection conneciton = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = conneciton;

                    command.CommandText = "SELECT * FROM [Customer Recent History] WHERE Ride = @RideNum ORDER BY StaffDate1 ASC";
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
                            p.CustomerCFS1 = int.Parse(reader["CustomerCFS1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.Staff1 = reader["Staff1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.StaffCFS1 = int.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.Staff2 = reader["Staff2"].ToString();
                            p.StaffDate2 = DateTime.Parse(reader["StaffDate2"].ToString());
                            p.StaffCFS2 = int.Parse(reader["StaffCFS2"].ToString());
                            p.StaffComments2 = reader["StaffComments2"].ToString();
                            p.Ride = int.Parse(reader["Ride"].ToString());

                            HistoryList.Add(p);
                        }
                    }

                }
            }
            return (HistoryList);
        }

        //View Requests for all completed Requests ViewRequests4
        //SELECT * FROM Requests WHERE StaffCFS2 IS NOT NULL AND Structure LIKE '_4%' ORDER BY RequestID ASC
        //RequestID, TimeStampCustomer1, CustomerDate1, CustomerID, CustomerName, Structure, CustomerCFS1, TimeStampStaff1, Staff1, StaffDate1, RequestStatus1, StaffCFS1, StaffComments1, CustomerDate2, CustomerCFS2, TimeStampStaff2, Staff2, StaffDate2, RequestStatus2, StaffCFS2, StaffComments2
        //Use for CompletedRequests.cshtml, 
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
                            p.CustomerCFS1 = int.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments1 = reader["CustomerComments1"].ToString();
                            p.TimeStampStaff1 = DateTime.Parse(reader["TimeStampStaff1"].ToString());
                            p.Staff1 = reader["Staff1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.StaffCFS1 = int.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();
                            p.TimeStampStaff2 = DateTime.Parse(reader["TimeStampStaff2"].ToString());
                            p.Staff2 = reader["Staff2"].ToString();
                            p.StaffDate2 = DateTime.Parse(reader["StaffDate2"].ToString());
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.StaffCFS2 = int.Parse(reader["StaffCFS2"].ToString());
                            p.StaffComments2 = reader["StaffComments2"].ToString();
                            p.Ride = int.Parse(reader["Ride"].ToString());

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }

        //View Active Requests Ride 4 On
        //SELECT * FROM Requests WHERE Structure LIKE '_4%' AND StaffCFS1 IS NULL
        //RequestID, CustomerDate1, CustomerName, Structure, RequestStatus1, CustomerCFS1, CustomerCommetns
        //Use for CompletedRequests.cshtml, _ActiveRequestsOn.cshtml, EditRequests4On(), Index4.cshtml
        //@RideNum% works?
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
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.CustomerCFS1 = int.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments1 = reader["CustomerComments1"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }

        //View Active Requests Ride 4 Off
        //SELECT * FROM Requests WHERE Structure LIKE '_4%' AND StaffCFS2 IS NULL AND CustomerDate2 IS NOT NULL AND RequestStatus2 = 'Confirm'
        //RequestID, CustomerDate2, CustomerName, Structure, RequestStatus2, CustomerCFS2, CustomerComments2
        //Use in _ActiveRequestsOff4.cshtml, EditRequest4Off.cshtml
        //@RideNum% works?
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
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.CustomerCFS2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }

        //View Pending Requests 4 on
        //SELECT * FROM Requests WHERE RequestStatus1 = 'Pending' AND Structure LIKE '_4%'
        //RequestID, CustomerDate1, CustomerName, Structure, RequestStatus1, CustomerCFS1, CustomerCommetns
        //Use for EditRequestStatus_On, Appending_4On.cshtml
        //@RideNum% works?
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
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.CustomerCFS1 = int.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments1 = reader["CustomerComments1"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }

        //View RequestsStatus2 Pending
        //SELECT * FROM Requests WHERE RequestStatus42= 'Pending' AND Structure LIKE '_4%'
        //RequestID, CustomerDate2, CustomerName, Structure, RequestStatus2, CustomerCFS2, CustomerComments2
        //Use in Appending_4Off.cshtml, EditRequestStatus_Off
        //@RideNum% works?
        public List<DitchRiderRequests> ViewPending_Off(int id)
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@RideNum", id);
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE Ride = @RideNum AND RequestStatus2 != 'Confirm' AND RequestStatus2 != 'Wait List' ORDER BY CustomerDate2 ";
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
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.CustomerCFS2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }

        //View Waitlist 4 on
        //SELECT * FROM Requests WHERE RequestStatus1 = 'Wait list' AND Structure LIKE '_4%'
        //RequestID, CustomerDate1, CustomerName, Structure, RequestStatus1, CustomerCFS1, CustomerComments1
        //Use for WaitList_4On.cshtml, EditWaitList_4On.cshtml
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
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.CustomerCFS1 = int.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments1 = reader["CustomerComments1"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }

        //View Waitlist 4 off
        //SELECT * FROM Requests WHERE RequestStatus2 = 'Wait list' AND Structure LIKE '_4%'
        //RequestID, CustomerDate2, CustomerName, Structure, RequestStatus2, CustomerCFS2, CustomerComments2
        //Use in WaitList_4Off.cshtml, EditWaitList_4Off.cshtml
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
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.CustomerCFS2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();

                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }


        /*-------------------------Stored Procedures---------------------------------------*/

        //Add Request as if Customer On For Ride 4
        //sp_DitchRider_AddRequests4On
        //RequestID, TimeStampCustomer1, CustomerDate1, CustomerID, CustomerName, Structure, CustomerCFS1, CustomerCommetns1
        //Use in AddRequest4On.cshtml
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
                    command.Parameters.AddWithValue("@CustomerCFS1", ditchriderrequests.CustomerCFS1);
                    command.Parameters.AddWithValue("@CustomerComments1", ditchriderrequests.CustomerComments1);
                    command.Parameters.AddWithValue("@RequestStatus1", ditchriderrequests.RequestStatus1);
                    command.Parameters.AddWithValue("@Ride", ditchriderrequests.Ride);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //Add Request as if Customer Off For Ride 4
        //sp_DitchRider_AddRequests4Off
        //RequestID, TimeStampCustomer2, CustomerDate2, CustomerCFS2, CustomerComments2
        //Use in _AddRequest4Off.cshtml
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

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //Turn Water On 
        //sp_DitchRider_EditRequests4On
        //RequestID, TimeStampStaff1, Staff1, StaffDate1, RequestStatus1, StaffCFS1, StaffComments1
        //Use in EditRequests4On.cshtml, EditWaitList_4On.cshtml
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

        //Turn Water Off
        //sp_DitchRider_EditRequests4Off
        //RequestID, TimeStampStaff2, Staff2, StaffDate2, RequestStatus2, StaffCFS2, StaffComments2
        //Use in EditRequest4Off.cshtml, EditWaitList_4Off.cshtml
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

        //Edit RequestStatus1_On
        //sp_DitchRider_EditRequestStatus1_On
        //RequestID, TimeStampStaff1, Staff2, RequestStatus1, StaffComments1
        //Use in EditRequestStatus_On.csthml
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

        //Edit RequestStatus2_Off
        //sp_DitchRider_EditRequestStatus2_Off
        //RequestID, TimeStampStaff2, Staff2, RequestStatus2, StaffComments2
        //Use in EditRequestStatus_Off.cshtml
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

        //Display Tomorrow's CFS in Canal
        //dbo.WaterCFS_NextDayByCanal
        //@Lateral
        //Use in ...
        //public int WaterCFS_NextDayByCanal(DitchRiderRequests lateral)
        public int WaterCFS_NextDayByCanal(string lateral)
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
                    int cfs;
                    if (returnval != null)
                    {
                        cfs = int.Parse(returnval.ToString());                                               
                    }
                    else
                    {
                        return (cfs = int.Parse(returnval.ToString()));
                    }
                    return (cfs);
                }                           
            }
            //return (-1);
        }
        public int WaterCFS_TodayByCanal(string lateral)
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
                    int cfs;
                    if (returnval != null)
                    {
                        cfs = int.Parse(returnval.ToString());
                    }
                    else
                    {
                        return (cfs = int.Parse(returnval.ToString()));
                    }
                    return (cfs);
                }
            }
            //return (cfs);
        }
    }
}