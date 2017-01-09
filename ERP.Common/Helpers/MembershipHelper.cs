using ERP.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ERP.Common.Helpers
{
    public static class MembershipHelper
    {
        public static Membership ValidateResetCode(string digest)
        {
            return new Membership();
        }
    }
}
