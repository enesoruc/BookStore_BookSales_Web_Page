using BookStore.Core.DAL.EntityFramework;
using BookStore.DAL.Abstract;
using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Concrete.EntityFramework.DAL
{
    public class EFCategoryDAL : EFRepositoryBase<Category, BookStoreDBContext>, ICategoryDAL
    {
    }
}
