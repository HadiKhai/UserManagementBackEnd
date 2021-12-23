using System;
using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Repository
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();
        User?  GetUserById(Guid id);
        User CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}