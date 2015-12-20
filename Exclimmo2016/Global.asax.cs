using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Exclimmo2016.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Exclimmo2016
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Seed();
        }

        private async void Seed()
        {
            const string roleName = "administrator";
            const string userName = "admin@koekoek.be";
            var userContext = new ApplicationDbContext();
            var roleStore = new RoleStore<IdentityRole>(userContext);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (roleManager.RoleExists(roleName)) return;
            await roleManager.CreateAsync(new IdentityRole(roleName));
            var userStore = new UserStore<ApplicationUser>(userContext);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var admin = new ApplicationUser() {UserName = userName};
            await userManager.CreateAsync(admin, "Koekoek!IsNummer1");
            await userManager.AddToRoleAsync(admin.Id, roleName);

            var pandContext = new ExclimmoContext();
            pandContext.SeedPanden();

        }
    }
}
