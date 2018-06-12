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

        //--------------------------------------------------------------------------------------------
        //enable the office staff to establish customer login and set their roles
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
        //-------------------------------------------------------------------------------------------------------------------------------------

        //set the connection with the repository to that of controller
        private ICustomerRepository _custRepo;

        public CustomersController()
        {
            _custRepo = new CustomerRepository();
        }

        /* View Active Requests On
         * Page: Index
         * Repository: getCustomerID, ActiveRequests(id)*/
        [HttpGet]
        public ActionResult Index(int? id)
        {
            //ryhayandgrain@gmail.com       ID = 760
            //josh@horsleyfarms.com         ID = 3681
            if (!id.HasValue)
            {
                //pull out of a repository - Username (Email)
                string userID = User.Identity.Name;
                id = _custRepo.getCustomerID(userID);       //See Repository
                                               
                //pass the user's customerID to the URL
                return RedirectToAction("Index", new { id = id });
            }

            if (!User.IsInRole("Customer"))
            {
                return View("Unauthorized");
            }
                    
             //this will establish current allotment at the menu bar
             ViewBag.CurrentAllotment = _custRepo.getCurrentAllotment(id.Value);

            var std = _custRepo.ActiveRequests(id.Value);
            return View(std);

        }

        /* Allow user to see the water request page
         * Page:    CustomerAddRequest
         *          -Website: under 'requests'*/
        [HttpGet]
        public ActionResult CustomerAddRequest(int ID)
        {
            if (!User.IsInRole("Customer"))
            {
                return View("Unauthorized");
            }

            //passes the customers into info
            List<Customers> info = _custRepo.ViewCustomers(ID);

            //this will establish current allotment at the menu bar
            ViewBag.CurrentAllotment = _custRepo.getCurrentAllotment(ID);

            //populate the structure dropdown
            ViewData["Structure"] = _custRepo.getStructure(ID).Select(s => new SelectListItem() { Text = s.Structure, Value = s.Structure }).ToList();

            //only takes one customer - apply 'First' function
            return View(info.First());
        }

        /* Allow user to input information for water request page
         * Page:        CustomerAddRequest
         * Repository:  AddWaterOrderRequest*/
        [Authorize(Roles = "Office Specialist, Customer")]
        [HttpPost]
        public ActionResult CustomerAddRequest(Customers WaterRequest)
        {
            _custRepo.AddWaterOrderRequest(WaterRequest);
            return new RedirectResult(Url.Action("Index/" + Url.RequestContext.RouteData.Values["id"]));
        }

        /* View Customer's recent requests - need approval (RequestStatus)
          * Page: CustomerRecentRequest
          * Repository: RecentRequest(id)*/
        public ActionResult CustomerRecentRequest(int id)
        {
            //this will establish current allotment at the menu bar
            ViewBag.CurrentAllotment = _custRepo.getCurrentAllotment(id);

            var std = _custRepo.RecentRequests(id);
            return View(std);
        }

        /* View the Requests that have been waitlisted
         * Page: CustomerWaitList
         * Repository: WaitListCustomerRequest(id)*/
        public ActionResult CustomerWaitList(int id)
        {
            //this will establish current allotment at the menu bar
            ViewBag.CurrentAllotment = _custRepo.getCurrentAllotment(id);

            var std = _custRepo.WaitListCustomerRequest(id);
            return View(std);

        }

        /* View the employees of KID - contact info
         * Page:        ContactsPage
         * Repository:  ViewStaff()*/
        public ActionResult ContactsPage()
        {
            if (!User.IsInRole("Customer"))
            {
                return View("Unauthorized");
            }

            var std = _custRepo.ViewStaff();
            return View(std);
        }

        /* View the Profile of the customer (Address) along with their total allotment for year
         * with any violations that they may have accrued
         * Page:        CustomerProfile
         * Repository:  ViewCustomers(id)*/
        public ActionResult CustomerProfile(int id)
        {
            //this will establish current allotment at the menu bar
            ViewBag.CurrentAllotment = _custRepo.getCurrentAllotment(id);

            var std = _custRepo.ViewCustomers(id);
            return View(std);
        }

        /* customer can view their history of requests
         * Page:        CustomerWaterHistory
         * Repository:  CompleteCustomerRequests(id)*/
        [OutputCache(Duration = 500, VaryByParam = "CustomerID")]
        public ActionResult CustomerWaterHistory(int id, int? page)
        {
            if (!User.IsInRole("Customer"))
            {
                return View("Unauthorized");
            }

            //this will establish current allotment at the menu bar
            ViewBag.CurrentAllotment = _custRepo.getCurrentAllotment(id);

            int pageSize = 15;
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

        //AddCustomer
        /* Allow the office staff to add a customer
         * Page: AddCustomer */
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
            var cust = _custRepo.ViewCustomers(CustomerID).Where(s => s.CustomerID == CustomerID).FirstOrDefault();
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
            float TotalAllotment = cust.TotalAllotment;
            _custRepo.Save(cust);
            //_custRepo.ViewCustomerRequests(cust.CustomerID);     //given edit -> change history
            return RedirectToAction("Index");
        }

    }
}