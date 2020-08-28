using System.ComponentModel.DataAnnotations;

namespace eCommerceWeb.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
