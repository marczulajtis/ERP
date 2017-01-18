using ERP.Common.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private EFDbContext context;

        public AdminController(EFDbContext context)
        {
            this.context = context;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            return View();
        }
    }
}