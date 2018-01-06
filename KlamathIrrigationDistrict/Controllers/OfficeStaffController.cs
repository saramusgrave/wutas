using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.Controllers
{
    public class OfficeStaffController : Controller
    {
        private IOfficeStaffRepository _stafRepo;
        public OfficeStaffController()
        {
            _stafRepo = new StaffRepository();
        }
        /*Views for Home page of Office Staff*/
        //Home page office staff will display list of all staff
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<KIDStaff> staff = null;
            StaffRepository staffrepository = new StaffRepository();
            KIDStaff KidStaff = new KIDStaff();
            List<KIDStaff> obStaffList = new List<KIDStaff>();
            obStaffList = staffrepository.ViewStaff();
            KidStaff.kidstaff = obStaffList;
            staff = obStaffList.ToPagedList(pageIndex, pageSize);
            return View(staff);
        }
        //Edit Staff
        public ActionResult StaffEdit(int StaffID)
        {
            var std = _stafRepo.ViewStaff().Where(s => s.StaffID == StaffID).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult StaffEdit(KIDStaff std)
        {
            int StaffID = std.StaffID;
            string Position = std.Position;
            string FirstName = std.FirstName;
            string LastName = std.LastName;
            string Password = std.Password;
            string Email = std.Email;
            string PhoneNumber = std.PhoneNumber;
            Boolean StaffStatus = std.StaffStatus;
            DateTime StartDate = std.StartDate;
            DateTime EndDate = std.EndDate;
            DateTime ModifiedDateTime = std.ModifiedDateTime;
            string ModifiedUser = std.ModifiedUser;
            _stafRepo.Save(std);
            return RedirectToAction("Index");
        }
        //Add Staff
        [HttpGet]
        public ActionResult Add()
        {
            return View(new KIDStaff());
        }
        [HttpPost]
        public ActionResult Add(KIDStaff kidstaff)
        {
            if (!ModelState.IsValid)
            {
                return View(kidstaff);
            }
            _stafRepo.Save(kidstaff);
            return RedirectToAction("Index");
        }
        //Add Customer
        public ActionResult AddCustomer()
        {
            return View("AddCustomer");
        }
        //Edit Customer
        public ActionResult Edit()
        {
            return View("Edit");
        }
        /*Delete?
        [HttpGet]
        public ActionResult Edit(int StaffID)
        {
            KIDStaff kidstaff = _stafRepo.Get(StaffID);
            return View(kidstaff);
        }
        */
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult ViewStaff(int StaffID)
        {
            KIDStaff kidstaff = _stafRepo.Get(StaffID);
            KIDStaff StaffModel = new KIDStaff()
            {
                StaffID = kidstaff.StaffID,
                Position = kidstaff.Position,
                FirstName = kidstaff.FirstName,
                LastName = kidstaff.LastName,
                Password = kidstaff.Password,
                Email = kidstaff.Email,
                PhoneNumber = kidstaff.PhoneNumber,
                StaffStatus = kidstaff.StaffStatus,
                StartDate = kidstaff.StartDate,
                EndDate = kidstaff.EndDate,
                ModifiedDateTime = kidstaff.ModifiedDateTime,
                ModifiedUser = kidstaff.ModifiedUser,
            };
            return ViewStaff(StaffID);
         }
    }
}