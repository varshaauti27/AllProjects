using BlogPostWebsite.Models;
using BlogPostWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Data
{
    public class CategoryRepositoryEF : ICategoryRepository
    {
        readonly ApplicationDbContext dbContext;

        public CategoryRepositoryEF()
        {
            dbContext = new ApplicationDbContext();
        }
        public List<Category> GetAllCategory()
        {
            return dbContext.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return dbContext.Categories.FirstOrDefault(i => i.CategoryId == categoryId);
        }
    }
}