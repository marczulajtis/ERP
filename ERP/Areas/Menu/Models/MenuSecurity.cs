using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Areas.Menu.Models
{
    public class MenuSecurity
    {
        public static bool IsAdministrator
        {
            get
            {
                return HttpContext.Current.User != null && HttpContext.Current.User.IsInRole("Admin");
            }
        }
    }
}