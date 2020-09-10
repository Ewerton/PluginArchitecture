using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BlogRepo
    {
        private readonly PostRepo _postRepo;

        public BlogRepo(PostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        public IEnumerable<Blog> GetByName(string name)
        {
            IEnumerable<Blog> lstBlogs = InMemoryDatabase.BlogTable.Where(b => b.Name.ToUpper().Trim() == name.ToUpper().Trim());

            foreach (var blog in lstBlogs)
                blog.Posts = _postRepo.GetAllByBlog(blog);

            return lstBlogs;
        }

        public void Save(Blog blog)
        {
            InMemoryDatabase.BlogTable.Add(blog);
        }

        public void Delete(Blog blog)
        {
            if (InMemoryDatabase.BlogTable.Contains(blog))
                InMemoryDatabase.BlogTable.Remove(blog);
        }
    }
}
