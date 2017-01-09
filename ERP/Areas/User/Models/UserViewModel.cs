using ERP.Common.Concrete;
using ERP.Common.Entities;
using ERP.Common.Exceptions;
using ERP.Common.Helpers;
using ERP.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UserEntity = ERP.Common.Models.User;

namespace ERP.Areas.User.Models
{
    public class UserViewModel
    {
        private EFDbContext context;
        private EmailService emailService;

        public UserViewModel(EFDbContext context, EmailService emailService)
        {
            this.context = context;
            this.emailService = emailService;
        }

        public bool ValidateUserAgainstDatabase(string userName, string newPassword)
        {
            try
            {
                UserEntity foundUser = this.context.Users.FirstOrDefault(x => x.UserName == userName);

                if (foundUser != null)
                {
                    string hashToCompare = Encryption.GenerateHash(foundUser.Salt, newPassword);

                    if (Encryption.CompareHashes(foundUser.PasswordHash, hashToCompare))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            catch (Exception ex)
            { 
                throw new UserException("An exception occured while validating user against database.", ex);
            }
        }

        public bool RegisterNewUser(RegisterUser newUser)
        {
            try
            {
                if (newUser != null)
                {
                    // generate salt
                    string salt = Encryption.GenerateSalt();

                    // generate password hash
                    string originalHash = Encryption.GenerateHash(salt, newUser.Password);

                    // add new user to database
                    newUser.PasswordHash = originalHash;
                    newUser.Salt = salt;

                    this.context.Users.Add(ConvertToDBUser(newUser));
                    this.context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An exception occured while registering new user.", ex);
            }
        }

        public bool ResetUserPassword(PasswordResetUser user)
        {
            if (user != null)
            {
                try
                {
                    UserEntity userToUpdate = this.context.Users.FirstOrDefault(x => x.UserID == user.UserID);

                    // generate salt
                    string salt = Encryption.GenerateSalt();

                    // generate password hash
                    string originalHash = Encryption.GenerateHash(salt, user.Password);

                    if (userToUpdate != null)
                    {
                        userToUpdate.PasswordHash = originalHash;
                        userToUpdate.Salt = salt;

                        this.context.SaveChanges();

                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw new Exception("An exception occured while changin password for user." + user.UserName, ex);
                }
            }

            return false;
        }

        private UserEntity ConvertToDBUser(RegisterUser newUser)
        {
            return new UserEntity
            {
                UserName = newUser.UserName,
                Name = newUser.Name,
                Email = newUser.Email,
                Surname = newUser.Surname,
                Salt = newUser.Salt,
                PasswordHash = newUser.PasswordHash,
                Phone = newUser.Phone
            };
        }

        public UserEntity RetrieveUserData(string userName)
        {
            // get user from database

            return new UserEntity();
        }

        public bool SendPasswordResetLink(UserEntity user)
        {
            if (context.Users.FirstOrDefault(x => x.UserName == user.UserName || x.Email == user.Email) != null)
            {
                //send link to user email to reset password
                try
                {
                    this.emailService.SendResetEmail(user);

                    return true;
                }
                catch (Exception ex)
                {
                    throw new UserException("An error occured while reseting password. Please try again", ex);
                }
            }

            return false;
        }

        public bool LetUserResetPassword(string linkArguments)
        {
            // get datetime now
            DateTime now = DateTime.Now;

            PasswordReset passwordResetModel = this.GetPasswordResetDataFromLink(linkArguments);

            if ((passwordResetModel.LinkSentDate - now).Minutes < 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public PasswordReset GetPasswordResetDataFromLink(string linkArguments)
        {
            // decrypt part of link
            string nameAndTicks = PasswordResetHelper.GetArgumentValueFromLink(linkArguments);

            // convert ticks to datetime 
            return PasswordResetHelper.ValidateResetCode(nameAndTicks);
        }
    }
}