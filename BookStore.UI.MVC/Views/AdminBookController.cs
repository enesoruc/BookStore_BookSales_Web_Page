using BookStore.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.UI.MVC.Views
{
    public class AdminBookController : Controller
    {
        IBookService _bookService;
        public AdminBookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult ListAll()
        {
            return View();
        }

        public ActionResult BookDetail(int id)
        {
            return View(_bookService.Get(id));
        }
    }
}