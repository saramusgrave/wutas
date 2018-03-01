﻿using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerRepository _custRepo;

        public CustomersController()
        {
            _custRepo = new CustomerRepository();
        }

        //NEED AN ActionResult for each page in views

        //CURRENTLY THIS DISPLAYS ALL PAGES REGARDING CUSTOMERS JOSH AND RYAN
        //RYAN IS DEFAULT!!
        //----------------------------------------------------------------------------------------
        /*Views for list of Customers*/
        [Authorize(Roles = "Office Specialist, Customer")]
        //[OutputCache(Duration = 500, VaryByParam = "CustomerID")]
        [HttpGet]
        public ActionResult Index(int? page)
        {
            //defualt of index is ryan
            int CustomerID;

            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            IPagedList<Customers> cstaff = null;
            CustomerRepository customerrepository = new CustomerRepository();
            Customers CustomerStaff = new Customers();
            List<Customers> obCustomerList = new List<Customers>();

            if (User.Identity.Name.Equals("ryhayandgrain@gmail.com"))
            {
                CustomerID = 760;
                obCustomerList = customerrepository.ViewCustomerRequests(CustomerID);
                CustomerStaff.customers = obCustomerList;
                cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
                return View(cstaff);
            }
            else if (User.Identity.Name.Equals("josh@horsleyfarms.com"))
            {
                CustomerID = 3681;

                obCustomerList = customerrepository.ViewCustomerRequests(CustomerID);
                CustomerStaff.customers = obCustomerList;
                cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
                return View(cstaff);
            }
            else
                CustomerID = 760;
                obCustomerList = customerrepository.ViewCustomerRequests(CustomerID);
                CustomerStaff.customers = obCustomerList;
                cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
                return View(cstaff);
        }            
        
        //only page in which everyone shares
        public ActionResult ContactsPage(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            IPagedList<Customers> cstaff = null;
            CustomerRepository customerrepository = new CustomerRepository();
            Customers CustomerStaff = new Customers();
            List<Customers> obCustomerList = new List<Customers>();

            obCustomerList = customerrepository.ViewStaff();
            CustomerStaff.customers = obCustomerList;
            cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
            return View(cstaff);
        }

        //currently displaying Ryan's Customer Info
        //Hardcoded customerID
        //does not work because there is no ID referenced, attained at login
        //[OutputCache(Duration = 500, VaryByParam = "CustomerID")]
        public ActionResult CustomerProfile(int ? page)
        {
            int CustomerID;

            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Customers> cInfo = null;

            CustomerRepository customerrepository = new CustomerRepository();
            Customers CustomerInfo = new Customers();
            List<Customers> obCustomerInfo = new List<Customers>();

            if (User.Identity.Name.Equals("ryhayandgrain@gmail.com"))
            {
                CustomerID = 760;

                obCustomerInfo = customerrepository.ViewCustomers(CustomerID);
                CustomerInfo.customers = obCustomerInfo;
                cInfo = obCustomerInfo.ToPagedList(pageIndex, pageSize);
                return View(cInfo);
                //return View(obCustomerInfo);

            }
            else if (User.Identity.Name.Equals("josh@horsleyfarms.com"))
            {
                CustomerID = 3681;

                obCustomerInfo = customerrepository.ViewCustomers(CustomerID);
                CustomerInfo.customers = obCustomerInfo;
                cInfo = obCustomerInfo.ToPagedList(pageIndex, pageSize);
                return View(cInfo);
                //return View(obCustomerInfo);
            }
            else
                CustomerID = 760;
                obCustomerInfo = customerrepository.ViewCustomers(CustomerID);
                CustomerInfo.customers = obCustomerInfo;
                cInfo = obCustomerInfo.ToPagedList(pageIndex, pageSize);
                return View(cInfo);
            
            //return CustomerProfile();

            //Customers customers = _custRepo.Get(CustomerID);
            //Customers customers = _custRepo.Get(CustomerID);
            //Customers CustomerModel = new Customers()
            //{
            //    CustomerID = customers.CustomerID,
            //    TrackingID = customers.TrackingID,
            //    Name = customers.Name,
            //    Address1 = customers.Address1,
            //    Address2 = customers.Address2,
            //    City = customers.City,
            //    State = customers.State,
            //    Zip = customers.Zip,
            //    TotalAllotment = customers.TotalAllotment,
            //};
            ////return CustomerProfile(CustomerID);
            //return CustomerProfile(CustomerID);
        }

        public ActionResult CustomerWaterHistory(int? page)
        {
            int CustomerID;

            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            IPagedList<Customers> cHistory = null;
            CustomerRepository customerrepository = new CustomerRepository();
            Customers CustomerHistory = new Customers();
            List<Customers> obCustomerWaterList = new List<Customers>();

            if (User.Identity.Name.Equals("ryhayandgrain@gmail.com"))
            {
                CustomerID = 760;

                obCustomerWaterList = customerrepository.ViewCustomerRequests(CustomerID);
                CustomerHistory.customers = obCustomerWaterList;
                cHistory = obCustomerWaterList.ToPagedList(pageIndex, pageSize);
                return View(cHistory);
            }
            else if (User.Identity.Name.Equals("josh@horsleyfarms.com"))
            {
                CustomerID = 3681;

                obCustomerWaterList = customerrepository.ViewCustomerRequests(CustomerID);
                CustomerHistory.customers = obCustomerWaterList;
                cHistory = obCustomerWaterList.ToPagedList(pageIndex, pageSize);
                return View(cHistory);                
            }
            else
                CustomerID = 760;
                obCustomerWaterList = customerrepository.ViewCustomerRequests(CustomerID);
                CustomerHistory.customers = obCustomerWaterList;
                cHistory = obCustomerWaterList.ToPagedList(pageIndex, pageSize);
                return View(cHistory);
        }

        //referenced by the Customer in Submiting a Request
        //[Authorize(Roles = "Customer")]
        [HttpGet]
        public ActionResult CustomerAddRequest(Customers WaterRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(WaterRequest);
            }
            //_custRepo..AddRequest4On(ditchriderrequests);
            _custRepo.AddWaterOrderRequest(WaterRequest);
            return RedirectToAction("Index");
        }

        
        //---------------------------------------------------------------------------------------
        //functionality for specific people under the customer side

        //View for Staff to add a customer
        [Authorize(Roles = "Office Specialist")]
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View(new Customers());
        }
                
        //used to add water order request
        //[Authorize(Roles = "Customer")]
        //[HttpPost]
        //public ActionResult AddCustomerRequest(Customers CustomersRequest)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(CustomersRequest);
        //    }
        //    //_custRepo.Save(customers);
        //    //reference CustomerRepository - AddWaterOrderRequest
        //    _custRepo.AddWaterOrderRequest(CustomersRequest);
        //    return RedirectToAction("IndexCustomer");
        //}

        //View for Staff to Edit a customer
        [Authorize(Roles = "Office Specialist")]
        public ActionResult StaffEditCustomer(int CustomerID)
        {
            var cust = _custRepo.ViewCustomers().Where(s => s.CustomerID == CustomerID).FirstOrDefault();
            return View(cust);
        }
        [Authorize(Roles = "Office Specialist")]
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
            //_custRepo.ViewCustomerRequests(cust.CustomerID);     //given edit -> change history
            return RedirectToAction("Index");
        }



        //[OutputCache(Duration = 500, VaryByParam = "CustomerID")]
        //View 'CustomerWaterHistory' will use this function as reference
        //will be used when have CustomerID as a reference to their own profile
        public ActionResult ViewCustomerWaterHistory(int CustomerID)
        {
            CustomerID = 760;

            Customers customers = _custRepo.Get(CustomerID);
            Customers CustomerHistory = new Customers()
            {
                RequestID = customers.RequestID,
                TimeStampCustomer1 = customers.TimeStampCustomer1,
                CustomerDate1 = customers.CustomerDate1,
                CustomerID = customers.CustomerID,
                Name = customers.Name,
                Structure = customers.Structure,
                CustomerCFS_1 = customers.CustomerCFS_1,
                CustomerComments_1 = customers.CustomerComments_1,
                TimeStampStaff1 = customers.TimeStampStaff1,
                StaffName_1 = customers.StaffName_1,
                StaffDate1 = customers.StaffDate1,
                RequestStatus1 = customers.RequestStatus1,
                StaffCFS1 = customers.StaffCFS1,
                StaffComments1 = customers.StaffComments1,
                TimeStampCustomer2 = customers.TimeStampCustomer2,
                CustomerDate2 = customers.CustomerDate2,
                CustomerCFS_2 = customers.CustomerCFS_2,
                CustomerComments_2 = customers.CustomerComments_2,
                TimeStampStaff2 = customers.TimeStampStaff2,
                StaffName_2 = customers.StaffName_2,
                StaffDate2 = customers.StaffDate2,
                RequestStatus2 = customers.RequestStatus2,
                StaffCFS2 = customers.StaffCFS2,
                StaffComments2 = customers.StaffComments2
            };
            return ViewCustomerWaterHistory(CustomerID);
        }

        //----------------------------------------------------------------------------------------------------------------
        
        //referenced by the Customer in Submiting a Request
        //[HttpPost]
        //public ActionResult SubmitRequest(Customers std)
        //{
        //    int RequestID = std.RequestID;
        //    DateTime CustomerDate = std.CustomerDate1;
        //    Decimal CFSRequested = std.CustomerCFS_1;
        //    string CustomerComments = std.CustomerComments_1;
        //    _custRepo.AddWaterOrderRequest(std);
        //    return RedirectToAction("Index");
        //}

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

            _custRepo.ViewCustomerRequests(CustomerID);
            return RedirectToAction("CustomerWaterOrderHistory");
        }
    }
}