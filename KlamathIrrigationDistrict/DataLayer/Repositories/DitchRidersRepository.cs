using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.DataLayer.Repositories
{
    public class DitchRidersRepository :IDitchRidersRepository
    {
        //Get request ID
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
        /*-----------------------------------------------------------------------------------
         --------------RIDE 4--------------------------------------------------------------*/
        
        //View Customers on Ride 4
        //SELECT * FROM [Ride Customer List TotalAllotment] WHERE Ride = '4' ORDER BY Lateral ASC
            //StructureID, Lateral, Ride, CustomerMTLHisID, Name, CustomerID, TotalAllotment
        //Use for Customers4.cshtml
        public List<DitchRiderCustomers> Customers4()
        {
            List<DitchRiderCustomers> CustomerList = new List<DitchRiderCustomers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [Ride Customer List TotalAllotment] WHERE Ride = '4' ORDER BY Lateral ASC";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderCustomers c = new DitchRiderCustomers();
                            c.StructureID = reader["StructureID"].ToString();
                            c.Lateral = reader["Lateral"].ToString();
                            c.Ride = int.Parse(reader["Ride"].ToString());
                            c.CustomerMTLHisID = int.Parse(reader["CustomerMTLHisID"].ToString());
                            c.Name = reader["Name"].ToString();
                            c.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            c.TotalAllotment = float.Parse(reader["TotalAllotment"].ToString());
                            CustomerList.Add(c);
                        }
                    }
                }
            }
        return (CustomerList);
    }

        //View Requests for all completed Requests ViewRequests4
        //SELECT * FROM Requests WHERE StaffCFS2 IS NOT NULL AND Structure LIKE '_4%' ORDER BY RequestID ASC
            //RequestID, TimeStampCustomer1, CustomerDate1, CustomerID, CustomerName, Structure, CustomerCFS1, TimeStampStaff1, Staff1, StaffDate1, REquestStatus1, StaffCFS1, StaffComments1, CustomerDate2, CustomerCFS2, TimeStampStaff2, Staff2, StaffDate2, RequestStatus2, StaffCFS2, StaffComments2
        //Use for CompletedREquests.cshtml
        public List<DitchRiderRequests> ViewRequests4()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE StaffCFS2 IS NOT NULL AND Structure LIKE '_4%' ORDER BY RequestID ASC";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
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
                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }

        //View Active Requests Ride 4 On
        //SELECT * FROM Requests WHERE Structure LIKE '_4%' AND StaffCFS1 IS NULL
            //RequestID, CustomerDate1, Structure, RequestStatus1, CustomerCFS1, CustomerCommetns
        //Use for _ActiveRequestsOn4.cshtml
        public List<DitchRiderRequests> ViewActiveRequestOn4()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE Structure LIKE '_4%' AND StaffCFS1 IS NULL ";
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
        //SELECT * FROM Requests WHERE Structure LIKE '_4%'
            //RequestID, CustomerDate2, CustomerName, REquestStatus2, Structure, CustomerCFS2, CustomerComments2
        //Use in _ActiveRequestsOff4.cshtml
        public List<DitchRiderRequests> ViewActiveRequestOff4()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE Structure LIKE '_4%' AND StaffCFS2 IS NULL AND CustomerDate2 IS NOT NULL";
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
        //RequestID, CustomerDate1, Structure, RequestStatus1, CustomerCFS1, CustomerCommetns
        //Use for _ActiveRequestsOn4.cshtml
        public List<DitchRiderRequests> ViewPending_4On()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE RequestStatus1 = 'Pending' AND Structure LIKE '_4%'";
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
        //RequestID, CustomerDate2, CustomerName, REquestStatus2, Structure, CustomerCFS2, CustomerComments2
        //Use in _ActiveRequestsOff4.cshtml
        public List<DitchRiderRequests> ViewPending_4Off()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE RequestStatus2 = 'Pending' AND Structure LIKE '_4%'";
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
        //SELECT * FROM Requests WHERE RequestStatus1 = 'Pending' AND Structure LIKE '_4%'
        //RequestID, CustomerDate1, Structure, RequestStatus1, CustomerCFS1, CustomerCommetns
        //Use for _ActiveRequestsOn4.cshtml
        public List<DitchRiderRequests> ViewWaitlist_4On()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE RequestStatus1 = 'Wait list' AND Structure LIKE '_4%'";
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
        //SELECT * FROM Requests WHERE RequestStatus42= 'Pending' AND Structure LIKE '_4%'
        //RequestID, CustomerDate2, CustomerName, REquestStatus2, Structure, CustomerCFS2, CustomerComments2
        //Use in _ActiveRequestsOff4.cshtml
        public List<DitchRiderRequests> ViewWaitlist_4Off()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE RequestStatus2 = 'Wait list' AND Structure LIKE '_4%'";
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







        //Add Request as if Customer On For Ride 4
        //sp_DitchRider_AddRequests4On
        //RequestID, TimeStampCustomer1, CustomerDate1, CustomerID, CustomerName, Structure, CustomerCFS1, CustomerCommetns1
        //Use in AddRequest4On.cshtml
        public virtual void AddRequest_4On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_AddRequests4On";

                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@TimeStampCustomer1", ditchriderrequests.TimeStampCustomer1);
                    command.Parameters.AddWithValue("@CustomerDate1", ditchriderrequests.CustomerDate1);
                    command.Parameters.AddWithValue("@CustomerID", ditchriderrequests.CustomerID);
                    command.Parameters.AddWithValue("@CustomerName", ditchriderrequests.CustomerName);
                    command.Parameters.AddWithValue("@Structure", ditchriderrequests.Structure);
                    command.Parameters.AddWithValue("@CustomerCFS1", ditchriderrequests.CustomerCFS1);
                    command.Parameters.AddWithValue("@CustomerComments1", ditchriderrequests.CustomerComments1);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //Add Request as if Customer Off For Ride 4
        //sp_DitchRider_AddRequests4Off
            //TimeStampCustomer2, CustomerDate2, CustoemrCFS2, CustomerCommetns2, RequestID
        //Use in _AddRequest4Off.cshtml
        public virtual void AddRequest_4Off(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_AddRequests4Off";

                    command.Parameters.AddWithValue("@TimeStampCustomer2", ditchriderrequests.TimeStampCustomer2);
                    command.Parameters.AddWithValue("@CustomerDate2", ditchriderrequests.CustomerDate2);
                    command.Parameters.AddWithValue("@CustomerCFS2", ditchriderrequests.CustomerCFS2);
                    command.Parameters.AddWithValue("@CustomerComments2", ditchriderrequests.CustomerComments2);

                    //added
                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@CustomerID", ditchriderrequests.CustomerID);
                    command.Parameters.AddWithValue("@Structure", ditchriderrequests.Structure);
                    command.Parameters.AddWithValue("@CustomerName", ditchriderrequests.CustomerName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //Turn Water On 
        //sp_DitchRider_EditRequests4On
            //RequestID, TimeStampStaff1, Staff1, StaffDate1, RequestStatus1, StaffCFS1, StaffComments1
        //Use in EditRequests4On.cshtml
        public virtual void EditRequest4On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_EditRequests4On";

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
        //Use in EditRequests4Off.cshtml
        public virtual void EditRequest4Off(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_EditRequests4Off";
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
        //RequestID, RequestStatus1, TimeStampStaff1, StaffComments1
        //Use in Appending/Waitlist Page
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
        //Use in Appending/Waitlist page
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
        //Store procedure to view how much is in a canal.
        public void  WaterCFS_NextDayByCanal(DitchRiderCustomers lateral)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.WaterCFS_NextDayByCanal";
                  
                    command.Parameters.AddWithValue("@Lateral", lateral.Lateral);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        







        //Use when getting Status in drop down 
        public List<DitchRiderRequestStatus> Status()
        {
            List<DitchRiderRequestStatus> list = new List<DitchRiderRequestStatus>();
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
                            DitchRiderRequestStatus r = new DitchRiderRequestStatus();
                            r.RequestStatusID = int.Parse(reader["RequestStatusID"].ToString());
                            r.RequestStatusName = reader["RequestStatusName"].ToString();
                            list.Add(r);
                        }
                    }
                }
            }
            return (list);
        }
        //Use when getting Ditch Rider Comments in drop down 
        public List<DitchRiderComments> Comments()
        {
            List<DitchRiderComments> list = new List<DitchRiderComments>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Comments";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderComments r = new DitchRiderComments();
                            r.CommentID = int.Parse(reader["CommentID"].ToString());
                            r.Comment = reader["Comment"].ToString();
                            list.Add(r);
                        }
                    }
                }
            }
            return (list);
        }






        /*------------------------------------------------------------------------------------
         * ------------------RIDE 5---------------------------------------------------------*/

        //View Requests for all completed Requests ViewRequests4
        //SELECT * FROM Requests WHERE StaffCFS2 IS NOT NULL AND Structure LIKE '_5%' ORDER BY RequestID ASC
        //RequestID, TimeStampCustomer1, CustomerDate1, CustomerID, CustomerName, Structure, CustomerCFS1, TimeStampStaff1, Staff1, StaffDate1, REquestStatus1, StaffCFS1, StaffComments1, CustomerDate2, CustomerCFS2, TimeStampStaff2, Staff2, StaffDate2, RequestStatus2, StaffCFS2, StaffComments2
        //Use for CompletedRequests5.cshtml
        public List<DitchRiderRequests> ViewRequests5()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE StaffCFS2 IS NOT NULL AND Structure LIKE '_5%' ORDER BY RequestID ASC";
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
                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }

        //Ditch rider4 add request as if customer off
        public virtual void AddRequest5Off(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_AddRequests5On";

                    command.Parameters.AddWithValue("@TimeStampCustomer2", ditchriderrequests.TimeStampCustomer2);
                    command.Parameters.AddWithValue("@CustomerDate2", ditchriderrequests.CustomerDate2);
                    command.Parameters.AddWithValue("@CustomerCFS2", ditchriderrequests.CustomerCFS2);
                    command.Parameters.AddWithValue("@CustomerComments2", ditchriderrequests.CustomerComments2);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //Ditch rider5 add request as if customer on
        public virtual void AddRequest5On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_AddRequests5On";

                    command.Parameters.AddWithValue("@TimeStampCustomer1", ditchriderrequests.TimeStampCustomer1);
                    command.Parameters.AddWithValue("@CustomerDate1", ditchriderrequests.CustomerDate1);
                    command.Parameters.AddWithValue("@CustomerID", ditchriderrequests.CustomerID);
                    command.Parameters.AddWithValue("@CustomerName", ditchriderrequests.CustomerName);
                    command.Parameters.AddWithValue("@Structure", ditchriderrequests.Structure);
                    command.Parameters.AddWithValue("@CustomerCFS1", ditchriderrequests.CustomerCFS1);
                    command.Parameters.AddWithValue("@CustomerComments1", ditchriderrequests.CustomerComments1);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
       
        //Edit a Requests as ditch Rider 5 on
        public virtual void EditRequest5On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_EditRequests5On";
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
       
        //Edit a Requests as ditch Rider off 5
        public virtual void EditRequest5Off(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_EditRequests5Off";
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
    }
}