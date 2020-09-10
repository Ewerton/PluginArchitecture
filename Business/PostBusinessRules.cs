using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PostBusinessRules
    {
        private readonly PostRepo _postRepo;
        private readonly CommentBusinessRules _commentBll;

        public PostBusinessRules(PostRepo postRepo, CommentBusinessRules commentBll)
        {
            _postRepo = postRepo;
            _commentBll = commentBll;
        }

        public void NewPost(Post post)
        {
            _postRepo.Save(post);
        }

        public void DeletePost(Post post)
        {
            _postRepo.Delete(post);
        }

        public void AddComment(Post post, Comment comment)
        {
            comment.Post = post;
            _commentBll.NewComment(comment);
        }
    }
}
