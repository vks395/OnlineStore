using OnlineStore.ActionFilters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [CheckUserSecurity]
    public class OnlineStoreBaseController : Controller
    {
      
    }
}