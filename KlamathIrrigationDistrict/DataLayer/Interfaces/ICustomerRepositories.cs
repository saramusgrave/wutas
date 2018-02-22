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

        //list all of customers request
        List<Customers> ViewAppliedRequests();

        //save the customer information when updated
        //used by the staff or customer
        void Save(Customers customers);

        //CustomerID allow for user to see their History of water usage
        //history based on customerID
        void ViewCustomerWaterHistory(int CustomerID);

        //Does not use stored procedure, will only apply all that a customer can in request for
        void AddWaterOrderRequest(Customers NewWaterOrder);

        //Submit a customer request for water
        //void SubmitRequest(Customers std);


    }


    //public interface ICustomerRepository : WaterOrderRequest


    //public class List<T1, T2>
    //{
    //}
}