using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Models;

namespace UserManagement.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext _context;

        public UserRepo(UserContext context)
        {
            _context = context;
        }
        
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        
        public User GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(p => p.UserId.Equals(id));
        }

        public User CreateUser(User user)
        {
            var userResponse = _context.Add(user).Entity;
            _context.SaveChanges();
            return userResponse;
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            _context.SaveChanges();
        }
    }
}