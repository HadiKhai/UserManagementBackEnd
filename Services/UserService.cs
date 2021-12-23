using System;
using System.Collections.Generic;
using AutoMapper;
using UserManagement.DTO;
using UserManagement.Models;
using UserManagement.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserManagement.Services
{

    public class UserService : IUserService
    {


        private readonly IUserRepo _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(Guid id)
        {
            var userResponse = _userRepository.GetUserById(id);
            if (userResponse == null)
            {
                throw new ArgumentException("User");
            }

            return userResponse;
        }

        public User CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentException(nameof(user));
            }

            user.UserId = Guid.NewGuid();
            return _userRepository.CreateUser(user);
        }

        public void PatchUser(Guid id, JsonPatchDocument<UserUpdateDTO> patchDoc, ModelStateDictionary modelState )
        {
            var userModelFromRepo = _userRepository.GetUserById(id);
            if(userModelFromRepo == null)
            {
                throw new ArgumentException(nameof(userModelFromRepo));
            }

            var userToPatch = _mapper.Map<UserUpdateDTO>(userModelFromRepo);
            patchDoc.ApplyTo(userToPatch, modelState);

            _mapper.Map(userToPatch, userModelFromRepo);

            _userRepository.UpdateUser(userModelFromRepo);
        }

        public void UpdateUser(Guid id, UserUpdateDTO userUpdateDto)
        {
            var userToBeUpdated = _userRepository.GetUserById(id);
            if (userToBeUpdated == null)
            {
                throw new ArgumentException(nameof(userToBeUpdated));
            }

            _mapper.Map(userUpdateDto, userToBeUpdated);
            _userRepository.UpdateUser(userToBeUpdated);
        }

        public void DeletedUserById(Guid id)
        {
            var userToBeDeleted = _userRepository.GetUserById(id);

            if (userToBeDeleted == null)
            {
                throw new ArgumentException(nameof(userToBeDeleted));
            }

            _userRepository.DeleteUser(userToBeDeleted);
        }
    }
}