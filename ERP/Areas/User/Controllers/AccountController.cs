using ERP.Areas.User.Models;
using ERP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using UserEntity = ERP.Common.Entities.User;

namespace ERP.Areas.User.Controllers
{
    public class AccountController : Controller
    {
        private UserViewModel viewModel;

        public AccountController(UserViewModel vm)
        {
            this.viewModel = vm;
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                // validate user against database
                if (this.viewModel.ValidateUserAgainstDatabase(user.UserName, user.Password))
                {
                    return View("Success", user);
                }
                else
                {
                    ModelState.AddModelError("", "Login failed. Please check your credentials and try again.");

                    return View(user);
                }
            }

            TempData["ViewData"] = ViewData;

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpPost]
        public ActionResult ForgotPassword(string userNameOrEmail)
        {
            if (ModelState.IsValid)
            {
                if (this.viewModel.SendPasswordResetLink(userNameOrEmail))
                {
                    return View("LinkSent");
                }
                else
                {
                    ModelState.AddModelError("", "User with this name or email does not exist. Try again.");
                }
            }

            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}