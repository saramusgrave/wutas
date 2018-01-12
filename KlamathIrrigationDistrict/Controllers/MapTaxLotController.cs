using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Mvc;
using PagedList;

namespace KlamathIrrigationDistrict.Controllers
{
    public class MapTaxLotController : Controller
    {
        private IMapTaxLotRepository _mapRepo;
        public MapTaxLotController()
        {
            _mapRepo = new MapTaxLotRepository();
        }
        //Creates Paged List
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 15;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<MapTaxLots> map = null;
            MapTaxLotRepository maprepository = new MapTaxLotRepository();
            MapTaxLots maptaxlots = new MapTaxLots();
            List<MapTaxLots> obMapList = new List<MapTaxLots>();
            obMapList = maprepository.ViewTaxLot();
            maptaxlots.maptaxlots = obMapList;
            map = obMapList.ToPagedList(pageIndex, pageSize);
            return View(map);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View(new MapTaxLots());
        }
        [HttpPost]
        public ActionResult Add(MapTaxLots maptaxlots)
        {
            if (!ModelState.IsValid)
            {
                return View(maptaxlots);
            }
            _mapRepo.Save(maptaxlots);
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public ActionResult Edit(int? page)
        //{
        //    int pageSize = 10;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    IPagedList<MapTaxLots> map = null;
        //    MapTaxLotRepository maprepository = new MapTaxLotRepository();
        //    MapTaxLots maptaxlots = new MapTaxLots();
        //    List<MapTaxLots> obMapList = new List<MapTaxLots>();
        //    obMapList = maprepository.ViewTaxLot();
        //    maptaxlots.maptaxlots = obMapList;
        //    map = obMapList.ToPagedList(pageIndex, pageSize);
        //    return View(map);
        //}
        //[HttpGet]
        public ActionResult Edit(string MapTaxLot)
        {
            //MapTaxLots maptaxlot = _mapRepo.Get(MapTaxLot);
            //return View(maptaxlot);
            //return View(new MapTaxLots());
            var std = _mapRepo.ViewTaxLot().Where(s => s.MapTaxLot == MapTaxLot).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult Edit(MapTaxLots maptaxlots)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(maptaxlots);
            //}
            //_mapRepo.Save(maptaxlots);
            //return RedirectToAction("Index");
            string MapTaxLot = maptaxlots.MapTaxLot;
            string DivisionID = maptaxlots.DivisionID;
            int TrackingID = maptaxlots.TrackingID;
            string Structure = maptaxlots.Structure;
            string LongName = maptaxlots.LongName;
            int Ride = maptaxlots.Ride;
            string Status = maptaxlots.Status;
            decimal Acers = maptaxlots.Acers;
            decimal Rate = maptaxlots.Rate;
            string Name = maptaxlots.Name;
            decimal Allotment = maptaxlots.Allotment;
            _mapRepo.Save(maptaxlots);
            return RedirectToAction("Index");
        }

        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult ViewTaxLot(string MapTaxLot)
        {
            MapTaxLots maptaxlot = _mapRepo.Get(MapTaxLot);
            MapTaxLots MapModel = new MapTaxLots()
            {
                MapTaxLot = maptaxlot.MapTaxLot,
                DivisionID = maptaxlot.DivisionID,
                TrackingID = maptaxlot.TrackingID,
                Structure = maptaxlot.Structure,
                LongName = maptaxlot.LongName,
                Ride = maptaxlot.Ride,
                Status = maptaxlot.Status,
                Acers = maptaxlot.Acers,
                Rate = maptaxlot.Rate,
                Name = maptaxlot.Name,
                Allotment = maptaxlot.Allotment
            };
            return ViewTaxLot(MapTaxLot);
        }
    }
}