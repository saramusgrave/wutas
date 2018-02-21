using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KlamathIrrigationDistrict.DataLayer.DataModels
{
    //Request tabel
    public class DitchRiderRequests
    {
        public int RequestID { get; set; }
        public int CustomerID { get; set; }
        public int TrackingID { get; set; }
        public string CustomerName { get; set; }
        public decimal Allotment { get; set; }
        [StringLength(16)]
        public string MapTaxLot { get; set; }
        public string Structure { get; set; }
        public DateTime CustomerDate { get; set; }
        public int CFSRequested { get; set; }
        public string CustomerComments { get; set; }
        public DateTime _Getdate = DateTime.Now;
        public DateTime DitchRiderDate
        {
            get
            {
                return _Getdate;
            }
            set
            {
                _Getdate = value;
            }
        }
        public int CFSGiven { get; set; }
        public string DitchRiderComments { get; set; }
        public List<DitchRiderRequests> ditchriderrequests { get; set; }
    }
}