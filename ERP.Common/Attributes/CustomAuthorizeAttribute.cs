using ERP.Common.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EntityUser = ERP.Common.Models.User;

namespace ERP.Common.Attributes
{
    public class  CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);

            if (isAuthorized)
            {
                var authCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie != null)
                {
                    string userName = FormsAuthentication.Decrypt(httpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                    string roles = string.Empty;

                    using (EFDbContext context = new EFDbContext())
                    {
                        EntityUser user = context.Users.SingleOrDefault(x => x.UserName == userName);

                        if (user.Role != null)
                        {
                            roles = user.Role.RoleName;
                        }
                    }

                    httpContext.User = new GenericPrincipal(
                        new GenericIdentity(userName, "Forms"), roles.Split(','));
                }
            }

            return isAuthorized;
        }
    }
}
