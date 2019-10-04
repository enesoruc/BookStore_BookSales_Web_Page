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
    public class PublishingHouseController : Controller
    {
        IPublishingHouseService _publishingHouseService;
        Hata hata;

        public PublishingHouseController(IPublishingHouseService publishingHouseService)
        {
            hata = new Hata();
            _publishingHouseService = publishingHouseService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewPublishingHouse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPublishingHouse(PublishingHouseVM publishingHouseVM, HttpPostedFileBase PHImage)
        {
            string imgName = string.Empty;
            bool result = false;
            PublishingHouse publishingHouse = new PublishingHouse();
            publishingHouse.CompanyName = publishingHouseVM.CompanyName;
            publishingHouse.ContactName = publishingHouseVM.ContactName;
            publishingHouse.Phone = publishingHouseVM.Phone;
            publishingHouse.AddressDetail = publishingHouseVM.AddressDetail;
            if (PHImage != null)
            {
                Image image = Image.FromStream(PHImage.InputStream);
                int width = 300;
                int height = 300;
                imgName = "/BookStore/Images/PublishingHouseImages/" + publishingHouse.CompanyName.Substring(0, 5) + Path.GetExtension(PHImage.FileName);//GetExtension verilen dosyanın uzantısını geri döner
                Bitmap bitmap = new Bitmap(image, width, height);
                bitmap.Save(Server.MapPath(imgName));
            }
            publishingHouse.ImagePath =imgName;
            try
            {
                result= _publishingHouseService.Add(publishingHouse);
                if (result)
                {
                    ViewBag.result = hata.KayıtBasarili;
                }
                else
                {
                    ViewBag.result = hata.KayıtBasarisiz;
                }
            }
            catch (Exception)
            {
                ViewBag.result = hata.HataOlustu;
            }

            return View();
        }
    }
}