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
    public class CartController : Controller
    {
        // GET: Cart
        IBookService _bookService;
        List<CartItem> cart;

        public CartController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public JsonResult AddToCart(int id, int quantity = 1)
        {
            Book currentBook = _bookService.Get(id);
            if (currentBook != null)
            {
                if (Session["cart"] == null)
                {
                    cart = new List<CartItem>();
                }
                else
                {
                    cart = Session["cart"] as List<CartItem>;
                }

                cart.Add(new CartItem()
                {
                    BookID = currentBook.ID,
                    BookName = currentBook.Name,
                    Price = currentBook.Price,
                    Quantity = quantity,
                    ImagePath = currentBook.ImagePath
                });
                Session["cart"] = cart;
                return Json(cart.Count, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCartItemsCount()
        {
            if (Session["cart"] == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = Session["cart"] as List<CartItem>;
            }
            Session["cart"] = cart;
            return Json(cart.Count, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteToCart(int id)
        {
            cart = Session["cart"] as List<CartItem>;
            CartItem currentBook = cart.Where(a => a.BookID == id).First();
            if (currentBook != null)
            {
                cart.Remove(currentBook);
            }
            return Json(cart.Count,JsonRequestBehavior.AllowGet);
        }

        public ActionResult CartList()
        {
            if (Session["cart"] == null)
            {
                return View("EmptyCart");
            }
            else
            {
                List<CartItem> cart = Session["cart"] as List<CartItem>;
                return View("CartView", cart);
            }
        }

        [HttpPost]
        public ActionResult CartView(string qty)
        {
            return View();
        }
    }
}