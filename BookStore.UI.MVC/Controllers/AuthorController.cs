using BookStore.BLL.Abstract;
using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.UI.MVC.Controllers
{
    public class AuthorController : Controller
    {
        IAuthorService _authorService;
        Hata Hata;

        public AuthorController(IAuthorService authorService)
        {
            Hata = new Hata();
            _authorService = authorService;
        }

        public ActionResult Author(int id)
        {
            return View(_authorService.Get(id));
        }

        public ActionResult NewAuthor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewAuthor(Author author)
        {
            bool result = false;
            try
            {
                result = _authorService.Add(author);
                if (result)
                {
                    ViewBag.result = Hata.KayıtBasarili;
                }
                else
                {
                    ViewBag.result = Hata.KayıtBasarisiz;
                }
            }
            catch (Exception)
            {
                ViewBag.result = Hata.HataOlustu;
            }  
            return View();
        }

        public ActionResult ListAllAuthors()
        {
            return View(_authorService.GetAll());
        }

        public ActionResult ListByLetter(string letter)
        {
            return View(_authorService.ListAuthorsByLetter(letter));
        }

        public JsonResult Delete(int id)
        {
            Author author = _authorService.Get(id);
            _authorService.Delete(author);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
    }
}