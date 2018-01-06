using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KlamathIrrigationDistrict.DataLayer.DataModels
{
    //Customers Table
    public class Customers
    {
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public int TrackingID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(2)]
        public string State { get; set; }
        [StringLength(5)]
        public int Zip { get; set; }
        public decimal TotalAllotment { get; set; }
    }
}