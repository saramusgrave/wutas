using KlamathIrrigationDistrict.DataLayer.DataModels;
using System.Collections.Generic;

namespace KlamathIrrigationDistrict.DataLayer.Interfaces
{
    public interface IOfficeStaffRepository
    {
        //Get KIDStaff by StaffID
        KIDStaff Get(int id);
        //View KIDStaff list
        List<KIDStaff> ViewStaff();
        //KIDStaff: Insert & Update 
        void Save(KIDStaff kidstaff);
    }
}
