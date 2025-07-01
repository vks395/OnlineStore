using DAL.DataOperation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineStore.ActionFilters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public string Roles { get; set; }
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            //var role = System.Web.Security.Roles.GetRolesForUser().Single();
            var userId = Convert.ToString(httpContext.Session["UserId"]);
            if (!string.IsNullOrEmpty(userId))
            {
               
                UserDAL userDal = new UserDAL();
                if (userDal.getAllUser().Where(m => m.UserId == userId).Select(m => m.RoleName).ToArray().Intersect(Roles.Split(',')).Any())
                {
                    return true;
                }
                //foreach (var role in allowedroles)
                //{
                //    if (userRoles.Contains(role)) return true;
                //}
           
            
        }

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "LogIn" },
                    { "action", "NotAuthorized" }
               });
        }
    }
}