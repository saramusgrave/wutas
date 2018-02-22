using KlamathIrrigationDistrict.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.Models
{
    public class StructureListModel
    {
        public DitchRiderRequests request {get;set;}
        public List<SelectListItem>  HorsleyStructures { get; set; }
        public List<SelectListItem> RyanStructures { get; set; }
    }
}