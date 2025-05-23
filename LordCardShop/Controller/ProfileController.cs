using LordCardShop.Handler;
using LordCardShop.Model;
using LordCardShop.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Controller
{
    public class ProfileController
    {
        public static bool UpdateProfile(int userId, string username, string email, string password, string gender, string oldPassword, string newPassword, string confirmationPass, string dobStr, out string errorMessage)
        {
            errorMessage = "";

            if (!CheckUsername(username))
            {
                errorMessage = "Username must be between 5 and 30 characters and contain letters/spaces only";
                return false;
            }

            if (!email.Contains('@'))
            {
                errorMessage = "Email must contain '@'";
                return false;
            }

            if (string.IsNullOrWhiteSpace(gender))
            {
                errorMessage = "Gender must be chosen";
                return false;
            }

            if (!CheckDob(dobStr, out DateTime dob))
            {
                errorMessage = "Date of birth is invalid (must be at least 13 years old and not a future date)";
                return false;
            }

            if (!string.IsNullOrEmpty(newPassword))
            {
                if (string.IsNullOrWhiteSpace(oldPassword))
                {
                    errorMessage = "Old password must be filled to change password";
                    return false;
                }

                if (newPassword.Length < 8 || !newPassword.Any(char.IsLetter) || !newPassword.Any(char.IsDigit))
                {
                    errorMessage = "New password must be at least 8 characters and alphanumeric";
                    return false;
                }

                if (newPassword != confirmationPass)
                {
                    errorMessage = "Confirmation password must be the same as new password";
                    return false;
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(oldPassword) || !string.IsNullOrWhiteSpace(confirmationPass))
                {
                    errorMessage = "Please fill in new password if you intend to change your password.";
                    return false;
                }
            }

            // Panggil handler
            bool updateResult = ProfileHandler.UpdateUserProfile(userId, username, email, gender, dob, oldPassword, newPassword).Success;

            return updateResult;
        }


        // Metode validasi yang sama dari RegisterController, bisa dipindah ke Utilities/Helper class jika banyak digunakan
        public static bool CheckUsername(string username)
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