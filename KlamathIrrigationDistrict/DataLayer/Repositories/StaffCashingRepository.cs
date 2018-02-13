//using KlamathIrrigationDistrict.DataLayer.DataModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace KlamathIrrigationDistrict.DataLayer.Repositories
//{
//    public class StaffCashingRepository : StaffRepository
//    {
//        public override List<KIDStaff>ViewStaff()
//        {
//            List<KIDStaff> staff = null;
//            staff = (List<KIDStaff>)HttpRuntime.Cache["StaffList"];
//            if (staff == null)
//            {
//                staff = base.ViewStaff();
//                HttpRuntime.Cache["StaffList"] = staff;
//            }
//            return staff;
//        }
//        public override void Save (KIDStaff kidstaff)
//        {
//            base.Save(kidstaff);
//            HttpRuntime.Cache.Remove("StaffList");
//        }
//        public override KIDStaff Get(int id)
//        {
//            return base.Get(id);
//        }
//    }
//}