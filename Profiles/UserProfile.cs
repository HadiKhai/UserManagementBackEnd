using AutoMapper;
using UserManagement.DTO;
using UserManagement.Models;

namespace UserManagement.Profiles
{
    public class UserManagementProfile : Profile
    {
        public UserManagementProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserUpdateDTO>();
        }

    }
    
}