using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Models
{
    public class PasswordReset
    {
        public bool IsValid { get; set; }

        public string UserName { get; set; }

        public DateTime LinkSentDate { get; set; }
    }
}
