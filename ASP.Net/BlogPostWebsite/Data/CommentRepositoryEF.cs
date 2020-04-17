using BlogPostWebsite.Models;
using BlogPostWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Data
{
    public class CommentRepositoryEF : ICommentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CommentRepositoryEF()
        {
            dbContext = new ApplicationDbContext();
        }

        public List<Comment> GetCommentByPostId(int postId)
        {
            return dbContext.Comment.Where(i => i.PostId == postId).ToList();
        }
    }
}