using BookStore.BLL.Abstract;
using BookStore.Model.Models;
using BookStore.UI.MVC.Helpers;
using BookStore.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;
        IUserRoleService _userRoleService;
        ICategoryService _categoryService;

        public AccountController(IUserService userService, IUserRoleService userRoleService,ICategoryService categoryService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountVM model)
        {
            try
            {
                if (model.Password != model.RePassword)
                {
                    ViewBag.Message = "Şifreler uyuşmuyor";
                }
                else
                {
                    User user = new User();
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.BirthDate = model.BirthDate;
                    user.Password = model.Password;
                    user.EMail = model.EMail;
                    user.PhoneNumber = model.PhoneNumber;
                    user.UserName = model.UserName;
                    user.IsActive = false;
                    user.UserRole = _userRoleService.GetByRoleName("Standart");
                    user.ActivationCode = Guid.NewGuid();
                    bool result = _userService.Add(user);
                    if (result)
                    {
                        result = MailHelper.SendMail(model.FirstName, model.EMail, user.ActivationCode);
                        ViewBag.Message = result ? "Aktivasyon maili gönderilmiştir.Mailiniz kontrol ediniz." : "Aktivasyon maili gönderilemedi";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password)
        {
            User user;
            if (userName != null && password != null)
            {
                user = _userService.GetUserByLogin(userName, password);
                if (user != null)
                {
                    Session["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.result = "Böyle bir kullanıcı bulunamadı";
                }
            }
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(AdminLoginVM adminVM)
        {
            User admin = _userService.GetUserByLogin(adminVM.UserName, adminVM.Password);

            if (admin != null)
            {
                Session["admin"] = admin;
                Session["categories"] = _categoryService.GetAll();
                return RedirectToAction("Home", "Admin");
            }
            ViewBag.result = "Bilgilerinizi Kontrol Edip Tekrar Deneyiniz.";
            return View();
        }

        public ActionResult Activate(Guid code)
        {
            User user = _userService.GetUserByCode(code);
            if (user != null)
            {
                _userService.ActivateUser(user);
                ViewBag.Result = "Üyeliğiniz aktifleştirilmiştir.";
            }
            else
            {
                ViewBag.Result = "Böyle bir kullanıcı bulunamadı";
            }

            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            if (Session["admin"]!=null)
            {
                return RedirectToAction("AdminLogin", "Account");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}