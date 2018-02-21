using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Repository;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KlamathIrrigationDistrict.DataLayer.Repositories
{
    //Actual body for the header file -> ICustomerRepository
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

        //use the stored procedure to display the customer's water history
        //parameter need to be customerID? Not customers?
        public virtual void ViewCustomerWaterHistory (int CustomerID)
        {
            //Customers C_CustomerID = CustomerID;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_CustomerHistory";
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            //return (CustomerID)
        }

        //apply the stored procedure of updating or entering in new customer data
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

        //-------------------------------------------------------------------------------------------------------------------
        //take parameters to apply the requested water order
        //public virtual void ApplyWaterOrder(WaterOrderRequest WaterOrder)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandType = CommandType.StoredProcedure;
        //            //not sure if procedure (CustomerWaterRequest) need more to handle variables
        //            //command.CommandText = "SELECT * FROM Customers ORDER BY Name"; -- viewcustomers function
        //            command.CommandText = "CustomerWaterRequest";
        //            command.Parameters.AddWithValue("@CustomerID", WaterOrder.CustomerID);
        //            command.Parameters.AddWithValue("@Allotment", WaterOrder.TotalAllotment);
        //            command.Parameters.AddWithValue("@TrackingID", WaterOrder.TrackingID);
        //            command.Parameters.AddWithValue("@StructureID", WaterOrder.Structure);
        //            command.Parameters.AddWithValue("@CFSRequested", WaterOrder.RequestedCFS);
        //            command.Parameters.AddWithValue("CustomerName", WaterOrder.Name);
        //            command.Parameters.AddWithValue("CustomerComments", WaterOrder.CustomerComments);

        //            connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //    }

        //}
        //-------------------------------------------------------------------------------------------------------------------

        public virtual void AddWaterOrderRequest(WaterOrderRequest NewWaterOrder)
        {
            //find a better way to Apply request for Water Order
            //WaterOrderRequest NewOrder = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = 
                        "INSERT INTO Requests" + 
                        "(CustomerID, TrackingID, CustomerName, Structure, CustomerDate, CFSRequested, CustomerComments" +
                        "VALUES (@CustomerID, @TrackingID, @CustomerName, @Structure, @CustomerDate, @CFSRequested, @CustomerComments";
                    command.Parameters.AddWithValue("@CustomerID", NewWaterOrder.CustomerID);
                    command.Parameters.AddWithValue("@TrackingID", NewWaterOrder.TrackingID);
                    command.Parameters.AddWithValue("@CustomerName", NewWaterOrder.Name);
                    command.Parameters.AddWithValue("@Structure", NewWaterOrder.Structure);
                    //use getdate parameter to fulfill the customerdate
                    command.Parameters.AddWithValue("@CustomerDate", "GETDATE()");
                    command.Parameters.AddWithValue("@CFSRequested", NewWaterOrder.RequestedCFS);
                    command.Parameters.AddWithValue("@CustomerComments", NewWaterOrder.CustomerComments);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        //public static void AddProduct(Product product)

        //{

        //    //set up sql connection

        //    SqlConnection conn = DatabaseDB.GetConnection();



        //    //write query

        //    string strIns =

        //        "INSERT INTO Products " +

        //        "(ProductCode, Description, UnitPrice)" +

        //        "Values (@Code, @Description, @UnitPrice)";



        //    //creates our command

        //    SqlCommand cmd = new SqlCommand(strIns, conn);



        //    cmd.Parameters.AddWithValue("@Code", product.ProdCode);

        //    cmd.Parameters.AddWithValue("@Description", product.Description);

        //    cmd.Parameters.AddWithValue("@UnitPrice", product.Price);



        //    try

        //    {

        //        conn.Open();



        //        cmd.ExecuteNonQuery();



        //        MessageBox.Show("Record has been added");



        //    }

        //    catch (Exception ex)

        //    {

        //        throw ex;

        //    }

        //    finally

        //    {

        //        conn.Close();

        //    }
        //}

    }
}
