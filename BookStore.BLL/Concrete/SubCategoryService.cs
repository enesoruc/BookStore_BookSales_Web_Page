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
    public class SubCategoryService : ISubCategoryService
    {
        ISubCategoryDAL _subCategoryDAL;

        public SubCategoryService(ISubCategoryDAL subCategoryDAL)
        {
            _subCategoryDAL = subCategoryDAL;
        }

        public bool Add(SubCategory model)
        {
            return _subCategoryDAL.Add(model) > 0;
        }

        public bool Delete(SubCategory model)
        {
            return _subCategoryDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            SubCategory subCategory = _subCategoryDAL.Get(a => a.ID == modelID);
            return _subCategoryDAL.Delete(subCategory) > 0;
        }

        public SubCategory Get(int modelID)
        {
            return _subCategoryDAL.Get(a => a.ID == modelID);
        }

        public List<SubCategory> GetAll()
        {
            return _subCategoryDAL.GetAll().ToList();
        }

        public List<SubCategory> GetSubCategoriesByCategoryID(int categoryID)
        {
            return _subCategoryDAL.GetAll(a => a.CategoryID == categoryID).ToList();
        }

        public bool Update(SubCategory model)
        {
           return _subCategoryDAL.Update(model) > 0;
        }
    }
}
