using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.Controllers
{
    public class DitchRidersController : Controller
    {
        private IDitchRidersRepository _ditchRiderRepo;
        public DitchRidersController()
        {
            _ditchRiderRepo = new DitchRidersRepository();
        }
        /*-------------------------------------------
         --------RIDE 4----------------------------*/
         
        //View Active Requests On
        //ViewActiveRequestsOn4()
        //Page: _ActiveRequestsOn4.cshtml
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpGet]
        public ActionResult Index4(int? page)
        {
            int pageSize = 25;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewActiveRequestOn4();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }
        //ViewActiveRequestsOn4()
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult _ActiveRequestsOn4()
        {
            var std = _ditchRiderRepo.ViewActiveRequestOn4();
            return View(std);
        }

        //Turn On Water For an Active Request
        //ViewActiveRequestOn4()
        //Page: EditRequest4On
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult EditRequest4On(int RequestID)
        {
            ViewData["S"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["StaffComments2"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            var std = _ditchRiderRepo.ViewActiveRequestOn4().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
        //EditRequests4On
        [Authorize(Roles = "Ride 4 ,Relief Ride 4")]
        [HttpPost]
        public ActionResult EditRequest4On(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            string Staff1 = std.Staff1;
            DateTime StaffDate1 = std.StaffDate1;
            int StaffCFS1 = std.StaffCFS1;
            string StaffComments1 = std.StaffComments1;
            string RequestStatus1 = std.RequestStatus1;
            _ditchRiderRepo.EditRequest4On(std);
            return RedirectToAction("Index4");
        }

        //View Active Requests Off
        //ViewActiveRequestOff4()
        //Page: _ActiveRequestsOff4
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpGet]
        public ActionResult _ActiveRequestsOff4(int? page)
        {
            int pageSize = 25;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewActiveRequestOff4();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }

        //Turn Off Water For an Active Off Request
        //ViewActiveRequestOff4()
        //Page: EditRequests4Off
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult EditRequest4Off(int RequestID)
        {
            var std = _ditchRiderRepo.ViewActiveRequestOff4().Where(s => s.RequestID == RequestID).FirstOrDefault();
            ViewData["S"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["StaffComments2"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            return View(std);
        }
        //EditRequests4Off
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpPost]
        public ActionResult EditRequest4Off(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            DateTime StaffDate2 = std.StaffDate2;
            int StaffCFS2 = std.StaffCFS2;
            string StaffComments2 = std.StaffComments2;
            _ditchRiderRepo.EditRequest4Off(std);
            return RedirectToAction("Index4");
        }

        //View Pending On Requests
        //ViewPending_4On()
        //Page: Appending_4On
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpGet]
        public ActionResult Appending_4On(int? page)
        {
            int pageSize = 25;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewPending_4On();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }

        //Edit Request Status On
        //ViewPending_4On()
        //Page: EditRequestStatus_On
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult EditRequestStatus_On(int RequestID)
        {
            var std = _ditchRiderRepo.ViewPending_4On().Where(s => s.RequestID == RequestID).FirstOrDefault();
            //Drop down pulling form SQL
            ViewData["S"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["StaffComments2"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            return View(std);
        }
        //EditRequestStatus1_On
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpPost]
        public ActionResult EditRequestStatus_On(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            string Staff1 = std.Staff1;
            string StaffComments1 = std.StaffComments1;
            string RequestStatus1 = std.RequestStatus1;
            _ditchRiderRepo.EditRequestStatus1_On(std);
            if (User.IsInRole("Ride 1, Relief Ride 1"))
            {
                return RedirectToAction("Index1");
            }
            else if (User.IsInRole("Ride 2, Relief Ride 2"))
            {
                return RedirectToAction("Index2");
            }
            else if (User.IsInRole("Ride 3, Relief Ride 3"))
            {
                return RedirectToAction("Index3");
            }
            else if (User.IsInRole("Ride 4, Relief Ride 4"))
            {
                return RedirectToAction("Index4");
            }
            else if (User.IsInRole("Ride 5, Relief Ride 5"))
            {
                return RedirectToAction("Index5");
            }
            else if (User.IsInRole("Ride 6, Relief Ride 6"))
            {
                return RedirectToAction("Index6");
            }
            else if (User.IsInRole("Ride 7, Relief Ride 7"))
            {
                return RedirectToAction("Index7");
            }
            else if (User.IsInRole("Ride 8, Relief Ride 8"))
            {
                return RedirectToAction("Index8");
            }
            return RedirectToAction("Index");
        }

        //View Pending Off Requests 
        //ViewPending_4Off()
        //Page: Appending_4Off
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpGet]
        public ActionResult Appending_4Off(int? page)
        {
            int pageSize = 25;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewPending_4Off();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }
        
        //Edit Request Status Off
        //ViewPending_4Off()
        //Page: EditRequests4On
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult EditRequestStatus_Off(int RequestID)
        {
            var std = _ditchRiderRepo.ViewPending_4Off().Where(s => s.RequestID == RequestID).FirstOrDefault();
            ViewData["S"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["StaffComments2"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            return View(std);
        }
        //EditRequestStatus2_Off()
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpPost]
        public ActionResult EditRequestStatus_Off(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            string Staff2 = std.Staff2;
            string StaffComments2 = std.StaffComments2;
            string RequestStatus2 = std.RequestStatus2;
            _ditchRiderRepo.EditRequestStatus2_Off(std);
            if (User.IsInRole("Ride 1"))
            {
                return RedirectToAction("Index1");
            }
            else if (User.IsInRole("Ride 2"))
            {
                return RedirectToAction("Index2");
            }
            else if (User.IsInRole("Ride 3"))
            {
                return RedirectToAction("Index3");
            }
            else if (User.IsInRole("Ride 4"))
            {
                return RedirectToAction("Index4");
            }
            else if (User.IsInRole("Ride 5"))
            {
                return RedirectToAction("Index5");
            }
            else if (User.IsInRole("Ride 6"))
            {
                return RedirectToAction("Index6");
            }
            else if (User.IsInRole("Ride 7"))
            {
                return RedirectToAction("Index7");
            }
            else if (User.IsInRole("Ride 8"))
            {
                return RedirectToAction("Index8");
            }
            return RedirectToAction("Index");
        }
        
        //View Completed On and Off Requests
        //ViewRequests4()
        //Page: CompletedRequests
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult CompletedRequests(int? page)
        {
            int pageSize = 25;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewRequests4();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }

        //View WaitList On
        //ViewWaitlist_4On()
        //Page: WaitList_4On
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult WaitList_4On(int? page)
        {
            int pageSize = 25;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewWaitlist_4On();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }

        //Turn On WaitList Water
        //ViewWaitlist_4On()
        //Page: EditRequest4On
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult EditWaitList_4On(int RequestID)
        {
            ViewData["S"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["StaffComments2"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            var std = _ditchRiderRepo.ViewWaitlist_4On().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
        //EditRequests4On
        [Authorize(Roles = "Ride 4 ,Relief Ride 4")]
        [HttpPost]
        public ActionResult EditWaitList_4On(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            string Staff1 = std.Staff1;
            DateTime StaffDate1 = std.StaffDate1;
            int StaffCFS1 = std.StaffCFS1;
            string StaffComments1 = std.StaffComments1;
            string RequestStatus1 = std.RequestStatus1;
            _ditchRiderRepo.EditRequest4On(std);
            return RedirectToAction("Index4");
        }

        //View WaitList Off
        //ViewWaitlist_4Off()
        //Page: WaitList_4Off
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult WaitList_4Off(int? page)
        {
            int pageSize = 25;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewWaitlist_4Off();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }

        //Turn Off Waitlist Water
        //ViewWaitlist_4Off()
        //Page: EditRequests4Off
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult EditWaitList_4Off(int RequestID)
        {
            var std = _ditchRiderRepo.ViewWaitlist_4Off().Where(s => s.RequestID == RequestID).FirstOrDefault();
            ViewData["S"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["StaffComments2"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            return View(std);
        }
        //EditRequests4Off
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpPost]
        public ActionResult EditWaitList_4Off(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            DateTime StaffDate2 = std.StaffDate2;
            int StaffCFS2 = std.StaffCFS2;
            string StaffComments2 = std.StaffComments2;
            _ditchRiderRepo.EditRequest4Off(std);
            return RedirectToAction("Index4");
        }
        
        //Customer List
        //Customers4()
        //Page: Customers4()
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpGet]
        public ActionResult Customers4(int? page)
        {
            int pageSize = 25;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.Customers4();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }

        //Turn On Water as if Customer
        //Customers4
        //Page: AddRequest4On
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult AddRequest4On(string Structure)
        {
            var std = _ditchRiderRepo.Customers4().Where(s => s.Structure == Structure).FirstOrDefault();
            return View(std);
        }
        //AddRequest_4On()
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpPost]
        public ActionResult AddRequest4On(DitchRiderRequests ditchriderrequests)
        {
            int RequestID = ditchriderrequests.RequestID;
            int CustomerID = ditchriderrequests.CustomerID;
            string structure = ditchriderrequests.Structure;
            string Name = ditchriderrequests.CustomerName;
            DateTime CustomerDate1 = ditchriderrequests.CustomerDate1;
            int CustomerCFS1 = ditchriderrequests.CustomerCFS1;
            string CustomerComments1 = ditchriderrequests.CustomerComments1;
            _ditchRiderRepo.AddRequest_4On(ditchriderrequests);
            return RedirectToAction("Customers4");
        }

        //Customers who currently have water on
        //ViewCustomersWithWater_4On()
        //Page: Customers_4On()
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpGet]
        public ActionResult Customers_4On(int? page)
        {
            int pageSize = 25;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewCustomersWithWater_4On();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }
        
        //Request Water Off as if Customer
        //ViewCustomersWithWater_4On()
        //Page: _AddRequest4Off
        [Authorize(Roles = "Ride 4 ,Relief Ride 4")]
        //[HttpGet]
        public ActionResult _AddRequest4Off(int RequestID)
        {
            var std = _ditchRiderRepo.ViewCustomersWithWater_4On().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
        //AddRequest_4Off()
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpPost]
        public ActionResult _AddRequest4Off(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            DateTime CustomerDate2 = std.CustomerDate2;
            string Structure = std.Structure;
            int CustomerCFS2 = std.CustomerCFS2;
            string CustomerComments2 = std.CustomerComments2;
            _ditchRiderRepo.AddRequest_4Off(std);
            return RedirectToAction("Customers4");
        }
        
        //View Water in Canal
        //WaterCFS_NextDayByCanal()
        //CanalWater.cshtml    
        public ActionResult CanalWater()
        {
            return View();            
        }
        //View Water in next day canal
        //ViewActiveRequestsOn4()
        //Page: _ActiveRequstsOn4
        public ActionResult _CanalCFS(int CFS)
        {
            return View(CFS);
        }
                
        //OutputCache 
        //ViewRequests4()
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult ViewRequests4(int RequestID)
        {
            DitchRiderRequests ditchriderrequests = _ditchRiderRepo.Get(RequestID);
            DitchRiderRequests DitchRiderModel = new DitchRiderRequests()
            {
                RequestID = ditchriderrequests.RequestID,
                TimeStampCustomer1 = ditchriderrequests._Getdate,
                CustomerDate1 = ditchriderrequests.CustomerDate1,
                CustomerID = ditchriderrequests.CustomerID,
                CustomerName = ditchriderrequests.CustomerName,
                Structure = ditchriderrequests.Structure,
                CustomerCFS1 = ditchriderrequests.CustomerCFS1,
                TimeStampStaff1 = ditchriderrequests._Getdate,
                Staff1 = ditchriderrequests.Staff1,
                StaffDate1 = ditchriderrequests.StaffDate1,
                RequestStatus1 = ditchriderrequests.RequestStatus1,
                StaffCFS1 = ditchriderrequests.StaffCFS1,
                StaffComments1 = ditchriderrequests.StaffComments1,
                CustomerDate2 = ditchriderrequests.CustomerDate2,
                CustomerCFS2 = ditchriderrequests.CustomerCFS2,
                TimeStampStaff2 = ditchriderrequests._Getdate,
                Staff2 = ditchriderrequests.Staff2,
                StaffDate2 = ditchriderrequests.StaffDate2,
                RequestStatus2 = ditchriderrequests.RequestStatus2,
                StaffCFS2 = ditchriderrequests.StaffCFS2,
                StaffComments2 = ditchriderrequests.StaffComments2,
            };
            return ViewRequests4(RequestID);
        }


        
        /*---------------------------------------------------------------
          ------RIDE 5 ---------------------------------------------*/
        /*Ride 5*/
        //Index Ride 5
        [Authorize(Roles = "Ride 5, Relief Ride 5")]
        [HttpGet]
        public ActionResult Index5(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewRequests5();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }

        //Ditch Rider Edit Request Ride 5 On
        [Authorize(Roles = "Ride 5, Relief Ride 5")]
        public ActionResult EditRequest5On(int RequestID)
        {
            var std = _ditchRiderRepo.ViewRequests5().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }


        [Authorize(Roles = "Ride 5, Relief Ride 5")]
        [HttpPost]
        public ActionResult EditRequest5On(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            DateTime StaffDate1 = std.StaffDate1;
            int StaffCFS1 = std.StaffCFS1;
            string StaffComments1 = std.StaffComments1;
            _ditchRiderRepo.EditRequest5On(std);
            return RedirectToAction("Index5");
        }

        //Ditch Rider Edit Request Ride 5 Off
        [Authorize(Roles = "Ride 5, Relief Ride 5")]
        public ActionResult EditRequest5Off(int RequestID)
        {
            var std = _ditchRiderRepo.ViewRequests5().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }


        [Authorize(Roles = "Ride 5, Relief Ride 5")]
        [HttpPost]
        public ActionResult EditRequest5Off(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            DateTime StaffDate2 = std.StaffDate2;
            int StaffCFS2 = std.StaffCFS2;
            string StaffComments2 = std.StaffComments2;
            _ditchRiderRepo.EditRequest5Off(std);
            return RedirectToAction("Index5");
        }
        
        //Ditch Rider Add Request as if Customer Ride 5
        [Authorize(Roles = "Ride 5, Relief Ride 5")]
        [HttpGet]
        public ActionResult AddRequest5On()
        {
            return View(new DitchRiderRequests());
        }
        
        [Authorize(Roles = "Ride 5, Relief Ride 5")]
        [HttpPost]
        public ActionResult AddRequest5On(DitchRiderRequests ditchriderrequests)
        {
            if (!ModelState.IsValid)
            {
                return View(ditchriderrequests);
            }
            _ditchRiderRepo.AddRequest5On(ditchriderrequests);
            return RedirectToAction("Index5");
        }
        
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult ViewRequests5(int RequestID)
        {
            DitchRiderRequests ditchriderrequests = _ditchRiderRepo.Get(RequestID);
            DitchRiderRequests DitchRiderModel = new DitchRiderRequests()
            {
                RequestID = ditchriderrequests.RequestID,
                TimeStampCustomer1 = ditchriderrequests._Getdate,
                CustomerDate1 = ditchriderrequests.CustomerDate1,
                CustomerID = ditchriderrequests.CustomerID,
                CustomerName = ditchriderrequests.CustomerName,
                Structure = ditchriderrequests.Structure,
                CustomerCFS1 = ditchriderrequests.CustomerCFS1,
                TimeStampStaff1 = ditchriderrequests._Getdate,
                Staff1 = ditchriderrequests.Staff1,
                StaffDate1 = ditchriderrequests.StaffDate1,
                RequestStatus1 = ditchriderrequests.RequestStatus1,
                StaffCFS1 = ditchriderrequests.StaffCFS1,
                StaffComments1 = ditchriderrequests.StaffComments1,
                CustomerDate2 = ditchriderrequests.CustomerDate2,
                CustomerCFS2 = ditchriderrequests.CustomerCFS2,
                TimeStampStaff2 = ditchriderrequests._Getdate,
                Staff2 = ditchriderrequests.Staff2,
                StaffDate2 = ditchriderrequests.StaffDate2,
                RequestStatus2 = ditchriderrequests.RequestStatus2,
                StaffCFS2 = ditchriderrequests.StaffCFS2,
                StaffComments2 = ditchriderrequests.StaffComments2,
            };
            return ViewRequests5(RequestID);
        }
    }
}