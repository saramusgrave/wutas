using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
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
            obCustomerList = customerrepository.ViewAppliedRequests();
            CustomerStaff.customers = obCustomerList;
            cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
            return View(cstaff);
        }

        //public ActionResult RequestIndex(int? page)
        //{
        //    int pageSize = 10;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    IPagedList<Customers> cstaff = null;
        //    CustomerRepository customerrepository = new CustomerRepository();
        //    Customers CustomerStaff = new Customers();
        //    List<Customers> obCustomerList = new List<Customers>();

        //    obCustomerList = customerrepository.ViewCustomerWaterHistory(_custRepo.Get);

        //    CustomerStaff.customers = obCustomerList;
        //    cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
        //    return View(cstaff);
        //}

        //View for Staff to add a customer
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View(new Customers());
        }

        //used to add water order request
        [HttpPost]
        public ActionResult AddCustomerRequest(Customers CustomersRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(CustomersRequest);
            }
            //_custRepo.Save(customers);
            //reference CustomerRepository - AddWaterOrderRequest
            _custRepo.AddWaterOrderRequest(CustomersRequest);
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
            _custRepo.ViewCustomerWaterHistory(cust.CustomerID);     //given edit -> change history
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
        

        //----------------------------------------------------------------------------------------------------------------
        //user will apply for water
        public ActionResult ApplyWaterRequest(Customers Request)
        {
            if (!ModelState.IsValid)
            {
                return View(Request);
            }
            //reference repository to add a request
            _custRepo.AddWaterOrderRequest(Request);

            return RedirectToAction("Index");
        }

        public ActionResult SubmitRequest(int RequestID)
        {
            var std = _custRepo.ViewAppliedRequests().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }

        //
        [HttpPost]
        public ActionResult SubmitRequest(Customers std)
        {
            int RequestID = std.RequestID;
            DateTime CustomerDate = std.CustomerDate1;
            Decimal CFSRequested = std.CustomerCFS_1;
            string CustomerComments = std.CustomerComments_1;
            _custRepo.AddWaterOrderRequest(std);
            return RedirectToAction("Index");
        }

        //----------------------------------------------------------------------------------------------------------------


        //view the ICustomerRepositories
        //need to add the TrackingID from the MTL - ensure that it matches with Customer's Tracking ID
        //Allow to sync with 
        public ActionResult ViewWaterHistory(int CustomerID)
        {
            //do i need to specify how to get the customerID? (BELOW)
            //Customers customers = _custRepo.Get(CustomerID);
            //if(customers == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(customers);

            _custRepo.ViewCustomerWaterHistory(CustomerID);
            return RedirectToAction("CustomerWaterOrderHistory");
        }
    }
}