using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsermanagementApp.Entity
{
    public class UserContact
    {
        [Key]
       public int Id { get; set; }
       
        [Required]
        [DisplayName("First Name")]
       public string FirstName { get; set; }
      

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Select Gender")]
        public string Gender { get; set; }

        [DisplayName("Telephone")]
        public string Phone { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [DisplayName("ZipCode")]
        public string Zip { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }
    }
}
