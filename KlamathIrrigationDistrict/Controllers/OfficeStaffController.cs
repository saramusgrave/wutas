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
using Microsoft.AspNet.Identity.EntityFramework;

namespace KlamathIrrigationDistrict.Controllers
{
    public class OfficeStaffController : Controller
    {
        private ApplicationUserManager _userManager;
        public OfficeStaffController(ApplicationUserManager userManager, ApplicationRoleManager userRole)
        {
            UserManager = userManager;
            RoleManager = userRole;
            //SignInManager = signInManager;
        }
        private ApplicationRoleManager _RoleManager;
        protected ApplicationRoleManager RoleManager
        {
            get
            {
                if (_RoleManager == null)
                {
                    _RoleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
                }
                return _RoleManager;
            }
            private set
            {
                _RoleManager = value;
            }
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
        //[Authorize(Roles = "Office Specialist")]
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
        //add all kid staff to roles in asp tabel run one time
        public ActionResult LogIn()
        {
            PositionsRepository pos = new PositionsRepository();
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var positions = pos.PositionsList();
            foreach (var p in positions)
            {
                if (!RoleManager.RoleExists(p.Position))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = p.Position;
                    roleManager.Create(role);
                }
            }
            var list = _stafRepo.ViewStaff();
            foreach (var kidstaff in list)
            {
                var user = new ApplicationUser { UserName = kidstaff.Email, Email = kidstaff.Email };
                var result = this.UserManager.Create(user, kidstaff.Password);
                if (result.Succeeded)
                {
                    //UserManager.AddToRole(user.Id, positions.Where(p => p.PositionID == kidstaff.Position).FirstOrDefault()?.Position);
                    UserManager.AddToRole(user.Id, positions.Where(p => p.Position == kidstaff.Position).FirstOrDefault()?.Position);
                }
            }
            return (RedirectToAction("Index"));
        }
        //Edit Staff
        //[Authorize(Roles = "Office Specialist")]

        public ActionResult StaffEdit(int StaffID)
        {
            //StaffEditModel model = new StaffEditModel();
            //model.StaffMember = _stafRepo.ViewStaff().Where(s => s.StaffID == StaffID).FirstOrDefault();
            //model.PositionID = new List<SelectListItem>();
            //return View(model);


            //Original
            var std = _stafRepo.ViewStaff().Where(s => s.StaffID == StaffID).FirstOrDefault();
            return View(std);
        }
        //[Authorize(Roles = "Office Specialist")]

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
            //DateTime ModifiedDateTime = std.ModifiedDateTime;
            DateTime ModifiedDateTime = DateTime.Now;
            //string ModifiedUser = std.ModifiedUser;
            string ModifiedUser = User.Identity.Name;
            _stafRepo.EditStaff(std);
            return RedirectToAction("Index");
        }

        //Add Staff
        //[Authorize(Roles = "Office Specialist")]

        [HttpGet]
        public ActionResult Add()
        {
            return View(new KIDStaff());
        }
        //[Authorize(Roles = "Office Specialist")]

        [HttpPost]
        public ActionResult Add(KIDStaff kidstaff)
        {
            //Adding to KIDStaff
            if (!ModelState.IsValid)
            {
                return View(kidstaff);
            }
            //Adds user to ASP side of things...ASP = SQL, ASP = SQL
            //modified date time = get now
            //modifed user = get current user login
            var user = new ApplicationUser { UserName = kidstaff.Email, Email = kidstaff.Email};
            var result = this.UserManager.Create(user, kidstaff.Password);
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, kidstaff.Position.ToString());

                //UserManager.AddToRole(user.Id, "Project Worker");
                var role = this.RoleManager.FindByName("");
                //role.Users.Add();
                //this.UserManager.AddToRole(user.Id, kidstaff.UserRoles);
            }
            //SQL Statement to add to KIDStaff
            _stafRepo.AddStaff(kidstaff);
            //Return home page
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "Office Specialist")]

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