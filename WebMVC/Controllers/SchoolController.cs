using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {
            Session["headurl"] = "";
            return View();
        }

        public PartialViewResult _PartialEcdeLeft()
        {
            return PartialView();
        }
        public PartialViewResult _PartialPrimLeft()
        {
            return PartialView();
        }
        public PartialViewResult _PartialSecLeft()
        {
            return PartialView();
        }
        public PartialViewResult _PartialTerLeft()
        {
            return PartialView();
        }
        public PartialViewResult _PartialGenLeft()
        {
            return PartialView();
        }

        public PartialViewResult _PartialEcdeRight()
        {
            return PartialView();
        }
        public PartialViewResult _PartialPrimRight()
        {
            return PartialView();
        }
        public PartialViewResult _PartialSecRight()
        {
            return PartialView();
        }
        public PartialViewResult _PartialTerRight()
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

        public ActionResult MyLearners()
        {
            var mylearner = new ListLearnerViewModel();
            NEMISEntities Db = new NEMISEntities();
            List<SelectListItem> aCategory = new List<SelectListItem>();
            List<SelectListItem> aGradeList = new List<SelectListItem>();
            List<SelectListItem> aRecsList = new List<SelectListItem>();

            List<proc_GetLearnerCategory_Result1> cCategories = Db.proc_GetLearnerCategory().ToList();
            cCategories.ForEach(x =>
            {
                aCategory.Add(new SelectListItem { Text = x.Description, Value = x.Code.ToString() });
            });
            List<proc_Get_ClassGrades2_Result> cGradeList = Db.proc_Get_ClassGrades2(Session["Institution_Code"].ToString(), Session["LEVELCODE"].ToString()).ToList();
            cGradeList.ForEach(x =>
            {
                aGradeList.Add(new SelectListItem { Text = x.Class_Name, Value = x.Class_Code.ToString() });
            });
            List<int?> cPageRecs = Db.proc_Get_PageRecords().ToList();
            cPageRecs.ForEach(x =>
            {
                aRecsList.Add(new SelectListItem { Text = x.Value.ToString(), Value = x.Value.ToString() });
            });

            mylearner.CategoryList = aCategory;
            mylearner.GradeList = aGradeList;
            mylearner.PageRecordsList = aRecsList;
            return View(mylearner);
        }
    }
}