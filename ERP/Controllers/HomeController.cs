using ERP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            return View();
        }
    }
}