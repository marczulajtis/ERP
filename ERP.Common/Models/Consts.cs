using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Models
{
    public static class Consts
    {
        /// <summary>
        /// Stores phone validation regex
        /// </summary>
        public const string PhoneValidationRegex = @"^\d{3}(?:[-]?)\d{3}(?:[-]?)\d{3}$";

        public const int MinPasswordLength = 6;

        public const int MaxPasswordLength = 50;

        /// <summary>
        /// Gets hash set of special characters
        /// </summary>
        public static HashSet<char> SpecialCharactersSet
        {
            get
            {
                return new HashSet<char>() { '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '{', '}', '[', ']', '|', ';', ':', '"', '<', ',', '>', '.', '?' };
            }
        }

        public static string PasswordResetLinkSent = "Password reset link has been sent.";

        public static string SomethingWentWrongError = "Something went wrong. Please try again.";

        public const string UserDoesNotExistError = "User with this name or email does not exist. Please try again.";
    }
}
