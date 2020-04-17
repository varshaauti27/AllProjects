using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Models
{
    public class SearchParam
    {
        public string SearchTerm { get; set; }

        public string SearchBy { get; set; }

        public int Category { get; set; }
    }
}