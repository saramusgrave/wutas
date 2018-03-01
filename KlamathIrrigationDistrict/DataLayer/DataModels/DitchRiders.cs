using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.DataLayer.DataModels
{
    //Request tabel
    public class DitchRiderRequests
    {
        public int RequestID { get; set; }
        public DateTime TimeStampCustomer1 { get { return _Getdate; } set { _Getdate = value; } }
        public DateTime CustomerDate1 { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Structure { get; set; }
        public int CustomerCFS1 { get; set; }
        public string CustomerComments1 { get; set; }
        public DateTime TimeStampStaff1 { get {return _Getdate; } set { _Getdate = value; }}
        public string Staff1 { get; set; }
        public DateTime StaffDate1 { get; set; }
        public string RequestStatus1 { get; set; }
        public int StaffCFS1 { get; set; }
        public string StaffComments1 { get; set; }
        public DateTime TimeStampCustomer2 { get { return _Getdate; } set { _Getdate = value; } }
        public DateTime CustomerDate2 { get; set; }
        public int CustomerCFS2 { get; set; }
        public string CustomerComments2 { get; set; }
        public DateTime TimeStampStaff2 { get { return _Getdate; } set { _Getdate = value; } }
        public string Staff2 { get; set; }
        public DateTime StaffDate2 { get; set; }
        public string RequestStatus2 { get; set; }
        public int StaffCFS2 { get; set; }
        public string StaffComments2 { get; set; }
        public DateTime _Getdate = DateTime.Now;
        public List<DitchRiderRequests> ditchriderrequests { get; set; }
        public List<SelectListItem> HorsleyStructures { get; set; }
        public List<SelectListItem> RyanStructures { get; set; }
    }
    public class DitchRiderCustomers
    {
        public string StructureID { get; set; }
        public int Ride { get; set; }
        public int CustomerMTLHisID { get; set; }
        public string Name { get; set; }
        public int CustomerID { get; set; }
    }
}