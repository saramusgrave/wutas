using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KlamathIrrigationDistrict.DataLayer.DataModels
{
    //MapTaxLot Table
    public class MapTaxLotTable
    {
        [Required]
        [StringLength (16)]
        public string MapTaxLot { get; set; }
        [Required]
        public string DivisionID { get; set; }
        public string TrackingID { get; set; }
        public string Structure { get; set; }
        public string LongNmae { get; set; }
        public int Ride { get; set; }
        [Required]
        public string Status { get; set; }
        public decimal Rate { get; set; }
        public decimal Allotment { get; set; }
    }
}