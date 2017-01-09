using ERP.Areas.User.Models;
using ERP.Common.Concrete;
using ERP.Common.Entities;
using ERP.Common.Exceptions;
using ERP.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityUser = ERP.Common.Models.User;

namespace ERP.Areas.User.Controllers
{
    public class AccountController : Controller
    {
        private UserViewModel viewModel;
        private EFDbContext context;

        public AccountController(UserViewModel vm, EFDbContext context)
        {
            this.viewModel = vm;
            this.context = context;
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
            try
            {
                if (ModelState.IsValid)
                {
                    EntityUser user = this.context.Users.FirstOrDefault(x => x.UserName == userNameOrEmail || x.Email == userNameOrEmail);

                    if (user != null)
                    {
                        if (this.viewModel.SendPasswordResetLink(user))
                        {
                            //return View("ResetPasswordLinkSent");
                            //TempData.Add("successs", Consts.PasswordResetLinkSent);
                            ViewBag.Success = Consts.PasswordResetLinkSent;
                        }
                        else
                        {
                            ModelState.AddModelError("", Consts.UserDoesNotExistError);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", Consts.UserDoesNotExistError);
                    }
                }
            }
            catch (UserException userEx)
            {
                ModelState.AddModelError("", Consts.SomethingWentWrongError);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", Consts.SomethingWentWrongError);
            }

            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}