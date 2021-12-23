using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.DTO
{
    public class UserCreateDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }        
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public UserCreateDTO(string firstName, string lastName, string phoneNumber, string emailAddress, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            BirthDate = birthDate;
        }
    }
}