﻿using KlamathIrrigationDistrict.DataLayer.DataModels;
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
        //Get request id
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
        /*Ride 4*/
        //View Customers on Ride 4
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
    //View Request for all completed request ViewRequests4
    public List<DitchRiderRequests> ViewRequests4()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE Structure LIKE '_4%' ORDER BY CustomerDate1 ";
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
        //View Active Requests on for Ride 4
        public List<DitchRiderRequests> ViewActiveRequestOn4()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT CustomerDate1, CustomerName, Structure, CustomerCFS1, CustomerComments1 FROM Requests WHERE Structure LIKE '_4%' AND StaffCFS1 IS NULL";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerCFS1 = int.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments1 = reader["CustomerComments1"].ToString();
                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }
        //View Active Requests off for Ride 4
        public List<DitchRiderRequests> ViewActiveRequestOff4()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT CustomerDate2, CustomerName, Structure, CustomerCFS2, CustomerComments2 FROM Requests WHERE Structure LIKE '_4%' AND StaffCFS2 IS NULL";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerCFS2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments2 = reader["CustomerComments2"].ToString();
                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }


        //Ditch rider4 add request as if customer on
        public virtual void AddRequest4On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_AddRequests4On";

                    
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
        //Ditch rider4 add request as if customer off
        public virtual void AddRequest4Off(DitchRiderRequests ditchriderrequests)
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
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //Edit a Requests as Ditch Rider 4 On
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
        //Edit a Requests as ditch Rider off 4
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
                            r.RequestStatusName = reader["ResquestStatusName"].ToString();
                            list.Add(r);
                        }
                    }
                }
            }
            return (list);
        }
        public  List<SelectListItem> RequestStatus_2()
        {
            List<SelectListItem> status = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["KID"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT RequestStatusName, RequestSatusID FROM RequestStatusList";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            status.Add(new SelectListItem { Text = sdr["RequestStatusName"].ToString(), Value = sdr["RequestStatusID"].ToString()});
                        }
                    }
                    con.Close();
                }
            }
            return status;
                //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
                //{
                //    using (SqlCommand command = new SqlCommand())
                //    {
                //        command.Connection = connection;
                //        command.CommandText = "SELECT * FROM RequestStatusList";
                //        command.CommandType = CommandType.Text;
                //        connection.Open();
                //        using (SqlDataReader reader = command.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                status.Add(new SelectListItem
                //                {
                //                    Text = reader["ResquestStatusName"].ToString(),
                //                    Value = reader["RequestStatusID"].ToString()
                //                });
                //            }
                //        }
                //    }
                //}
                //return status;
        }








        /*Ride 5*/
        //View Request List5
        public List<DitchRiderRequests> ViewRequests5()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE CustomerID = '760' ORDER BY CustomerDate1 ";
                    //command.CommandText = "SELECT CustomerID, CustomerName, Structure, CustomerDate, CFSRequested, CustomerComments, DitchRiderComments FROM Requests";
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