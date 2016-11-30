using ERP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
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
        public ActionResult Login(User user)
        {
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;

                return RedirectToAction("Index", "Home");
            }
            return View("Success", user);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}