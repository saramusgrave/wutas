using KlamathIrrigationDistrict.DataLayer.DataModels;
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

        //NEED AN ActionResult for each page in views

        //CURRENTLY THIS DISPLAYS ALL PAGES REGARDING CUSTOMERS JOSH AND RYAN
        //RYAN IS DEFAULT!!
        //-------------------------------------------------------------------------------------------------------------------------------------
        /*Views for list of Customers*/
        [Authorize(Roles = "Office Specialist, Customer")]
        [HttpGet]
        public ActionResult Index(int? page)
        {

            //defualt of index is ryan
            int CustomerID;
            //int TotalAllotment;

            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            IPagedList<Customers> cstaff = null;
            //IPagedList<Customers> cAllot = null;
            CustomerRepository customerrepository = new CustomerRepository();
            Customers CustomerStaff = new Customers();
            List<Customers> obCustomerList = new List<Customers>();

            //((applicationUser)User.Identity).CustomerID
            //CustomerID = ((ApplicationUser)User.Identity).CustomerID;

            if (User.Identity.Name.Equals("ryhayandgrain@gmail.com"))
            {
                CustomerID = 760;
                //CustomerStaff.TotalAllotment = _custRepo.GetAllotment(CustomerID);

                obCustomerList = customerrepository.RequestNeedActivation(CustomerID);
                CustomerStaff.customers = obCustomerList;               
                cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
                return View(cstaff);
            }
            else if (User.Identity.Name.Equals("josh@horsleyfarms.com"))
            {
                //CustomerID = 3681;        //josh customerID
                CustomerID = 549;           //Webb Gene & Pamela 

                obCustomerList = customerrepository.RequestNeedActivation(CustomerID);
                CustomerStaff.customers = obCustomerList;
                cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
                return View(cstaff);
            }
            else
                CustomerID = 760;
                obCustomerList = customerrepository.RequestNeedActivation(CustomerID);
                CustomerStaff.customers = obCustomerList;
                cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
                return View(cstaff);
        }

        //waitlist - customer request is on hold by ditch rider because not enough water
        public ActionResult CustomerWaitList (int? page)
        {
            int CustomerID;
            //int TotalAllotment;

            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            IPagedList<Customers> cstaff = null;
            //IPagedList<Customers> cAllot = null;
            CustomerRepository customerrepository = new CustomerRepository();
            Customers CustomerStaff = new Customers();
            List<Customers> obCustomerList = new List<Customers>();

            if (User.Identity.Name.Equals("ryhayandgrain@gmail.com"))
            {
                CustomerID = 760;
                //CustomerStaff.TotalAllotment = _custRepo.GetAllotment(CustomerID);

                obCustomerList = customerrepository.WaitListCustomerRequest(CustomerID);
                CustomerStaff.customers = obCustomerList;
                cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
                return View(cstaff);
            }
            else if (User.Identity.Name.Equals("josh@horsleyfarms.com"))
            {
                //CustomerID = 3681;        //josh customerID
                CustomerID = 549;           //Webb Gene & Pamela 

                obCustomerList = customerrepository.WaitListCustomerRequest(CustomerID);
                CustomerStaff.customers = obCustomerList;
                cstaff = obCustomerList.ToPagedList(pageIndex, pageSize);
                return View(cstaff);
            }
            else
                CustomerID = 760;
                obCustomerList = customerrepository.WaitListCustomerRequest(CustomerID);
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
        public ActionResult CustomerProfile(int? page)
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
        }

        public ActionResult CustomerWaterHistory(int? page)
        {
            int CustomerID;

            int pageSize = 20;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            IPagedList<Customers> cHistory = null;
            CustomerRepository customerrepository = new CustomerRepository();
            Customers CustomerHistory = new Customers();
            List<Customers> obCustomerWaterList = new List<Customers>();

            if (User.Identity.Name.Equals("ryhayandgrain@gmail.com"))
            {
                CustomerID = 760;

                obCustomerWaterList = customerrepository.CompleteCustomerRequests(CustomerID);
                CustomerHistory.customers = obCustomerWaterList;
                cHistory = obCustomerWaterList.ToPagedList(pageIndex, pageSize);
                return View(cHistory);
            }
            else if (User.Identity.Name.Equals("josh@horsleyfarms.com"))
            {
                //CustomerID = 3681;        //Josh CustomerID
                CustomerID = 549;           //Webb Gene & Pamela 

                obCustomerWaterList = customerrepository.CompleteCustomerRequests(CustomerID);
                CustomerHistory.customers = obCustomerWaterList;
                cHistory = obCustomerWaterList.ToPagedList(pageIndex, pageSize);
                return View(cHistory);
            }
            else
                CustomerID = 760;
                obCustomerWaterList = customerrepository.CompleteCustomerRequests(CustomerID);
                CustomerHistory.customers = obCustomerWaterList;
                cHistory = obCustomerWaterList.ToPagedList(pageIndex, pageSize);
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
            int CustomerCFS1 = WaterRequest.CustomerCFS_1;
            string CustomerComments1 = WaterRequest.CustomerComments_1;

            _custRepo.AddWaterOrderRequest(WaterRequest);
            return RedirectToAction("Index");
            //return View("Index");
        }

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


        [HttpPost]
        //user can set a date range and view requests within that period
        //post will get the input from the user -> get will read input and apply
        public ActionResult View_SetDate_CustomerRequest(Customers DateRange, FormCollection form)
        {
            int CustomerID = 760;

            if (!ModelState.IsValid)
            {
                return View(DateRange);
            }

            //reference input name from BeginForm
            string StartDate = form["Input_StartDate"];
            string EndDate = form["Input_EndDate"];

            DateRange.CustomerID = CustomerID;
            DateRange.StartDate = Convert.ToDateTime(StartDate);
            DateRange.EndDate = Convert.ToDateTime(EndDate);

            //DateTime Input_StartDate = Convert.ToDateTime(StartDate);
            //DateTime Input_EndDate = Convert.ToDateTime(EndDate);

            //obCustomerRangeList = _custRepo.ViewRequestDates(CustomerID, DateRange.StartDate, DateRange.EndDate);



            //return RedirectToAction("View_SetDate_CustomerRequest");
            //return View("View_SetDate_CustomerRequest", new {CustomerID = DateRange.CustomerID, StartDate = DateRange.StartDate, EndDate = DateRange.EndDate });
            //return View("View_SetDate_CustomerRequest", obCustomerRangeList);
            return View("View_SetDate_CustomerRequest");
        }

        [HttpGet]
        //receive data input from 'HttpPost' and will then display it
        public ActionResult View_SetDate_CustomerRequest(int? page)
        {
            //hard coded Ryan's info
            //int CustomerID = 760;
            //DateTime Input_StartDate;
            //DateTime Input_EndDate;
            //int CustomerID = 760;

            int pageSize = 20;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            IPagedList<Customers> cDateHistory = null;
            CustomerRepository customerrepository = new CustomerRepository();
            Customers CustomerRangeHistory = new Customers();
            List<Customers> obCustomerRangeList = new List<Customers>();

            //obCustomerRangeList = customerrepository.ViewRequestDates(CustomerID, Input_StartDate, Input_EndDate);
            CustomerRangeHistory.customers = obCustomerRangeList;
            cDateHistory = obCustomerRangeList.ToPagedList(pageIndex, pageSize);

            return View(cDateHistory);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //functionality for specific people under the customer side

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