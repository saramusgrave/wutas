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
                            p.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            p.TrackingID = int.Parse(reader["TrackingID"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Allotment = decimal.Parse(reader["Allotment"].ToString());
                            p.MapTaxLot = reader["MapTaxLot"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerDate = DateTime.Parse(reader["CustomerDate"].ToString());
                            p.CFSRequested = int.Parse(reader["CFSRequested"].ToString());
                            p.CustomerComments = reader["CustomerComments"].ToString();
                            p.DitchRiderDate = DateTime.Parse(reader["DitchRiderDate"].ToString());
                            p.CFSGiven = int.Parse(reader["CFSGiven"].ToString());
                            p.DitchRiderComments = reader["DitchRiderComments"].ToString();
                        }
                    }
                }
            }
            return (p);
        }

        //View Request List
        public List<DitchRiderRequests> ViewRequests()
        {
            List<DitchRiderRequests> RequestList = new List<DitchRiderRequests>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Requests";
                    //command.CommandText = "SELECT CustomerID, CustomerName, Structure, CustomerDate, CFSRequested, CustomerComments, DitchRiderComments FROM Requests";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            DitchRiderRequests p = new DitchRiderRequests();
                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            p.TrackingID = int.Parse(reader["TrackingID"].ToString());
                            p.CustomerName = reader["CustomerName"].ToString();
                            p.Allotment = decimal.Parse(reader["Allotment"].ToString());
                            p.MapTaxLot = reader["MapTaxLot"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerDate = DateTime.Parse(reader["CustomerDate"].ToString());
                            p.CFSRequested = int.Parse(reader["CFSRequested"].ToString());
                            p.CustomerComments = reader["CustomerComments"].ToString();
                            p.DitchRiderDate = DateTime.Parse(reader["DitchRiderDate"].ToString());
                            p.CFSGiven = int.Parse(reader["CFSGiven"].ToString());
                            p.DitchRiderComments = reader["DitchRiderComments"].ToString();
                            RequestList.Add(p);
                        }
                    }
                }
            }
            return (RequestList);
        }
        //Ditch rider add request as if customer
        public virtual void AddRequest(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRider_AddRequests";

                    command.Parameters.AddWithValue("@CustomerID", ditchriderrequests.CustomerID);
                    command.Parameters.AddWithValue("@TrackingID", ditchriderrequests.TrackingID);
                    command.Parameters.AddWithValue("@CustomerName", ditchriderrequests.CustomerName);
                    command.Parameters.AddWithValue("@Allotment", ditchriderrequests.Allotment);
                    command.Parameters.AddWithValue("@MapTaxLot", ditchriderrequests.MapTaxLot);
                    command.Parameters.AddWithValue("@Structure", ditchriderrequests.Structure);
                    command.Parameters.AddWithValue("@Customerdate", ditchriderrequests.CustomerDate);
                    command.Parameters.AddWithValue("@CFSRequeted", ditchriderrequests.CFSRequested);
                    command.Parameters.AddWithValue("@CustomerComments", ditchriderrequests.CustomerComments);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //Edit a Requests as ditch Rider
        public virtual void EditRequest(DitchRiderRequests ditchriderrequests)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DitchRiderEditRequests";

                    command.Parameters.AddWithValue("@RequestID", ditchriderrequests.RequestID);
                    command.Parameters.AddWithValue("@DitchRiderDate", ditchriderrequests.DitchRiderDate);
                    command.Parameters.AddWithValue("@CFSGiven", ditchriderrequests.CFSGiven);
                    command.Parameters.AddWithValue("@DitchRiderComments", ditchriderrequests.DitchRiderComments);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}