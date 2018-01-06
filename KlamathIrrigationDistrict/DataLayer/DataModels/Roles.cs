using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlamathIrrigationDistrict.DataLayer.DataModels
{
    public class Roles
    {
        public int StaffID { get; set; }
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}