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
        /* PURPOSE: retrieve the CustomerID from UserID
         * RETURNS: int
         * USE:     Index
         */
        int getCustomerID(string userID);

        float getCurrentAllotment(int CustomerID);
        
        /*----------------------------------------Views----------------------------------------------------*/
        

        /* PURPOSE: 
         * RETURNS: 
         * USE:     
         */
        
            
        /* PURPOSE: View CustomerInfo
         * RETURNS: List of Customer
         * USE:     CustomerProfile(id), StaffEditCustomer(id)
         */
         //pull the specific customer information
        List<Customers> ViewCustomers(int CustomerID);

        /* PURPOSE: view staff contact information
         * RETURNS: list of staff
         * USE:     ContactsPage()
         */
        List<Customers> ViewStaff();

        /* PURPOSE: View the requests that are 'wait list' status
         * RETURNS: list of requests
         * USE:     CustomerWaitList(id)
         */
        List<Customers> WaitListCustomerRequest(int CustomerID);

        /* PURPOSE: view the recently submitted requests (waiting status)
         * RETURNS: list of requests
         * USE:     CustomerRecentRequest(id)
         */
        List<Customers> RecentRequests(int CustomerID);

        /* PURPOSE: View the requests that have been confirmed (RequestStatus1)
         * RETURNS: list of active requests
         * USE:     Index
         */
        List<Customers> ActiveRequests(int CustomerID);

        //list of complete request that would include staff input
        List<Customers> CompleteCustomerRequests(int CustomerID);

        /*------------------------------------ Stored Procedures -------------------------------------------*/
        
        /* PURPOSE: Save the customer information that is inputed
         * RETURNS: Customers
         * USE:     StaffEditCustomer
         */
        void Save(Customers customers);

        /* PURPOSE: allow user to input information for request
         * RETURNS: Request
         * USE:     CustomerAddRequest(Customers)
         */
        void AddWaterOrderRequest(Customers NewWaterOrder);
    }
}