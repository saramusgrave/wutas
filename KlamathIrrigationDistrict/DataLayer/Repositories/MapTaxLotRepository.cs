using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KlamathIrrigationDistrict.DataLayer.Repositories
{
    public class MapTaxLotRepository : IMapTaxLotRepository 
    {
        public virtual MapTaxLots Get(string MapTaxLot)
        {
            MapTaxLots s = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_Map_Get";
                    command.Parameters.AddWithValue("@MapTaxLot", MapTaxLot);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            s = new MapTaxLots();
                            s.MapTaxLot = reader["MapTaxLot"].ToString();
                            s.DivisionID = reader["DivisionID"].ToString();
                            s.TrackingID = int.Parse(reader["TrackingID"].ToString());
                            s.Structure = reader["Structure"].ToString();
                            s.LongName = reader["LongName"].ToString();
                            s.Ride = int.Parse(reader["Ride"].ToString());
                            s.Status = reader["Statust"].ToString();
                            s.Acers = decimal.Parse(reader["Acers"].ToString());
                            s.Rate = decimal.Parse(reader["Rate"].ToString());
                            s.Allotment = decimal.Parse(reader["Allotment"].ToString());
                            s.Name = reader["Name"].ToString();
                        }
                    }
                }
            }
            return (s);
        }
        public virtual List<MapTaxLots> ViewTaxLot()
        {
            List<MapTaxLots> TaxLotList = new List<MapTaxLots>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM MapTaxLot ORDER BY Name ASC";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MapTaxLots r = new MapTaxLots();
                            r.MapTaxLot = reader["MapTaxLot"].ToString();
                            r.DivisionID = reader["DivisionID"].ToString();
                            r.TrackingID = int.Parse(reader["TrackingID"].ToString());
                            r.Structure = reader["Structure"].ToString();
                            r.LongName = reader["LongName"].ToString();
                            //won't work some odd reason don't show in depoloyment
                           // r.Ride = int.Parse(reader["Ride"].ToString());
                            r.Status = reader["Status"].ToString();
                            r.Acers = decimal.Parse(reader["Acers"].ToString());
                            r.Rate = decimal.Parse(reader["Rate"].ToString());
                            r.Allotment = decimal.Parse(reader["Allotment"].ToString());
                            r.Name = reader["Name"].ToString();
                            TaxLotList.Add(r);
                        }
                    }
                }
            }
            return (TaxLotList);
        }
        public virtual void Save(MapTaxLots maptaxlots)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_map_InsertUpdate";
                    if(maptaxlots.MapTaxLot != null)
                    {
                        command.Parameters.AddWithValue("@MapTaxLot", maptaxlots.MapTaxLot);
                    }
                    command.Parameters.AddWithValue("@DivisionID", maptaxlots.DivisionID);
                    command.Parameters.AddWithValue("@TrackingID", maptaxlots.TrackingID);
                    command.Parameters.AddWithValue("@Structure", maptaxlots.Structure);
                    command.Parameters.AddWithValue("@LongName", maptaxlots.LongName);
                    command.Parameters.AddWithValue("@Ride", maptaxlots.Ride);
                    command.Parameters.AddWithValue("@Status", maptaxlots.Status);
                    command.Parameters.AddWithValue("@Acers", maptaxlots.Acers);
                    command.Parameters.AddWithValue("@Rate", maptaxlots.Rate);
                    command.Parameters.AddWithValue("@Allotment", maptaxlots.Allotment);
                    command.Parameters.AddWithValue("@Name", maptaxlots.Name);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}