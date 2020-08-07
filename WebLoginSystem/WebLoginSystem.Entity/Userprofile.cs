using System;
using System.ComponentModel.DataAnnotations;

namespace WebLoginSystem.Entity
{
    public class Userprofile
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
      
        public DateTime DateRegistered { get; set; }
        public DateTime DateUpdated { get; set; }

        public int UserCredentailId { get; set; }

        public UserCredentail UserCredentail { get; set; }
    }
}
