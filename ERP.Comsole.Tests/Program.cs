﻿using ERP.Common.Concrete;
using ERP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Comsole.Tests
{
    class Program
    {
        private static EFDbContext context = new EFDbContext();

        static void Main(string[] args)
        {
            //EncryptDecryptPassword();

            Menu();

            Console.WriteLine();
            Console.WriteLine("Please enter an option number : ");
            string option = Console.ReadLine();
            Console.WriteLine();

            while (option != "3")
            {
                switch (option)
                {
                    case "1":
                        CreateNewUser();
                        break;
                    case "2":
                        RetrieveUser();
                        break;
                    case "3":
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Please enter an option number : ");
                option = Console.ReadLine();
                Console.WriteLine();
            }
        }

        private static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("---- MENU ----");
            Console.WriteLine("Select an option from menu:");
            Console.WriteLine("1: Create new user");
            Console.WriteLine("2: Get user from database");
            Console.WriteLine("3: Exit");
        }

        private static void RetrieveUser()
        {
            string newHash = string.Empty;

            Console.WriteLine("Please enter your user name:");
            string userName = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            
            User retrivedUser = context.Users.FirstOrDefault(x => x.UserName == userName);

            if (retrivedUser != null)
            {
                newHash = PasswordAuthentication.GenerateHash(retrivedUser.Salt, password);

                if (PasswordAuthentication.CompareHashes(retrivedUser.PasswordHash, newHash))
                {
                    Console.WriteLine("You are now logged in!");
                }
                else
                {
                    Console.WriteLine("Passwords do nat match for the specified user name. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("User with given name and password not found. Try again.");
            }
        }

        private static void CreateNewUser()
        {
            try
            {
                Console.WriteLine("Please enter user name:");
                string userName = Console.ReadLine();
                
                Console.WriteLine("Please enter password:");
                string password = Console.ReadLine();

                Console.WriteLine("Please enter email:");
                string email = Console.ReadLine();

                Console.WriteLine("Please enter your first name:");
                string name = Console.ReadLine();

                Console.WriteLine("Please enter last name:");
                string surname = Console.ReadLine();

                Console.WriteLine("Please enter phone number (optional):");
                string phone = Console.ReadLine();

                string salt = PasswordAuthentication.GenerateSalt();
                string hash = PasswordAuthentication.GenerateHash(salt, password);

                Console.WriteLine("Salt : {0}", salt);
                Console.WriteLine("Pssword hash : {0}", hash);
                
                RegisterUser newUser = new RegisterUser
                {
                    UserName = userName,
                    Password = password,
                    Salt = salt,
                    PasswordHash = hash,
                    Email = email,
                    Name = name,
                    Surname = surname,
                    Phone = phone
                };

                context.Users.Add(new User
                {
                    UserName = newUser.UserName,
                    Salt = newUser.Salt,
                    PasswordHash = newUser.PasswordHash,
                    Email = newUser.Email,
                    Name = newUser.Name,
                    Surname = newUser.Surname,
                    Phone = newUser.Phone
                });

                context.SaveChanges();

                Console.WriteLine("Your account has been created.");
                Console.ReadKey();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        private static void EncryptDecryptPassword()
        {
            Console.WriteLine("---- Encrypt password ----");
            Console.WriteLine();

            Console.WriteLine("Please enter a password to use:");
            string password = Console.ReadLine();

            string salt = PasswordAuthentication.GenerateSalt();

            string hash = PasswordAuthentication.GenerateHash(salt, password);

            Console.WriteLine("Your encrypted password : {0}", hash);

            Console.WriteLine();
            Console.WriteLine("---- Decrypt password ----");
            Console.WriteLine();

            Console.WriteLine("Please enter your password:");
            string newPassword = Console.ReadLine();

            string newHash = PasswordAuthentication.GenerateHash(salt, newPassword);

            bool passwordsMatch = PasswordAuthentication.CompareHashes(hash, newHash);

            if (passwordsMatch)
            {
                Console.WriteLine("Given password matches the original.");
            }
            else
            {
                Console.WriteLine("Given password does not match the original.");
            }

            Console.ReadKey();
        }
    }
}