using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;
using TrashCollector.Models;

[assembly: OwinStartupAttribute(typeof(TrashCollector.Startup))]
namespace TrashCollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }
        private void CreateRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Employee"))
            {
                var employeeRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                employeeRole.Name = "Employee";
                roleManager.Create(employeeRole);
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var customerRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                customerRole.Name = "Customer";
                roleManager.Create(customerRole);
            }
        }
    }
}
