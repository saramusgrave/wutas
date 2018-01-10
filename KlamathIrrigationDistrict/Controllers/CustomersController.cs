using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using KlamathIrrigationDistrict.DataLayer.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /*Views for list of Customers*/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Customers> cstaff = null;
            CustomerRepository customerrepository = new CustomerRepository();
            Customers CustomerStaff = new Customers();
            List<Customers> obCustomerList = new List<Customers>();
            obCustomerList = customerrepository.ViewCustomers();
            CustomerStaff.customers = obCustomerList;
            cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
            return View(cstaff);
        }
        //View for Staff to add a customer
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View(new Customers());
        }
        [HttpPost]
        public ActionResult AddCustomer(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return View(customers);
            }
            _custRepo.Save(customers);
            return RedirectToAction("Index");
        }
        //View for Staff to Edit a customer
        public ActionResult StaffEditCustomer(int CustomerID)
        {
            var cust = _custRepo.ViewCustomers().Where(s => s.CustomerID == CustomerID).FirstOrDefault();
            return View(cust);
        }
        [HttpPost]
        public ActionResult StaffEditCustomer(Customers cust)
        {
            int CustomerID = cust.CustomerID;
            int TrackingID = cust.TrackingID;
            string Name = cust.Name;
            string Address1 = cust.Address1;
            string Address2 = cust.Address2;
            string City = cust.City;
            string State = cust.State;
            int Zip = cust.Zip;
            decimal TotalAllotment = cust.TotalAllotment;
            _custRepo.Save(cust);
            return RedirectToAction("Index");
        }
        [OutputCache(Duration = 300, VaryByParam = "id")]
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
                TotalAllotment = customers.TotalAllotment,
            };
            return ViewCustomers(CustomerID);
        }
    }
}