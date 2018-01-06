using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public DateTime ModifiedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public List<KIDStaff> kidstaff { get; set; }
    }
}