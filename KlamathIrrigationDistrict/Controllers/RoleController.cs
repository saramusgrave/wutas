using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using KlamathIrrigationDistrict.DataLayer.Repositories;
using KlamathIrrigationDistrict.Models;
using System.Linq;
using System.Web.Mvc;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KlamathIrrigationDistrict.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        //private IOfficeStaffRepository _OfficeRepo;
        //private IRolesRepository _RoleRepo;
        ApplicationDbContext context;
        //userscontroller isAdminUser;
        public RoleController()
        {
            //_OfficeRepo = new OfficeStaffRepository();
            //_RoleRepo = new RoleRepository();
            context = new ApplicationDbContext();
        }
        
        //Get: Registration
        //[HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);
            //Original
            //return View(_RoleRepo.GetUserRole(User.Identity.Name));
        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {


                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Role = new IdentityRole();
            return View(Role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //[Authorize]
        //public ActionResult AddRole()
        //{
        //    RoleModel model = new RoleModel();
        //    model.Staff = _OfficeRepo.ViewStaff();
        //    return View(model);
        //}
        //[HttpPost]
        //[Authorize]
        //public ActionResult AddRole(RoleModel role)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        role.Staff = _OfficeRepo.ViewStaff();
        //        return View(role);
        //    }
        //    Roles roleData = new Roles();
        //    roleData.StaffID = role.StaffID;
        //    roleData.Position = role.Position;
        //    roleData.FirstName = role.FirstName;
        //    roleData.LastName = role.LastName;
        //    roleData.FullName = role.FullName;
        //    roleData.Password = role.Password;

        //    _RoleRepo.SaveRoles(roleData);
        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //public ActionResult AdminIndex()
        //{
        //    //original
        //    return View(_RoleRepo.GetRoles());
        //}
        //Commented out below 
        //private ApplicationRoleManager _RoleManager;
        //private ApplicationUserManager _UserManager;

        //protected ApplicationRoleManager RoleManager
        //{
        //    get
        //    {
        //        if (_RoleManager == null)
        //        {
        //            _RoleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
        //        }
        //        return _RoleManager;
        //    }
        //}

        //protected ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        if (_UserManager == null)
        //        {
        //            _UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //        }
        //        return _UserManager;
        //    }
        //    private set
        //    {
        //        _UserManager = value;
        //    }
        //}
        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public ActionResult JoinRole(string RoleName)
        //{
        //    UserManager.AddToRole(User.Identity.GetUserId(), RoleName);
        //    return RedirectToAction("Roles");
        //}
        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public ActionResult JoinRole(string RoleName, string UserName)
        //{
        //    UserManager.AddToRole(User.Identity.GetUserId(), RoleName);
        //    return RedirectToAction("Roles");
        //}
        //[HttpGet]
        //[Authorize]
        //public ActionResult Roles()
        //{
        //    List<string> roleNames = RoleManager.Roles.Select(role => role.Name).ToList();
        //    return View(roleNames);
        //}
        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public ActionResult Roles(string RoleName)
        //{
        //    var role = new ApplicationRole();
        //    role.Id = Guid.NewGuid().ToString();
        //    role.Name = RoleName;
        //    RoleManager.Create(role);
        //    return RedirectToAction("Roles");
        //}
        // GET: Role
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}