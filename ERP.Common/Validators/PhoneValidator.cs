using ERP.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ERP.Common.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PhoneValidator : ValidationAttribute
    {
        /// <summary>
        /// Checks if phone format matches the specified regex 
        /// </summary>
        /// <param name="value">Phone string</param>
        /// <returns>True if matches, otherwise false</returns>
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if (Regex.IsMatch(value.ToString(), Consts.PhoneValidationRegex))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
