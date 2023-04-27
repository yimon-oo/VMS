using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Security;

namespace EVMS.Controllers
{
    public class BaseController : Controller
    {
        public bool Authorize(utilities.AuthorizeAction action)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    User u = GetLoggedInUser();
            //    List<Permission> permissionlist = permissionRepo.Get();
            //    Permission permission = permissionlist.FirstOrDefault(p => p.program.code.Equals((int)program) && p.role_id.Equals(userRole.ID) && (p.CreateOrUpdate == action || p.View.Equals(action) || p.Delete.Equals(action) || p.Print.Equals(action)));
            //    if (permission != null)
            //    {
            //        return true;
            //    }
            //}      
            return false;
        }

    }
}
