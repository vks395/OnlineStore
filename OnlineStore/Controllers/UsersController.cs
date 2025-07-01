using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;

using DAL;

using OnlineStore.ActionFilters;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    [CustomAuthorizeAttribute(Roles = "administrators")]
    public class UsersController : OnlineStoreBaseController
    {
        private readonly UserBAL userBal;
        public UsersController()
        {
            userBal = new UserBAL();

        }
        // GET: Users
        public ActionResult UsersDetails()
        {
            //fetching Record of All Users 
            var userlist = userBal.getAllUser();
            return View(userlist);
        }
        public ActionResult UsersAdd()
        {
            UserVM user = new UserVM();
            user.RoleList = GetRolesDDL(); //Dropdown for Roles
            return View(user);
        }

        private List<SelectListItem> GetRolesDDL()
        {

            var ObjSelectListItemList = new List<SelectListItem>()
            {
                new SelectListItem {Text="Select",Value="",Selected=true },
                new SelectListItem {Text="customers",Value="1" },
                new SelectListItem {Text="administrators",Value="2"},
                new SelectListItem {Text="sellers",Value="3"},

            };
            return ObjSelectListItemList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsersAdd(UserVM user)
        {
            user.RoleList = GetRolesDDL();
            user.RoleId = user.RoleId;

            if (ModelState.IsValid)
            {

                if (!string.IsNullOrEmpty(user.UserId))
                {
                    User userobj = new User();
                    userobj.CreateDate = DateTime.Now;
                    userobj.UserId = user.UserId;
                    userobj.UserName = user.UserName;
                    userobj.RoleId = Convert.ToInt32(user.RoleId);
                    userobj.Password = user.Password;
                    TempData["msg"] = "";
                    if (!userBal.existingUser(user.UserId))
                    {

                        TempData["msg"] = userBal.createUser(userobj);
                    }
                    else
                    {
                        TempData["msg"] = userBal.updateUser(userobj);
                    }
                    return RedirectToAction("UsersDetails");
                }


                return View(user);
            }


            return View(user);
        }
        public ActionResult UsersDelete(string UserId)
        {
            if (userBal.existingUser(UserId))
            {
                TempData["msg"] = userBal.DeleteUser(UserId);
            }
            else
            {
                TempData["msg"] = "Not Found";
            }
            return RedirectToAction("UsersDetails");
        }
        public ActionResult UsersEdit(string UserId)
        {
            
            UserVM user = new Models.UserVM();
            var userdata=   userBal.getUserByUserId(UserId);
            user.RoleList = GetRolesDDL();
            user.RoleId = userdata.RoleId.ToString();
            user.UserId = userdata.UserId;
            user.UserName = userdata.UserName;
            user.Password = userdata.Password;
            return View(user);
        }
        [HttpPost]
        public ActionResult UsersEdit(UserVM user)
        {
            user.RoleList = GetRolesDDL();
            user.RoleId = user.RoleId;
            if (ModelState.IsValid)
            {

                if (!string.IsNullOrEmpty(user.UserId))
                {
                    User userobj = new User();
                    userobj.CreateDate = DateTime.Now;
                    userobj.UserId = user.UserId;
                    userobj.UserName = user.UserName;
                    userobj.RoleId = Convert.ToInt32(user.RoleId);
                    userobj.Password = user.Password;
                    TempData["msg"] = "";
                    if (userBal.existingUser(user.UserId))
                    {

                   
                        TempData["msg"] = userBal.updateUser(userobj);
                    }
                    return RedirectToAction("UsersDetails");
                }


                return View(user);
            }
            return View(user);
        }
        }
}