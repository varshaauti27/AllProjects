using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostWebsite.Models.Interfaces
{
    public interface IBlogRepository
    {
        List<Post> GetAllPosts();
        List<Post> GetPostByCategory(int categoryId);
        List<Post> GetPostByTag(string tags);
        void Add(Post post);
        void ApprovedPost(int postId);
        List<Post> GetAllApprovedPost(bool isApproved);
        void SetExpirationDate(int postId, DateTime date);
        void Dispose();
    }
}
