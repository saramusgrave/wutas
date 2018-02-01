using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    }
    public enum SelectPosition
    {
        //[Description("District Manager")]
        [Display(Name ="District Manager")]
        DistrictManager,
        [Description("Assistant Manager")]
        AssistantManager,
        [Description("Water Master")]
        WaterMaster,
        [Description("Office Specialist")]
        OfficeSpecialist,
        [Description("Book Keeper")]
        Bookkeeper,
        [Description("Maitenance Supervisor")]
        MaitenanceSupervisor,
        [Description("Ride 1")]
        Ride1,
        [Description("Ride 2")]
        Ride2,
        [Description("Ride 3")]
        Ride3,
        [Description("Ride 4")]
        Ride4,
        [Description("Ride 5")]
        Ride5,
        [Description("Ride 6")]
        Ride6,
        [Description("Ride 7")]
        Ride7,
        [Description("Ride 8")]
        Ride8,
        [Description("Relief Ride 1")]
        ReliefRide1,
        [Description("Relief Ride 2")]
        ReliefRide2,
        [Description("Relief Ride 3")]
        ReliefRide3,
        [Description("Relief Ride 4")]
        ReliefRide4,
        [Description("Relief Ride 5")]
        ReliefRide5,
        [Description("Relief Ride 6")]
        ReliefRide6,
        [Description("Relief Ride 7")]
        ReliefRide7,
        [Description("Relief Ride 8")]
        ReliefRide8
    }
}