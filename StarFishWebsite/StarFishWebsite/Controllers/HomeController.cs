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