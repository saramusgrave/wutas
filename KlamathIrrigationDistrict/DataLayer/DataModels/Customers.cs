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

        //3 var constructor created to help pass the info for customers into the requests
        //public CustomersInfo (int ID, int TrackingNum, string CustomerName)
        //{
        //    ID = CustomerID;
        //    TrackingNum = TrackingID;
        //    CustomerName = Name;
        //}

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
        
        //public Customers ( int PersonID, string CustomerName, int TrackNumber)
        //{
        //    CustomerID = PersonID;
        //    Name = CustomerName;
        //    TrackingID = TrackNumber;
        //}
        
    }

    //WaterOrderRequest Class would inherit the customerID from Customers
    public class WaterOrderRequest : Customers
    {
        public decimal RequestedCFS { get; set; }

        public string CustomerComments { get; set; }

        //this is the ID for the water request itself
        public int RequestID { get; set; }

        public string Structure { get; set; }

        //need to find datatype acceptable for date -> datetime 
        //public (date) CustomerDate {get; set;}

        //constructor to pass Variables into WaterOrder
        public WaterOrderRequest
            (int personID, string CustomerName, int tracknumber, decimal CFS, string Comments, decimal Allotment, string structureID)
        {
            personID = CustomerID;
            CustomerName = Name;
            tracknumber = TrackingID;
            CFS = RequestedCFS;
            Comments = CustomerComments;
            Allotment = TotalAllotment;
            structureID = Structure;
        }
    }
}