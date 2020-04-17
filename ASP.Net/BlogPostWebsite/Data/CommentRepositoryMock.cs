using BlogPostWebsite.Models;
using BlogPostWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPostWebsite.Data
{
    public class CommentRepositoryMock : ICommentRepository
    {
        private static readonly List<Comment> _allComment = new List<Comment>()
        {
            new Comment{ CommentId = 1, Name ="Varsha",PostId=1,CommentedOn = DateTime.Parse("4/4/2020"), CommentText = "This is comment 1 for post1"},
            new Comment{ CommentId = 2, Name ="Ashish",PostId=1,CommentedOn = DateTime.Parse("12/4/2020"), CommentText = "This is comment 2 for post1"},
            new Comment{ CommentId = 3, Name ="Tanvi",PostId=2,CommentedOn = DateTime.Parse("12/4/2020"), CommentText = "This is comment 1 for post2"},
            new Comment{ CommentId = 4, Name ="Varsha",PostId=6,CommentedOn = DateTime.Parse("12/4/2020"), CommentText = "This is comment 1 for post6"},
            new Comment{ CommentId = 5, Name ="Varsha",PostId=5,CommentedOn = DateTime.Parse("12/4/2020"), CommentText = "This is comment 1 for post5"}
        };

        public List<Comment> GetCommentByPostId(int postId)
        {
            return _allComment.Where(i => i.PostId == postId).ToList();
        }
    }
}