using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

        public static string ERPContextConnection = "ERPContextConnection";

        public static string PasswordResetLinkSent = "Password reset link has been sent.";

        public static string SomethingWentWrongError = "Something went wrong. Please try again.";

        public const string UserDoesNotExistError = "User with this name or email does not exist. Please try again.";

        public const string PasswordLinkExpiredError = "Password link expired.";

        public const string PasswordChanged = "Your password has been changed";

        public const string CouldNoChangePasswordError = "Something went wrong during your password change. Please try again.";

        #region Reset password

        public const string ResetLinkBodyMessagePart1 = "<p> Request has been received to reset your password." +
                " If you did not initiate this request, please ignore this email.</p> <p> Please click the following link ";
        public const string ResetLinkBodyMessagePart2 = " to reset your password </p> <br/> <p> This link will be active for 15 minutes from visiting it. </p>";

        public const string EmailSubject = "Password reset";

        internal static string PasswordLinkCommonPath = "/User/User/ResetPassword?userNameAndDate=";
        #endregion
    }
}
