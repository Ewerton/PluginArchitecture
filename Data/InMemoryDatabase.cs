using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal static class InMemoryDatabase
    {
        internal static List<Blog> BlogTable = new List<Blog>();
        internal static List<Post> PostTable = new List<Post>();
        internal static List<Comment> CommentTable = new List<Comment>();
    }
}
