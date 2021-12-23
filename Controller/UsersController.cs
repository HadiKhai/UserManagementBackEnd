using System;
using System.Collections.Generic;
using AutoMapper;
using UserManagement.DTO;
using UserManagement.Models;
using UserManagement.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace UserManagement.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UsersController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<User>> GetAllUsers()
        {
            var users = _service.GetAllUsers();

            return Ok(users);
        }
        
        [HttpGet("filtered", Name="GetAllFilteredUsers")]
        public ActionResult <IEnumerable<UserReadDTO>> GetAllFilteredUsers()
        {
            var users = _service.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDTO>>(users));
        }
        
        [HttpGet("{id}", Name="GetUserById")]
        public ActionResult <User> GetUserById(Guid id)
        {
            try
            {
                var user = _service.GetUserById(id);
                return Ok(_mapper.Map<UserReadDTO>(user));
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return Problem(e.GetBaseException().ToString());
            }
        }
        [HttpGet("filtered/{id}")]
        public ActionResult <User> GetUserFilteredById(Guid id)
        {
            try
            {
                var user = _service.GetUserById(id);
                return Ok(_mapper.Map<UserReadDTO>(user));
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return Problem(e.GetBaseException().ToString());
            }
        }
        
        [HttpPost]
        public ActionResult <UserReadDTO> CreateUser(UserCreateDTO userCreateDto)
        {
            try
            {
                var userModel = _mapper.Map<User>(userCreateDto);
                var userReadDto = _mapper.Map<UserReadDTO>(_service.CreateUser(userModel));
                return CreatedAtRoute("GetUserById", new { Id = userReadDto.UserId }, userReadDto);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return Problem(e.GetBaseException().ToString());
            }
        }
        
        [HttpPut("{id}")]
        public ActionResult UpdateUser(Guid id, UserUpdateDTO userUpdateDto)
        {
            try
            {
                _service.UpdateUser(id,userUpdateDto);
                return NoContent();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return Problem(e.GetBaseException().ToString());
            }
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUserUpdate(Guid id, JsonPatchDocument<UserUpdateDTO> patchDoc)
        {
            try
            {
                _service.PatchUser(id,patchDoc,ModelState);
                return NoContent();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return Problem(e.GetBaseException().ToString());
            }
        }

        //DELETE api/Users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletedUser(Guid id) {
            try
            {
                _service.DeletedUserById(id);
                return NoContent();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return Problem(e.GetBaseException().ToString());
            }
        }

    }
}