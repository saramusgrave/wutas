using KlamathIrrigationDistrict.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.Models
{
    public class StaffEditModel : Controller
    {
        public KIDStaff StaffMember { get; set; }
        public List<SelectListItem> PositionID { get; set; }
    }
}