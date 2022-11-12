using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            Session["mIndex"] = "";
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

            var mylearner = (from p in Db.proc_Get_Learner(id)
                             select new LearnerViewModel()
                             {
                                 UPI = p.UPI,
                                 Names = p.Names,
                                 Surname = p.Surname,
                                 FirstName = p.FirstName,
                                 OtherNames = p.OtherNames,
                                 Institution_Name = p.Institution_Name,
                                 Phone_Number = p.Phone_Number,
                                 Email_Address = p.Email_Address,
                                 Postal_Address = p.Postal_Address,
                                 Father_Name = p.Father_Name,
                                 Father_IDNo = p.Father_IDNo,
                                 Father_Contacts = p.Father_Contacts,
                                 Mother_Name = p.Mother_Name,
                                 Mother_IDNo = p.Mother_IDNo,
                                 Mother_Contacts = p.Mother_Contacts,
                                 Guardian_Contacts = p.Guardian_Contacts,
                                 Guardian_IDNo = p.Guardian_Contacts,
                                 Guardian_Name = p.Guardian_Name,
                                 Special_Medical_Condition = p.Special_Medical_Condition,
                                 Medical_Name = p.Medical_Name,
                                 Any_Special_Medical_Condition = p.Any_Special_Medical_Condition,
                                 Institution_Code = p.Institution_Code,
                                 Sub_County_Code = p.Sub_County_Code,
                                 Nationality = p.Nationality,
                                 County_Code = p.County_Code,
                                 County_Name = p.County_Name,
                                 LGender = p.Gender,
                                 Country_Name = p.Country_Name,
                                 Disability_Name = p.Disability_Name,
                                 Class_Name = p.Class_Name,
                                 DOB = p.DOB,
                                 DOB2 = p.DOB2,
                                 IsDateDOB = p.IsDateDOB,
                                 Birth_Cert_No = p.Birth_Cert_No,
                                 ID_No = p.ID_No,
                                 Disability_Code = p.Disability_Code,
                                 Class_Code = p.Class_Code,
                                 County_Learner = p.County_Learner,
                                 Sub_County_Learner = p.Sub_County_Learner,
                                 Special_Needs_List = p.Special_Needs_List,
                                 Father_Email = p.Father_Email,
                                 Mother_Email = p.Mother_Email,
                                 Guardian_Email = p.Guardian_Email,
                                 AGE = p.AGE,
                                 NHIF_No = p.NHIF_No,
                             }).SingleOrDefault();

            var ccty = (from p in Db.COUNTies
                          select p).ToList();
            ccty.ForEach(x =>
            {
                aCountyList.Add(new SelectListItem { Text = x.County_Name, Value = x.County_Code.ToString() });
            });

            if (mylearner.County_Code != "" && mylearner.County_Code != null)
            {
                var scty = (from k in Db.SUB_COUNTY
                            where k.County_Code == mylearner.County_Code
                            select k).ToList();
                scty.ForEach(x =>
                {
                    aSCountyList.Add(new SelectListItem { Text = x.Sub_County_Name, Value = x.Sub_County_Code.ToString() });
                });
            }
            else
            {
                aSCountyList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            }
            var myctry = (from k in Db.COUNTRies
                          select k).ToList();
            myctry.ForEach(x =>
            {
                aCountryList.Add(new SelectListItem { Text = x.Country_Name, Value = x.Country_Code.ToString() });
            });
            var medlst = (from p in Db.SPECIAL_MEDICAL_CONDITION_TYPE
                          select p).ToList();
            medlst.ForEach(x =>
            {
                aMedicalList.Add(new SelectListItem { Text = x.Medical_Name, Value = x.Medical_Code.ToString() });
            });
            var mlevel = Session["LEVELCODE"].ToString();
            var minst = Session["Institution_Code"].ToString();
            var mgrd = (from p in Db.proc_Get_ClassGrades(mlevel)
                        select p).ToList();
            mgrd.ForEach(x =>
            {
                aGradeList.Add(new SelectListItem { Text = x.Class_Name, Value = x.Class_Code.ToString() });
            });

            ViewBag.CountryList = aCountryList;
            ViewBag.GenderList = aGenderList;
            ViewBag.MedicalList = aMedicalList;
            ViewBag.CountyList = aCountyList;
            ViewBag.SCountyList = aSCountyList;
            ViewBag.ClassList = aGradeList;

            return View(mylearner);
        }
        [HttpPost]
        public ActionResult EditLearner(LearnerViewModel mymodel)
        {
            ViewBag.Message = "";
            using (NEMISEntities Db = new NEMISEntities())
            {
                if (Session["user"] == null)
                {
                    this.RedirectToAction("LogOff", "Account");
                }
                var mUser = (string)Session["user"];
                var mIndex = (string)Session["mIndex"];
                var bizna = mymodel;

                var mResultSet = Db.proc_InsLearnerWithIndexNew(
                        bizna.Institution_Code,
                        bizna.UPI,
                        bizna.Surname,
                        bizna.OtherNames,
                        bizna.FirstName,
                        bizna.Birth_Cert_No,
                        bizna.DOB2,
                        bizna.LGender,
                        bizna.Nationality,
                        mUser,
                        bizna.Class_Code,
                        bizna.Disability_Code,
                        bizna.Special_Medical_Condition,
                        bizna.Phone_Number,
                        bizna.Email_Address,
                        bizna.Postal_Address,
                        bizna.Father_Name,
                        bizna.Mother_Name,
                        bizna.Guardian_Name,
                        bizna.Father_IDNo,
                        bizna.Mother_IDNo,
                        bizna.Guardian_IDNo,
                        bizna.Father_Contacts,
                        bizna.Mother_Contacts,
                        bizna.Guardian_Contacts,
                        bizna.Father_Email,
                        bizna.Mother_Email,
                        bizna.Guardian_Email,
                        bizna.County_Code,
                        bizna.Sub_County_Code,
                        mUser,
                        mIndex
                    );

                if (mResultSet != null)
                {
                    var mUPI = mResultSet.First().GenUPI.ToString();
                    if (mUPI == "100001")
                    {
                        ViewBag.Message2 = "Record NOT Successed Saved!!! Check Birth Certificate Details and Resubmit!!!";
                    }
                    else
                    {
                        mymodel.UPI = mUPI;
                        ViewBag.Message = "Record Successfully Saved!!! = " + mUPI;
                    }
                }
                else
                {
                    ViewBag.Message2 = "Record NOT Successed Saved!!! = " + mResultSet.First().GenUPI.ToString();
                }
                
                List<SelectListItem> aGenderList = new List<SelectListItem>();
                List<SelectListItem> aCountryList = new List<SelectListItem>();
                List<SelectListItem> aMedicalList = new List<SelectListItem>();
                List<SelectListItem> aCountyList = new List<SelectListItem>();
                List<SelectListItem> aSCountyList = new List<SelectListItem>();
                List<SelectListItem> aGradeList = new List<SelectListItem>();

                aGenderList.Add(new SelectListItem { Text = "M", Value = "M" });
                aGenderList.Add(new SelectListItem { Text = "F", Value = "F" });

                var mylearner = mymodel;
                //var mylearner = (from p in Db.proc_Get_Learner(id)
                //                 select p).SingleOrDefault();

                var ccty = (from p in Db.COUNTies
                            select p).ToList();
                ccty.ForEach(x =>
                {
                    aCountyList.Add(new SelectListItem { Text = x.County_Name, Value = x.County_Code.ToString() });
                });

                if (mylearner.County_Code != "" && mylearner.County_Code != null)
                {
                    var scty = (from k in Db.SUB_COUNTY
                                where k.County_Code == mylearner.County_Code
                                select k).ToList();
                    scty.ForEach(x =>
                    {
                        aSCountyList.Add(new SelectListItem { Text = x.Sub_County_Name, Value = x.Sub_County_Code.ToString() });
                    });
                }
                else
                {
                    aSCountyList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                }
                var myctry = (from k in Db.COUNTRies
                              select k).ToList();
                myctry.ForEach(x =>
                {
                    aCountryList.Add(new SelectListItem { Text = x.Country_Name, Value = x.Country_Code.ToString() });
                });
                var medlst = (from p in Db.SPECIAL_MEDICAL_CONDITION_TYPE
                              select p).ToList();
                medlst.ForEach(x =>
                {
                    aMedicalList.Add(new SelectListItem { Text = x.Medical_Name, Value = x.Medical_Code.ToString() });
                });
                var mlevel = Session["LEVELCODE"].ToString();
                var minst = Session["Institution_Code"].ToString();
                var mgrd = (from p in Db.proc_Get_ClassGrades(mlevel)
                            select p).ToList();
                mgrd.ForEach(x =>
                {
                    aGradeList.Add(new SelectListItem { Text = x.Class_Name, Value = x.Class_Code.ToString() });
                });

                ViewBag.CountryList = aCountryList;
                ViewBag.GenderList = aGenderList;
                ViewBag.MedicalList = aMedicalList;
                ViewBag.CountyList = aCountyList;
                ViewBag.SCountyList = aSCountyList;
                ViewBag.ClassList = aGradeList;
            }

            return View("EditLearner", mymodel);
        }

        public ActionResult MoveLearner(string id)
        {
            NEMISEntities Db = new NEMISEntities();
            var mtransfer = new MoveLearnerViewModel();

            List<SelectListItem> aGradeList = new List<SelectListItem>();
            
            var mylearner = (from p in Db.proc_Get_Learner(id)
                             select new LearnerViewModel()
                             {
                                 UPI = p.UPI,
                                 Names = p.Names,
                                 Surname = p.Surname,
                                 FirstName = p.FirstName,
                                 OtherNames = p.OtherNames,
                                 Institution_Name = p.Institution_Name,
                                 Phone_Number = p.Phone_Number,
                                 Email_Address = p.Email_Address,
                                 Postal_Address = p.Postal_Address,
                                 Father_Name = p.Father_Name,
                                 Father_IDNo = p.Father_IDNo,
                                 Father_Contacts = p.Father_Contacts,
                                 Mother_Name = p.Mother_Name,
                                 Mother_IDNo = p.Mother_IDNo,
                                 Mother_Contacts = p.Mother_Contacts,
                                 Guardian_Contacts = p.Guardian_Contacts,
                                 Guardian_IDNo = p.Guardian_Contacts,
                                 Guardian_Name = p.Guardian_Name,
                                 Special_Medical_Condition = p.Special_Medical_Condition,
                                 Medical_Name = p.Medical_Name,
                                 Any_Special_Medical_Condition = p.Any_Special_Medical_Condition,
                                 Institution_Code = p.Institution_Code,
                                 Sub_County_Code = p.Sub_County_Code,
                                 Nationality = p.Nationality,
                                 County_Code = p.County_Code,
                                 County_Name = p.County_Name,
                                 LGender = p.Gender,
                                 Country_Name = p.Country_Name,
                                 Disability_Name = p.Disability_Name,
                                 Class_Name = p.Class_Name,
                                 DOB = p.DOB,
                                 DOB2 = p.DOB2,
                                 IsDateDOB = p.IsDateDOB,
                                 Birth_Cert_No = p.Birth_Cert_No,
                                 ID_No = p.ID_No,
                                 Disability_Code = p.Disability_Code,
                                 Class_Code = p.Class_Code,
                                 County_Learner = p.County_Learner,
                                 Sub_County_Learner = p.Sub_County_Learner,
                                 Special_Needs_List = p.Special_Needs_List,
                                 Father_Email = p.Father_Email,
                                 Mother_Email = p.Mother_Email,
                                 Guardian_Email = p.Guardian_Email,
                                 AGE = p.AGE,
                                 NHIF_No = p.NHIF_No,
                             }).SingleOrDefault();
            
            var mlevel = Session["LEVELCODE"].ToString();
            var minst = Session["Institution_Code"].ToString();
            var mgrd = (from p in Db.proc_Get_ClassGrades(mlevel)
                        select p).ToList();
            mgrd.ForEach(x =>
            {
                aGradeList.Add(new SelectListItem { Text = x.Class_Name, Value = x.Class_Code.ToString() });
            });
            
            ViewBag.ClassList = aGradeList;
            mtransfer.ALearnerViewModel = mylearner;
            mtransfer.OriginalGrade = mylearner.Class_Code;
            mtransfer.NewGrade = "";
            mtransfer.NewGradeList = aGradeList;
            mtransfer.UPI = id;
            return View(mtransfer);
        }

        [HttpPost]
        public ActionResult MoveLearner(MoveLearnerViewModel mycase)
        {
            var mtransfer = new MoveLearnerViewModel();
            var mlevel = Session["LEVELCODE"].ToString();
            var minst = Session["Institution_Code"].ToString();
            //NEMISEntities Db2 = new NEMISEntities();
            //List<SelectListItem> aGradeList = new List<SelectListItem>();
            string id = mycase.UPI;
            //var mgrd = (from p in Db2.proc_Get_ClassGrades(mlevel)
            //            select p).ToList();
            //mgrd.ForEach(x =>
            //{
            //    aGradeList.Add(new SelectListItem { Text = x.Class_Name, Value = x.Class_Code.ToString() });
            //});

            //ViewBag.ClassList = aGradeList;

            //if (!ModelState.IsValid)
            //    return View(mycase);

            if (Session["user"] == null)
            {
                this.RedirectToAction("LogOff", "Account");
            }
            var mUser = (string)Session["user"];
            mycase.DateEffected = DateTime.Now;

            using (NEMISEntities Db = new NEMISEntities())
            {

                Db.LEARNER_TRANSFER_GRADE.Add(new LEARNER_TRANSFER_GRADE()
                {
                    UPI = mycase.UPI,
                    Category = "1",
                    OriginalGrade = mycase.OriginalGrade,
                    NewGrade = mycase.NewGrade,
                    DateEffected = mycase.DateEffected
                });

                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges
                    Db.SaveChanges();
                    ViewBag.Message = "Learner Moved Successfully Saved!!!";
                    return RedirectToAction("MyLearners");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

                var mylearner = (from p in Db.proc_Get_Learner(id)
                                 select new LearnerViewModel()
                                 {
                                     UPI = p.UPI,
                                     Names = p.Names,
                                     Surname = p.Surname,
                                     FirstName = p.FirstName,
                                     OtherNames = p.OtherNames,
                                     Institution_Name = p.Institution_Name,
                                     Phone_Number = p.Phone_Number,
                                     Email_Address = p.Email_Address,
                                     Postal_Address = p.Postal_Address,
                                     Father_Name = p.Father_Name,
                                     Father_IDNo = p.Father_IDNo,
                                     Father_Contacts = p.Father_Contacts,
                                     Mother_Name = p.Mother_Name,
                                     Mother_IDNo = p.Mother_IDNo,
                                     Mother_Contacts = p.Mother_Contacts,
                                     Guardian_Contacts = p.Guardian_Contacts,
                                     Guardian_IDNo = p.Guardian_Contacts,
                                     Guardian_Name = p.Guardian_Name,
                                     Special_Medical_Condition = p.Special_Medical_Condition,
                                     Medical_Name = p.Medical_Name,
                                     Any_Special_Medical_Condition = p.Any_Special_Medical_Condition,
                                     Institution_Code = p.Institution_Code,
                                     Sub_County_Code = p.Sub_County_Code,
                                     Nationality = p.Nationality,
                                     County_Code = p.County_Code,
                                     County_Name = p.County_Name,
                                     LGender = p.Gender,
                                     Country_Name = p.Country_Name,
                                     Disability_Name = p.Disability_Name,
                                     Class_Name = p.Class_Name,
                                     DOB = p.DOB,
                                     DOB2 = p.DOB2,
                                     IsDateDOB = p.IsDateDOB,
                                     Birth_Cert_No = p.Birth_Cert_No,
                                     ID_No = p.ID_No,
                                     Disability_Code = p.Disability_Code,
                                     Class_Code = p.Class_Code,
                                     County_Learner = p.County_Learner,
                                     Sub_County_Learner = p.Sub_County_Learner,
                                     Special_Needs_List = p.Special_Needs_List,
                                     Father_Email = p.Father_Email,
                                     Mother_Email = p.Mother_Email,
                                     Guardian_Email = p.Guardian_Email,
                                     AGE = p.AGE,
                                     NHIF_No = p.NHIF_No,
                                 }).SingleOrDefault();

                
                mtransfer.ALearnerViewModel = mylearner;
                mtransfer.OriginalGrade = mylearner.Class_Code;
                mtransfer.UPI = id;
                return View(mtransfer);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult DeleteLearner(string id)
        {
            //update database
            if (Session["user"] == null)
            {
                this.RedirectToAction("LogOff", "Account");
            }
            var mUser = (string)Session["user"];
            var minst = Session["Institution_Code"].ToString();
            using (NEMISEntities Db = new NEMISEntities())
            {
                var alearner = Db.proc_Get_Learner(id).FirstOrDefault();
                Db.proc_DeleteLearner(id, mUser, minst);
                Db.SaveChanges();
                ViewBag.Message = "Record Successfully Deleted!!!";

                return Json(alearner);
            }

            return new EmptyResult();
        }

        public ActionResult MyInstitution()
        {
            var mlevel = Session["LEVELCODE"].ToString();
            var minst = Session["Institution_Code"].ToString();
            Session["controller"] = "School";
            Session["action"] = "Index";

            return RedirectToAction("Edit", "Institution", new { area = "", id = minst });
        }
    }
}