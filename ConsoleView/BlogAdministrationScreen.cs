using Business;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class BlogAdministrationScreen
    {
        private readonly BlogBusinessRules _blogBll;
        private readonly PostBusinessRules _postBll;
        private readonly CommentBusinessRules _commentsBll;

        public BlogAdministrationScreen(BlogBusinessRules blogBll, PostBusinessRules postBll, CommentBusinessRules commentsBll)
        {
            _blogBll = blogBll;
            _postBll = postBll;
            _commentsBll = commentsBll;
        }

        public IEnumerable<Blog> GetBlogsByName(string blogName)
        {
            return _blogBll.GetByName(blogName);
        }

        public Blog CreateABlog(string blogName, string creator)
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

            _commentsBll.NewComment(newComment);

            return newComment;
        }
    }
}
