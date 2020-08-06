﻿
using System;
using System.Collections.Generic;

namespace BlogPostDemo.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}
