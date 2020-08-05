using System;
using System.Collections.Generic;
using System.Text;

namespace BlogPostDemo.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
