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

        public ActionResult NewPublishingHouse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPublishingHouse(PublishingHouseVM publishingHouseVM, HttpPostedFileBase PHImage)
        {
            CreatePublishingHouse(publishingHouseVM,PHImage);
            return View();
        }

        public ActionResult Update(int id)
        {
            return View(_publishingHouseService.Get(id));
        }

        [HttpPost]
        public ActionResult Update(PublishingHouseVM publishingHouseVM,HttpPostedFileBase PHImage)
        {
            return View();
        }

        public JsonResult DeleteByID(int id)
        {
            _publishingHouseService.Delete(id);
            return Json("ok",JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListAll()
        {
            return View(_publishingHouseService.GetAll());
        }

        private void CreatePublishingHouse(PublishingHouseVM publishingHouseVM, HttpPostedFileBase PHImage)
        {
            bool result = false;
            PublishingHouse publishingHouse = new PublishingHouse();
            publishingHouse.CompanyName = publishingHouseVM.CompanyName;
            publishingHouse.ContactName = publishingHouseVM.ContactName;
            publishingHouse.Phone = publishingHouseVM.Phone;
            publishingHouse.AddressDetail = publishingHouseVM.AddressDetail;
            if (PHImage != null)
            {
                publishingHouse.ImagePath = CreateImagePath(PHImage, publishingHouse.CompanyName);
            }
            try
            {
                result = _publishingHouseService.Add(publishingHouse);
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
        }

        private string CreateImagePath(HttpPostedFileBase PHImage, string companyName)
        {
            string imgName = string.Empty;
            Image image = Image.FromStream(PHImage.InputStream);
            int width = 300;
            int height = 300;
            imgName = "/BookStore/Images/PublishingHouseImages/" + companyName.Substring(0, 5) + Path.GetExtension(PHImage.FileName);//GetExtension verilen dosyanın uzantısını geri döner
            Bitmap bitmap = new Bitmap(image, width, height);
            bitmap.Save(Server.MapPath(imgName));
            return imgName;
        }
    }
}