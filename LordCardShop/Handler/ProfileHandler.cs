using LordCardShop.Model;
using LordCardShop.Module;
using LordCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Handler
{
    public class ProfileHandler
    {
        public static Response<User> UpdateUserProfile(int userId, string newUsername, string newEmail, string newGender, DateTime newDob, string oldPassword, string newPassword)
        {
            User userToUpdate = UserRepository.GetUserById(userId);

            if (userToUpdate == null)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "User not found.",
                    Data = null
                };
            }

            // Validasi jika username baru sudah digunakan oleh user lain
            if (userToUpdate.UserName != newUsername)
            {
                if (UserRepository.GetUser(newUsername) != null)
                {
                    return new Response<User>()
                    {
                        Success = false,
                        Message = "Username already taken by another user.",
                        Data = null
                    };
                }
            }

            // Perbarui data yang tidak terkait password
            userToUpdate.UserName = newUsername;
            userToUpdate.UserEmail = newEmail;
            userToUpdate.UserGender = newGender;
            userToUpdate.UserDOB = newDob;

            // Jika ada password baru yang diisi, validasi dan perbarui password
            if (!string.IsNullOrEmpty(newPassword))
            {
                // Verifikasi old password
                if (userToUpdate.UserPassword != oldPassword)
                {
                    return new Response<User>()
                    {
                        Success = false,
                        Message = "Old password does not match.",
                        Data = null
                    };
                }
                userToUpdate.UserPassword = newPassword; // Di aplikasi nyata, hash password baru
            }

            try
            {
                UserRepository.UpdateUser(userToUpdate);
                return new Response<User>()
                {
                    Success = true,
                    Message = "Profile updated successfully!",
                    Data = userToUpdate // Kembalikan objek user yang sudah diperbarui
                };
            }
            catch (Exception ex)
            {
                // Log exception (opsional)
                return new Response<User>()
                {
                    Success = false,
                    Message = "Failed to update profile: " + ex.Message,
                    Data = null
                };
            }
        }
    }
}