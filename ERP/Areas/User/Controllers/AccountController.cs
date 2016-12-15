using ERP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.User.Controllers
{
    public class AccountController : Controller
    {
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
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;

                return RedirectToAction("Index", "Home", new { area = "" });
            }

            // validate user against database

            return View("Success", user);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}