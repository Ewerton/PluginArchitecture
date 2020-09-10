using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Comment
    {
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public Post Post { get; set; }
    }
}
