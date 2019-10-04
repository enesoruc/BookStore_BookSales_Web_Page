using BookStore.BLL.Abstract;
using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.UI.MVC.Filters
{
    public class CustomCategoryAttribute : ActionFilterAttribute
    {
        ICategoryService _categoryService;
        public CustomCategoryAttribute(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            List<Category> categories = filterContext.HttpContext.Session["categories"] as List<Category>;
            if (categories==null)
            {
                filterContext.HttpContext.Session["categories"] = _categoryService.GetAll();
            }
        }
    }
}