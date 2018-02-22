﻿using KlamathIrrigationDistrict.DataLayer.DataModels;
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
        //Index Ride 4
        [HttpGet]
        public ActionResult Index4(int? page)
        {
            int pageSize = 10;
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
        //Ditch Rider Edit Request Ride 4 On
        public ActionResult EditRequest4On(int RequestID)
        {
            var std = _ditchRiderRepo.ViewRequests4().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
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
        //Ditch Rider Edit Request Ride 5 On
        public ActionResult EditRequest5On(int RequestID)
        {
            var std = _ditchRiderRepo.ViewRequests5().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
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
        //Ditch Rider Edit Request Ride 4 Off
        public ActionResult EditRequest4Off(int RequestID)
        {
            var std = _ditchRiderRepo.ViewRequests4().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
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
        //Ditch Rider Edit Request Ride 5 Off
        public ActionResult EditRequest5Off(int RequestID)
        {
            var std = _ditchRiderRepo.ViewRequests5().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
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
        //Ditch Rider Add Request as if Customer Ride 4
        [HttpGet]
        public ActionResult AddRequest4On()
        {
            ////StructureListModel model = new StructureListModel();
            //DitchRiderRequests model = new DitchRiderRequests();
            //model.HorsleyStructures = new List<SelectListItem>()
            //{
            //    new SelectListItem() { Text = "T4603", Value = "T4603"},
            //    new SelectListItem() { Text = "T4604", Value = "T4604" },
            //    new SelectListItem() { Text = "T4505", Value = "T4605"},
            //    new SelectListItem() { Text = "T4607", Value = "T4607"},
            //    new SelectListItem() { Text = "T4603", Value = "T4603"},
            //    new SelectListItem() { Text = "P4609", Value = "P4609"},
            //    new SelectListItem() { Text = "T4610", Value = "T4610"},
            ////};
            //return View(model);
            return View(new DitchRiderRequests());
        }
        //public ActionResult AddRequest4On()
        //{
        //    //StructureListModel model = new StructureListModel();
        //    DitchRiderRequests model = new DitchRiderRequests();
        //    model.HorsleyStructures = new List<SelectListItem>()
        //    {
        //        new SelectListItem() { Text = "T4603", Value = "T4603"},
        //        new SelectListItem() { Text = "T4604", Value = "T4604" },
        //        new SelectListItem() { Text = "T4505", Value = "T4605"},
        //        new SelectListItem() { Text = "T4607", Value = "T4607"},
        //        new SelectListItem() { Text = "T4603", Value = "T4603"},
        //        new SelectListItem() { Text = "P4609", Value = "P4609"},
        //        new SelectListItem() { Text = "T4610", Value = "T4610"},
        //    };
        //    return View(model);
        //    //List<SelectListItem> HorsleyStructures = new List<SelectListItem>()
        //    //{
        //    //    new SelectListItem() {Value = "T4603", Text = "T4603" },
        //    //    new SelectListItem() {Value = "T4604", Text = "T4604" },
        //    //    new SelectListItem() {Value = "T4505", Text = "T4505" },
        //    //    new SelectListItem() {Value = "T4607", Text =  "T4607" },
        //    //    new SelectListItem() {Value = "T4603", Text = "T4603" },
        //    //    new SelectListItem() {Value = "P4609", Text = "P4609" },
        //    //    new SelectListItem() {Value = "T4610", Text = "T4610" },
        //    //HorsleyStructures.Add(new SelectListItem { Text = "T4603", Value = "T4603" });
        //    //HorsleyStructures.Add(new SelectListItem { Text = "T4604", Value = "T4604" });
        //    //HorsleyStructures.Add(new SelectListItem { Text = "T4505", Value = "T4605" });
        //    //HorsleyStructures.Add(new SelectListItem { Text = "T4607", Value = "T4607" });
        //    //HorsleyStructures.Add(new SelectListItem { Text = "T4603", Value = "T4603" });
        //    //HorsleyStructures.Add(new SelectListItem { Text = "P4609", Value = "P4609" });
        //    //HorsleyStructures.Add(new SelectListItem { Text = "T4610", Value = "T4610" });
        //    //};

        //}
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
        [HttpGet]
        public ActionResult _AddRequest4Off()
        {
            return View(new DitchRiderRequests());
        }
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
        //Ditch Rider Add Request as if Customer Ride 5
        [HttpGet]
        public ActionResult AddRequest5On()
        {
            //List<SelectListItem> RyanStructures = new List<SelectListItem>();
            //RyanStructures.Add(new SelectListItem { Text = "T5814", Value = "T5814" });
            //RyanStructures.Add(new SelectListItem { Text = "P5815", Value = "P5815" });
            return View(new DitchRiderRequests());
        }
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
        public ActionResult ViewRequests4(int RequestID)
        {
            DitchRiderRequests ditchriderrequests = _ditchRiderRepo.Get(RequestID);
            DitchRiderRequests DitchRiderModel = new DitchRiderRequests()
            {
                RequestID = ditchriderrequests.RequestID,
                TimeStampCustomer1 = ditchriderrequests.TimeStampCustomer1,
                CustomerDate1 = ditchriderrequests.CustomerDate1,
                CustomerID = ditchriderrequests.CustomerID,
                CustomerName = ditchriderrequests.CustomerName,
                Structure = ditchriderrequests.Structure,
                CustomerCFS1 = ditchriderrequests.CustomerCFS1,
                TimeStampStaff1 = ditchriderrequests.TimeStampStaff1,
                KIDStaffID1 = ditchriderrequests.KIDStaffID1,
                StaffName1 = ditchriderrequests.StaffName1,
                StaffDate1 = ditchriderrequests.StaffDate1,
                RequestStatus1 = ditchriderrequests.RequestStatus1,
                StaffCFS1 = ditchriderrequests.StaffCFS1,
                StaffComments1 = ditchriderrequests.StaffComments1,
                CustomerDate2 = ditchriderrequests.CustomerDate2,
                CustomerCFS2 = ditchriderrequests.CustomerCFS2,
                TimeStampStaff2 = ditchriderrequests.TimeStampStaff2,
                KIDStaffID2 = ditchriderrequests.KIDStaffID2,
                StaffName2 = ditchriderrequests.StaffName2,
                StaffDate2 = ditchriderrequests.StaffDate2,
                RequestStatus2 = ditchriderrequests.RequestStatus2,
                StaffCFS2 = ditchriderrequests.StaffCFS2,
                StaffComments2 = ditchriderrequests.StaffComments2,
            };
            return ViewRequests4(RequestID);
        }
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult ViewRequests5(int RequestID)
        {
            DitchRiderRequests ditchriderrequests = _ditchRiderRepo.Get(RequestID);
            DitchRiderRequests DitchRiderModel = new DitchRiderRequests()
            {
                RequestID = ditchriderrequests.RequestID,
                TimeStampCustomer1 = ditchriderrequests.TimeStampCustomer1,
                CustomerDate1 = ditchriderrequests.CustomerDate1,
                CustomerID = ditchriderrequests.CustomerID,
                CustomerName = ditchriderrequests.CustomerName,
                Structure = ditchriderrequests.Structure,
                CustomerCFS1 = ditchriderrequests.CustomerCFS1,
                TimeStampStaff1 = ditchriderrequests.TimeStampStaff1,
                KIDStaffID1 = ditchriderrequests.KIDStaffID1,
                StaffName1 = ditchriderrequests.StaffName1,
                StaffDate1 = ditchriderrequests.StaffDate1,
                RequestStatus1 = ditchriderrequests.RequestStatus1,
                StaffCFS1 = ditchriderrequests.StaffCFS1,
                StaffComments1 = ditchriderrequests.StaffComments1,
                CustomerDate2 = ditchriderrequests.CustomerDate2,
                CustomerCFS2 = ditchriderrequests.CustomerCFS2,
                TimeStampStaff2 = ditchriderrequests.TimeStampStaff2,
                KIDStaffID2 = ditchriderrequests.KIDStaffID2,
                StaffName2 = ditchriderrequests.StaffName2,
                StaffDate2 = ditchriderrequests.StaffDate2,
                RequestStatus2 = ditchriderrequests.RequestStatus2,
                StaffCFS2 = ditchriderrequests.StaffCFS2,
                StaffComments2 = ditchriderrequests.StaffComments2,
            };
            return ViewRequests5(RequestID);
        }
    }
}