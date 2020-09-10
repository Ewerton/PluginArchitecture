using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using AspNetCoreMvcWebView.Models;

namespace AspNetCoreMvcWebView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogBusinessRules _blogBll;
        private readonly PostBusinessRules _postBll;
        private readonly CommentBusinessRules _commentBll;

        public HomeController(ILogger<HomeController> logger, BlogBusinessRules blogBll, PostBusinessRules postBll, CommentBusinessRules commentBll)
        {
            _logger = logger;
            _blogBll = blogBll;
            _postBll = postBll;
            _commentBll = commentBll;
        }

        public IActionResult Index()
        {
            string blogname = "My Awesome Blog";

            Blog myBlog = new Blog()
            {
                Name = blogname,
                Owner = "MySelf",
                Posts = new List<Post>()
            };

            var blog = CreateABlog(blogname, "Ewerton");
            var post = AddPostToBlog(blog, "My New Post", "This is a post testing my new blog");
            var comment = AddCommentToPost(post, "Hey, what a awesome blog, man!");

            var savedBlogs = GetBlogsByName(blogname);

            string htmlContent = String.Empty;

            foreach (var blogItem in savedBlogs)
            {
                htmlContent = htmlContent + "You just created the following blog:";
                htmlContent = htmlContent + $"    Blog Name: {blog.Name} | Blog Owner: {blog.Owner}";

                foreach (var postItem in blogItem.Posts)
                {
                    htmlContent = htmlContent + "<BR><BR>";
                    htmlContent = htmlContent + "Here are the Posts:";
                    htmlContent = htmlContent + $"    Post Title: {postItem.Title} | Post Body: {postItem.Body}";

                    foreach (var commentItem in postItem.Comments)
                    {
                        htmlContent = htmlContent + "<BR><BR>";
                        htmlContent = htmlContent + "Here are the Comments:";
                        htmlContent = htmlContent + $"    Comment Text: {commentItem.CommentText } | Crete Date: {commentItem.Date.ToShortTimeString()}";
                    }
                }
            }

            htmlContent = htmlContent + "<BR><BR>";

            return new ContentResult()
            {
                Content = htmlContent,
                ContentType = "text/html",
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private Blog CreateABlog(string blogName, string creator)
        {
            Blog myNewBlog = new Blog()
            {
                Name = blogName,
                Owner = creator,
                Posts = new List<Post>(),
            };

            _blogBll.CreateBlog(myNewBlog);

            Blog recentlyCreated = _blogBll.GetByName(blogName).FirstOrDefault();

            return recentlyCreated;
        }

        public Post AddPostToBlog(Blog recentBlog, string postTitle, string postBody)
        {
            Post newPost = new Post()
            {
                Blog = recentBlog,
                Title = postTitle,
                Body = postBody,
                PublishDate = DateTime.Now,
                Comments = new List<Comment>()
            };

            _postBll.NewPost(newPost);

            return newPost;
        }

        public Comment AddCommentToPost(Post post, string commentText)
        {
            Comment newComment = new Comment()
            {
                CommentText = commentText,
                Date = DateTime.Now,
                Post = post
            };

            _commentBll.NewComment(newComment);

            return newComment;
        }

        public IEnumerable<Blog> GetBlogsByName(string blogName)
        {
            return _blogBll.GetByName(blogName);
        }
    }
}
