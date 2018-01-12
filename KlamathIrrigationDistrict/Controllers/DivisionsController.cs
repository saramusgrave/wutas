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
    public class DivisionsController : Controller
    {
        private IDivisionsRepository _divRepo;
        public DivisionsController()
        {
            _divRepo = new DivisionsRepository();
        } 
        // GET: Divisions
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Divisions> div = null;
            DivisionsRepository divisionsrepository = new DivisionsRepository();
            Divisions Divisions = new Divisions();
            List<Divisions> obDivList = new List<Divisions>();
            obDivList = divisionsrepository.ViewDivisions();
            Divisions.divisions = obDivList;
            div = obDivList.ToPagedList(pageIndex, pageSize);
            return View(div);
        }
        public ActionResult Edit(string DivisionID)
        {
            var div = _divRepo.ViewDivisions().Where(s => s.DivisionID == DivisionID).FirstOrDefault();
            return View(div);
        }
        [HttpPost]
        public ActionResult Edit(Divisions div)
        {
            string DivisionID = div.DivisionID;
            decimal Rate = div.Rate;
            string StatusID1 = div.StatusID1;
            string StatusID2 = div.StatusID2;
            string StatusID3 = div.StatusID3;
            string StatusID4 = div.StatusID4;
            string StatusID5 = div.StatusID5;
            string StatusID6 = div.StatusID6;
            string StatusID7 = div.StatusID7;
            string StatusID8 = div.StatusID8;
            _divRepo.Save(div);
            return RedirectToAction("Index");
        }
    }
}