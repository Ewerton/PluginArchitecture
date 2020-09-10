using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Blog
    {
        public string Name { get; set; }

        public string Owner { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
