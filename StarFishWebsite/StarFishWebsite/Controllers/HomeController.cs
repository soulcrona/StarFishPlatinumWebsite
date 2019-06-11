using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarFishWebsite.Models;

namespace StarFishWebsite.Controllers
{
    public class HomeController : Controller
    {
        public Context ucContext = new Context();
        public ActionResult Index()
        {

            return View(ucContext.fish.Include("ImageCall"));
        }
        
        public ActionResult ConvertImageButton(int value)
        {
            if (ucContext.buttons.Include("image").Where(u => u.value == value).SingleOrDefault().image.ImageFile != null)
            {
                var imageData = ucContext.buttons.Include("image").Where(u => u.value == value).SingleOrDefault().image.ImageFile;
                return File(imageData, "image/jpg");
            }
            return null;

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}