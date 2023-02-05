using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RentaCar.Models;

[assembly:OwinStartupAttribute(typeof(RentaCar.Startup))]
namespace RentaCar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesAndUsers();
        }

        private void createRolesAndUsers()
        {

                 ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists(Role.Admin))
            {

                var role = new IdentityRole();
                role.Name = Role.Admin;

                roleManager.Create(role); /// napravio si role Admin.

                // kreiras super admina
                var user = new ApplicationUser();
                user.UserName = "bokiadmin44@gmail.com";
                user.Email = "bokiadmin44@gmail.com";
                // user.LockoutEnabled = true;
                string userPWD = "Bokica.89";

                var chkUser = UserManager.Create(user, userPWD); // kreiran super admin

                // add default User to Role Admin
                if (chkUser.Succeeded)
                {

                    var result1 = UserManager.AddToRole(user.Id, Role.Admin);
                }

            }
          else if (!roleManager.RoleExists(Role.Employee))
            {

                var role = new IdentityRole();
                role.Name = Role.Employee;
                roleManager.Create(role);
            }

        else
            {

               var role = new IdentityRole();
                role.Name = Role.User;
                roleManager.Create(role);

            }


             }


        }
    }
