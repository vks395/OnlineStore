using DAL.DataOperation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineStore.ActionFilters
{
   
    public class CheckUserSecurityAttribute : ActionFilterAttribute
    {
      
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        
            var redirectResult = new RedirectResult("/LogIn/NotAuthorized");
			var redirectResultlogOut = new RedirectResult("/LogIn/LogOut");
			if (filterContext.HttpContext.Session["UserId"] == null && filterContext.HttpContext.Session["UserName"] == null)
            {
                filterContext.Result = redirectResultlogOut;

            }
           else if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = redirectResult;
            }


        }
    }
}
