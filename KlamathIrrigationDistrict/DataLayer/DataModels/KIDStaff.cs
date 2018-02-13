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
        public int Position { get; set; }
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
        Admin = 1,
        DistrictManager = 2,
        AssistantManager = 3,
        WaterMaster = 4,
        OfficeSpecialist = 5,
        Bookkeeper = 6,
        MaitenanceSupervisor = 7,
        Ride1 = 8,
        Ride2 = 9,
        Ride3 = 10,
        Ride4 = 11,
        Ride5 = 12,
        Ride6 = 13,
        Ride7 = 14,
        Ride8 = 15,
        ReliefRide1 = 16,
        ReliefRide2 = 17,
        ReliefRide3 = 18,
        ReliefRide4 = 19,
        ReliefRide5 = 20,
        ReliefRide6 = 21,
        ReliefRide7 = 22,
        ReliefRide8 = 23
    }
}