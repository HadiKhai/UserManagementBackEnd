using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Models
{
    [Index(nameof(EmailAddress), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
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