using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public string AuthorName { get; set; }
        public List<Comment> Comments { get; set; }
    }
}