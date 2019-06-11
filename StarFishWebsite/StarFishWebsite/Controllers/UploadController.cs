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

        public ActionResult NewEnvironment()
        {
            List<SelectListItem> foodTypes = new List<SelectListItem>();

            foreach (var item in ucContext.foodTypes)
            {
                SelectListItem Object = new SelectListItem();
                Object.Value = item.ID.ToString();
                Object.Text = item.Name;
                foodTypes.Add(Object);
            }

            SelectList a = new SelectList(foodTypes, "Value", "Text");

            ViewBag.FoodTypes = a;

            return View();
        }

        [HttpPost]
        public ActionResult AddEnvironment(Models.Environment environment, int foodType, HttpPostedFileBase filetobeuploaded)
        {
            using (MemoryStream a = new MemoryStream())
            {
                filetobeuploaded.InputStream.CopyTo(a);
                byte[] imagefile = a.GetBuffer();

                Image picture = new Image();
                picture.Name = filetobeuploaded.FileName;
                picture.ImageFile = imagefile;

                environment.foodType = ucContext.foodTypes.Where(x => x.ID == foodType).FirstOrDefault();
                environment.image = picture;
                ucContext.environments.Add(environment);
                ucContext.SaveChanges();

                return RedirectToAction("Environment", "List", null);
            }

                
        }

        public ActionResult NewUser()
        {
            List<SelectListItem> Roles = new List<SelectListItem>();

            foreach (var item in ucContext.roles)
            {
                SelectListItem Object = new SelectListItem();
                Object.Value = item.ID.ToString();
                Object.Text = item.Name + "(" + item.AccessLevel.ToString() + ")";
                Roles.Add(Object);
            }

            SelectList a = new SelectList(Roles, "Value", "Text");

            ViewBag.Roles = a;

            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Login user, int? RoleID)
        {
            if(RoleID == null)
            {
                RoleID = ucContext.roles.Where(x => x.AccessLevel == 0).FirstOrDefault().ID;
            }

            user.Role = ucContext.roles.Where(x => x.ID == RoleID).FirstOrDefault();
            user.IPAddress = Request.UserHostAddress;
            user.MachineName = Request.UserHostName;
            user.LoginTime = DateTime.Now;
            ucContext.logins.Add(user);
            ucContext.SaveChanges();

            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult NewRole ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(Role role)
        {
            ucContext.roles.Add(role);
            ucContext.SaveChanges();
            return RedirectToAction("Index", "Home", null);
        }


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

        public ActionResult NewButton()
        {
            List<SelectListItem> Button = new List<SelectListItem>();

            SelectListItem fish = new SelectListItem();
            fish.Value = 1.ToString();
            fish.Text = "Fish";
            Button.Add(fish);
            SelectListItem food = new SelectListItem();
            food.Value = 2.ToString();
            food.Text = "Food";
            Button.Add(food);
            SelectListItem environment = new SelectListItem();
            environment.Value = 3.ToString();
            environment.Text = "Environment";
            Button.Add(environment);

            SelectList a = new SelectList(Button, "Value", "Text");

            ViewBag.buttons = a;

            return View();
        }

        [HttpPost]
        public ActionResult SetButton(int selectedbutton, HttpPostedFileBase filetobeuploaded)
        {
            using (MemoryStream a = new MemoryStream())
            {
                filetobeuploaded.InputStream.CopyTo(a);
                byte[] imagefile = a.GetBuffer();
                Image picture = new Image();
                picture.Name = filetobeuploaded.FileName;
                picture.ImageFile = imagefile;

                if(ucContext.buttons.Where(x => x.value == selectedbutton).FirstOrDefault() == null)
                {
                    Button button = new Button();
                    button.value = selectedbutton;
                    button.image = picture;
                    ucContext.buttons.Add(button);
                    ucContext.SaveChanges();
                }
                else
                {
                    Button button = ucContext.buttons.Where(x => x.value == selectedbutton).FirstOrDefault();
                    button.image = picture;
                    ucContext.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }
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
        public ActionResult AddFood(Food food, int selectedfoodtype, HttpPostedFileBase filetobeuploaded)
        {
            using (MemoryStream a = new MemoryStream())
            {
                filetobeuploaded.InputStream.CopyTo(a);
                byte[] imagefile = a.GetBuffer();
                Image picture = new Image();
                picture.Name = filetobeuploaded.FileName;
                picture.ImageFile = imagefile;


                food.TypeofFood = ucContext.foodTypes.Where(x => x.ID == selectedfoodtype).FirstOrDefault();
                food.Available = true;
                food.icon = picture;
                ucContext.foods.Add(food);
                ucContext.SaveChanges();
                return RedirectToAction("Food", "List");
            }
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
                FishToBeUploaded.Price = FishUploaded.fish.Price;
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