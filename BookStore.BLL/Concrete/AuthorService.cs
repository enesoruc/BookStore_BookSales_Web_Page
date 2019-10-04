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
    public class AuthorService : IAuthorService
    {
        IAuthorDAL _authorDAL;

        public AuthorService(IAuthorDAL authorDAL)
        {
            _authorDAL = authorDAL;
        }

        public bool Add(Author model)
        {
            return _authorDAL.Add(model) > 0;
        }

        public bool Delete(Author model)
        {
            return _authorDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Author author = _authorDAL.Get(a=>a.ID==modelID);
            return _authorDAL.Delete(author) > 0;
        }

        public Author Get(int modelID)
        {
            return _authorDAL.Get(a => a.ID == modelID);
        }

        public List<Author> GetAll()
        {
            return _authorDAL.GetAll().ToList();
        }

        public List<Author> ListAuthorsByLetter(string letter)
        {
            return _authorDAL.GetAll(a => a.FirstName.StartsWith(letter)).ToList();
        }

        public bool Update(Author model)
        {
            return _authorDAL.Update(model) > 0;
        }
    }
}
