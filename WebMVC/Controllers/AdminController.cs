using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _PartialGenLeft()
        {
            return PartialView();
        }
        public PartialViewResult _PartialGenRight()
        {
            return PartialView();
        }
        public PartialViewResult _PartialGenCenter()
        {
            return PartialView();
        }
    }
}