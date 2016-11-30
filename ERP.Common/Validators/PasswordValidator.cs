using ERP.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Validators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class PasswordValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string password = value.ToString();

                if (password.Any(char.IsLower) &&
                    password.Any(char.IsUpper) &&
                    password.Any(char.IsDigit) &&
                    password.Any(Consts.SpecialCharactersSet.Contains) &&
                    password.Length >= Consts.MinPasswordLength &&
                    password.Length <= Consts.MaxPasswordLength)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
