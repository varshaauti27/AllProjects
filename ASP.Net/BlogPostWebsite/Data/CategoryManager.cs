using BlogPostWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Data
{
    public class CategoryManager
    {
        public static ICategoryRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Mock":
                    return new CategoryRepositoryMock();
                case "EF":
                    return new CategoryRepositoryEF();
                default:
                    throw new Exception("Mode value in App.config is not valid");
            }
        }
    }
}