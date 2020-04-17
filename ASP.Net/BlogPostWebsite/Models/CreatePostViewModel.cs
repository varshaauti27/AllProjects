using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogPostWebsite.Models
{
    public class CreatePostViewModel
    {
        public Post Post { get; set; }
        public List<SelectListItem> CategoryItem { get; set; }
        public string CategoryName { get; set; }

        public CreatePostViewModel()
        {
            Post = new Post() { DatePosted = DateTime.Now };
            CategoryItem = new List<SelectListItem>();
        }
        public void SetCategoryItem(IEnumerable<Category> Category)
        {
            foreach (var category in Category)
            {
                CategoryItem.Add(new SelectListItem()
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.Name
                });
            }
        }
    }
}