using LordCardShop.Handler;
using LordCardShop.Model;
using LordCardShop.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Controller
{
    public class LoginController
    {
        public static bool AttemptLogin(string username, string password, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Username and password must be filled.";
                return false;
            }

            var response = LoginHandler.AuthenticateUser(username, password);
            if (!response.Success)
            {
                errorMessage = response.Message;
                return false;
            }

            // Simpan user ke session atau cookie bisa dilakukan di controller/view
            HttpContext.Current.Session["User"] = response.Data;

            return true;
        }
        public static bool ProcessRememberMeLogin(HttpCookie rememberCookie, out string errorMessage)
        {
            errorMessage = "";
            if (rememberCookie == null || string.IsNullOrWhiteSpace(rememberCookie["Username"]))
                return false;

            string username = rememberCookie["Username"];
            var response = LoginHandler.AuthenticateUserFromCookie(username);

            if (!response.Success || response.Data == null)
            {
                errorMessage = response.Message;
                return false;
            }

            // Simpan user ke session
            HttpContext.Current.Session["User"] = response.Data;
            return true;
        }
    }
}