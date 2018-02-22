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
    public class DitchRidersRepository :IDitchRidersRepository
    {
        //Get request id
        public DitchRiderRequests Get(int ID)
        {
            DitchRiderRequests p = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FORM Requests";
                    command.CommandType = CommandType.Text;

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
                            p.KIDStaffID1 = int.Parse(reader["KIDStaffID1"].ToString());
                            p.StaffName1 = reader["StaffName1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.StaffCFS1 = int.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.TimeStampStaff2 = DateTime.Parse(reader["TimeStampStaff2"].ToString());
                            p.KIDStaffID2 = int.Parse(reader["KIDStaffID2"].ToString());
                            p.StaffName2 = reader["StaffName2"].ToString();
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

        //View Request List4
        public List<DitchRiderRequests> ViewRequests4()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests WHERE CustomerID = '3681' ORDER BY CustomerDate1 ";
                    //command.CommandText = "SELECT CustomerID, CustomerName, Structure, CustomerDate, CFSRequested, CustomerComments, DitchRiderComments FROM Requests";
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
                            p.KIDStaffID1 = int.Parse(reader["KIDStaffID1"].ToString());
                            p.StaffName1 = reader["StaffName1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.StaffCFS1 = int.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.TimeStampStaff2 = DateTime.Parse(reader["TimeStampStaff2"].ToString());
                            p.KIDStaffID2 = int.Parse(reader["KIDStaffID2"].ToString());
                            p.StaffName2 = reader["StaffName2"].ToString();
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
        //View Request List5
        public List<DitchRiderRequests> ViewRequests5()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
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
                            p.KIDStaffID1 = int.Parse(reader["KIDStaffID1"].ToString());
                            p.StaffName1 = reader["StaffName1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.StaffCFS1 = int.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.TimeStampStaff2 = DateTime.Parse(reader["TimeStampStaff2"].ToString());
                            p.KIDStaffID2 = int.Parse(reader["KIDStaffID2"].ToString());
                            p.StaffName2 = reader["StaffName2"].ToString();
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
        //Ditch rider4 add request as if customer on
        public virtual void AddRequest4On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_AddRequests4";

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
        //Ditch rider5 add request as if customer on
        public virtual void AddRequest5On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_AddRequests5";

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
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_Add_Requests4";

                    command.Parameters.AddWithValue("@TimeStampCustomer2", ditchriderrequests.TimeStampCustomer2);
                    command.Parameters.AddWithValue("@CustomerDate2", ditchriderrequests.CustomerDate2);
                    command.Parameters.AddWithValue("@CustomerCFS2", ditchriderrequests.CustomerCFS2);
                    command.Parameters.AddWithValue("@CustomerComments2", ditchriderrequests.CustomerComments2);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //Edit a Requests as ditch Rider on 4
        public virtual void EditRequest4On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRiderEditRequests4";

                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@TimeStampStaff1", ditchriderrequests.TimeStampCustomer1);
                    command.Parameters.AddWithValue("@KIDStaffID1", ditchriderrequests.KIDStaffID1);
                    command.Parameters.AddWithValue("@StaffName1", ditchriderrequests.StaffName1);
                    command.Parameters.AddWithValue("@StaffDate1", ditchriderrequests.StaffDate1);
                    command.Parameters.AddWithValue("@RequestStatus1", ditchriderrequests.RequestStatus1);
                    command.Parameters.AddWithValue("@StaffCFS1", ditchriderrequests.StaffCFS1);
                    command.Parameters.AddWithValue("@StaffComments1", ditchriderrequests.StaffComments1);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //Edit a Requests as ditch Rider 5 on
        public virtual void EditRequest5On(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRiderEditRequests5";
                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@TimeStampStaff1", ditchriderrequests.TimeStampCustomer1);
                    command.Parameters.AddWithValue("@KIDStaffID1", ditchriderrequests.KIDStaffID1);
                    command.Parameters.AddWithValue("@StaffName1", ditchriderrequests.StaffName1);
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
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_EditRequests4";
                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@TimeStampStaff2", ditchriderrequests.TimeStampCustomer2);
                    command.Parameters.AddWithValue("@KIDStaffID2", ditchriderrequests.KIDStaffID2);
                    command.Parameters.AddWithValue("@StaffName2", ditchriderrequests.StaffName2);
                    command.Parameters.AddWithValue("@StaffDate2", ditchriderrequests.StaffDate2);
                    command.Parameters.AddWithValue("@RequestStatus2", ditchriderrequests.RequestStatus2);
                    command.Parameters.AddWithValue("@StaffCFS2", ditchriderrequests.StaffCFS2);
                    command.Parameters.AddWithValue("@StaffComments2", ditchriderrequests.StaffComments2);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //Edit a Requests as ditch Rider off 5
        public virtual void EditRequest5Off(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_EditRequests5";
                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@TimeStampStaff2", ditchriderrequests.TimeStampCustomer2);
                    command.Parameters.AddWithValue("@KIDStaffID2", ditchriderrequests.KIDStaffID2);
                    command.Parameters.AddWithValue("@StaffName2", ditchriderrequests.StaffName2);
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