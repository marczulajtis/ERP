using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class PasswordsMustMatchAttribute : ValidationAttribute
    {
        private const string defaultErrorMessage = "'{0}' and '{1}' do not match";

        public PasswordsMustMatchAttribute(string password, string confirmPassword)
            :base(defaultErrorMessage)
        {
            OriginalPassword = password;
            ConfirmPassword = confirmPassword;
        }

        public string OriginalPassword { get; private set; }
        public string ConfirmPassword { get; private set; }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                OriginalPassword, ConfirmPassword);
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalPassword = properties.Find(OriginalPassword, true).GetValue(value);
            object confirmPassword = properties.Find(ConfirmPassword, true).GetValue(value);

            return object.Equals(originalPassword, confirmPassword);
        }
    }
}
