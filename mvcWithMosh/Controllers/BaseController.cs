using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using mvcWithMosh.Models;
using System.Web.Mvc;

namespace mvcWithMosh.Controllers
{
    public abstract class BaseController<TApplicationUser, TIdentityRole, TIdentityDbContext> : Controller
        where TApplicationUser : ApplicationUser, new()
        where TIdentityRole : IdentityRole, new()
        where TIdentityDbContext : IdentityDbContext<TApplicationUser>, new()
        {
            public UserManager<TApplicationUser> UserManager { get; set; }
            public RoleManager<TIdentityRole> RoleManager { get; set; }
            public TIdentityDbContext Context { get; set; }
            protected BaseController()
            {
                Context = new TIdentityDbContext();
                UserManager = new UserManager<TApplicationUser>(new UserStore<TApplicationUser>(Context));
                UserManager.UserValidator = new UserValidator<TApplicationUser>(UserManager) { AllowOnlyAlphanumericUserNames = false };
                RoleManager = new RoleManager<TIdentityRole>(new RoleStore<TIdentityRole>(Context));
            }
            protected override void Dispose(bool disposing)
            {
                if (RoleManager != null) RoleManager.Dispose();
                if (UserManager != null) UserManager.Dispose();
                if (Context != null) Context.Dispose();
                base.Dispose(disposing);
            }
        }

    
}