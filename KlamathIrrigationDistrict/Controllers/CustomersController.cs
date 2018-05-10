﻿using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using KlamathIrrigationDistrict.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace KlamathIrrigationDistrict.Controllers
{
    public class CustomersController : Controller
    {
        //attain the login information

        private ApplicationUserManager _userManager;

        public CustomersController(ApplicationUserManager userManager, ApplicationRoleManager userRole)
        {
            UserManager = userManager;
            RoleManager = userRole;
        }

        private ApplicationRoleManager _RoleManager;
        protected ApplicationRoleManager RoleManager
        {
            get
            {
                if (_RoleManager == null)
                {
                    _RoleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
                }
                return _RoleManager;
            }
            private set
            {
                _RoleManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ICustomerRepository _custRepo;

        public CustomersController()
        {
            _custRepo = new CustomerRepository();
        }

       
        //-------------------------------------------------------------------------------------------------------------------------------------
        /*Views for list of Customers*/
        [Authorize(Roles = "Office Specialist, Customer")]
        //[Authorize]
        [HttpGet]
        //public ActionResult Index()
        public ActionResult Index(int? id)
        {
            //ryhayandgrain@gmail.com       ID = 760
            //josh@horsleyfarms.com         ID = 3681

            if (!id.HasValue)
            {
                //pull out of a repository
                string userID = User.Identity.Name;
                id = _custRepo.getCustomerID(userID);

                //pass the user's customerID to the URL
                return RedirectToAction("Index", new { id = id });
            }

            if (!User.IsInRole("Customer"))
            {
                return View("Unauthorized");
            }
            
            var std = _custRepo.ActiveRequests(id.Value);
            return View(std);

        }

        //NEED A VIEW FOR THE CUSTOMER TO SEE SUBMITTED REQUESTS (CHECK REQUESTSTATUS1 IS NULL)
        //allow for the user to remember what they had submitted

        //allow user to see the differnce of request status - waitlist
        public ActionResult CustomerWaitList(int id)
        {
            var std = _custRepo.WaitListCustomerRequest(id);
            return View(std);

        }        

        //simply just view the staff
        public ActionResult ContactsPage()
        {
            if (!User.IsInRole("Customer"))
            {
                return View("Unauthorized");
            }

            var std = _custRepo.ViewStaff();
            return View(std);
        }


        public ActionResult CustomerProfile(int id)
        {
            var std = _custRepo.ViewCustomers(id);
            return View(std);
        }

        public ActionResult CustomerWaterHistory(int id, int ?page)
        {
            if (!User.IsInRole("Customer"))
            {
                return View("Unauthorized");
            }

            int pageSize = 20;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            IPagedList<Customers> cHistory = null;
            CustomerRepository customerrepository = new CustomerRepository();
            Customers CustomerHistory = new Customers();
            List<Customers> obCustomerWaterList = new List<Customers>();

            obCustomerWaterList = customerrepository.CompleteCustomerRequests(id);
            CustomerHistory.customers = obCustomerWaterList;
            cHistory = obCustomerWaterList.Where(s => s.CustomerID == id).ToPagedList(pageIndex, pageSize);
            ViewData["CID"] = id;
            return View(cHistory);
        }

        //should read this fucntion when running CustomerAddRequest view
        //Referenced by "CustomerAddRequest.cshtml" - functionality
        //[Authorize(Roles = "Office Specialist, Customer")]
        //needs to pass in a new customer to allow for add in HttpPost -> CustomerAddRequest
        [HttpGet]
        public ActionResult CustomerAddRequest()
        {

            return View(new Customers());
        }

        //HttpPost will not allow for display of view, only get
        //referenced by the Customer in Submiting a Request
        //[Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult CustomerAddRequest(Customers WaterRequest)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(WaterRequest);
            //}

            //controller needs to see what is coming in and set variable
            int CustomerID = WaterRequest.CustomerID;
            string structure = WaterRequest.Structure;
            string Name = WaterRequest.Name;
            DateTime CustomerDate1 = WaterRequest.CustomerDate1;
            float CustomerCFS1 = WaterRequest.CustomerCFS_1;
            string CustomerComments1 = WaterRequest.CustomerComments_1;

            _custRepo.AddWaterOrderRequest(WaterRequest);
            return new RedirectResult(Url.Action("Customers/" + Url.RequestContext.RouteData.Values["id"]));

            //return RedirectToAction("Index");
            //return View("Index");
        }

        //Display water currently on
        //will need to be a dropdown of requests
        //[HttpGet]
        //public ActionResult RequestWater_On(int id)
        //{
        //    var std = _custRepo.ActiveRequests(id);
        //    return View(std);
        //}

        //AddCustomer
        [Authorize(Roles = "Office Specialist")]
        [HttpPost]
        public ActionResult AddCustomer(Customers personInfo)
        {
            //Adding to KIDStaff
            if (!ModelState.IsValid)
            {
                return View(personInfo);
            }
            //Adds user to ASP side of things...ASP = SQL, ASP = SQL
            //modified date time = get now
            //modifed user = get current user login
            var user = new ApplicationUser { UserName = personInfo.Email, Email = personInfo.Email };
            var result = this.UserManager.Create(user, personInfo.Password);
            if (result.Succeeded)
            {
                //is this correct -> add to the role of customer
                UserManager.AddToRole(user.Id, "Customer");

                //UserManager.AddToRole(user.Id, "Project Worker");
                var role = this.RoleManager.FindByName("");
                //role.Users.Add();
                //this.UserManager.AddToRole(user.Id, kidstaff.UserRoles);
            }
            //SQL Statement to add to KIDStaff
            //_stafRepo.AddStaff(kidstaff);
            //Return home page
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult ViewAllotment(Customers cusAllotment)
        {
            int CustomerID;
            decimal std;
            if (User.Identity.Name.Equals("ryhayandgrain@gmail.com"))
            {
                CustomerID = 760;
                std = _custRepo.GetAllotment(CustomerID);
                return View(std);
            }

            else if (User.Identity.Name.Equals("josh@horsleyfarms.com"))
            {
                CustomerID = 3681;        //josh customerID
                //CustomerID = 549;           //Webb Gene & Pamela 
                std = _custRepo.GetAllotment(CustomerID);
                return View(std);
            }
            else
                CustomerID = 760;
            std = _custRepo.GetAllotment(CustomerID);
            return View(std);
        }


        //View for Staff to add a customer
        [Authorize(Roles = "Office Specialist")]
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View(new Customers());
        }

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

        //public ActionResult ViewCustomerAllotment(int CustomerID)
        //{
        //    CustomerRepository customerrepository = new CustomerRepository();
        //    Customers CustomerAllotment = new Customers();
        //    List<Customers> obCustomerAllotment = new List<Customers>();

        //    if (User.Identity.Name.Equals("ryhayandgrain@gmail.com"))
        //    {
        //        CustomerID = 760;
        //        //CustomerAllotment.TotalAllotment = _custRepo.ViewCustomerAllotment(CustomerID);
        //        obCustomerAllotment = customerrepository.ViewCustomerAllotment(CustomerID);
        //        CustomerAllotment.customers = obCustomerAllotment;

        //        return View(CustomerAllotment.TotalAllotment);
        //        //return View(obCustomerInfo);

        //    }
        //    else if (User.Identity.Name.Equals("josh@horsleyfarms.com"))
        //    {
        //        CustomerID = 3681;
        //        //CustomerAllotment.TotalAllotment = _custRepo.ViewCustomerAllotment(CustomerID);
        //        obCustomerAllotment = customerrepository.ViewCustomerAllotment(CustomerID);
        //        CustomerAllotment.customers = obCustomerAllotment;

        //        return View(CustomerAllotment.TotalAllotment);
        //        //return View(obCustomerInfo);
        //    }
        //    else
        //        CustomerID = 760;
        //    obCustomerAllotment = customerrepository.ViewCustomerAllotment(CustomerID);
        //    CustomerAllotment.customers = obCustomerAllotment;

        //    return View(CustomerAllotment.TotalAllotment);
        //}

        [OutputCache(Duration = 500, VaryByParam = "CustomerID")]
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

        //-------------------------------------------------------------------------------------------------------------------------------------

        //referenced by the Customer in Submiting a Request
        //[HttpPost]
        //public ActionResult SubmitRequest(Customers std)
        //{
        //    int RequestID = std.RequestID;
        //    DateTime CustomerDate = std.CustomerDate1;
        //    Decimal CFSRequested = std.CustomerCFS1;
        //    string CustomerComments = std.CustomerComments_1;
        //    _custRepo.AddWaterOrderRequest(std);
        //    return RedirectToAction("Index");
        //}

        //-------------------------------------------------------------------------------------------------------------------------------------

        //view the ICustomerRepositories
        //need to add the TrackingID from the MTL - ensure that it matches with Customer's Tracking ID
        //Allow to sync with 
        //public ActionResult ViewWaterHistory(int CustomerID)
        //{
        //    //do i need to specify how to get the customerID? (BELOW)
        //    //Customers customers = _custRepo.Get(CustomerID);
        //    //if(customers == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(customers);

        //    _custRepo.ViewCustomerRequests(CustomerID);
        //    return RedirectToAction("CustomerWaterOrderHistory");
        //}
    }
}