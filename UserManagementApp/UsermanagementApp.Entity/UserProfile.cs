using System;

namespace UsermanagementApp.Entity
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreateDt { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDt { get; set; }
        public string UpdateBy { get; set; }
    }
}
