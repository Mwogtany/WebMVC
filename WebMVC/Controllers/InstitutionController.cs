using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Models.ViewModels;

namespace WebMVC.Controllers
{
    public class InstitutionController : Controller
    {
        // GET: Institution
        public ActionResult Index()
        {
            NEMISEntities Db = new NEMISEntities();
            var minst = new InstitutionsViewModel();

            List<SelectListItem> aLevelList = new List<SelectListItem>();
            List<SelectListItem> aTypeList = new List<SelectListItem>();
            List<SelectListItem> aRecsList = new List<SelectListItem>();
            List<SelectListItem> aCountyList = new List<SelectListItem>();
            List<SelectListItem> aSCountyList = new List<SelectListItem>();

            List<proc_Get_InstLevel_Result> cLevels = Db.proc_Get_InstLevel().ToList();
            cLevels.ForEach(x =>
            {
                aLevelList.Add(new SelectListItem { Text = x.Level_Name, Value = x.Level_Code.ToString() });
            });
            
            var ccty = (from p in Db.COUNTies
                        select p).ToList();
            ccty.ForEach(x =>
            {
                aCountyList.Add(new SelectListItem { Text = x.County_Name, Value = x.County_Code.ToString() });
            });
            
            aSCountyList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            List<int?> cPageRecs = Db.proc_Get_PageRecords().ToList();
            cPageRecs.ForEach(x =>
            {
                aRecsList.Add(new SelectListItem { Text = x.Value.ToString(), Value = x.Value.ToString() });
            });
            aTypeList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            aTypeList.Add(new SelectListItem { Text = "All", Value = "All" });
            aTypeList.Add(new SelectListItem { Text = "Public", Value = "Public" });
            aTypeList.Add(new SelectListItem { Text = "Private", Value = "Private" });

            minst.LevelList = aLevelList;
            minst.CountyList = aCountyList;
            minst.SubCountyList = aSCountyList;
            minst.TypeList = aTypeList;
            var Insts = Db.proc_Get_Institutions("0","0","All").ToList() as IEnumerable<InstitutionViewModel>;
            minst.Institutions = Insts;

            minst.PageRecordsList = aRecsList;

            return View(minst);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Delete(string id)
        {
            //update database
            if (Session["user"] == null)
            {
                this.RedirectToAction("LogOff", "Account");
            }
            var mUser = (string)Session["user"];
            using (NEMISEntities Db = new NEMISEntities())
            {
                var aInst = Db.proc_Get_Institution(id).FirstOrDefault();
                Db.proc_DeleteInstitution(id, mUser);
                Db.SaveChanges();
                ViewBag.Message = "Record Successfully Deleted!!!";
                return Json(aInst);
            }
            return new EmptyResult();
        }
    }
}