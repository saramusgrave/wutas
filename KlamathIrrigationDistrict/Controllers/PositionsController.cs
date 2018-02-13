using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.Controllers
{
    public class PositionsController : Controller
    {
        // GET: Positions
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult Index(int? page)
        {
            //display current user log in create partial for all views
            // User.Identity.GetUserName();
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Positions> pos = null;
            PositionsRepository positionsrepository = new PositionsRepository();
            Positions p = new Positions();
            List<Positions> obPositionsList = new List<Positions>();
            obPositionsList = positionsrepository.PositionsList();
            p.positions = obPositionsList;
            pos = obPositionsList.ToPagedList(pageIndex, pageSize);
            return View(pos);
        }
    }
}