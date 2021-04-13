using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManager.Repositories
{
    public class UseRepository
    {
        public static User Get(string userName, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, UserName = "d.modesto", Password = "Teste@123", Role = "teacher" });
            users.Add(new User { Id = 2, UserName = "j.silva", Password = "Teste@123", Role = "student" });
            return users.Where(x => x.UserName.ToLower() == userName.ToLower() && x.Password == password).FirstOrDefault(); 
        }
    }
}
