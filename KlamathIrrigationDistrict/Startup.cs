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
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
