using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Repository;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KlamathIrrigationDistrict.DataLayer.Repositories
{
    public class CustomerRepository : ICustomerRepositories
    {
        public virtual Customers Get(int CustomerID)
        {
            Customers s = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Customers";
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            s = new Customers();
                            s.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            s.TrackingID = int.Parse(reader["TrackingID"].ToString());
                            s.Name = reader["Name"].ToString();
                            s.Address1 = reader["Address1"].ToString();
                            s.Address2 = reader["Address2"].ToString();
                            s.City = reader["City"].ToString();
                            s.State = reader["State"].ToString();
                            s.Zip = int.Parse(reader["Zip"].ToString());
                            s.TotalAllotment = decimal.Parse(reader["TotalAllotment"].ToString());
                        }
                    }
                }
            }
            return (s);
        }

        public virtual Customers GetTrackingID(int TrackingID)
        {
            Customers C_TrackID = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT TrackingID FROM Customers";
                    command.Parameters.AddWithValue("@TrackingID", TrackingID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            C_TrackID = new Customers();
                            C_TrackID.TrackingID = int.Parse(reader["TrackingID"].ToString());                            
                        }
                    }
                }
            }
            return (C_TrackID);
        }

        public virtual List<Customers> ViewCustomers()
        {
            List<Customers> vc = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Customers ORDER BY Name";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers s = new Customers();
                            s.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            s.TrackingID = int.Parse(reader["TrackingID"].ToString());
                            s.Name = reader["Name"].ToString();
                            s.Address1 = reader["Address1"].ToString();
                            s.Address2 = reader["Address2"].ToString();
                            s.City = reader["City"].ToString();
                            s.State = reader["State"].ToString();
                            s.Zip = int.Parse(reader["Zip"].ToString());
                            s.TotalAllotment = decimal.Parse(reader["TotalAllotment"].ToString());
                            vc.Add(s);
                        }
                    }
                }
            }
            return (vc);
        }

        public virtual List<Customers.MapTaxLots> ViewHistory()
        {
            //view history - vh
            List<Customers>  vh = new List<Customers>();
            //List<MapTaxLots> ch = new List<MapTaxLots>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT Name, CustomerID, TrackingID, Structures, Status, Acres FROM C.Customers, M.MapTaxLots WHERE C.TrackingID = M.TrackingID;";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers.MapTaxLots s = new Customers.MapTaxLots();
                            s.Name = reader["Name"].ToString();
                            s.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            s.TrackingID = int.Parse(reader["TrackingID"].ToString());
                            s.Structure  = reader["Structure"].ToString();
                            s.Status     = reader["Statust"].ToString();
                            s.Acers = decimal.Parse(reader["Acers"].ToString());
                            
                            //will add the above data to the customer's profile - view history (VH)
                            vh.Add(s);
                        }
                    }
                }
            }
        }

        public virtual void Save(Customers customers)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_Customer_Insert_Update";
                    //if (customers.CustomerID != null)
                    //{
                    //    command.Parameters.AddWithValue("@CustomerID", customers.CustomerID);
                    //}
                    command.Parameters.AddWithValue("@CustomerID", customers.CustomerID);
                    command.Parameters.AddWithValue("@TrackingID", customers.TrackingID);
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
    }

    //public class List<T1, T2>
    //{
    //    List<T1> vh = new List<T1>();
    //    List<T2> ch = new List<T2>();
        
    //}
}