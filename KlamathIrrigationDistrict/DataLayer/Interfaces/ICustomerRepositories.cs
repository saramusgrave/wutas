using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using System.Collections.Generic;

namespace KlamathIrrigationDistrict.DataLayer.Repository
{
    //------------------------------------------------------------
    //Header for the CustomerRepository file
    //------------------------------------------------------------
    public interface ICustomerRepositories 
    {
        Customers Get(int CustomerID);

        //allow customer to view their information
        List<Customers> ViewCustomers();

        //save the customer information when updated
        //used by the staff or customer
        void Save(Customers customers);

        //CustomerID allow for user to see their History of water usage
        //history based on customerID
        void ViewCustomerWaterHistory(int CustomerID);

        //uses a stored procedure to reference process
        //allocate info form customer profile into a water order with request
        //void ApplyWaterOrder(WaterOrderRequest WaterOrder);

        //Does not use stored procedure, will only apply all that a customer can in request for
        void AddWaterOrderRequest(WaterOrderRequest NewWaterOrder);

     
    }


    //public interface ICustomerRepository : WaterOrderRequest


    //public class List<T1, T2>
    //{
    //}
}