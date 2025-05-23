using LordCardShop.Handler;
using LordCardShop.Model;
using LordCardShop.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LordCardShop.Controller
{
    public class RegisterController
    {
        public static bool AddUser(string username, string email, string password, string gender, string confirmationPass, string dobStr, out string errorMessage)
        {
            errorMessage = "";
            if (!CheckName(username))
            {
                errorMessage = "Invalid username";
                return false;
            }
            if (!email.Contains('@'))
            {
                errorMessage = "Email must contain '@'";
                return false;
            }
            if (password.Length >= 8 || !password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                errorMessage = "Password must be at least 8 characters and alphanumeric ";
                return false;
            }
            if (password != confirmationPass)
            {
                errorMessage = "Confirmation password must be the same with password";
                return false;
            }
            if (!CheckDob(dobStr, out DateTime dob))
            {
                errorMessage = "Date of birth is invalid";
                return false;
            }
            if (gender.All(char.IsWhiteSpace))
            {
                errorMessage = "Gender must be chosen";
                return false;
            }
            bool handlerResutl = RegisterHandler.AddUser(username, email, password, dob, gender).Success;
            return handlerResutl;
        }
        public static bool CheckName(string username)
        {
            if (username.Length < 5 || username.Length > 30)
                return false;
            foreach (char c in username)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }
        public static bool CheckDob(string dobStr, out DateTime dob)
        {
            bool isValid = DateTime.TryParse(dobStr, out dob);
            if (!isValid)
                return false;
            if (dob >= DateTime.Today || dob > DateTime.Today.AddYears(-13))
                return false;
            return true;
        }
    }
}