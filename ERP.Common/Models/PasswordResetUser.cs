using ERP.Common.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Models
{
    public class PasswordResetUser
    {
        public int UserID { get; set; }
        
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [PasswordValidator(ErrorMessage = "Password must have at least one digit, one special character, one lower and upper case letter and must be 6 - 50 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public string Salt { get; set; }

        public string PasswordHash { get; set; }
    }
}
