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
        //Customers(int CustomerID, int TrackingID, String Name, Decimal TotalAllotment)
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
        public int Zip { get; set; }
        public decimal TotalAllotment { get; set; }
        public List<Customers> customers { get; set; }
        
        //allow the return of info form the MapTaxLots to Customer
        public class MapTaxLots : Customers
        {            
            //public MapTaxLots(String MapTaxLot, String Division, int TrackingID, String Structure, String LongName, int Ride, String Status, Decimal Acers, Decimal Rate, Decimal Allotment, String Name) :
            //    base (Name, CustomerID, TrackingID, Structure, Status, Acers)
            //{
            //    Customers.MapTaxLots s = new Customers.MapTaxLots();
            //    Customers n = new Customers();
            //    if (s.TrackingID == n.TrackingID)
            //    {

            //    }
            //}

            public List<MapTaxLots> MTL { get; set; }

            //need to be able to read and write for update in customer
            public string MapTaxLot { get; }
            public string DivisionID { get; }
            public int TrackingID { get; set; }
            public string Structure { get; set; }
            public string LongName { get; set; }
            public string Status { get; set; }
            public decimal Acers { get; set; }
            public decimal Rate { get; set; }
            public decimal Allotment { get; set; }
        }
    }
}