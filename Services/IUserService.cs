using System;
using System.Collections.Generic;
using UserManagement.DTO;
using UserManagement.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace UserManagement.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid id);
        User CreateUser(User user);
        void PatchUser(Guid id, JsonPatchDocument<UserUpdateDTO> patchDoc, ModelStateDictionary modelState);
        void UpdateUser(Guid id, UserUpdateDTO userDto);
        void DeletedUserById(Guid id);
    }
}