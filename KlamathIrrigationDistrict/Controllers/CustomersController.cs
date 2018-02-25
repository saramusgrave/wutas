﻿using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using KlamathIrrigationDistrict.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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

        /*Views for list of Customers*/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Customers> RequestList = null;
            CustomerRepository customerrepository = new CustomerRepository();
            Customers CustomerStaff = new Customers();
            List<Customers> obCustomerList = new List<Customers>();
            obCustomerList = customerrepository.ViewCustomerRequests();
            CustomerStaff.customers = obCustomerList;
            RequestList = obCustomerList.ToPagedList(pageIndex, pageSize);
            return View(RequestList);
        }

        public ActionResult ContactsPage(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Customers> CustomerContacts = null;
            CustomerRepository Contacts_Page = new CustomerRepository();
            Customers CustomerStaff = new Customers();
            List<Customers> obCustomerContactList = new List<Customers>();
            obCustomerContactList = Contacts_Page.ViewStaff();
            CustomerStaff.customers = obCustomerContactList;
            CustomerContacts = obCustomerContactList.ToPagedList(pageIndex, pageSize);
            return View(CustomerContacts);
        }



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
            //_custRepo.ViewCustomerWaterHistory(cust.CustomerID);     //given edit -> change history
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


        //[OutputCache(Duration = 300, VaryByParam = "id")]
        //public ActionResult ViewStaff(int StaffID)
        //{
        //    Customers kidstaff = _custRepo.;
        //    KIDStaff StaffModel = new KIDStaff()
        //    {
        //        StaffID = kidstaff.StaffID,
        //        Position = kidstaff.Position,
        //        FirstName = kidstaff.FirstName,
        //        LastName = kidstaff.LastName,
        //        Password = kidstaff.Password,
        //        Email = kidstaff.Email,
        //        PhoneNumber = kidstaff.PhoneNumber,
        //        StaffStatus = kidstaff.StaffStatus,
        //        StartDate = kidstaff.StartDate,
        //        EndDate = kidstaff.EndDate,
        //        ModifiedDateTime = kidstaff.ModifiedDateTime,
        //        ModifiedUser = kidstaff.ModifiedUser,
        //    };
        //    return ViewStaff(StaffID);
        //}


        public ActionResult IndexContacts(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Customers> CustomerContacts = null;
            CustomerRepository repository = new CustomerRepository();
            Customers customers_StaffInfo = new Customers();
            List<Customers> obCustomerContactList = new List<Customers>();
            obCustomerContactList = repository.ViewStaff();
            customers_StaffInfo.customers = obCustomerContactList;
            CustomerContacts = obCustomerContactList.ToPagedList(pageIndex, pageSize);
            return View(CustomerContacts);
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
            var std = _custRepo.ViewCustomerRequests().Where(s => s.RequestID == RequestID).FirstOrDefault();
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
        public ActionResult ViewCustomerRequest(int CustomerID)
        {
            //do i need to specify how to get the customerID? (BELOW)
            //Customers customers = _custRepo.Get(CustomerID);
            //if(customers == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(customers);

            //_custRepo.ViewCustomerWaterHistory(CustomerID);
            _custRepo.ViewCustomerRequests();
            return RedirectToAction("CustomerWaterOrderHistory");
        }
    }
}