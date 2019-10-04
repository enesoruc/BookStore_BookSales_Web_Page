using BookStore.BLL.Abstract;
using BookStore.DAL.Abstract;
using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Concrete
{
    public class CommentService : ICommentService
    {
        ICommentDAL _commentDAL;

        public CommentService(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }

        public bool Add(Comment model)
        {
            return _commentDAL.Add(model) > 0;
        }

        public bool Delete(Comment model)
        {
            return _commentDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Comment comment = _commentDAL.Get(a=>a.ID==modelID);
            return _commentDAL.Delete(comment) > 0;
        }

        public Comment Get(int modelID)
        {
            return _commentDAL.Get(a => a.ID == modelID);
        }

        public List<Comment> GetAll()
        {
            return _commentDAL.GetAll().ToList();
        }

        public bool Update(Comment model)
        {
            return _commentDAL.Update(model) > 0;
        }
    }
}
