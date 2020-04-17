using BlogPostWebsite.Models;
using BlogPostWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Data
{
    public class BlogManager
    {
        public static IBlogRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Mock":
                    return new BlogRepositoryMock();
                case "EF":
                    return new BlogRepositoryEF();
                default:
                    throw new Exception("Mode value in App.config is not valid");
            }
        }
    }
}