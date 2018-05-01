using KlamathIrrigationDistrict.DataLayer.DataModels;
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

        //----------------------------------------Views-----------------------------------

        //get the Request ID
        //Customers GetRequestID(int RequestID);

        //allow customer to view their information
        List<Customers> ViewCustomers();

        //pull the specific customer information
        List<Customers> ViewCustomers(int CustomerID);

        //allow user to see staff contacts
        List<Customers> ViewStaff();

        //list of customers request dependent on their CustomerID
        List<Customers> ViewCustomerRequests(int CustomerID);

        //list of active customers requests that have yet to be acknowledged by ditch rider
        List<Customers> RequestNeedActivation(int CustomerID);

        List<Customers> WaitListCustomerRequest(int CustomerID);

        List<Customers> ActiveRequests(int CustomerID);

        //list of complete request that would include staff input
        List<Customers> CompleteCustomerRequests(int CustomerID);

        //list of customer TotalAllotment, Ride, Lateral, Structure, Name, CustomerMTLHisID
        List<Customers> ViewCustomerAllotment(int CustomerID);

        //customer set date range of requests wanting to view
        List<Customers> ViewRequestDates(int CustomerID, System.DateTime StartDate, System.DateTime EndDate);



        //save the customer information when updated
        //used by the staff or customer
        void Save(Customers customers);

        //Does not use stored procedure, will only apply all that a customer can in request for
        void AddWaterOrderRequest(Customers NewWaterOrder);

        //this funcitonality needs work - apply to display or add to 'customer'
        decimal GetAllotment(int CustomerID);

    


        //need to write a an update function that would update the AspNetUsers when customerID is updated

    }
}