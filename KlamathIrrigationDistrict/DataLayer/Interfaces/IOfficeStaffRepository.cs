using KlamathIrrigationDistrict.DataLayer.DataModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.DataLayer.Interfaces
{
    public interface IOfficeStaffRepository
    {
        //Get KIDStaff by StaffID
        KIDStaff Get(int id);
        //View KIDStaff list
        List<KIDStaff> ViewStaff();
        //Add a kid staff member
        void AddStaff(KIDStaff kidstaff);
        //edit a kid staff member
        void EditStaff(KIDStaff kidstaff);
        //KIDStaff: Insert & Update 
        void Save(KIDStaff kidstaff);
        //from Alen
        //KIDStaff StaffMember { get; set; }
        List<SelectListItem> GetPositionList(KIDStaff p);
    }
}
