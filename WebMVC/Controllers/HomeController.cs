using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        NEMISEntities Db = new NEMISEntities();
        [Route("")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var content = Db.CONTENTITEMS.Where(p => p.Visible == "1" && p.Link == "0").DefaultIfEmpty().ToList();
            return View(content);
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