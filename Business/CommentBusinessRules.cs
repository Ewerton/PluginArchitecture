using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CommentBusinessRules
    {
        private readonly CommentRepo _CommentRepo;

        public CommentBusinessRules(CommentRepo commentRepo)
        {
            _CommentRepo = commentRepo;
        }

        public void NewComment(Comment comment)
        {
            _CommentRepo.Save(comment);
        }


        public void DeleteComment(Comment comment)
        {
            _CommentRepo.Delete(comment);
        }
    }
}
