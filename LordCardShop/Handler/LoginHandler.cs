using LordCardShop.Model;
using LordCardShop.Module;
using LordCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Handler
{
    public class LoginHandler
    {
        public static Response<User> AuthenticateUser(string username, string password)
        {
            User user = UserRepository.GetUser(username);
            if(user == null || user.UserPassword != password)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Invalid username or password",
                    Data = null
                };
            }
            return new Response<User>()
            {
                Success = true,
                Message = "Login successfully",
                Data = user
            };
        }
        public static Response<User> AuthenticateUserFromCookie(string username)
        {
            User user = UserRepository.GetUser(username);
            if (user == null)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Invalid username",
                    Data = null
                };
            }
            return new Response<User>()
            {
                Success = true,
                Message = "Successfully login",
                Data = user
            };
        }

    }
}