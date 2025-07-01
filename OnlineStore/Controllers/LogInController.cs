using BAL;

using DAL;
using DAL.DataOperation;

using OnlineStore.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineStore.Controllers
{
    [AllowAnonymous]
    public class LogInController : Controller
    {
        // GET: LogIn
        private readonly UserBAL userBal;
        public LogInController()
        {
            userBal = new UserBAL();
        }
        public ActionResult Index()
        {   //checking sesssion exist then redirect to Home Page
            if (Session["UserName"] != null && Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            LoginVM user = new LoginVM();
            return View(user);
        }
        [HttpPost]
        public ActionResult Index(LoginVM user)
        {
            if (user != null)
            {
                if (ModelState.IsValid)
                {

                    User userObject = new User();
                    userObject.UserId = user.UserId;
                    userObject.Password = user.Password;
                    ViewData["msg"] = "";
                    if (userBal.existingUser(user.UserId))
                    {
                        var UserData = userBal.getUserLogin(userObject);
                        if (UserData != null)
                        {
                            FormsAuthentication.SetAuthCookie(UserData.UserId, false); //Use in Role Provide for FormsAuthentication
                             //Created Session                                                
                            Session["UserName"] = UserData.UserName;
                            Session["UserId"] = UserData.UserId;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewData["msg"] = "Entered Password is wrong !";
                            return View(user);
                        }
                    }
                    else
                    {
                        ViewData["msg"] = "Entered User Id is wrong !";
                        return View(user);
                    }
                }



            }
            return View(user);
        }

        public ActionResult LogOut()
        {//clearing all session 
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public ActionResult NotAuthorized()
        {
            return View();
        }
    }
}