using BlogPostWebsite.Models;
using BlogPostWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Data
{
    public class CategoryRepositoryMock : ICategoryRepository
    {
        private readonly List<Category> _allCateogy = new List<Category>()
        {
            new Category{ CategoryId =1, Name = "Food", Description = "This is food category"},
            new Category{ CategoryId = 2, Name = "Health", Description = "This is health category"},
            new Category{ CategoryId = 3, Name = "Book", Description = "This is book category"},
            new Category{ CategoryId = 4, Name = "Science", Description = "This is bcience category"},
        };

        public List<Category> GetAllCategory()
        {
            return _allCateogy;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _allCateogy.FirstOrDefault(i => i.CategoryId == categoryId);
        }
    }
}