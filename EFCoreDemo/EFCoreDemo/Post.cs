using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo
{
   public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Dsc { get; set; }
        public DateTime DateCreated { get; set; }
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
