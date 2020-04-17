using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogPostWebsite.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Description { get; set; }
        public string Tags { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime? DateModified { get; set; }
        public string AuthorId { get; set; }
        public int CategoryId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public Post()
        {
            DatePosted = DateTime.Now;
        }
    }
}