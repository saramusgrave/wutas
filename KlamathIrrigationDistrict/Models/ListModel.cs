using KlamathIrrigationDistrict.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.Models
{
    public class ListModel
    {
        public Positions Position { get; set; }
        public List<SelectListItem>PositionList { get; set; }
    }
}