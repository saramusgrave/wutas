using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using KlamathIrrigationDistrict.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.Controllers
{
    public class OfficeStaffController : Controller
    {
        private ApplicationUserManager _userManager;
        public OfficeStaffController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
            //SignInManager = signInManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private IOfficeStaffRepository _stafRepo;
        public OfficeStaffController()
        {
            _stafRepo = new OfficeStaffRepository();
        }
        /*Views for Home page of Office Staff*/
        //Home page office staff will display list of all staff
        [HttpGet]
        public ActionResult Index(int? page)
        {
            //display current user log in create partial for all views
           // User.Identity.GetUserName();
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<KIDStaff> staff = null;
            OfficeStaffRepository staffrepository = new OfficeStaffRepository();
            KIDStaff KidStaff = new KIDStaff();
            List<KIDStaff> obStaffList = new List<KIDStaff>();
            obStaffList = staffrepository.ViewStaff();
            KidStaff.kidstaff = obStaffList;
            staff = obStaffList.ToPagedList(pageIndex, pageSize);
            return View(staff);
        }
        //Allen
        //public ActionResult StaffEdit()
        //{
        //    StaffEditModel model = new StaffEditModel();
        //    model.StaffMember = new KIDStaff()
        //    {

        //        FirstName = "",
        //        LastName = "",
        //        Position = "Administrator"
        //    };
        //    model.PositionID = new List<SelectListItem>()
        //    {
        //        new SelectListItem() {Text = "Administrator", Value = "1" },
        //        new SelectListItem() {Text = "user", Value = "2" },
        //    };
        //    return View(model);
        //}
        //Edit Staff
        public ActionResult StaffEdit(int StaffID)
        {
            //StaffEditModel model = new StaffEditModel();
            //model.StaffMember = _stafRepo.ViewStaff().Where(s => s.StaffID == StaffID).FirstOrDefault();
            //model.PositionID = new List<SelectListItem>();
            //return View(model);

            //var x = new StaffEditModel
            //x.staff = _stafRepo.ViewStaff().Where(s => s.StaffID == StaffID).FirstOrDefault();

            //Original
            var std = _stafRepo.ViewStaff().Where(s => s.StaffID == StaffID).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult StaffEdit(KIDStaff std)
        {
            int StaffID = std.StaffID;
            int Position = std.Position;
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
            _stafRepo.EditStaff(std);
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
            //Adding to KIDStaff
            if (!ModelState.IsValid)
            {
                return View(kidstaff);
            }
            //Adds user to ASP side of things
            var user = new ApplicationUser { UserName = kidstaff.Email, Email = kidstaff.Email};
            var result = this.UserManager.Create(user, kidstaff.Password);
            if (result.Succeeded)
            {
                //this.UserManager.AddToRole(user.Id, kidstaff.UserRoles);
            }
            //SQL Statement to add to KIDStaff
            _stafRepo.AddStaff(kidstaff);
            //Return home page
            return RedirectToAction("Index");
        }
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