using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarFishWebsite.Models;

namespace StarFishWebsite.Controllers
{
    public class UploadController : Controller
    {
        public Context ucContext = new Context();

        public ActionResult NewAffiliate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAffiliate(AffiliateLink affiliate)
        {
            affiliate.Available = true;
            ucContext.affiliateLinks.Add(affiliate);
            ucContext.SaveChanges();

            return RedirectToAction("Affiliate", "List");
        }

        public ActionResult NewFishType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFishType(FishType fishType)
        {
            fishType.Available = true;
            ucContext.fishTypes.Add(fishType);
            ucContext.SaveChanges();

            return RedirectToAction("FishType", "List");
        }

        public ActionResult NewFoodType()
        {
            return View();
        }

        public ActionResult AddFoodType(FoodType foodType)
        {
            foodType.Available = true;
            ucContext.foodTypes.Add(foodType);
            ucContext.SaveChanges();

            return RedirectToAction("FoodType", "List");
        }

        public ActionResult NewFood()
        {
            List<SelectListItem> FoodTypes = new List<SelectListItem>();
            foreach (var item in ucContext.foodTypes)
            {
                SelectListItem Object = new SelectListItem();
                Object.Value = item.ID.ToString();
                Object.Text = item.Name;
                FoodTypes.Add(Object);
            }
            SelectList a = new SelectList(FoodTypes, "Value", "Text");

            ViewBag.FoodTypes = a;

            return View();

        }
        [HttpPost]
        public ActionResult AddFood(Food food, int selectedfoodtype)
        {
            food.TypeofFood = ucContext.foodTypes.Where(x => x.ID == selectedfoodtype).FirstOrDefault();
            food.Available = true;
            ucContext.foods.Add(food);
            ucContext.SaveChanges();
            return RedirectToAction("Food", "List");
        }

        public ActionResult UploadFile()
        {
            List<SelectListItem> FileInfo = new List<SelectListItem>();
            List<SelectListItem> FishTypes = new List<SelectListItem>();

            foreach (var item in ucContext.affiliateLinks)
            {
                SelectListItem Object = new SelectListItem();
                Object.Value = item.ID.ToString();
                Object.Text = item.name;
                FileInfo.Add(Object);
                
            }
            foreach (var item in ucContext.fishTypes)
            {
                SelectListItem Object = new SelectListItem();
                Object.Value = item.ID.ToString();
                Object.Text = item.Name;
                FishTypes.Add(Object);
            }


            SelectList a = new SelectList(FileInfo, "Value", "Text");
            SelectList b = new SelectList(FishTypes, "Value", "Text");

            IEnumerable<SelectListItem> inum = FileInfo;
            ViewBag.Affiliates = a;
            ViewBag.Context = ucContext;
            ViewBag.FishTypes = b;

            return View();
        }

        [HttpPost]
        public ActionResult UploadFish (AllTables FishUploaded, HttpPostedFileBase filetobeuploaded, int selectedaffiliate, int selectedfishtype)
        {
            using (MemoryStream a = new MemoryStream())
            {
                filetobeuploaded.InputStream.CopyTo(a);
                byte[] imagefile = a.GetBuffer();

                Image picture = new Image();
                picture.Name = filetobeuploaded.FileName;
                picture.ImageFile = imagefile;

                Fish FishToBeUploaded = FishUploaded.fish;
                FishToBeUploaded.ImageCall = picture;
                FishToBeUploaded.AffiliateLink = ucContext.affiliateLinks.Where(u => u.ID == selectedaffiliate).FirstOrDefault();
                FishToBeUploaded.FishType = ucContext.fishTypes.Where(u => u.ID == selectedfishtype).FirstOrDefault();
                FishToBeUploaded.Available = true;
                int i = 0;
                List<Food> foodpreference = new List<Food>();
                foreach (var item in FishUploaded.fpyn)
                {
                    if (item == true)
                    {
                        int temp = FishUploaded.fpid[i];
                        foodpreference.Add(ucContext.foods.Where(u => u.ID == temp).SingleOrDefault());
                    }
                    i++;
                }
                FishToBeUploaded.PreferredFood = foodpreference;
                FishToBeUploaded.Available = true;

                ucContext.fish.Add(FishToBeUploaded);
                ucContext.SaveChanges();

            }

            return RedirectToAction("Fish", "List");
        }

    }
}