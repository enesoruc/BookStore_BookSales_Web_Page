using BookStore.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.UI.MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        //[ValidateAntiForgeryToken]
        public ActionResult Register(AccountVM user)
        {
            return View();
        }
    }
}