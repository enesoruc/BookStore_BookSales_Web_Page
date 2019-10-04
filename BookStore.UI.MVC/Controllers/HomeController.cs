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
    public class HomeController : Controller
    {
        // GET: Home
        ICategoryService _categoryService;
        IBookService _bookService;
        IAuthorService _authorService;
        IPublishingHouseService _publishingHouseService;
        ICampaignService _campaignService;

        public HomeController(ICategoryService categoryService,IBookService bookService,IAuthorService authorService,IPublishingHouseService publishingHouseService,ICampaignService campaignService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
            _authorService = authorService;
            _publishingHouseService = publishingHouseService;
            _campaignService = campaignService;
        }
        public ActionResult Index()
        {
            int id = 1;
            Session["categories"] = _categoryService.GetAll();
            Author author = _authorService.Get(id);
            HomeIndexVM homeIndexVM = new HomeIndexVM();
            homeIndexVM.AuthorOfTheWeek = author;
            homeIndexVM.AuthorBooks = _bookService.GetBooksByAuthorID(author.ID);
            homeIndexVM.AuthorsOfTheMonth = _authorService.GetAll();
            homeIndexVM.PublishingHousesOfTheMonth = _publishingHouseService.GetAll();
            homeIndexVM.PublishingHouseOfTheWeek = _publishingHouseService.Get(id);
            homeIndexVM.Campaigns = _campaignService.GetAll();
            homeIndexVM.PublishingHouseOfTheWeekBooks = _bookService.GetBooksByPublishingHouseID(id);

            return View(homeIndexVM);
        }
        
        public ActionResult Contact()
        {
            return View();
        }
    }
}