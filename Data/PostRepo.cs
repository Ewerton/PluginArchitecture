using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PostRepo
    {
        private readonly CommentRepo _commentRepo;

        public PostRepo(CommentRepo commenRepo)
        {
            _commentRepo = commenRepo;
        }

        public IEnumerable<Post> GetAllByBlog(Blog blog)
        {
            IEnumerable<Post> lstPosts = InMemoryDatabase.PostTable.Where(p => p.Blog.Name.ToUpper().Trim() == blog.Name.ToUpper().Trim());

            foreach (var post in lstPosts)
                post.Comments = _commentRepo.GetAllByPost(post);

            return lstPosts;
        }

        public void Save(Post post)
        {
            InMemoryDatabase.PostTable.Add(post);
        }

        public void Delete(Post post)
        {
            if (InMemoryDatabase.PostTable.Contains(post))
                InMemoryDatabase.PostTable.Remove(post);
        }
    }
}
