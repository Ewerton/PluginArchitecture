using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CommentRepo
    {
        public IEnumerable<Comment> GetAllByPost(Post post)
        {
            return InMemoryDatabase.CommentTable.Where(c => c.Post == post);
        }

        public void Save(Comment post)
        {
            InMemoryDatabase.CommentTable.Add(post);
        }

        public void Delete(Comment post)
        {
            if (InMemoryDatabase.CommentTable.Contains(post))
                InMemoryDatabase.CommentTable.Remove(post);
        }
    }
}
