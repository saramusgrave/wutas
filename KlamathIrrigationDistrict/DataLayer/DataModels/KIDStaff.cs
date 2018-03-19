using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.DataLayer.DataModels
{
    //KIDStaff Table
    public class KIDStaff
    {
        public int StaffID { get; set; }
        public string Position { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [StringLength(13)]
        public string PhoneNumber { get; set; }
        public bool StaffStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //public DateTime ModifiedDateTime { get; set; }
        private DateTime _Getdate = DateTime.Now;
        public DateTime ModifiedDateTime
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
        public string ModifiedUser { get; set; }
        public List<KIDStaff> kidstaff { get; set; }
        //public List<SelectListItem> PositionTypes { get; set; }
        public List<SelectListItem> GetPositionList { get; set; }
        public string RoleName { get; set; }
    }
}