using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
         
        //View Active Requests On
        //ViewActiveRequestsOn4()
        //Page: _ActiveRequestsOn4.cshtml
        //[Authorize]
        //[HttpGet]
        //public ActionResult _ActiveRequestsOn(int id, int? page)
        //{
        //    if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }
        //    int pageSize = 25;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    IPagedList<DitchRiderRequests> ditchRider = null;
        //    DitchRidersRepository repository = new DitchRidersRepository();
        //    DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
        //    List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
        //    obditchriderlist = repository.ViewActiveRequestOn(id);
        //    ditchriderrequests.ditchriderrequests = obditchriderlist;
        //    ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
        //    var std = _ditchRiderRepo.ViewActiveRequestOn(id);
        //    return View(ditchRider);
        //}
        //ViewActiveRequestsOn4()
        [Authorize]
        public ActionResult _ActiveRequestsOn(int id)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewActiveRequestOn(id);
            return View(std);
        }
        //drop down for violations bassed off of drop down for Comments
        public JsonResult Violations(string Comments)
        {
            ViewData["Comments"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            if(ViewData["Comments"].Equals("Other"))
            {
                ViewData["Violations"] = _ditchRiderRepo.Violations().Select(s => new SelectListItem() { Text = s.Violation, Value = s.Violation }).ToList();
            }
            else
            {
                ViewData["Comments"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            }
            return Json(ViewData);
        }
        //Turn On Water For an Active Request
        //ViewActiveRequestOn4()
        //Page: EditRequest4On
        [Authorize]
        public ActionResult EditRequestOn(int id, int RequestID, string Other, string lateral)
        {

            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            ViewData["Status"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["Comments"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            ViewData["Violations"] = _ditchRiderRepo.Violations().Select(s => new SelectListItem() { Text = s.Violation, Value = s.Violation }).ToList();
            ViewData["Today"] = _ditchRiderRepo.WaterCFS_TodayByCanal(lateral);
            ViewData["Tomorrow"] = _ditchRiderRepo.WaterCFS_NextDayByCanal(lateral);

            var std = _ditchRiderRepo.ViewActiveRequestOn(id).Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
        //EditRequests4On
        [Authorize]
        [HttpPost]
        public ActionResult EditRequestOn(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            string Staff1 = std.Staff1;
            DateTime StaffDate1 = std.StaffDate1;
            int StaffCFS1 = std.StaffCFS1;
            string StaffComments1 = std.StaffComments1;
            string RequestStatus1 = std.RequestStatus1;
            _ditchRiderRepo.EditRequestOn(std);
            return new RedirectResult(Url.Action("_ActiveRequestsOn/" + Url.RequestContext.RouteData.Values["id"]));
        }

        //View Active Requests Off
        //ViewActiveRequestOff4()
        //Page: _ActiveRequestsOff4
        //[Authorize]
        //[HttpGet]
        //public ActionResult _ActiveRequestsOff(int id, int? page)
        //{
        //    if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }
        //    int pageSize = 25;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    IPagedList<DitchRiderRequests> ditchRider = null;
        //    DitchRidersRepository repository = new DitchRidersRepository();
        //    DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
        //    List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
        //    obditchriderlist = repository.ViewActiveRequestOff(id);
        //    ditchriderrequests.ditchriderrequests = obditchriderlist;
        //    ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
        //    return View(ditchRider);
        //}
        [Authorize]
        [HttpGet]
        public ActionResult _ActiveRequestsOff(int id)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewActiveRequestOff(id);
            return View(std);
        }
        //Turn Off Water For an Active Off Request
        //ViewActiveRequestOff4()
        //Page: EditRequests4Off
        [Authorize]
        public ActionResult EditRequestOff(int id, int RequestID, string lateral)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewActiveRequestOff(id).Where(s => s.RequestID == RequestID).FirstOrDefault();
            ViewData["Status"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["Comments"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            ViewData["Today"] = _ditchRiderRepo.WaterCFS_TodayByCanal(lateral);
            ViewData["Tomorrow"] = _ditchRiderRepo.WaterCFS_NextDayByCanal(lateral);

            return View(std);
        }
        //EditRequests4Off
        [Authorize]
        [HttpPost]
        public ActionResult EditRequestOff(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            DateTime StaffDate2 = std.StaffDate2;
            int StaffCFS2 = std.StaffCFS2;
            string StaffComments2 = std.StaffComments2;
            _ditchRiderRepo.EditRequestOff(std);
            return new RedirectResult(Url.Action("_ActiveRequestsOff/" + Url.RequestContext.RouteData.Values["id"]));
        }

        //View Pending On Requests
        //ViewPending_4On()
        //Page: Appending_4On
        [Authorize]
        [HttpGet]
        //public ActionResult Appending_On(int id, int? page)
        //{
        //    if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }
        //    int pageSize = 25;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    IPagedList<DitchRiderRequests> ditchRider = null;
        //    DitchRidersRepository repository = new DitchRidersRepository();
        //    DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
        //    List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
        //    obditchriderlist = repository.ViewPending_On(id);
        //    ditchriderrequests.ditchriderrequests = obditchriderlist;
        //    ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
        //    return View(ditchRider);
        //}
        public ActionResult Appending_On(int id)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewPending_On(id);
            return View(std);
        }

        //Edit Request Status On
        //ViewPending_4On()
        //Page: EditRequestStatus_On
        [Authorize]
        public ActionResult EditRequestStatus_On(int id, int RequestID, string lateral)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewPending_On(id).Where(s => s.RequestID == RequestID).FirstOrDefault();
            //Drop down pulling form SQL
            ViewData["Status"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["Comments"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            ViewData["Today"] = _ditchRiderRepo.WaterCFS_TodayByCanal(lateral);
            ViewData["Tomorrow"] = _ditchRiderRepo.WaterCFS_NextDayByCanal(lateral);

            return View(std);
        }
        //EditRequestStatus1_On
        [Authorize]
        [HttpPost]
        public ActionResult EditRequestStatus_On(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            string Staff1 = std.Staff1;
            string StaffComments1 = std.StaffComments1;
            string RequestStatus1 = std.RequestStatus1;
            _ditchRiderRepo.EditRequestStatus1_On(std);
            return new RedirectResult(Url.Action("Appending_On/" + Url.RequestContext.RouteData.Values["id"]));
        }

        //View Pending Off Requests 
        //ViewPending_4Off()
        //Page: Appending_4Off
        [Authorize]
        [HttpGet]
        //public ActionResult Appending_Off(int id, int? page)
        //{
        //    if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }
        //    int pageSize = 25;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    IPagedList<DitchRiderRequests> ditchRider = null;
        //    DitchRidersRepository repository = new DitchRidersRepository();
        //    DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
        //    List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
        //    obditchriderlist = repository.ViewPending_Off(id);
        //    ditchriderrequests.ditchriderrequests = obditchriderlist;
        //    ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
        //    return View(ditchRider);
        //}
        public ActionResult Appending_Off(int id)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewPending_Off(id);
            return View(std);
        }

        //Edit Request Status Off
        //ViewPending_4Off()
        //Page: EditRequests4On
        [Authorize]
        public ActionResult EditRequestStatus_Off(int id, int RequestID, string lateral)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewPending_Off(id).Where(s => s.RequestID == RequestID).FirstOrDefault();
            ViewData["Status"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["Comments"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            ViewData["Today"] = _ditchRiderRepo.WaterCFS_TodayByCanal(lateral);
            ViewData["Tomorrow"] = _ditchRiderRepo.WaterCFS_NextDayByCanal(lateral);

            return View(std);
        }
        //EditRequestStatus2_Off()
        [Authorize]
        [HttpPost]
        public ActionResult EditRequestStatus_Off(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            string Staff2 = std.Staff2;
            string StaffComments2 = std.StaffComments2;
            string RequestStatus2 = std.RequestStatus2;
            _ditchRiderRepo.EditRequestStatus2_Off(std);
            return new RedirectResult(Url.Action("Appending_Off/"+ Url.RequestContext.RouteData.Values["id"]));
        }
        
        //View Completed On and Off Requests
        //ViewRequests4()
        //Page: CompletedRequests
        [Authorize]
        //public ActionResult CompletedRequests(int id, int? page)
        //{
        //    if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }
        //    int pageSize = 25;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    IPagedList<DitchRiderRequests> ditchRider = null;
        //    DitchRidersRepository repository = new DitchRidersRepository();
        //    DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
        //    List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
        //    obditchriderlist = repository.ViewRequests(id);
        //    ditchriderrequests.ditchriderrequests = obditchriderlist;
        //    ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
        //    return View(ditchRider);
        //}
        public ActionResult CompletedRequests(int id)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewRequests(id);
            return View(std);
        }

        //View WaitList On
        //ViewWaitlist_4On()
        //Page: WaitList_4On
        [Authorize]
        //public ActionResult WaitList_On(int id, int? page)
        //{
        //    if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }
        //    int pageSize = 25;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    IPagedList<DitchRiderRequests> ditchRider = null;
        //    DitchRidersRepository repository = new DitchRidersRepository();
        //    DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
        //    List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
        //    obditchriderlist = repository.ViewWaitlist_On(id);
        //    ditchriderrequests.ditchriderrequests = obditchriderlist;
        //    ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
        //    return View(ditchRider);
        //}
        public ActionResult WaitList_On(int id)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewWaitlist_On(id);
            return View(std);
        }

        //Turn On WaitList Water
        //ViewWaitlist_4On()
        //Page: EditRequest4On
        [Authorize]
        public ActionResult EditWaitList_On(int id, int RequestID, string lateral)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            ViewData["Status"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["Comments"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            ViewData["Today"] = _ditchRiderRepo.WaterCFS_TodayByCanal(lateral);
            ViewData["Tomorrow"] = _ditchRiderRepo.WaterCFS_NextDayByCanal(lateral);

            var std = _ditchRiderRepo.ViewWaitlist_On(id).Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
        //EditRequests4On
        [Authorize]
        [HttpPost]
        public ActionResult EditWaitList_On(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            string Staff1 = std.Staff1;
            DateTime StaffDate1 = std.StaffDate1;
            int StaffCFS1 = std.StaffCFS1;
            string StaffComments1 = std.StaffComments1;
            string RequestStatus1 = std.RequestStatus1;
            _ditchRiderRepo.EditRequestOn(std);
            return new RedirectResult(Url.Action("WaitList_On/" + Url.RequestContext.RouteData.Values["id"]));
        }

        //View WaitList Off
        //ViewWaitlist_4Off()
        //Page: WaitList_4Off
        [Authorize]
        //public ActionResult WaitList_Off(int id, int? page)
        //{
        //    if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }
        //    int pageSize = 25;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    IPagedList<DitchRiderRequests> ditchRider = null;
        //    DitchRidersRepository repository = new DitchRidersRepository();
        //    DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
        //    List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
        //    obditchriderlist = repository.ViewWaitlist_Off(id);
        //    ditchriderrequests.ditchriderrequests = obditchriderlist;
        //    ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
        //    return View(ditchRider);
        //}
        public ActionResult WaitList_Off(int id)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewWaitlist_Off(id);
            return View(std);
        }

        //Turn Off Waitlist Water
        //ViewWaitlist_4Off()
        //Page: EditRequests4Off
        [Authorize]
        public ActionResult EditWaitList_Off(int id, int RequestID, string lateral)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewWaitlist_Off(id).Where(s => s.RequestID == RequestID).FirstOrDefault();
            ViewData["Status"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["Comments"] = _ditchRiderRepo.Comments().Select(s => new SelectListItem() { Text = s.Comment, Value = s.Comment }).ToList();
            ViewData["Today"] = _ditchRiderRepo.WaterCFS_TodayByCanal(lateral);
            ViewData["Tomorrow"] = _ditchRiderRepo.WaterCFS_NextDayByCanal(lateral);

            return View(std);
        }
        //EditRequests4Off
        [Authorize]
        [HttpPost]
        public ActionResult EditWaitList_Off(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            DateTime StaffDate2 = std.StaffDate2;
            int StaffCFS2 = std.StaffCFS2;
            string StaffComments2 = std.StaffComments2;
            _ditchRiderRepo.EditRequestOff(std);
            return new RedirectResult(Url.Action("WaitList_Off/" + Url.RequestContext.RouteData.Values["id"]));
        }

        //Customer List
        //Customers4()
        //Page: Customers4()
        //[Authorize]
        //[HttpGet]
        //public ActionResult Customers4(int id, int? page)
        //{
        //    if(!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }
        //    int pageSize = 25;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    IPagedList<DitchRiderRequests> ditchRider = null;
        //    DitchRidersRepository repository = new DitchRidersRepository();
        //    DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
        //    List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
        //    obditchriderlist = repository.Customers4(id);
        //    ditchriderrequests.ditchriderrequests = obditchriderlist;
        //    ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
        //    return View(ditchRider);
        //}
        [Authorize]
        [HttpGet]
        public ActionResult Customers(int id)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.Customers(id);
            return View(std);
        }

        //Turn On Water as if Customer
        //Customers4
        //Page: AddRequest4On
        [Authorize]
        //public ActionResult AddRequestOn(int id, string Structure)
        //{
        //    if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }
        //    ViewData["Status"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
        //    var std = _ditchRiderRepo.Customers(id).Where(s => s.Structure == Structure).FirstOrDefault();

        //    return View(std);
        //}
        public ActionResult AddRequestOn(int id, string Structure, string lateral)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            ViewData["Status"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();       
            ViewData["Today"] = _ditchRiderRepo.WaterCFS_TodayByCanal(lateral);
            ViewData["Tomorrow"] = _ditchRiderRepo.WaterCFS_NextDayByCanal(lateral);
            var std = _ditchRiderRepo.Customers(id).Where(s => s.Structure == Structure).FirstOrDefault();              
            
            return View(std);
        }
        //AddRequest_4On()
        [Authorize]
        [HttpPost]
        public ActionResult AddRequestOn(DitchRiderRequests ditchriderrequests)
        {
            int RequestID = ditchriderrequests.RequestID;
            int CustomerID = ditchriderrequests.CustomerID;
            string structure = ditchriderrequests.Structure;
            string Name = ditchriderrequests.CustomerName;            
            DateTime CustomerDate1 = ditchriderrequests.CustomerDate1;
            int CustomerCFS1 = ditchriderrequests.CustomerCFS1;
            string CustomerComments1 = ditchriderrequests.CustomerComments1;
            //string Ride = ditchriderrequests.Ride;
            int Ride = ditchriderrequests.Ride;
            string RequestStatus1 = ditchriderrequests.RequestStatus1;
            _ditchRiderRepo.AddRequest_On(ditchriderrequests);
            return new RedirectResult(Url.Action("Customers/" + Url.RequestContext.RouteData.Values["id"]));
        }

        //Customers who currently have water on
        //ViewCustomersWithWater_4On()
        //Page: Customers_4On()
        [Authorize]
        [HttpGet]
        //public ActionResult Customers_On(int id, int? page)
        //{
        //    if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }
        //    int pageSize = 25;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    IPagedList<DitchRiderRequests> ditchRider = null;
        //    DitchRidersRepository repository = new DitchRidersRepository();
        //    DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
        //    List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
        //    obditchriderlist = repository.ViewCustomersWithWater_On(id);
        //    ditchriderrequests.ditchriderrequests = obditchriderlist;
        //    ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
        //    return View(ditchRider);
        //}
        public ActionResult Customers_On(int id)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            var std = _ditchRiderRepo.ViewCustomersWithWater_On(id);
            return View(std);
        }

        //Request Water Off as if Customer
        //ViewCustomersWithWater_4On()
        //Page: _AddRequest4Off
        [Authorize]
        //[HttpGet]
        public ActionResult _AddRequestOff(int id, int RequestID, string lateral)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            ViewData["Status"] = _ditchRiderRepo.Status().Select(s => new SelectListItem() { Text = s.RequestStatusName, Value = s.RequestStatusName }).ToList();
            ViewData["Today"] = _ditchRiderRepo.WaterCFS_TodayByCanal(lateral);
            ViewData["Tomorrow"] = _ditchRiderRepo.WaterCFS_NextDayByCanal(lateral);
            var std = _ditchRiderRepo.ViewCustomersWithWater_On(id).Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
        //AddRequest_4Off()
        [Authorize]
        [HttpPost]
        public ActionResult _AddRequestOff(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            DateTime CustomerDate2 = std.CustomerDate2;
            string Structure = std.Structure;
            int CustomerCFS2 = std.CustomerCFS2;
            string CustomerComments2 = std.CustomerComments2;
            _ditchRiderRepo.AddRequest_Off(std);
            return new RedirectResult(Url.Action("Customers_On/" + Url.RequestContext.RouteData.Values["id"]));
        }
        [HttpGet]
        public ActionResult CanalWater(int id)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            DitchRiderRequests r = new DitchRiderRequests();
            return View(r);
        }
        [HttpPost]
        public ActionResult CanalWater(int id, string lateral)
        {
            if(!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            int Today = _ditchRiderRepo.WaterCFS_TodayByCanal(lateral);
            int Tomorrow = _ditchRiderRepo.WaterCFS_NextDayByCanal(lateral);
            DitchRiderRequests r = new DitchRiderRequests();
            r.Lateral = lateral;
            r.TodayCFS = Today;
            r.TomorrowCFS = Tomorrow;
            return View(r);
        }
        //Partial View for Ditch Riders to see what is in a canal when adding water
        [HttpGet]
        public ActionResult _CanalWater(int id)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            DitchRiderRequests r = new DitchRiderRequests();
            return View(r);
        }





        //OutputCache 
        //ViewRequests4()
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult ViewRequests(int RequestID)
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
            return ViewRequests(RequestID);
        }
        
        




        //Unauthorized View
        public ActionResult Unauthorized()
        {
            return View();
        }

        //Customer History
        //ViewCustomersHistory()
        //CustomerHistory
        [Authorize]
        [HttpGet]
        public ActionResult CustomerHistory(int id, int CustomerID, int? page)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            int pageSize = 15;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewCustomersHistory(id);
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.Where(s => s.CustomerID == CustomerID).ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }
        //public ActionResult CustomerHistory(int id, int CustomerID)
        //{
        //    if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }
        //    var std = _ditchRiderRepo.ViewCustomersHistory(id).Where(s => s.CustomerID == CustomerID).FirstOrDefault();
        //    return View(std);
        //}
        //Customer Recent History
        //ViewCustomersRecentHistory
        //CustomerRHistory
        [Authorize]
        [HttpGet]
        public ActionResult CustomerRHistory(int id, int CustomerID, int? page)
        {
            if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
            {
                return View("Unauthorized");
            }
            int pageSize = 15;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewCustomersRecentHistory(id);
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.Where(s => s.CustomerID == CustomerID).ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }
        //public ActionResult CustomerRHistory(int id, int CustomerID)
        //{
        //    if (!User.IsInRole("Ride " + id.ToString()) && !User.IsInRole("Relief Ride " + id.ToString()))
        //    {
        //        return View("Unauthorized");
        //    }            
        //    var std = _ditchRiderRepo.ViewCustomersRecentHistory(id).Where(s => s.CustomerID == CustomerID).FirstOrDefault();          
            
        //    return View(std);
        //}
    }
}