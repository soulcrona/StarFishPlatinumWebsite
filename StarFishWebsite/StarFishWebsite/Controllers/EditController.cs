using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarFishWebsite.Models;

namespace StarFishWebsite.Controllers
{
    public class EditController : Controller
    {
        public Context context = new Context();

        public ActionResult Affiliate(int id)
        {
            return View(context.affiliateLinks.Where(x => x.ID == id).FirstOrDefault());
        }
        
        [HttpPost]
        public ActionResult EditAffiliate(AffiliateLink affiliate)
        {
            AffiliateLink editedAffiliate = context.affiliateLinks.Where(x => x.ID == affiliate.ID).FirstOrDefault();
            editedAffiliate.name = affiliate.name;
            editedAffiliate.SiteName = affiliate.SiteName;
            editedAffiliate.Description = affiliate.Description;
            context.SaveChanges();

            return RedirectToAction("Affiliate", "List");
        }

        public ActionResult SoftDeleteAffiliate(int id)
        {
            AffiliateLink deletedAffiliate = context.affiliateLinks.Where(x => x.ID == id).FirstOrDefault();
            deletedAffiliate.Available = false;
            context.SaveChanges();

            return RedirectToAction("Affiliate", "List");
        }


        public ActionResult FoodType(int id)
        {
            return View(context.foodTypes.Where(x => x.ID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult EditFoodType(FoodType foodType)
        {
            FoodType editedFoodType = context.foodTypes.Where(x => x.ID == foodType.ID).FirstOrDefault();
            editedFoodType.Name = foodType.Name;
            context.SaveChanges();

            return RedirectToAction("FoodType", "List");
        }

        public ActionResult DeleteFoodType(int id)
        {
            FoodType deletedFoodType = context.foodTypes.Where(x => x.ID == id).FirstOrDefault();
            context.foodTypes.Remove(deletedFoodType);
            context.SaveChanges();

            return RedirectToAction("FoodType", "List");
        }

        public ActionResult SoftDeleteFoodType(int id)
        {
            FoodType deletedFoodType = context.foodTypes.Where(x => x.ID == id).FirstOrDefault();
            deletedFoodType.Available = false;
            context.SaveChanges();

            return RedirectToAction("FoodType", "List");
        }

        public ActionResult Food(int id)
        {
            Food currentFood = context.foods.Include("TypeofFood").Where(x => x.ID == id).FirstOrDefault();

            {
                List<SelectListItem> FoodTypes = new List<SelectListItem>();

                SelectListItem currentfoodtype = new SelectListItem();
                currentfoodtype.Value = currentFood.TypeofFood.ID.ToString();
                currentfoodtype.Text = currentFood.TypeofFood.Name;
                FoodTypes.Add(currentfoodtype);

                foreach (var item in context.foodTypes.Where(x => x.ID != currentFood.TypeofFood.ID))
                {
                    SelectListItem Object = new SelectListItem();
                    Object.Value = item.ID.ToString();
                    Object.Text = item.Name;
                    FoodTypes.Add(Object);
                }
                SelectList a = new SelectList(FoodTypes, "Value", "Text");

                ViewBag.FoodTypes = a;
            }

            return View(currentFood);
        }

        public ActionResult EditFood(Food food, int selectedfoodtype)
        {
            Food editedFood = context.foods.Include("TypeofFood").Where(x => x.ID == food.ID).FirstOrDefault();
            editedFood.TypeofFood = context.foodTypes.Where(x => x.ID == selectedfoodtype).FirstOrDefault();
            editedFood.Name = food.Name;
            editedFood.InGame = food.InGame;

            context.SaveChanges();

            return RedirectToAction("Food", "List");
        }

        public ActionResult DeleteFood(int id)
        {
            Food deletedFood = context.foods.Where(x => x.ID == id).FirstOrDefault();
            context.foods.Remove(deletedFood);
            context.SaveChanges();

            return RedirectToAction("Food", "List");
        }

        public ActionResult SoftDeleteFood(int id)
        {
            Food deletedFood = context.foods.Where(x => x.ID == id).FirstOrDefault();
            deletedFood.Available = false;
            context.SaveChanges();

            return RedirectToAction("Food", "List");
        }

        public ActionResult FishType(int id)
        {
            return View(context.fishTypes.Where(x => x.ID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult EditFishType(FishType fish)
        {
            FishType editedFishType = context.fishTypes.Where(x => x.ID == fish.ID).FirstOrDefault();
            editedFishType.Name = fish.Name;
            context.SaveChanges();

            return RedirectToAction("FishType", "List");
        }

        public ActionResult DeleteFishType(int id)
        {
            FishType deletedFishType = context.fishTypes.Where(x => x.ID == id).FirstOrDefault();
            context.fishTypes.Remove(deletedFishType);
            context.SaveChanges();

            return RedirectToAction("FishType", "List");
        }
        public ActionResult SoftDeleteFishType(int id)
        {
            FishType deletedFishType = context.fishTypes.Where(x => x.ID == id).FirstOrDefault();
            deletedFishType.Available = false;
            context.SaveChanges();

            return RedirectToAction("FishType", "List");
        }

        public ActionResult Fish(int id)
        {

            List<SelectListItem> FileInfo = new List<SelectListItem>();
            List<SelectListItem> FishTypes = new List<SelectListItem>();

            AllTables fish = new AllTables();
            fish.fish = context.fish.Include("AffiliateLink").Include("FishType").Include("ImageCall").Include("PreferredFood").Where(x => x.ID == id).FirstOrDefault();
            {
                SelectListItem defaultValue = new SelectListItem();
                defaultValue.Value = fish.fish.AffiliateLink.ID.ToString();
                defaultValue.Text = fish.fish.AffiliateLink.name;
                FileInfo.Add(defaultValue);
            }
            {
                SelectListItem Object = new SelectListItem();
                Object.Value = fish.fish.FishType.ID.ToString();
                Object.Text = fish.fish.FishType.Name;
                FishTypes.Add(Object);
            }
            foreach (var item in context.affiliateLinks)
            {
                if (item.ID != fish.fish.AffiliateLink.ID)
                {
                    SelectListItem Object = new SelectListItem();
                    Object.Value = item.ID.ToString();
                    Object.Text = item.name;
                    FileInfo.Add(Object);
                }

            }
            foreach (var item in context.fishTypes)
            {
                if (item.ID != fish.fish.FishType.ID)
                {
                    SelectListItem Object = new SelectListItem();
                    Object.Value = item.ID.ToString();
                    Object.Text = item.Name;
                    FishTypes.Add(Object);
                }
            }


            SelectList a = new SelectList(FileInfo, "Value", "Text");
            SelectList b = new SelectList(FishTypes, "Value", "Text");

            IEnumerable<SelectListItem> inum = FileInfo;
            ViewBag.Affiliates = a;
            ViewBag.Context = context;
            ViewBag.FishTypes = b;


            return View(fish);
        }

        [HttpPost]
        public ActionResult EditFish(Fish fish, int selectedaffiliate, HttpPostedFileBase filetobeuploaded, int selectedfishtype, bool[] fpyn, int[]fpid)
        {

            Fish editedfish = context.fish.Include("AffiliateLink").Include("FishType").Include("ImageCall").Include("PreferredFood").Where(x => x.ID == fish.ID).FirstOrDefault();
            editedfish.Name = fish.Name;
            editedfish.AffiliateLink = context.affiliateLinks.Where(x => x.ID == selectedaffiliate).FirstOrDefault();
            editedfish.FishType = context.fishTypes.Where(x => x.ID == selectedfishtype).FirstOrDefault();
            editedfish.Description = fish.Description;
            editedfish.MoreDescriptions = fish.MoreDescriptions;
            editedfish.SubDescriptions = fish.SubDescriptions;
            editedfish.PrivateNotes = fish.PrivateNotes;
            editedfish.InGame = fish.InGame;

            //Construct New PreferredFood List
            {
                int i = 0;
                List<Food> foodpreference = new List<Food>();
                foreach (var item in fpyn)
                {
                    if (item == true)
                    {
                        int temp = fpid[i];
                        foodpreference.Add(context.foods.Where(u => u.ID == temp).SingleOrDefault());
                    }
                    i++;
                }

                editedfish.PreferredFood = foodpreference;
            }


                //If new image uploaded, replace
                if (filetobeuploaded != null)
            {
                using (MemoryStream a = new MemoryStream())
                {
                    filetobeuploaded.InputStream.CopyTo(a);
                    byte[] imagefile = a.GetBuffer();

                    Image picture = new Image();
                    picture.Name = filetobeuploaded.FileName;
                    picture.ImageFile = imagefile;

                    editedfish.ImageCall = picture;
                }
            }

            context.SaveChanges();

            return RedirectToAction("Fish", "List");

        }
        

        public ActionResult DeleteFish(int id)
        {
            Fish fishToBeDeleted = context.fish.Where(x => x.ID == id).FirstOrDefault();
            context.fish.Remove(fishToBeDeleted);
            context.SaveChanges();
            return RedirectToAction("Fish", "List");
        }
        public ActionResult SoftDeleteFish(int id)
        {
            Fish fishToBeDeleted = context.fish.Where(x => x.ID == id).FirstOrDefault();
            fishToBeDeleted.Available = false;
            context.SaveChanges();
            return RedirectToAction("Fish", "List");
        }




    }
}