using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UsermanagementApp.Entity
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [DisplayName("LastName")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        public DateTime CreateDt { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDt { get; set; }
        public string UpdateBy { get; set; }
    }
}
