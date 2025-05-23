using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Factory
{
    public class UserFactory
    {
        public static User NewUser(string username, string password, string email, DateTime dob, string gender)
        {
            User user = new User();
            user.UserName = username;
            user.UserPassword = password;
            user.UserEmail = email;
            user.UserDOB = dob;
            user.UserGender = gender;
            user.UserRole = "Customer";

            return user;
        }
    }
}