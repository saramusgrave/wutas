using KlamathIrrigationDistrict.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

[assembly: OwinStartupAttribute(typeof(KlamathIrrigationDistrict.Startup))]
namespace KlamathIrrigationDistrict
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Role authentication
            createRolesandUsers();
        }
        //create efault user roles and admin user for login
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            
            //In startup iam createing first admin role and creating a default admin user
            if (!roleManager.RoleExists("Admin"))
            {
                //first create admin rool
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                //create admin super user who will maintain the website
                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "Admin@Admin.com";
                string userPWD = "Admin01";
                var chkUser = UserManager.Create(user, userPWD);

                //Add default user to Role Admin
                if(chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
            //creating Creating District Manager role
            if (!roleManager.RoleExists("District Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "District Manager";
                roleManager.Create(role);
            }
            //creating creating Assistant Manager role
            if(!roleManager.RoleExists("Assistant Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Assistant Manager";
                roleManager.Create(role);
            }
            //Creating creating Water Master Role
            if(!roleManager.RoleExists("Water Master"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework. IdentityRole();
                role.Name = "Water Master";
                roleManager.Create(role);
            }
            //creating Office Specialist Role
            if (!roleManager.RoleExists("Office Specialist"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Office Specialist";
                roleManager.Create(role);
            }
            //Crating Bookkeeper Role
            if (!roleManager.RoleExists("Book Keeper"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Book Keeper";
                roleManager.Create(role);
            }
            //Creating Maitenance Supervisor
            if (!roleManager.RoleExists("Maitenance Supervisor"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Maitenance Supervisor";
                roleManager.Create(role);
            }
            //Ride 1 Role
            if (!roleManager.RoleExists("Ride 1"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Ride 2";
                roleManager.Create(role);
            }
            //Ride 2 Role
            if (!roleManager.RoleExists("Ride 2"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Ride 2";
                roleManager.Create(role);
            }
            //Ride 3 Role
            if (!roleManager.RoleExists("Ride 3"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Ride 3";
                roleManager.Create(role);
            }
            //Ride 4 Role
            if (!roleManager.RoleExists("Ride 4"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Ride 4";
                roleManager.Create(role);
            }
            //Ride 5 Role
            if (!roleManager.RoleExists("Ride 5"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Ride 5";
                roleManager.Create(role);
            }
            //Ride 6 Role
            if (!roleManager.RoleExists("Ride 6"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Ride 6";
                roleManager.Create(role);
            }
            //Ride 7 Role
            if (!roleManager.RoleExists("Ride 7"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Ride 7";
                roleManager.Create(role);
            }
            //Ride 8 Role
            if (!roleManager.RoleExists("Ride 8"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Ride 8";
                roleManager.Create(role);
            }
            //Relief Ride 1
            if (!roleManager.RoleExists("Relief Ride 1"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Relief Ride 2";
                roleManager.Create(role);
            }
            //Relief Ride 2
            if (!roleManager.RoleExists("Relief Ride 2"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Relief Ride 2";
                roleManager.Create(role);
            }
            //Relief Ride 3
            if (!roleManager.RoleExists("Relief Ride 3"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Relief Ride 3";
                roleManager.Create(role);
            }
            //Relief Ride 4
            if (!roleManager.RoleExists("Relief Ride 4"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Relief Ride 4";
                roleManager.Create(role);
            }
            //Relief Ride 5
            if (!roleManager.RoleExists("Relief Ride 5"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Relief Ride 5";
                roleManager.Create(role);
            }
            //Relief Ride 6
            if (!roleManager.RoleExists("Relief Ride 6"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Relief Ride 6";
                roleManager.Create(role);
            }
            //Relief Ride 7
            if (!roleManager.RoleExists("Relief Ride 7"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Relief Ride 7";
                roleManager.Create(role);
            }
            //Relief Ride 8
            if (!roleManager.RoleExists("Relief Ride 8"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Relief Ride 8";
                roleManager.Create(role);
            }
            //Project Manager
            if (!roleManager.RoleExists("Project Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Project Manager";
                roleManager.Create(role);
            }
            //Project Worker
            if (!roleManager.RoleExists("Project Worker"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Project Worker";
                roleManager.Create(role);
            }
        }
    }
}
