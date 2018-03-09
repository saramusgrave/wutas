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
        // GET: DitchRiders
        /*-------------------------------------------
         --------RIDE 4----------------------------*/
        //Index Ride 4
        //ViewActiveRequestsOn4()
        //Page: _ActiveRequestsOn4.cshtml and _ActiveRequestsOff4.cshtml
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
        
        //Customer List on Ride 4
        //Customers4()
        //Page: Customers4()
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
        }

        //View Pending On Requests Ride 4
        //ViewPending_4On()
        //Page: Appending_4On
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

        //View Pending Off Requests on Ride 4
        //ViewPending_4Off()
        //Page: Appending_4Off
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

        //View Active Requests On
        //ViewActiveRequestsOn4()
        //Page: _ActiveRequstsOn4
        [Authorize (Roles = "Ride 4, Relief Ride 4")]
        public ActionResult _ActiveRequestsOn4()
        {
            var std = _ditchRiderRepo.ViewActiveRequestOn4();
            return View(std);

        }


        /*
        public ActionResult _ActiveRequestsOff4()
        {
            var std = _ditchRiderRepo.ViewActiveRequestOff4();
            return View(std);
        }
        */
        //View Active Requests Off
        //Customers4()
        //Page: _ActiveRequestsOff4
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult _ActiveRequestsOff4(int? page)
        {
            //var std = _ditchRiderRepo.Customers4().Where(s => s.CustomerID == CustomerID).FirstOrDefault();
            //var tsd = _ditchRiderRepo.Customers4().Where(s => s.StructureID == Structure).FirstOrDefault();
            //return View(std.CustomerID.ToString(), tsd.StructureID);
            //var std = _ditchRiderRepo.ViewActiveRequestOff4();
            //return View(std);
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

        //View WaitList 4 On
        //Customers4()
        //Page: _ActiveRequestsOff4
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

        //View WaitList 4 On
        //Customers4()
        //Page: _ActiveRequestsOff4
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





        //View Active Requests off 
        //AddRequests_4Off
        //Page: _ActiveRequestsOff4
        //[Authorize(Roles = "Ride 4, Relief Ride 4")]
        //[HttpPost]
        //public ActionResult _ActiveRequestsOff4(DitchRiderRequests std)
        //{
        //    int RequestID = std.RequestID;
        //    DateTime CustomerDate2 = std.CustomerDate2;
        //    string Structure = std.Structure;
        //    int CustomerCFS2 = std.CustomerCFS2;
        //    string CustomerComments2 = std.CustomerComments2;
        //    _ditchRiderRepo.AddRequest_4Off(std);
        //    return RedirectToAction("Index4");
        //}

        //Turn On Water
        //ViewRequests4
        //Page: EditRequest4On
        public ActionResult EditRequest4On(int RequestID)
        {
            //This shit works!!!
            DitchRiderRequests model = new DitchRiderRequests();
            var list = model.RequestStatus_1 = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Pending", Value = "Pending" },
                new SelectListItem() { Text = "Confirm", Value = "Confirm" },
                new SelectListItem() { Text = "Rejected", Value = "Rejected" },
                new SelectListItem() { Text = "Violation", Value = "Violation" },
                new SelectListItem() { Text = "Contact Office", Value = "Contact Office" },
                new SelectListItem() { Text = "Wait List", Value = "Wait List" },
            };
            ViewData["RequestStatus_1"] = list;
            var std = _ditchRiderRepo.ViewRequests4().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }

        //Turn On Water
        //EditRequests4On
        //Page: EditRequests4On
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

        //Turn Off Water
        //ViewRequests4()
        //Page: EditRequests4Off
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult EditRequest4Off(int RequestID)
        {
            DitchRiderRequests model = new DitchRiderRequests();
            var list = model.RequestStatus_2 = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Pending", Value = "Pending" },
                new SelectListItem() { Text = "Confirm", Value = "Confirm" },
                new SelectListItem() { Text = "Rejected", Value = "Rejected" },
                new SelectListItem() { Text = "Violation", Value = "Violation" },
                new SelectListItem() { Text = "Contact Office", Value = "Contact Office" },
                new SelectListItem() { Text = "Wait List", Value = "Wait List" },
            };
            ViewData["RequestStatus_2"] = list;
            var std = _ditchRiderRepo.ViewRequests4().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }

        //Turn Off Water
        //EditREquests4Off
        //Page: EditRequest4Off
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




        //Edit Request Status1 On
        //EditRequestStatus1_On
        //Page: EditRequests4On
        public ActionResult EditRequestStatus_On(int RequestID)
        {
            var std = _ditchRiderRepo.ViewPending_4On().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }

        //Edit Request Status1 On
        //EditRequestStatus1_On
        //Page: EditRequests4On

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

        //Edit Request Status1 On
        //ViewPending_4On
        //Page: EditRequests4On
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult EditRequestStatus_Off(int RequestID)
        {
            var std = _ditchRiderRepo.ViewPending_4Off().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }

        //Turn Off Water
        //EditREquests4Off
        //Page: EditRequest4Off
 
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
































        /*
                [HttpGet]
                public ActionResult AddRequest4On()
                {
                    //DitchRiderRequests repo = new DitchRiderRequests();
                    //var std = _ditchRiderRepo.Customers4().Where(s => s.Name == repo.CustomerName).FirstOrDefault();
                    //var req = _ditchRiderRepo.Customers4().Where(s => s.StructureID == repo.Structure).FirstOrDefault();
                    //var ght = _ditchRiderRepo.Customers4().Where(s => s.CustomerID == CustomerID).FirstOrDefault();
                    //return View(ght);
                    //Drop down works
                    //DitchRiderRequests model = new DitchRiderRequests();
                    //model.HorsleyStructures = new List<SelectListItem>()
                    //{
                    //    new SelectListItem() { Text = "T4603", Value = "T4603"},
                    //    new SelectListItem() { Text = "T4604", Value = "T4604"},
                    //    new SelectListItem() { Text = "T4505", Value = "T4605"},
                    //    new SelectListItem() { Text = "T4607", Value = "T4607"},
                    //    new SelectListItem() { Text = "T4603", Value = "T4603"},
                    //    new SelectListItem() { Text = "P4609", Value = "P4609"},
                    //    new SelectListItem() { Text = "T4610", Value = "T4610"},
                    //};
                    //return View(model);
                    //return view without using drop down keep
                    return View(new DitchRiderRequests());
                }
                */
        //Turn On Water as if Customer
        //Ditch Rider Add Request as if Customer Ride 4
        //Customers4
        //Page: AddRequest4On
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        public ActionResult AddRequest4On()
        {
            return View(new DitchRiderRequests());
        }

        //Turn On Water as if Customer
        //AddREquest_4On
        //Page: AddREquest4On
        [Authorize(Roles = "Ride 4, Relief Ride 4")]
        [HttpPost]
        public ActionResult AddRequest4On(DitchRiderRequests ditchriderrequests)
        {
            //keep
            if (!ModelState.IsValid)
            {
                return View(ditchriderrequests);
            }
            //int RequestID = ditchriderrequests.RequestID;
            //int CustomerID = ditchriderrequests.CustomerID;
            //string structure = ditchriderrequests.Structure;
            //string Name = ditchriderrequests.CustomerName;
            //DateTime CustomerDate1 = ditchriderrequests.CustomerDate1;
            //int CustomerCFS1 = ditchriderrequests.CustomerCFS1;
            //string CustomerComments1 = ditchriderrequests.CustomerComments1;
            _ditchRiderRepo.AddRequest_4On(ditchriderrequests);
            return RedirectToAction("Customers4");
        }


        //Turn Off Water as if Customer
        //new DitchRiderRequests
        //Page: _AddREquest4Off
        [Authorize(Roles = "Ride 4 ,Relief Ride 4")]
        //[HttpGet]
        //public ActionResult _AddRequest4Off()
        //{
        //    return View(new DitchRiderRequests());
        //}
        public ActionResult _AddRequest4Off()
        {
            //var std = _ditchRiderRepo.Customers4().Where(s => s.CustomerID == CustomerID).FirstOrDefault();
            //var tsd = _ditchRiderRepo.Customers4().Where(s => s.StructureID == StructureID).FirstOrDefault();
            //return View(std);
            return View(new DitchRiderRequests());
        }
        //Turn Off Water as if Customer
        //AddRequest_4Off
        //Page: _AddRequests4Off
        //[Authorize(Roles = "Ride 4, Relief Ride 4")]
        //[HttpPost]
        //public ActionResult _AddRequest4Off(DitchRiderRequests ditchriderrequests)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(ditchriderrequests);
        //    }
        //    _ditchRiderRepo.AddRequest_4Off(ditchriderrequests);
        //    return RedirectToAction("Index4");
        //}
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


        //OutputCache 
        //ViewRequests4
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

        //View Completed On and Off Requests
        //ViewREquests4
        //Page: CompletedREquests
        public ActionResult CompletedRequests(int ? page)
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