using ERP.Common.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Entities
{
    public class RegisterUser
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [PasswordValidator(ErrorMessage = "Password must have at least one digit, one special character, one lower and upper case letter and must be 6 - 50 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        //[PasswordsMustMatchAttribute(Password, ConfirmPassword)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public string Salt { get; set; }

        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "E-mail is required.")]
        [EmailAddress(ErrorMessage = "E-mail address is not in a correct format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }

        [PhoneValidator]
        public string Phone { get; set; }
    }
}
