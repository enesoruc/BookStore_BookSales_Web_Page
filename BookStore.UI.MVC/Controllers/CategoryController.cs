using BookStore.BLL.Abstract;
using BookStore.Model.Models;
using BookStore.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.UI.MVC.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        IBookService _bookService;
        ISubCategoryService _subCategoryService;
        public CategoryController(ICategoryService categoryService, IBookService bookService,ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
            _subCategoryService = subCategoryService;
        }

        public ActionResult Index()
        {
            ViewBag.categories = _categoryService.GetAll();
            CategoryIndexVM categoryIndexVM = new CategoryIndexVM();
            categoryIndexVM.MostSales = _bookService.GetAll();
            categoryIndexVM.NewBooks = _bookService.GetAll();
            return View(categoryIndexVM);
        }

        public ActionResult Category(int id)
        {
            ViewBag.subCategories = _subCategoryService.GetSubCategoriesByCategoryID(id);
            return View(_bookService.GetBooksByCategoryID(id));

        }

        public ActionResult SubCategory(int id)
        {
            SubCategory subCategory = _subCategoryService.Get(id);
            Category category = subCategory.Category;
            ViewBag.subCategories = _subCategoryService.GetSubCategoriesByCategoryID(category.ID);
            return View(_bookService.GetBooksBySubCategoryID(id));
        }

        [HttpPost]
        public JsonResult GetSubCategoryByCategoryID(int id)
        {
            Category category = _categoryService.Get(id);
            var subCategories = _subCategoryService.GetSubCategoriesByCategoryID(category.ID);
            return Json(new SelectList(subCategories.ToArray(), "ID", "Name"), JsonRequestBehavior.AllowGet);
        }
    }
}