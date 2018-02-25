﻿using KlamathIrrigationDistrict.DataLayer.DataModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.DataLayer.Interfaces
{
    //------------------------------------------------------------
    //Header for the CustomerRepository file
    //------------------------------------------------------------
    public interface ICustomerRepository 
    {
        //get the customer information - customerID
        Customers Get(int CustomerID);

        //get the Request ID
        Customers GetRequestID(int RequestID);

        //allow customer to view their information
        List<Customers> ViewCustomers();

        //allow user to see staff contacts
        List<Customers> ViewStaff();

        //list all of customers request
        List<Customers> ViewCustomerRequests();

        //save the customer information when updated
        //used by the staff or customer
        void Save(Customers customers);

        //CustomerID allow for user to see their History of water usage
        //history based on customerID
        //void ViewCustomerWaterHistory(int CustomerID);

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