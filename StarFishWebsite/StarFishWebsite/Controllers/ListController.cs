using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarFishWebsite.Models;

namespace StarFishWebsite.Controllers
{
    public class ListController : Controller
    {
        public Context ucContext = new Context();

        public ActionResult Fish()
        {
            return View(ucContext.fish.Include("ImageCall").Include("AffiliateLink").Include("FishType").Include("PreferredFood").Include("PreferredFood.icon").Where(x => x.Available == true));
        }
        public ActionResult ConvertImage(int id)
        {
            var imageData = ucContext.images.Where(u => u.ID == id).SingleOrDefault().ImageFile;

            return File(imageData, "image/jpg");
        }

        public ActionResult Food()
        {
            ViewBag.Fish = ucContext.fish.Include("PreferredFood");
            return View(ucContext.foods.Include("TypeofFood").Include("preferringfish").Include("icon").Where(x => x.Available == true));
        }

        public ActionResult FoodType()
        {
            ViewBag.Food = ucContext.foods.Include("TypeofFood");

            return View(ucContext.foodTypes.Where(x => x.Available == true));
        }

        public ActionResult FishType()
        {
            ViewBag.Fish = ucContext.fish.Include("FishType");
            return View(ucContext.fishTypes.Where(x => x.Available == true));
        }

        public ActionResult Environment()
        {
            return View(ucContext.environments.Include("image").Include("foodType").Where(x => x.available == true));
        }

        public ActionResult Affiliate()
        {
            return View(ucContext.affiliateLinks.Where(x => x.Available == true));
        }

        public ActionResult ExternalLink(string site)
        {
            return Redirect("http://www." + site);
        }
    }
}