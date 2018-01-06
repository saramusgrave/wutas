using KlamathIrrigationDistrict.DataLayer.DataModels;
using System.Collections.Generic;

namespace KlamathIrrigationDistrict.DataLayer.Repository
{
    public interface ICustomerRepositories
    {
        Customers Get(int CustomerID);
        List<Customers> ViewCustomers();
        void Save(Customers customers);

    }
}