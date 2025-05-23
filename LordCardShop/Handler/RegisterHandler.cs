using LordCardShop.Factory;
using LordCardShop.Model;
using LordCardShop.Module;
using LordCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Handler
{
    public class RegisterHandler
    {
        public static Response<User> AddUser(string username, string email, string password, DateTime dob, string gender)
        {
            User user = UserFactory.NewUser(username, password, email, dob, gender);
            UserRepository.InsertUser(user);
            return new Response<User>()
            {
                Success = true,
                Message = "Successfully created new user",
                Data = user
            };
        }
    }
}