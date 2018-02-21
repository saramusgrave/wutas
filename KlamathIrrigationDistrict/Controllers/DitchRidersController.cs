using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using KlamathIrrigationDistrict.DataLayer.Repositories;
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
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<DitchRiderRequests> ditchRider = null;
            DitchRidersRepository repository = new DitchRidersRepository();
            DitchRiderRequests ditchriderrequests = new DitchRiderRequests();
            List<DitchRiderRequests> obditchriderlist = new List<DitchRiderRequests>();
            obditchriderlist = repository.ViewRequests();
            ditchriderrequests.ditchriderrequests = obditchriderlist;
            ditchRider = obditchriderlist.ToPagedList(pageIndex, pageSize);
            return View(ditchRider);
        }
        //Ditch Rider Edit Request
        public ActionResult EditRequest(int RequestID)
        {
            var std = _ditchRiderRepo.ViewRequests().Where(s => s.RequestID == RequestID).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult EditRequest(DitchRiderRequests std)
        {
            int RequestID = std.RequestID;
            DateTime DitchRiderDate = std.DitchRiderDate;
            int CFSGicen = std.CFSGiven;
            string DitchRiderComments = std.DitchRiderComments;
            _ditchRiderRepo.EditRequest(std);
            return RedirectToAction("Index");
        }
        //Ditch Rider Add Request as if Customer
        [HttpGet]
        public ActionResult Add()
        {
            return View(new DitchRiderRequests());
        }
        [HttpPost]
        public ActionResult Add(DitchRiderRequests ditchriderrequests)
        {
            if (!ModelState.IsValid)
            {
                return View(ditchriderrequests);
            }
            _ditchRiderRepo.AddRequest(ditchriderrequests);
            return RedirectToAction("Index");
        }
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult ViewRequests(int RequestID)
        {
            DitchRiderRequests ditchriderrequests = _ditchRiderRepo.Get(RequestID);
            DitchRiderRequests DitchRiderModel = new DitchRiderRequests()
            {
                RequestID = ditchriderrequests.RequestID,
                CustomerID = ditchriderrequests.CustomerID,
                TrackingID = ditchriderrequests.TrackingID,
                CustomerName = ditchriderrequests.CustomerName,
                Allotment = ditchriderrequests.Allotment,
                MapTaxLot = ditchriderrequests.MapTaxLot,
                Structure = ditchriderrequests.Structure,
                CustomerDate = ditchriderrequests.CustomerDate,
                CFSRequested = ditchriderrequests.CFSRequested,
                CustomerComments = ditchriderrequests.CustomerComments,
                DitchRiderDate = ditchriderrequests.DitchRiderDate,
                CFSGiven = ditchriderrequests.CFSGiven,
                DitchRiderComments = ditchriderrequests.DitchRiderComments,
            };
            return ViewRequests(RequestID);
        }
    }
}