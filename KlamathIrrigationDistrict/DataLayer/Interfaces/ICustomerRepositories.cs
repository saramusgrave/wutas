using KlamathIrrigationDistrict.DataLayer.DataModels;
using System.Collections.Generic;

namespace KlamathIrrigationDistrict.DataLayer.Repository
{
    public interface ICustomerRepositories
    {
        Customers Get(int CustomerID);

        //allow customer to view their information
        List<Customers> ViewCustomers();

        //allow customer to view their customer history
        List<Customers.MapTaxLots> ViewHistory();

        //return the trackingID of customer
        Customers GetTrackingID(int TrackingID);

        void Save(Customers customers);



    }

    //public class List<T1, T2>
    //{
    //}
}