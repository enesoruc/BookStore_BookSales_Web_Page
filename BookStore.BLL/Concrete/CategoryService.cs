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
    public class CategoryService : ICategoryService
    {
        ICategoryDAL _categoryDAL;

        public CategoryService(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public bool Add(Category model)
        {
            return _categoryDAL.Add(model) > 0;
        }

        public bool Delete(Category model)
        {
            return _categoryDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Category category = _categoryDAL.Get(a => a.ID == modelID);
            return _categoryDAL.Delete(category) > 0;
        }

        public Category Get(int modelID)
        {
            return _categoryDAL.Get(a => a.ID == modelID);
        }

        public List<Category> GetAll()
        {
            return _categoryDAL.GetAll().ToList();
        }

        public bool Update(Category model)
        {
            return _categoryDAL.Update(model) > 0;
        }
    }
}
