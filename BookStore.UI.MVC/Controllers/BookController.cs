using BookStore.BLL.Abstract;
using BookStore.Model.Models;
using BookStore.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.UI.MVC.Controllers
{
    public class BookController : Controller
    {

        IBookService _bookService;
        IAuthorService _authorService;
        ILanguageService _languageService;
        IPublishingHouseService _publishingHouseService;

        public BookController(IBookService bookService,IAuthorService authorService,ILanguageService languageService,IPublishingHouseService publishingHouseService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _languageService = languageService;
            _publishingHouseService = publishingHouseService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(int id)
        {
            return View(FillViewModel(id));
        }

        public ActionResult MostSales()
        {
            return View();
        }

        public ActionResult NewBook()
        {
            ViewBag.authors = _authorService.GetAll();
            ViewBag.languages = _languageService.GetAll();
            ViewBag.publishingHouses = _publishingHouseService.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult NewBook(Book book, int authorID,int subCategoryID, int languageID,int publishingHouseID, HttpPostedFileBase bookImage)
        {
            ViewBag.authors = _authorService.GetAll();
            ViewBag.languages = _languageService.GetAll();
            ViewBag.publishingHouses = _publishingHouseService.GetAll();
            string imgName = string.Empty;
            bool result = false;
            Book newBook = new Book();
            newBook = book;
            newBook.AuthorID = authorID;
            newBook.SubCategoryID = subCategoryID;
            newBook.LanguageID = languageID;
            newBook.PublishingHouseID = publishingHouseID;
            if (bookImage != null)
            {
                Image image = Image.FromStream(bookImage.InputStream);
                int width = 300;
                int height = 300;
                imgName = "/BookStore/Images/BookImages/" + book.Name.Substring(0, 3) + Path.GetExtension(bookImage.FileName);//GetExtension verilen dosyanın uzantısını geri döner
                Bitmap bitmap = new Bitmap(image, width, height);
                bitmap.Save(Server.MapPath(imgName));
            }
            book.ImagePath = imgName;
            try
            {
                result = _bookService.Add(newBook);
                if (result)
                {
                    ViewBag.result = "Ürün Başarıyla Eklendi";
                }
                else
                {
                    ViewBag.result = "Ürün Eklenirken Bir Hata Oluştu";
                }
            }
            catch (Exception)
            {
                ViewBag.result = "Bir Hata Oluştu";
            }   
            return View();
        }

        public JsonResult Delete(int id)
        {
            Book book = _bookService.Get(id);
            _bookService.Delete(book);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult Delete(int id)
        //{
        //    Book book = _bookService.Get(id);
        //    _bookService.Delete(book);
        //    return Json("ok", JsonRequestBehavior.AllowGet);
        //}

        public ActionResult ListAll()
        {
            return View(_bookService.GetAll());
        }

        public ActionResult ListByCategory(int id)
        {
            return View(_bookService.GetBooksByCategoryID(id));
        }

        public ActionResult BookDetail(int id)
        {
            return View(_bookService.Get(id));
        }

        public ActionResult BookUpdate(int id)
        {
            return View(_bookService.Get(id));
        }

        [HttpPost]
        public ActionResult BookUpdate(Book updatedBook)
        {
            Book book = _bookService.Get(updatedBook.ID);
            book.Name = updatedBook.Name;
            book.AuthorID = updatedBook.AuthorID;
            book.Count = updatedBook.Count;
            book.Description = updatedBook.Description;
            book.ImagePath = updatedBook.ImagePath;
            book.LanguageID = updatedBook.LanguageID;
            book.NumberOfPages = updatedBook.NumberOfPages;
            book.Price = updatedBook.Price;
            book.PublishingHouseID = updatedBook.PublishingHouseID;
            book.SubCategoryID = updatedBook.SubCategoryID;
            book.YearOfPrinting = updatedBook.YearOfPrinting;
            bool result = false;
            try
            {
                result = _bookService.Update(book);
            }
            catch (Exception ex)
            {
                ViewBag.result = "Bir Hata Oluştu";
            }
            if (result)
            {
                ViewBag.result = "Ürün Başarılı Bir Şekilde Güncellendi";
            }
            return View();
        }

        private BookDetailVM FillViewModel(int id)
        {
            Book book = _bookService.Get(id);
            BookDetailVM bookDetailVM = new BookDetailVM();
            bookDetailVM.Author = book.Author.FirstName + " " + book.Author.LastName;
            bookDetailVM.AuthorID = book.AuthorID;
            bookDetailVM.BookID = book.ID;
            bookDetailVM.BookName = book.Name;
            bookDetailVM.CategoryID = book.SubCategory.Category.ID;
            bookDetailVM.CategoryName = book.SubCategory.Category.Name;
            bookDetailVM.Description = book.Description;
            bookDetailVM.Discount = book.SubCategory.Category.Campaigns.Count;
            bookDetailVM.NumberOfPage = book.NumberOfPages;
            bookDetailVM.Price = book.Price;
            bookDetailVM.PublishingHouse = book.PublishingHouse.CompanyName;
            bookDetailVM.PublishingHouseID = book.PublishingHouseID;
            bookDetailVM.SubCategoryID = book.SubCategoryID;
            bookDetailVM.SubCategoryName = book.SubCategory.Name;
            bookDetailVM.ImagePath = book.ImagePath;
            return bookDetailVM;
        }
    }
}