using LordCardShop.Factory;
using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordCardShop.Repository
{
    public class UserRepository
    {
        static UserDatabaseEntities userDb = new UserDatabaseEntities();
        public static void InsertUser(User user)
        {
            userDb.Users.Add(user);
            userDb.SaveChanges();
        }
        public static User GetUser(string username)
        {
            return userDb.Users.FirstOrDefault(u => u.UserName == username);
        }
        public static User GetUserById(int userId)
        {
            using (var userDb = new UserDatabaseEntities())
            {
                return userDb.Users.FirstOrDefault(u => u.UserId == userId);
            }
        }
        public static void UpdateUser(User updatedUser)
        {
            using (var userDb = new UserDatabaseEntities())
            {
                userDb.Entry(updatedUser).State = System.Data.Entity.EntityState.Modified;
                userDb.SaveChanges();
            }
        }
    }
}