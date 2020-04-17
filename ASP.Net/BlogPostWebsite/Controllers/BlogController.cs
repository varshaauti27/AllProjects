using BlogPostWebsite.Data;
using BlogPostWebsite.Models;
using BlogPostWebsite.Models.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BlogPostWebsite.Controllers
{
    public class BlogController : Controller
    {
        readonly IBlogRepository _blogRepository;
        readonly ICategoryRepository _categoryRepository;
        readonly ICommentRepository _commentRepository;
      
        public BlogController()
        {
            _blogRepository = BlogManager.Create();
            _categoryRepository = CategoryManager.Create();
            _commentRepository = CommentManager.Create();
        }
        // GET: Blog
        public ActionResult Index(int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            List<PostViewModel> postVM = new List<PostViewModel>();

            var allPosts = _blogRepository.GetAllApprovedPost(true).Where(x => x.ExpirationDate >= DateTime.Now);

            if (allPosts != null && allPosts.Count() > 0)
            {
                var context = new ApplicationDbContext();

                foreach (var post in allPosts)
                {
                    postVM.Add(new PostViewModel { Post = post, Comments = _commentRepository.GetCommentByPostId(post.PostId), AuthorName = context.Users.FirstOrDefault(i=>i.Id == post.AuthorId).UserName });
                }
                //return View("Index", postVM.OrderBy(p=>p.Post.PostId).OrderByDescending(p=>p.Post.DatePosted));
            }
            //return View("Index");
            return View("Index", postVM.OrderBy(p => p.Post.PostId).OrderByDescending(p => p.Post.DatePosted).ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            CreatePostViewModel createPostModel = new CreatePostViewModel();
            createPostModel.SetCategoryItem(_categoryRepository.GetAllCategory());
            return View(createPostModel);
        }

        [Authorize(Roles = "Contributor,User,Admin")]
        public ActionResult Staging()
        {
            CreatePostViewModel createPostModel = new CreatePostViewModel();
            createPostModel.SetCategoryItem(_categoryRepository.GetAllCategory());
            return View(createPostModel);
        }

        public ActionResult SavePost(CreatePostViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Post.Title))
            {
                ModelState.AddModelError("Post.Title", "Please enter title");
            }

            if (string.IsNullOrWhiteSpace(model.Post.Description))
            {
                ModelState.AddModelError("Post.Description", "Please enter description");
            }

            if (string.IsNullOrWhiteSpace(model.Post.CategoryId.ToString()))
            {
                ModelState.AddModelError("Post.CategoryId", "Please select Category");
            }

            if (ModelState.IsValid)
            {
                model.Post.AuthorId = User.Identity.GetUserId();

                model.Post.IsApproved = false;
                model.Post.ExpirationDate = DateTime.Now.AddDays(30);
                _blogRepository.Add(model.Post);

                return RedirectToAction("Staging");
            }

            model.SetCategoryItem(_categoryRepository.GetAllCategory());
            return View("Staging", model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ExpirationDates(int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            List<PostViewModel> postVM = new List<PostViewModel>();

            var allPosts = _blogRepository.GetAllApprovedPost(true);

            if (allPosts != null && allPosts.Count > 0)
            {
                var context = new ApplicationDbContext();

                foreach (var post in allPosts)
                {
                    postVM.Add(new PostViewModel { Post = post, Comments = _commentRepository.GetCommentByPostId(post.PostId), AuthorName = context.Users.FirstOrDefault(i => i.Id == post.AuthorId).UserName });
                }
                //return View("ExpirationDates", postVM.OrderBy(p => p.Post.PostId).OrderByDescending(p => p.Post.DatePosted).ToPagedList(pageNumber, pageSize));
            }
            //return View("Index");
            return View("ExpirationDates", postVM.OrderBy(p => p.Post.PostId).OrderByDescending(p => p.Post.DatePosted).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult SaveExpirationDate(int PostId, string ExpirationDate)
        {
            _blogRepository.SetExpirationDate(PostId, DateTime.Parse(ExpirationDate));
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult ApprovePosts(int? PostId)
        {
            ModelState.Clear();
            _blogRepository.ApprovedPost((int)PostId);

            return RedirectToAction("Review");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Review(int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            List<PostViewModel> postVM = new List<PostViewModel>();
            List<Post> allUnapprovedPost = _blogRepository.GetAllApprovedPost(false);
            if (allUnapprovedPost != null && allUnapprovedPost.Count > 0)
            {
                var context = new ApplicationDbContext();
                foreach (var post in allUnapprovedPost)
                {
                    postVM.Add(new PostViewModel { Post = post, Comments = _commentRepository.GetCommentByPostId(post.PostId), AuthorName = context.Users.FirstOrDefault(i => i.Id == post.AuthorId).UserName });
                }
            }
            return View(postVM.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Create(CreatePostViewModel postVM)
        {
            if (string.IsNullOrWhiteSpace(postVM.Post.Title))
            {
                ModelState.AddModelError("Post.Title","Please enter title");
            }

            if (string.IsNullOrWhiteSpace(postVM.Post.Description))
            {
                ModelState.AddModelError("Post.Description", "Please enter description");
            }

            if (string.IsNullOrWhiteSpace(postVM.Post.CategoryId.ToString()))
            {
                ModelState.AddModelError("Post.CategoryId", "Please select Category");
            }

            if (ModelState.IsValid)
            {
                postVM.Post.AuthorId = User.Identity.GetUserId();

                postVM.Post.IsApproved = true;
                postVM.Post.ExpirationDate = DateTime.Now.AddDays(30);
                _blogRepository.Add(postVM.Post);

                TempData["Message"] = "Post Added successfully!!!";
                return RedirectToAction("Index");
            }

            postVM.SetCategoryItem(_categoryRepository.GetAllCategory());
            return View(postVM);
        }

        [HttpPost]
        public ActionResult Search(SearchParam searchParam,int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            List<PostViewModel> postVM = new List<PostViewModel>();
            List<Post> _searchPost = new List<Post>();

            if (searchParam.SearchBy.Equals("Category"))
            {
                _searchPost = _blogRepository.GetPostByCategory(searchParam.Category);
            }
            else
            {
                _searchPost = _blogRepository.GetPostByTag(searchParam.SearchTerm.ToLower());
            }

            if (_searchPost != null && _searchPost.Count > 0)
            {
                var context = new ApplicationDbContext();

                foreach (var post in _searchPost)
                {
                    postVM.Add(new PostViewModel { Post = post, Comments = _commentRepository.GetCommentByPostId(post.PostId), AuthorName = context.Users.FirstOrDefault(i => i.Id == post.AuthorId).UserName });
                }
            }
            return View("Index", postVM.OrderBy(p => p.Post.PostId).OrderByDescending(p => p.Post.DatePosted).ToPagedList(pageNumber, pageSize));
            //return View("Index", postVM.OrderBy(p => p.Post.PostId).OrderByDescending(p => p.Post.DatePosted));
        }

        public JsonResult GetAllCategory()
        {
            return Json(_categoryRepository.GetAllCategory(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _blogRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}