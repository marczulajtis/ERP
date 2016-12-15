using ERP.Common.Concrete;
using ERP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UserEntity = ERP.Common.Entities.User;

namespace ERP.Areas.User.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {            
        }

        public bool ValidatePasswordAgainstDatabase(string userName, string newPassword)
        {
            // retrieve salt
            // retrieve original password hash

            // generate new hash from given password

            // compare two hashes

            return false;
        }

        public void RegisterNewUser(RegisterUser newUser)
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
            }
        }

        public UserEntity RetrieveUserData(string userName)
        {
            // get user from database

            return new UserEntity();
        }
    }
}