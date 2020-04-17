using BlogPostWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Data
{
    public class CommentManager
    {
        public static ICommentRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Mock":
                    return new CommentRepositoryMock();
                case "EF":
                    return new CommentRepositoryEF();
                default:
                    throw new Exception("Mode value in App.config is not valid");
            }
        }
    }
}