using BlogPostWebsite.Models;
using BlogPostWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Data
{
    public class BlogRepositoryEF : IBlogRepository
    {
        readonly ApplicationDbContext dbContext;
        public BlogRepositoryEF()
        {
            dbContext = new ApplicationDbContext();
        }

        public void Add(Post post)
        {
            dbContext.Post.Add(post);
            dbContext.SaveChanges();
        }

        public void ApprovedPost(int postId)
        {
            var found = dbContext.Post.FirstOrDefault(p => p.PostId == postId);

            if (found != null)
            {
                found.IsApproved = true;
            }

            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public List<Post> GetAllApprovedPost(bool isApproved)
        {
            return dbContext.Post.Where(i => i.IsApproved == isApproved).ToList();
        }

        public List<Post> GetAllPosts()
        {
            return dbContext.Post.ToList();
        }

        public List<Post> GetPostByCategory(int categoryId)
        {
            return dbContext.Post.Where(i => i.CategoryId == categoryId && i.IsApproved && i.ExpirationDate >= DateTime.Now).ToList();
        }

        public List<Post> GetPostByTag(string tags)
        {
            return dbContext.Post.Where(i => i.Tags.ToLower().Contains(tags) && i.ExpirationDate >= DateTime.Now).ToList();
        }

        public void SetExpirationDate(int PostId, DateTime date)
        {
            dbContext.Post.FirstOrDefault(x => x.PostId == PostId).ExpirationDate = date;
            dbContext.SaveChanges();
        }

    }
}