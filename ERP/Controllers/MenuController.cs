using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult ShowMenu()
        {
            return View();
        }
    }
}