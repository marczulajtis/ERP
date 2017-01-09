using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ERP.Common.Helpers
{
    public static class ApplicationHelpers
    {
        public static string GetBaseURL()
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            }

            return string.Empty;
        }
    }
}
