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
    public class PositionsRepository : IPositionsRepository
    {
        public List<Positions> PositionsList()
        {
            List<Positions> PositionsList = new List<Positions>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KID"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Positions";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Positions p = new Positions();
                            p.PositionID = int.Parse(reader["PositionID"].ToString());
                            p.Position = reader["Position"].ToString();
                            PositionsList.Add(p);
                        }
                    }

                }
            }
            return (PositionsList);

        } 
    }
}