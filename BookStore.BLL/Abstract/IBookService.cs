using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Abstract
{
    public interface IBookService : IBaseService<Book>
    {
        List<Book> GetBooksByCategoryID(int categoryID);
        List<Book> GetBooksBySubCategoryID(int subCategoryID);
        List<Book> GetBooksByAuthorID(int authorID);
        List<Book> GetBooksByPublishingHouseID(int publishingHouseID);
    }
}
