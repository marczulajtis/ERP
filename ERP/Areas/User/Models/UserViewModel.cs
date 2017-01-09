using ERP.Common.Concrete;
using ERP.Common.Entities;
using ERP.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UserEntity = ERP.Common.Entities.User;

namespace ERP.Areas.User.Models
{
    public class UserViewModel
    {
        private EFDbContext context;

        public UserViewModel(EFDbContext context)
        {
            this.context = context;
        }

        public bool ValidateUserAgainstDatabase(string userName, string newPassword)
        {
            try
            {
                UserEntity foundUser = this.context.Users.FirstOrDefault(x => x.UserName == userName);

                if (foundUser != null)
                {
                    string hashToCompare = PasswordAuthentication.GenerateHash(foundUser.Salt, newPassword);

                    if (PasswordAuthentication.CompareHashes(foundUser.PasswordHash, hashToCompare))
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
            // retrieve salt
            // retrieve original password hash

            // generate new hash from given password

            // compare two hashes

            return false;
        }

        public bool RegisterNewUser(RegisterUser newUser)
        {
            try
            {
                if (newUser != null)
                {
                    // generate salt
                    string salt = PasswordAuthentication.GenerateSalt();

                    // generate password hash
                    string originalHash = PasswordAuthentication.GenerateHash(salt, newUser.Password);

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

        public bool SendPasswordResetLink(string userNameOrEmail)
        {
            if (this.context.Users.FirstOrDefault(x => x.UserName == userNameOrEmail || x.Email == userNameOrEmail) != null)
            {
                //send link to user email to reset password

                return true;
            }

            return false;
        }
    }
}