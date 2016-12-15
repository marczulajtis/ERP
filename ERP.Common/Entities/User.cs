using ERP.Common.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Entities
{
    public class User
    {
        public int UserID { get; set; }
        
        public string UserName { get; set; }
        
        public string Salt { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }
    }
}
