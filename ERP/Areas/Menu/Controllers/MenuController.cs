using ERP.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Menu.Controllers
{
    public class MenuController : Controller
    {
        [CustomAuthorize]
        public ActionResult ShowMenu()
        {
            if (!(User.Identity.IsAuthenticated))
            {
                ModelState.AddModelError("", "This site can only be viewed by authorized users.");

                return View("_NotAuthorized");
            }

            return View();
        }
    }
}