using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.UI.MVC.Filters
{
    public class CustomAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            User admin = filterContext.HttpContext.Session["admin"] as User;
            if (admin==null)
            {
                filterContext.Result = new RedirectResult("/Account/AdminLogin/");//admin girişi yapılmamışsa giriş yapmaya yönlendir
            }
        }
    }
}