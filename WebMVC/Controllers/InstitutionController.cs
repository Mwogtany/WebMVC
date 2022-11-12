using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
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
            if (Session["user"] == null)
            {
                this.RedirectToAction("LogOff", "Account");
            }
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
            var Insts = Db.proc_Get_Institutions("0", "0", "All").ToList() as IEnumerable<InstitutionViewModel>;
            minst.Institutions = Insts;

            minst.PageRecordsList = aRecsList;
            Session["controller"] = "Institution";
            Session["action"] = "Index";
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

        public ActionResult Edit(string id)
        {
            if (Session["user"] == null)
            {
                this.RedirectToAction("LogOff", "Account");
            }
            NEMISEntities Db = new NEMISEntities();
            //var minst = new InstitutionViewModel();
            var Insts = (from p in Db.proc_Get_Institution(id)
                         select new InstitutionViewModel()
                         {
                             Institution_Code = p.Institution_Code,
                             Institution_Name = p.Institution_Name,
                             Institution_Type = p.Institution_Type,
                             Institution_Current_Code = p.Institution_Current_Code,
                             Institution_Status = p.Institution_Status,
                             Tsc_Code = p.Tsc_Code,
                             Knec_Code = p.Knec_Code,
                             Institution_Category_Code = p.Institution_Category_Code,
                             Registration_Date = p.Registration_Date,
                             Institution_Level_Code = p.Institution_Level_Code,
                             Institution_Cluster = p.Institution_Cluster,
                             Classification_by_Gender = p.Classification_by_Gender,
                             Accommodation_Code = p.Accommodation_Code,
                             Mobile_Institution = p.Mobile_Institution,
                             Formal_Status = p.Formal_Status,
                             Institution_Residence = p.Institution_Residence,
                             Education_System_Code = p.Education_System_Code,
                             Employer_pin = p.Employer_pin,
                             County_Code = p.County_Code,
                             Sub_County_Code = p.Sub_County_Code,
                             Zone_Code = p.Zone_Code,
                             Constituency_Code = p.Constituency_Code,
                             Ward_Code = p.Ward_Code,
                             Latitude = p.Latitude,
                             Longitude = p.Longitude,
                             PlusCode = "",
                             Address = "",

                             Premise_Ownership = p.Premise_Ownership,
                             Ownershipdocuments = p.Ownership_Document,
                             Proprietor_Code = p.Proprietor_Code,
                             Registration_Certificate = p.Registration_Certificate,
                             Nearest_Police_Station = p.Nearest_Police_Station,
                             Nearest_Health_Facility = p.Nearest_Health_Facility,
                             Nearest_Town = p.Nearest_Town,

                             Postal_Address = p.Postal_Address,
                             Email_Address = p.Email_Address,
                             Tel_Number = p.Tel_Number,
                             Tel_Number2 = p.Tel_Number2,
                             Mobile_Number1 = p.Mobile_Number1,
                             Mobile_Number2 = p.Mobile_Number2,
                             Website = p.Website,
                             Social_Media = p.Social_Media,

                             InstitutionRegDocument = p.InstitutionRegDocument,
                             Ownership_Document = p.Ownership_Document,
                             Incorporationdocument = p.Incorporationdocument
                         }).Single();
            var minst = Insts;

            List<SelectListItem> aLevelList = new List<SelectListItem>();
            List<proc_Get_InstLevel_Result> cLevels = Db.proc_Get_InstLevel().ToList();
            cLevels.ForEach(x =>
            {
                aLevelList.Add(new SelectListItem { Text = x.Level_Name, Value = x.Level_Code.ToString() });
            });
            List<SelectListItem> aTypeList = new List<SelectListItem>();
            aTypeList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var stypes = (from p in Db.INSTITUTION_TYPES
                            select p).ToList();
            stypes.ForEach(x =>
            {
                aTypeList.Add(new SelectListItem { Text = x.Institution_Type_Name, Value = x.Institution_Type_Name.ToString() });
            });

            List<SelectListItem> aRecsList = new List<SelectListItem>();
            List<SelectListItem> aCountyList = new List<SelectListItem>();
            var ccty = (from p in Db.COUNTies
                        select p).ToList();
            ccty.ForEach(x =>
            {
                aCountyList.Add(new SelectListItem { Text = x.County_Name, Value = x.County_Code.ToString() });
            });
            List<SelectListItem> aSCountyList = new List<SelectListItem>();
            aSCountyList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var sccty = (from p in Db.SUB_COUNTY
                         where p.County_Code == minst.County_Code
                         select p).ToList();
            sccty.ForEach(x =>
            {
                aSCountyList.Add(new SelectListItem { Text = x.Sub_County_Name, Value = x.Sub_County_Code.ToString() });
            });
            List<SelectListItem> aZoneList = new List<SelectListItem>();
            aZoneList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var szones = (from p in Db.ZONEs
                          where p.Sub_County_Code == minst.Sub_County_Code
                          select p).ToList();
            szones.ForEach(x =>
            {
                aZoneList.Add(new SelectListItem { Text = x.Zone_Name, Value = x.Zone_Code.ToString() });
            });
            List<SelectListItem> aConstList = new List<SelectListItem>();
            aConstList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var sconst = (from p in Db.CONSTITUENCies
                          where p.County_Code == minst.County_Code
                          select p).ToList();
            sconst.ForEach(x =>
            {
                aConstList.Add(new SelectListItem { Text = x.Constituency_Name, Value = x.Constituency_Code.ToString() });
            });

            List<SelectListItem> aWardList = new List<SelectListItem>();
            aWardList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var swards = (from p in Db.WARDS
                          where p.Constituency_Code == minst.Constituency_Code
                          select p).ToList();
            swards.ForEach(x =>
            {
                aWardList.Add(new SelectListItem { Text = x.Ward_Name, Value = x.Ward_Code.ToString() });
            });

            List<SelectListItem> aRegStatusList = new List<SelectListItem>();
            aRegStatusList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var sregs = (from p in Db.INSTITUTION_STATUS
                         select p).ToList();
            sregs.ForEach(x =>
            {
                aRegStatusList.Add(new SelectListItem { Text = x.Status_Name, Value = x.Status_Code.ToString() });
            });

            List<SelectListItem> aCategoryList = new List<SelectListItem>();
            aCategoryList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var scate = (from p in Db.INSTITUTION_CATEGORY
                         select p).ToList();
            scate.ForEach(x =>
            {
                aCategoryList.Add(new SelectListItem { Text = x.Institution_Cat_Name, Value = x.Institution_Cat_Code.ToString() });
            });

            List<SelectListItem> aClusterList = new List<SelectListItem>();
            aClusterList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var scluster = (from p in Db.INSTITUTION_CLUSTERS
                            select p).ToList();
            scluster.ForEach(x =>
            {
                aClusterList.Add(new SelectListItem { Text = x.Cluster_Name, Value = x.Cluster_Code.ToString() });
            });

            List<SelectListItem> aGenderList = new List<SelectListItem>();
            aGenderList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var sgender = (from p in Db.INSTITUTION_GENDER
                           select p).ToList();
            sgender.ForEach(x =>
            {
                aGenderList.Add(new SelectListItem { Text = x.School_Gender_Name, Value = x.School_Gender_Code.ToString() });
            });

            List<SelectListItem> aAccommodationList = new List<SelectListItem>();
            aAccommodationList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var saccomm = (from p in Db.INSTITUTION_ACCOMMODATION
                           select p).ToList();
            saccomm.ForEach(x =>
            {
                aAccommodationList.Add(new SelectListItem { Text = x.Accommodation_Name, Value = x.Accommodation_Code.ToString() });
            });

            List<SelectListItem> aMobileList = new List<SelectListItem>();
            aMobileList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var smobile = (from p in Db.INSTITUTION_MOBILITY
                           select p).ToList();
            smobile.ForEach(x =>
            {
                aMobileList.Add(new SelectListItem { Text = x.Mobility_Name, Value = x.Mobility_Code.ToString() });
            });

            List<SelectListItem> aFormalityList = new List<SelectListItem>();
            aFormalityList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var sform = (from p in Db.INSTITUTION_FORMALITY
                         select p).ToList();
            sform.ForEach(x =>
            {
                aFormalityList.Add(new SelectListItem { Text = x.Formality_Name, Value = x.Formality_Code.ToString() });
            });

            List<SelectListItem> aResidenceList = new List<SelectListItem>();
            aResidenceList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var sres = (from p in Db.INSTITUTION_RESIDENCE
                        select p).ToList();
            sres.ForEach(x =>
            {
                aResidenceList.Add(new SelectListItem { Text = x.Residence, Value = x.Residence_Code.ToString() });
            });

            List<SelectListItem> aEduSysList = new List<SelectListItem>();
            aEduSysList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var sedusys = (from p in Db.INSTITUTION_EDUCATION_SYSTEM
                           select p).ToList();
            sedusys.ForEach(x =>
            {
                aEduSysList.Add(new SelectListItem { Text = x.Educationa_System_Name, Value = x.Education_System_Code.ToString() });
            });

            List<SelectListItem> aOwnDocList = new List<SelectListItem>();
            aOwnDocList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var sowndocs = (from p in Db.INSTITUTION_OWNERSHIP_DOCUMENT
                           select p).ToList();
            sowndocs.ForEach(x =>
            {
                aOwnDocList.Add(new SelectListItem { Text = x.Document_Name, Value = x.Document_Code.ToString() });
            });
            List<SelectListItem> aPremOwnList = new List<SelectListItem>();
            aPremOwnList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
            var spremown = (from p in Db.INSTITUTION_PREMISE_OWNERSHIP
                           select p).ToList();
            spremown.ForEach(x =>
            {
                aPremOwnList.Add(new SelectListItem { Text = x.Premise_Ownership_Name, Value = x.Premise_Ownership_Code.ToString() });
            });
            
            minst.LevelList = aLevelList;
            minst.CountyList = aCountyList;
            minst.SCountyList = aSCountyList;
            minst.TypeList = aTypeList;

            minst.ZoneList = aZoneList;
            minst.ConstituencyList = aConstList;
            minst.WardList = aWardList;

            minst.RegStatusList = aRegStatusList;
            minst.CategoryList = aCategoryList;
            minst.ClusterList = aClusterList;
            minst.GenderList = aGenderList;
            minst.AccommodationList = aAccommodationList;
            minst.MobileList = aMobileList;
            minst.FormalityList = aFormalityList;
            minst.ResidenceList = aResidenceList;
            minst.EduSysList = aEduSysList;
            minst.OwnerDocList = aOwnDocList;
            minst.PremOwnList = aPremOwnList;

            return View(minst);
        }

        [HttpPost]
        public ActionResult Edit(InstitutionViewModel mymodel)
        {
            if (Session["user"] == null)
            {
                this.RedirectToAction("LogOff", "Account");
            }
            var mUser = (string)Session["user"];

            using (NEMISEntities Db = new NEMISEntities())
            {
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges
                    Db.proc_Upd_InstitutionDetail(mymodel.Institution_Code, mymodel.Institution_Name, mymodel.Institution_Category_Code, mymodel.Institution_Level_Code,
                        mymodel.Institution_Cluster, mymodel.Classification_by_Gender, mymodel.Accommodation_Code, mymodel.Mobile_Institution, mymodel.Formal_Status,
                        mymodel.Institution_Residence, mymodel.Sub_County_Code, mymodel.Constituency_Code, mymodel.Zone_Code, mymodel.Ward_Code,
                        mymodel.Education_System_Code, mymodel.Latitude, mymodel.Longitude, mUser, mymodel.Institution_Current_Code, mymodel.Institution_Type,
                        mymodel.Institution_Status, mymodel.Tsc_Code, mymodel.Knec_Code, mymodel.Institution_Sponsor, mymodel.Registration_Date,
                        mymodel.Employer_pin);
                    ViewBag.Message = "Learner Moved Successfully Saved!!!";

                    //return View("Edit", mymodel);
                    //return  RedirectToAction("Index", "Dashboard");
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
                var minst = mymodel;
                List<SelectListItem> aLevelList = new List<SelectListItem>();
                List<proc_Get_InstLevel_Result> cLevels = Db.proc_Get_InstLevel().ToList();
                cLevels.ForEach(x =>
                {
                    aLevelList.Add(new SelectListItem { Text = x.Level_Name, Value = x.Level_Code.ToString() });
                });
                List<SelectListItem> aTypeList = new List<SelectListItem>();
                aTypeList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var stypes = (from p in Db.INSTITUTION_TYPES
                              select p).ToList();
                stypes.ForEach(x =>
                {
                    aTypeList.Add(new SelectListItem { Text = x.Institution_Type_Name, Value = x.Institution_Type_Name.ToString() });
                });

                List<SelectListItem> aRecsList = new List<SelectListItem>();
                List<SelectListItem> aCountyList = new List<SelectListItem>();
                var ccty = (from p in Db.COUNTies
                            select p).ToList();
                ccty.ForEach(x =>
                {
                    aCountyList.Add(new SelectListItem { Text = x.County_Name, Value = x.County_Code.ToString() });
                });
                List<SelectListItem> aSCountyList = new List<SelectListItem>();
                aSCountyList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var sccty = (from p in Db.SUB_COUNTY
                             where p.County_Code == minst.County_Code
                             select p).ToList();
                sccty.ForEach(x =>
                {
                    aSCountyList.Add(new SelectListItem { Text = x.Sub_County_Name, Value = x.Sub_County_Code.ToString() });
                });
                List<SelectListItem> aZoneList = new List<SelectListItem>();
                aZoneList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var szones = (from p in Db.ZONEs
                              where p.Sub_County_Code == minst.Sub_County_Code
                              select p).ToList();
                szones.ForEach(x =>
                {
                    aZoneList.Add(new SelectListItem { Text = x.Zone_Name, Value = x.Zone_Code.ToString() });
                });
                List<SelectListItem> aConstList = new List<SelectListItem>();
                aConstList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var sconst = (from p in Db.CONSTITUENCies
                              where p.County_Code == minst.County_Code
                              select p).ToList();
                sconst.ForEach(x =>
                {
                    aConstList.Add(new SelectListItem { Text = x.Constituency_Name, Value = x.Constituency_Code.ToString() });
                });

                List<SelectListItem> aWardList = new List<SelectListItem>();
                aWardList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var swards = (from p in Db.WARDS
                              where p.Constituency_Code == minst.Constituency_Code
                              select p).ToList();
                swards.ForEach(x =>
                {
                    aWardList.Add(new SelectListItem { Text = x.Ward_Name, Value = x.Ward_Code.ToString() });
                });

                List<SelectListItem> aRegStatusList = new List<SelectListItem>();
                aRegStatusList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var sregs = (from p in Db.INSTITUTION_STATUS
                             select p).ToList();
                sregs.ForEach(x =>
                {
                    aRegStatusList.Add(new SelectListItem { Text = x.Status_Name, Value = x.Status_Code.ToString() });
                });

                List<SelectListItem> aCategoryList = new List<SelectListItem>();
                aCategoryList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var scate = (from p in Db.INSTITUTION_CATEGORY
                             select p).ToList();
                scate.ForEach(x =>
                {
                    aCategoryList.Add(new SelectListItem { Text = x.Institution_Cat_Name, Value = x.Institution_Cat_Code.ToString() });
                });

                List<SelectListItem> aClusterList = new List<SelectListItem>();
                aClusterList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var scluster = (from p in Db.INSTITUTION_CLUSTERS
                                select p).ToList();
                scluster.ForEach(x =>
                {
                    aClusterList.Add(new SelectListItem { Text = x.Cluster_Name, Value = x.Cluster_Code.ToString() });
                });

                List<SelectListItem> aGenderList = new List<SelectListItem>();
                aGenderList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var sgender = (from p in Db.INSTITUTION_GENDER
                               select p).ToList();
                sgender.ForEach(x =>
                {
                    aGenderList.Add(new SelectListItem { Text = x.School_Gender_Name, Value = x.School_Gender_Code.ToString() });
                });

                List<SelectListItem> aAccommodationList = new List<SelectListItem>();
                aAccommodationList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var saccomm = (from p in Db.INSTITUTION_ACCOMMODATION
                               select p).ToList();
                saccomm.ForEach(x =>
                {
                    aAccommodationList.Add(new SelectListItem { Text = x.Accommodation_Name, Value = x.Accommodation_Code.ToString() });
                });

                List<SelectListItem> aMobileList = new List<SelectListItem>();
                aMobileList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var smobile = (from p in Db.INSTITUTION_MOBILITY
                               select p).ToList();
                smobile.ForEach(x =>
                {
                    aMobileList.Add(new SelectListItem { Text = x.Mobility_Name, Value = x.Mobility_Code.ToString() });
                });

                List<SelectListItem> aFormalityList = new List<SelectListItem>();
                aFormalityList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var sform = (from p in Db.INSTITUTION_FORMALITY
                             select p).ToList();
                sform.ForEach(x =>
                {
                    aFormalityList.Add(new SelectListItem { Text = x.Formality_Name, Value = x.Formality_Code.ToString() });
                });

                List<SelectListItem> aResidenceList = new List<SelectListItem>();
                aResidenceList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var sres = (from p in Db.INSTITUTION_RESIDENCE
                            select p).ToList();
                sres.ForEach(x =>
                {
                    aResidenceList.Add(new SelectListItem { Text = x.Residence, Value = x.Residence_Code.ToString() });
                });

                List<SelectListItem> aEduSysList = new List<SelectListItem>();
                aEduSysList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var sedusys = (from p in Db.INSTITUTION_EDUCATION_SYSTEM
                               select p).ToList();
                sedusys.ForEach(x =>
                {
                    aEduSysList.Add(new SelectListItem { Text = x.Educationa_System_Name, Value = x.Education_System_Code.ToString() });
                });

                List<SelectListItem> aOwnDocList = new List<SelectListItem>();
                aOwnDocList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var sowndocs = (from p in Db.INSTITUTION_OWNERSHIP_DOCUMENT
                                select p).ToList();
                sowndocs.ForEach(x =>
                {
                    aOwnDocList.Add(new SelectListItem { Text = x.Document_Name, Value = x.Document_Code.ToString() });
                });
                List<SelectListItem> aPremOwnList = new List<SelectListItem>();
                aPremOwnList.Add(new SelectListItem { Text = "<<Select>>", Value = "" });
                var spremown = (from p in Db.INSTITUTION_PREMISE_OWNERSHIP
                                select p).ToList();
                spremown.ForEach(x =>
                {
                    aPremOwnList.Add(new SelectListItem { Text = x.Premise_Ownership_Name, Value = x.Premise_Ownership_Code.ToString() });
                });

                mymodel.LevelList = aLevelList;
                mymodel.CountyList = aCountyList;
                mymodel.SCountyList = aSCountyList;
                mymodel.TypeList = aTypeList;

                mymodel.ZoneList = aZoneList;
                mymodel.ConstituencyList = aConstList;
                mymodel.WardList = aWardList;

                mymodel.RegStatusList = aRegStatusList;
                mymodel.CategoryList = aCategoryList;
                mymodel.ClusterList = aClusterList;
                mymodel.GenderList = aGenderList;
                mymodel.AccommodationList = aAccommodationList;
                mymodel.MobileList = aMobileList;
                mymodel.FormalityList = aFormalityList;
                mymodel.ResidenceList = aResidenceList;
                mymodel.EduSysList = aEduSysList;
                mymodel.OwnerDocList = aOwnDocList;
                mymodel.PremOwnList = aPremOwnList;

                return View(mymodel);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult InstOwnership(InstitutionOwnershipViewModel mymodel)
        {
            if (Session["user"] == null)
            {
                this.RedirectToAction("LogOff", "Account");
            }
            var mUser = (string)Session["user"];

            using (NEMISEntities Db = new NEMISEntities())
            {
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges
                    Db.proc_Upd_InstitutionDetail2(mymodel.Institution_Code, mymodel.Premise_Ownership, mymodel.Ownership_Document, mymodel.Proprietor_Code,
                        mymodel.Registration_Certificate, mymodel.Nearest_Police_Station, mymodel.Nearest_Health_Facility, mymodel.Nearest_Town, mUser);
                    return Json(mymodel);
                }
                catch (DbEntityValidationException e)
                {
                    return new EmptyResult();
                }

                return new EmptyResult();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult InstConstacts(InstitutionContactViewModel mymodel)
        {
            if (Session["user"] == null)
            {
                this.RedirectToAction("LogOff", "Account");
            }
            var mUser = (string)Session["user"];
            
            using (NEMISEntities Db = new NEMISEntities())
            {
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges
                    Db.proc_Upd_InstitutionDetail3(mymodel.Institution_Code, mymodel.Postal_Address, mymodel.Tel_Number, mymodel.Tel_Number2, mymodel.Email_Address,
                        mymodel.Mobile_Number1, mymodel.Mobile_Number2, mymodel.Website, mymodel.Social_Media, mUser);

                    return Json(mymodel);
                }
                catch (DbEntityValidationException e)
                {
                    return new EmptyResult();
                }

                return new EmptyResult();
            }
        }

        public JsonResult Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                            //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/") + fileName); //File will be saved in application root
            }
            return Json("Uploaded " + Request.Files.Count + " files");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult UploadFiles(string mcat)
        {
            // Checking no of files injected in Request object  
            int fileSize = 0;
            string fileName = "";
            string mimeType = "";
            string ext = "";
            string fname2;
            string fname = "";
            var minst = Session["Institution_Code"].ToString();
            NEMISEntities Db = new NEMISEntities();

            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        fileSize = file.ContentLength;
                        fileName = file.FileName;
                        mimeType = file.ContentType;

                        //System.IO.Stream fileContent = file.InputStream;
                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname2 = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname2 = file.FileName;
                        }

                        ext = fname2.Split('.')[1].ToString();
                        fname = minst + "" + ext;
                        // Get the complete folder path and store the file inside it.  
                        if (mcat == "1")
                        {
                            Db.proc_Upd_InstitutionRegDocument(minst, fname);
                            fname = Path.Combine(Server.MapPath("~/Documents/Institutions/InstitutionRegDocument/"), fname);
                        }
                        if (mcat == "2")
                        {
                            Db.proc_Upd_InstitutionOwnershipDocument(minst, fname);
                            fname = Path.Combine(Server.MapPath("~/Documents/Institutions/Ownershipdocuments/"), fname);
                        }
                        if (mcat == "3")
                        {
                            Db.proc_Upd_InstitutionIncorporationDocument(minst, fname);
                            fname = Path.Combine(Server.MapPath("~/Documents/Institutions/Incorporationdocument/"), fname);
                        }
                        if (mcat == "4")
                        {
                            Db.proc_Upd_InstitutionRegDocument(minst, fname);
                            fname = Path.Combine(Server.MapPath("~/Documents/Institutions/Capitation/"), fname);
                        }

                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
    }
}