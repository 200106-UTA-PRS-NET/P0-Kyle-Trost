using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using PizzaBox.Domain;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing
{
    public class TestUserRepository : IUserRepository<User>
    {
        public DbSet<User> TestUserRepo { get; set; }

        public TestUserRepository()
        {
            var fakeUser1 = new User
            {
                UserId = 1,
                UserName = "Harold",
                UserPass = "asdf",
            };
            var fakeUser2 = new User
            {
                UserId = 2,
                UserName = "Ronda",
                UserPass = "jkl;",
            };
            var fakeUser3 = new User
            {
                UserId = 3,
                UserName = "PizzaAdmin",
                UserPass = "iamthepizza",
                StoreId = 1
            };

            TestUserRepo.Add(fakeUser1);
            TestUserRepo.Add(fakeUser2);
            TestUserRepo.Add(fakeUser3);
        }

        public void AddUser(User user)
        {
            //throw new NotImplementedException();

            if (TestUserRepo.Any(u => u.UserName == user.UserName) || user.UserName == null)
            {
                Console.WriteLine($"User {user.UserName} already exists and cannot be added");
                return;
            }
            else
            {
                Console.WriteLine($"Adding user {user.UserName}...");
                TestUserRepo.Add(user);
                Console.WriteLine($"User {user.UserName} added successfully");
            }
        }

        public IEnumerable<User> GetUsers(string user = null, string pass = null)
        {
            var query = (user != null && pass != null)
                        ? from u in TestUserRepo
                          where u.UserName == user && u.UserPass == pass
                          select u
                        : from u in TestUserRepo
                          where u.UserName == user && u.UserPass == pass
                          select u;

            return query;
        }

        public void ModifyUser(User user)
        {
            if (TestUserRepo.Any(u => u.UserId == user.UserId))
            {
                var userTemp = TestUserRepo.FirstOrDefault(u => u.UserId == user.UserId);
                userTemp.UserName = user.UserName;
                userTemp.UserPass = user.UserPass;
                TestUserRepo.Update(userTemp);
            }
            else
            {
                Console.WriteLine($"User with ID {user.UserId} does not exist");
                return;
            }
        }

        public void RemoveUser(int id)
        {
            var userTemp = TestUserRepo.FirstOrDefault(u => u.UserId == id);
            if (userTemp.UserId == id)
            {
                TestUserRepo.Remove(userTemp);
            }
            else
            {
                Console.WriteLine($"User with ID {id} does not exist");
                return;
            }
        }
    }
}
