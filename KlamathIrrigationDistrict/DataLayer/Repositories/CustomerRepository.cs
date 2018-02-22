﻿using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Repository;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;

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

        //public virtual Customers GetTrackingID(int TrackingID)
        //{
        //    Customers C_TrackID = null;
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandType = CommandType.Text;
        //            command.CommandText = "SELECT TrackingID FROM Customers";
        //            command.Parameters.AddWithValue("@TrackingID", TrackingID);
        //            connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    C_TrackID = new Customers();
        //                    C_TrackID.TrackingID = int.Parse(reader["TrackingID"].ToString());                            
        //                }
        //            }
        //        }
        //    }
        //    return (C_TrackID);
        //}

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

        public List<Customers> ViewAppliedRequests()
        {
            List<Customers> RequestList = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    //command.CommandText = "SELECT * FROM Requests";
                    command.CommandText = "SELECT * FROM Requests";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers p = new Customers();
                            p.RequestID = int.Parse(reader["RequestID"].ToString());
                            p.TimeStampCustomer1 = DateTime.Parse(reader["TimeStampCustomer1"].ToString());
                            p.CustomerDate1 = DateTime.Parse(reader["CustomerDate1"].ToString());
                            p.CustomerID = int.Parse(reader["CustomerID"].ToString());
                            p.Name = reader["CustomerName"].ToString();
                            p.Structure = reader["Structure"].ToString();
                            p.CustomerCFS_1 = int.Parse(reader["CustomerCFS1"].ToString());
                            p.CustomerComments_1 = reader["CustomerComments1"].ToString();
                            p.TimeStampStaff1 = DateTime.Parse(reader["TimeStampStaff1"].ToString());
                            p.KIDStaffID_1 = int.Parse(reader["KIDStaffID1"].ToString());
                            p.StaffName_1 = reader["StaffName1"].ToString();
                            p.StaffDate1 = DateTime.Parse(reader["StaffDate1"].ToString());
                            p.RequestStatus1 = reader["RequestStatus1"].ToString();
                            p.StaffCFS1 = int.Parse(reader["StaffCFS1"].ToString());
                            p.StaffComments1 = reader["StaffComments1"].ToString();
                            p.TimeStampCustomer2 = DateTime.Parse(reader["TimeStampCustomer2"].ToString());
                            p.CustomerDate2 = DateTime.Parse(reader["CustomerDate2"].ToString());
                            p.CustomerCFS_2 = int.Parse(reader["CustomerCFS2"].ToString());
                            p.CustomerComments_2 = reader["CustomerCommetns2"].ToString();
                            p.TimeStampStaff2 = DateTime.Parse(reader["TimeStampStaff2"].ToString());
                            p.KIDStaffID_2 = int.Parse(reader["KIDStaffID2"].ToString());
                            p.StaffName_2 = reader["StaffName2"].ToString();
                            p.StaffDate2 = DateTime.Parse(reader["StaffDate2"].ToString());
                            p.RequestStatus2 = reader["RequestStatus2"].ToString();
                            p.StaffCFS2 = int.Parse(reader["StaffCFS2"].ToString());
                            p.StaffComments2 = reader["StaffComments2"].ToString();
                        }
                    }
                }
            }
            return (RequestList);
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

        public virtual void AddWaterOrderRequest(Customers NewWaterOrder)
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
                        "(CustomerID, CustomerName, Structure, CustomerCFS1, TimeStampCustomer1, " +
                        "CustomerDate1, CustomerComments1" +
                        "VALUES (@CustomerID, @CustomerName, @Structure, @TimeStampCustomer1, @CustomerDate1, @CustomerCFS1, @CustomerComments1";
                    command.Parameters.AddWithValue("@CustomerID", NewWaterOrder.CustomerID);
                    command.Parameters.AddWithValue("@CustomerName", NewWaterOrder.Name);
                    command.Parameters.AddWithValue("@Structure", NewWaterOrder.Structure);
                    //use getdate parameter to fulfill the customerdate
                    command.Parameters.AddWithValue("@TimeStampCustomer1", NewWaterOrder.TimeStampCustomer1);
                    command.Parameters.AddWithValue("@CustomerDate1", NewWaterOrder._GetCustomerDate);
                    command.Parameters.AddWithValue("@CustomerCFS1", NewWaterOrder.CustomerCFS_1);
                    command.Parameters.AddWithValue("@CustomerComments1", NewWaterOrder.CustomerComments_1);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //public virtual void AddRequest(Customers WaterOrder)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.CommandText = "sp_DitchRider_AddRequests";

        //            command.Parameters.AddWithValue("@CustomerID", WaterOrder.CustomerID);
        //            command.Parameters.AddWithValue("@TrackingID", WaterOrder.TrackingID);
        //            command.Parameters.AddWithValue("@CustomerName", WaterOrder.CustomerName);
        //            command.Parameters.AddWithValue("@Allotment", WaterOrder.Allotment);
        //            command.Parameters.AddWithValue("@MapTaxLot", WaterOrder.MapTaxLot);
        //            command.Parameters.AddWithValue("@Structure", WaterOrder.Structure);
        //            command.Parameters.AddWithValue("@Customerdate", WaterOrder.CustomerDate);
        //            command.Parameters.AddWithValue("@CFSRequeted", WaterOrder.CFSRequested);
        //            command.Parameters.AddWithValue("@CustomerComments", WaterOrder.CustomerComments);
        //            connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}


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
