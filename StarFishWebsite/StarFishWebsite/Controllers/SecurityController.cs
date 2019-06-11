using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarFishWebsite.Models;

namespace StarFishWebsite.Controllers
{
    public class SecurityController : Controller
    {
        public Context context = new Context();

        // GET: Security
        public ActionResult Login()
        {
            List<SelectListItem> times = new List<SelectListItem>();

            SelectListItem Ten = new SelectListItem
            {
                Value = 10.ToString(),
                Text = "10 Minutes"
            };
            SelectListItem Thirty = new SelectListItem
            {
                Value = 30.ToString(),
                Text = "30 Minutes"
            };
            SelectListItem Sixty = new SelectListItem
            {
                Value = 60.ToString(),
                Text = "1 Hour"
            };
            SelectListItem TwoH = new SelectListItem
            {
                Value = 120.ToString(),
                Text = "2 Hours"
            };
            SelectListItem FourH = new SelectListItem
            {
                Value = 240.ToString(),
                Text = "4 Hours"
            };
            SelectListItem EightH = new SelectListItem
            {
                Value = 480.ToString(),
                Text = "8 Hours"
            };
            SelectListItem OneD = new SelectListItem
            {
                Value = 1440.ToString(),
                Text = "1 Day"
            };

            times.Add(Ten);
            times.Add(Thirty);
            times.Add(Sixty);
            times.Add(TwoH);
            times.Add(FourH);
            times.Add(EightH);
            times.Add(OneD);

            SelectList a = new SelectList(times, "Value", "Text");

            ViewBag.Times = a;

            return View();
        }

        [HttpPost]
        public ActionResult LoginFunction(Login user, double logouttime)
        {
            Login UserToModify = context.logins.Where(x => x.Username == user.Username).FirstOrDefault();
            if(UserToModify != null && user.Password == UserToModify.Password)
            {
                UserToModify.IPAddress = Request.UserHostAddress;
                UserToModify.LoginTime = DateTime.Now.AddMinutes(logouttime);
                context.SaveChanges();
                return RedirectToAction("Index", "Home", null);
            }
            return RedirectToAction("Index", "Home", null);

        }
        
        public ActionResult LogoutUser()
        {
            if (context.logins.Where(x => x.IPAddress == Request.UserHostAddress).Where(x => x.LoginTime > DateTime.Now).FirstOrDefault() != null)
            {
                context.logins.Where(x => x.IPAddress == Request.UserHostAddress).Where(x => x.LoginTime > DateTime.Now).FirstOrDefault().LoginTime = DateTime.Now;
                context.SaveChanges();
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                return RedirectToAction("Index", "Home", null);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(Login NewUser, int role)
        {
            if (context.logins.Where(x => x.Username == NewUser.Username).ToList().Count() == 0)
            {
                NewUser.Role = context.roles.Where(x => x.ID == role).FirstOrDefault();
                NewUser.LoginTime = DateTime.Now;
            }
            return RedirectToAction("Index", "Home", null);
        }
    }
}