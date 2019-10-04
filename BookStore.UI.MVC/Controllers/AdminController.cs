using BookStore.UI.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.UI.MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [CustomAuthorize]
        public ActionResult Home()
        {
            return View();
        }


    }
}