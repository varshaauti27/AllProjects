using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentedOn { get; set; }
    }
}