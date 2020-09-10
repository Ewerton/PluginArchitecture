using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BlogBusinessRules
    {
        private readonly BlogRepo _blogRepo;
        private readonly PostBusinessRules _postBll;

        public BlogBusinessRules(BlogRepo blogRepo, PostBusinessRules postBll)
        {
            _blogRepo = blogRepo;
            _postBll = postBll;
        }

        public IEnumerable<Blog> GetByName(string name)
        {
            return _blogRepo.GetByName(name);
        }

        public void CreateBlog(Blog blog)
        {
            _blogRepo.Save(blog);
        }

        public void DeleteBlog(Blog blog)
        {
            _blogRepo.Delete(blog);
        }

        public void AddPost(Blog blog, Post post)
        {
            post.Blog = blog;
            _postBll.NewPost(post);
        }

        public void DeletePost(Blog blog, Post post)
        {
            _postBll.DeletePost(post);
        }


    }
}
