using BlogPostWebsite.Models;
using BlogPostWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Data
{
    public class BlogRepositoryMock : IBlogRepository
    {
        private static readonly List<Post> _allPosts = new List<Post>()
        {
            new Post{ PostId=1, Title="This is title 1", Description="This is <b>description</b> 1",Tags="tag1", AuthorId="1f2cf38a-fe8f-46a5-ab3c-e0a62f3b7470",CategoryId=1,DateModified=DateTime.Parse("2/2/2020"),DatePosted=DateTime.Parse("6/4/2020") ,IsApproved=true},
            new Post{ PostId=2, Title="This is title 2", Description="This is description 2",Tags="tag1" ,AuthorId="1f2cf38a-fe8f-46a5-ab3c-e0a62f3b7470",CategoryId=2,DateModified=DateTime.Parse("3/4/2020"),DatePosted=DateTime.Parse("9/9/2020") ,IsApproved = true },
            new Post{ PostId=3, Title="This is title 3", Description="This is <b>description</b> 3",Tags="",AuthorId="1f2cf38a-fe8f-46a5-ab3c-e0a62f3b7470",CategoryId=2,DateModified=DateTime.Parse("3/4/2020"),DatePosted=DateTime.Parse("8/9/2020") ,IsApproved = false},
            new Post{ PostId=4, Title="This is title 4", Description="This is description 4",Tags="",AuthorId="71f92f10-395f-4425-a5b1-04fbd96f9d8c",CategoryId=2,DateModified=DateTime.Parse("5/4/2020"),DatePosted=DateTime.Parse("3/9/2020") ,IsApproved = true},
            new Post{ PostId=5, Title="This is title 5", Description="This is description 5",Tags="tag2",AuthorId="71f92f10-395f-4425-a5b1-04fbd96f9d8c",CategoryId=2,DateModified=DateTime.Parse("8/4/2020"),DatePosted=DateTime.Parse("5/9/2020"), IsApproved = false},
            new Post{ PostId=6, Title="This is title 6", Description="This is description 6",Tags="tag2",AuthorId="71f92f10-395f-4425-a5b1-04fbd96f9d8c",CategoryId=2,DateModified=DateTime.Parse("8/4/2020"),DatePosted=DateTime.Parse("5/9/2020"), IsApproved = false}
        };

        public void Add(Post post)
        {
            post.PostId = _allPosts.Max(p => p.PostId) + 1;
            _allPosts.Add(post);
        }

        public void ApprovedPost(int postId)
        {
            var found = _allPosts.FirstOrDefault(p => p.PostId == postId);

            if (found != null)
            {
                found.IsApproved = true;
            }
        }

        public void Dispose()
        {
            _allPosts.Clear();
        }

        public List<Post> GetAllApprovedPost(bool isApproved)
        {
                return _allPosts.Where(i => i.IsApproved == isApproved).ToList();
        }

        public List<Post> GetAllPosts()
        {
            return _allPosts;
        }

        public List<Post> GetPostByCategory(int categoryId)
        {
            return _allPosts.Where(i => i.CategoryId == categoryId && i.IsApproved && i.ExpirationDate >= DateTime.Now).ToList();
            //return GetAllApprovedPost().Where(i => i.CategoryId == categoryId).ToList();
        }

        public List<Post> GetPostByTag(string tags)
        {
            return _allPosts.Where(i => i.Tags.Contains(tags) && i.IsApproved && i.ExpirationDate >= DateTime.Now).ToList();
            //return GetAllApprovedPost().Where(i => i.Tags.Contains(tags)).ToList();
        }

        public void SetExpirationDate(int postId, DateTime date)
        {
            _allPosts.FirstOrDefault(x => x.PostId == postId).ExpirationDate = date;
        }
    }
}