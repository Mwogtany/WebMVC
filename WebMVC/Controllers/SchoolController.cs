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
            Session["mCatBCert"] = "";
            Session["mGrade"] = "";
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

            string mCat = Session["mCatBCert"].ToString();
            if (mCat != "")
            {
                List<SelectListItem> selectedItems = aCategory.Where(p => p.Value == mCat).ToList();
                foreach (var selectedItem in selectedItems)
                {
                    selectedItem.Selected = true;
                }
            }

            List<proc_Get_ClassGrades2_Result> cGradeList = Db.proc_Get_ClassGrades2(Session["Institution_Code"].ToString(), Session["LEVELCODE"].ToString()).ToList();
            cGradeList.ForEach(x =>
            {
                aGradeList.Add(new SelectListItem { Text = x.Class_Name, Value = x.Class_Code.ToString() });
            });
            string mGrade = Session["mGrade"].ToString();
            if (mGrade != "")
            {
                List<SelectListItem> selectedGItems = aGradeList.Where(p => p.Value == mGrade).ToList();
                foreach (var selectedItem in selectedGItems)
                {
                    selectedItem.Selected = true;
                }
            }

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
        public ActionResult EditLearner(string id)
        {
            NEMISEntities Db = new NEMISEntities();

            List<SelectListItem> aGenderList = new List<SelectListItem>();
            List<SelectListItem> aCountryList = new List<SelectListItem>();
            List<SelectListItem> aMedicalList = new List<SelectListItem>();
            List<SelectListItem> aCountyList = new List<SelectListItem>();
            List<SelectListItem> aSCountyList = new List<SelectListItem>();
            List<SelectListItem> aGradeList = new List<SelectListItem>();
            aGenderList.Add(new SelectListItem { Text = "M", Value = "M" });
            aGenderList.Add(new SelectListItem { Text = "F", Value = "F" });
            aCountryList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            aMedicalList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            aCountyList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            aSCountyList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            aGradeList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });

            var mylearner = (from p in Db.proc_Get_Learner(id)
                             select p).SingleOrDefault();

            ViewBag.CountryList = aCountryList;
            ViewBag.GenderList = aGenderList;
            ViewBag.MedicalList = aMedicalList;
            ViewBag.CountyList = aCountyList;
            ViewBag.SCountyList = aSCountyList;
            ViewBag.ClassList = aGradeList;

            return View(mylearner);
        }
    }
}