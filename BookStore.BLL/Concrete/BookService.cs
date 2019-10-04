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
    public class BookService : IBookService
    {
        IBookDAL _bookDAL;

        public BookService(IBookDAL bookDAL)
        {
            _bookDAL = bookDAL;
        }

        public bool Add(Book model)
        {
            return _bookDAL.Add(model) > 0;
        }

        public bool Delete(Book model)
        {
            return _bookDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Book book = _bookDAL.Get(a => a.ID == modelID);
            return _bookDAL.Delete(book) > 0;
        }

        public Book Get(int modelID)
        {
            return _bookDAL.Get(a => a.ID == modelID);
        }

        public List<Book> GetAll()
        {
            return _bookDAL.GetAll().ToList();
        }

        public List<Book> GetBooksByAuthorID(int authorID)
        {
            return _bookDAL.GetAll(a => a.AuthorID == authorID).ToList();
        }

        public List<Book> GetBooksByCategoryID(int categoryID)
        {
            return _bookDAL.GetAll().Where(a => a.SubCategory.CategoryID == categoryID).ToList();
        }

        public List<Book> GetBooksByPublishingHouseID(int publishingHouseID)
        {
            return _bookDAL.GetAll(a => a.PublishingHouseID == publishingHouseID).ToList();
        }

        public List<Book> GetBooksBySubCategoryID(int subCategoryID)
        {
            return _bookDAL.GetAll(a => a.SubCategoryID == subCategoryID).ToList();
        }

        public bool Update(Book model)
        {
            return _bookDAL.Update(model) > 0;
        }
    }
}
