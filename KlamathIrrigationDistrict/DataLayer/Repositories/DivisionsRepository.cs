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
    public class DivisionsRepository : IDivisionsRepository
    {
        public Divisions Get(string DivisionID)
        {
            Divisions p = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Divisons";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new Divisions();
                            p.DivisionID = reader["DivisionID"].ToString();
                            p.Rate = decimal.Parse(reader["Rate"].ToString());
                            p.StatusID1 = reader["StatusID1"].ToString();
                            p.StatusID2 = reader["StatusID2"].ToString();
                            p.StatusID3 = reader["StatusID3"].ToString();
                            p.StatusID4 = reader["StatusID4"].ToString();
                            p.StatusID5 = reader["StatusID5"].ToString();
                            p.StatusID6 = reader["StatusID6"].ToString();
                            p.StatusID7 = reader["StatusID7"].ToString();
                            p.StatusID8 = reader["StatusID8"].ToString();
                        }
                    }
                }
            }
            return (p);
        }
        public List<Divisions> ViewDivisions()
        {
            List<Divisions> DivisionList = new List<Divisions>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Divisons";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Divisions Div = new Divisions();
                            Div.DivisionID = reader["DivisionID"].ToString();
                            Div.Rate = decimal.Parse(reader["Rate"].ToString());
                            Div.StatusID1 = reader["StatusID1"].ToString();
                            Div.StatusID2 = reader["StatusID2"].ToString();
                            Div.StatusID3 = reader["StatusID3"].ToString();
                            Div.StatusID4 = reader["StatusID4"].ToString();
                            Div.StatusID5 = reader["StatusID5"].ToString();
                            Div.StatusID6 = reader["StatusID6"].ToString();
                            Div.StatusID7 = reader["StatusID7"].ToString();
                            Div.StatusID8 = reader["StatusID8"].ToString();

                            DivisionList.Add(Div);
                        }
                    }
                }
            }
            return (DivisionList);
        }
        public void Save(Divisions divisions)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_Rate_Update";
                    if(divisions.DivisionID != null)
                    {
                        command.Parameters.AddWithValue("@DivisionsID", divisions.DivisionID);
                    }
                  //command.Parameters.AddWithValue("@DivisionID", divisions.DivisionID);
                    command.Parameters.AddWithValue("@Rate", divisions.Rate);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}