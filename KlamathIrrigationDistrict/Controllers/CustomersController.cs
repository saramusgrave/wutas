using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using KlamathIrrigationDistrict.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerRepositories _custRepo;
        public CustomersController()
        {
            _custRepo = new CustomerRepository();
        }
        [HttpGet]
        public ActionResult StaffEditCustomer(int CustomerID)
        {
            Customers customer = _custRepo.Get(CustomerID);
            return View(customer);
        }
        [HttpPost]
        public ActionResult StaffEditCustomer(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return View(customers);
            }
            _custRepo.Save(customers);
            return RedirectToAction("Index");
        }
        // GET: Customers
        public ActionResult Index()
        {
            ViewBag.Title = "KID Staff: Customers";
            return View(_custRepo.ViewCustomers());
        }
        [OutputCache(Duration = 300, VaryByParam ="id")]
        public ActionResult ViewCustomers(int CustomerID)
        {
            Customers customers = _custRepo.Get(CustomerID);
            Customers CustomerModel = new Customers()
            {
                CustomerID = customers.CustomerID,
                TrackingID = customers.TrackingID,
                Name = customers.Name,
                Address1 = customers.Address1,
                Address2 = customers.Address2,
                City = customers.City,
                State = customers.State,
                Zip = customers.Zip,
                TotalAllotment = customers.TotalAllotment
            };
            return ViewCustomers(CustomerID);
        }
        
    }
}