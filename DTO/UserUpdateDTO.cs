using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.DTO
{
    public class UserUpdateDTO
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

    }
}