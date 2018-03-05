using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using KlamathIrrigationDistrict.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        // GET: DitchRiders
        /*Ride 4*/
        //Index Ride 4
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
            obditchriderlist = repository.ViewRequests4();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }
        //Ditch Rider View Customer List on Ride 4
        [HttpGet]
        public ActionResult Customers4(int? page)
        {
            int pageSize = 25;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderCustomers> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderCustomers ditchriderrequests = new DitchRiderCustomers();
            List<DitchRiderCustomers> obditchriderlist = new List<DitchRiderCustomers>();
            obditchriderlist = repository.Customers4();
            ditchriderrequests.ditchridercustomers = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);



            //var std = _ditchRiderRepo.Customers4();
            //return View(std);
        }
        //Ditch Rider View Active Requests Ride 4 On
        [Authorize (Roles = "Ride 4, Relief Ride 4")]
        public ActionResult _ActiveRequestsOn4()
        {
            var std = _ditchRiderRepo.ViewActiveRequestOn4();
            return View(std);
        }
        //Ditch Rider View Active Requests Ride 4 Off
        [Authorize (Roles = "Ride 4, Relief Ride 4")]
        public ActionResult _ActiveRequestsOff4()
        {
            var std = _ditchRiderRepo.ViewActiveRequestOff4();
            return View(std);
        }
        //Ditch Rider Edit Request Ride 4 On
        public ActionResult EditRequest4On(int RequestID)
        {
            var std = _ditchRiderRepo.ViewRequests4().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
        [Authorize(Roles = "Ride 4 ,Relief Ride 4")]
        [HttpPost]
        public ActionResult EditRequest4On(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            DateTime StaffDate1 = std.StaffDate1;
            int StaffCFS1 = std.StaffCFS1;
            string StaffComments1 = std.StaffComments1;
            _ditchRiderRepo.EditRequest4On(std);
            return RedirectToAction("Index4");
        }
        //Ditch Rider Edit Request Ride 4 Off
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult EditRequest4Off(int RequestID)
        {
            var std = _ditchRiderRepo.ViewRequests4().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
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
        //Ditch Rider Add Request as if Customer Ride 4
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpGet]
        public ActionResult AddRequest4On()
        {
            //Drop down works
            DitchRiderRequests model = new DitchRiderRequests();
            model.HorsleyStructures = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "T4603", Value = "T4603"},
                new SelectListItem() { Text = "T4604", Value = "T4604"},
                new SelectListItem() { Text = "T4505", Value = "T4605"},
                new SelectListItem() { Text = "T4607", Value = "T4607"},
                new SelectListItem() { Text = "T4603", Value = "T4603"},
                new SelectListItem() { Text = "P4609", Value = "P4609"},
                new SelectListItem() { Text = "T4610", Value = "T4610"},
            };
            model.RequestStatus_1 = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Pending", Value = "Pending" },
                new SelectListItem() { Text = "Confirm", Value = "Confirm" },
                new SelectListItem() { Text = "Rejected", Value = "Rejected" },
                new SelectListItem() { Text = "Violation", Value = "Violation" },
                new SelectListItem() { Text = "Contact Office", Value = "Contact Office" },
                new SelectListItem() { Text = "Wait List", Value = "Wait List" },
            };
            model.RequestStatus_2 = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Pending", Value = "Pending" },
                new SelectListItem() { Text = "Confirm", Value = "Confirm" },
                new SelectListItem() { Text = "Rejected", Value = "Rejected" },
                new SelectListItem() { Text = "Violation", Value = "Violation" },
                new SelectListItem() { Text = "Contact Office", Value = "Contact Office" },
                new SelectListItem() { Text = "Wait List", Value = "Wait List" },
            };
            return View(model);

            //return view without using drop down keep
            //return View(new DitchRiderRequests());
        }
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpPost]
        public ActionResult AddRequest4On(DitchRiderRequests ditchriderrequests)
        {
            if (!ModelState.IsValid)
            {
                return View(ditchriderrequests);
            }
            _ditchRiderRepo.AddRequest4On(ditchriderrequests);
            return RedirectToAction("Index4");
        }
        //Ditch Rider Add Request as if Customer Ride 4
        [Authorize(Roles = "Ride 4 ,Relief Ride 4")]
        [HttpGet]
        public ActionResult _AddRequest4Off()
        {
            return View(new DitchRiderRequests());
        }
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpPost]
        public ActionResult _AddRequest4Off(DitchRiderRequests ditchriderrequests)
        {
            if (!ModelState.IsValid)
            {
                return View(ditchriderrequests);
            }
            _ditchRiderRepo.AddRequest4Off(ditchriderrequests);
            return RedirectToAction("Index4");
        }
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