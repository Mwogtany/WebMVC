using WebMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.ViewModels;
//-----------------------------------------------------------------------    
// <copyright file="AccountController.cs" company="pluscodesafrica.org">  
//   Copyright (c) Allow to distribute this code.    
// </copyright>  
// <author>Barnabas K. Sang</author>  
//-----------------------------------------------------------------------  
namespace WebMVC.Controllers
{
    /// <summary>  
    /// Account controller class.    
    /// </summary> 
    [RoutePrefix("Account")]
    public class AccountController : Controller
    {
        NEMISEntities Db = new NEMISEntities();
        #region Default Constructor    
        /// <summary>  
        /// Initializes a new instance of the <see cref="AccountController" /> class.    
        /// </summary>  
        public AccountController()
        {
        }
        #endregion
        #region Login methods    
        /// <summary>  
        /// GET: /Account/Login    
        /// </summary>  
        /// <param name="returnUrl">Return URL parameter</param>  
        /// <returns>Return login view</returns>  
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                // Verification.    
                if (this.Request.IsAuthenticated)
                {
                    // Info.    
                    return this.RedirectToLocal(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                Console.Write(ex);
            }
            // Info.    
            return this.View();
        }
        /// <summary>  
        /// POST: /Account/Login    
        /// </summary>  
        /// <param name="model">Model parameter</param>  
        /// <param name="returnUrl">Return URL parameter</param>  
        /// <returns>Return login view</returns>  
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View();
            
            var mpass = encryptpass(model.Password);
            var varuser = (from p in Db.Users
                           where p.Username == model.Username && (p.Password == model.Password || p.NewPass == mpass)
                           select p).FirstOrDefault();
            Db.LOGINLOGs.Add(new LOGINLOG()
            {
                UserName = model.Username,
                Dscription = "Category: User Login to NEMIS",
                DateLogged = DateTime.Now
            });
            Db.SaveChanges();

            if (varuser != null)
            {
                // Initialization.    
                var logindetails = varuser;
                // Login In.
                Session["surname"] = logindetails.Surname;
                Session["user"] = logindetails.Username;
                Session["userid"] = logindetails.userid;
                var muser = logindetails.Username;
                this.SignInUser(muser, false);
                // Info.    
                /*
                 * Retrieve Menus
                 */
                var RsMMenu = (from x in Db.proc_GetMainMenu(muser)
                               select new MainMenuViewModel()
                               {
                                   HrefPath = x.HrefPath,
                                   LinkTitle = x.LinkTitle,
                                   ssmenkey = x.ssmenkey,
                                   MenuType = x.MenuType
                               }).ToList();
                if (RsMMenu != null)
                {
                    var i = 0;
                    List<SubMenuViewModel> msubmenu;

                    Session["RsMMenu"] = RsMMenu;
                    Session["MMenuNo"] = RsMMenu.Count();
                    foreach (var item in RsMMenu)
                    {
                        msubmenu = (from x in Db.proc_GetSubMenu(muser, item.ssmenkey, "12/12/2022")
                                    select new SubMenuViewModel()
                                    {
                                        HrefPath = x.HrefPath,
                                        LinkTitle = x.LinkTitle,
                                        Controller = x.Controller,
                                        Action = x.Action
                                    }).ToList();

                        switch (i)
                        {
                            case 1:
                                Session["RsSMenu1"] = msubmenu;
                                break;
                            case 2:
                                Session["RsSMenu2"] = msubmenu;
                                break;
                            case 3:
                                Session["RsSMenu3"] = msubmenu;
                                break;
                            case 4:
                                Session["RsSMenu4"] = msubmenu;
                                break;
                            case 5:
                                Session["RsSMenu5"] = msubmenu;
                                break;
                            case 6:
                                Session["RsSMenu6"] = msubmenu;
                                break;
                            case 7:
                                Session["RsSMenu7"] = msubmenu;
                                break;
                            case 8:
                                Session["RsSMenu8"] = msubmenu;
                                break;
                            case 9:
                                Session["RsSMenu9"] = msubmenu;
                                break;
                            case 10:
                                Session["RsSMenu10"] = msubmenu;
                                break;
                            case 11:
                                Session["RsSMenu11"] = msubmenu;
                                break;
                            case 12:
                                Session["RsSMenu12"] = msubmenu;
                                break;
                            default:
                                Session["RsSMenu0"] = msubmenu;
                                break;
                        }
                        i++;
                    }
                }
                //return this.RedirectToLocal(returnUrl);
                var myuserdata = (from x in Db.proc_GetUser3(muser)
                                  select x).SingleOrDefault();
                Session["mUsername"] = muser;
                Session["Institution_Code"] = myuserdata.Institution_Code;
                Session["UPI"] = myuserdata.Institution_Code;
                Session["KNEC"] = myuserdata.KNECODE;
                Session["Login_Name"] = myuserdata.Surname;
                Session["Institution_Name"] = myuserdata.Surname;
                Session["INSTNAME"] = myuserdata.Surname;
                Session["mUserCat"] = myuserdata.RightsLevel;
                Session["mInstCat"] = myuserdata.Category;
                Session["mUserLevel"] = myuserdata.RightsLevel;
                Session["LEVELCODE"] = myuserdata.LevelCode;
                Session["mAdmin"] = myuserdata.RightsLevel == "1" ? true : false;
                Session["mAdmin2"] = myuserdata.RightsLevel == "2" ? true : false;
                Session["mAdmin"] = myuserdata.RightsLevel == "0" ? true : false;
                Session["mSchType"] = "GoK";
                Session["Institution_Level"] = myuserdata.Level_Name;
                Session["Institution_Type"] = myuserdata.Institution_Type;
                Session["InstGender"] = myuserdata.School_Gender_Name;
                Session["mBanks"] = myuserdata.BankAccs;
                Session["mSchType"] = myuserdata.Institution_Type;
                Session["mSchCategory"] = myuserdata.Institution_Cluster;
                Session["mRegCompletion"] = myuserdata.CompletedNessRegions;
                Session["SchoolHasProjects"] = false;

                if (logindetails.Institution_Code == logindetails.Username)  //School Login
                {

                    Session["HomeController"] = "School";
                    if (returnUrl != null)
                    {
                        return this.RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        return RedirectToActionPermanent("Index", "School");
                    }
                }
                else   //Admin or MOE Staff
                {
                    Session["mSchoolAccess"] = false;
                    Session["mSchool"] = "0";
                    Session["HomeController"] = "Admin";
                    if (returnUrl != null)
                    {
                        return this.RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        return RedirectToActionPermanent("Index", "Admin");
                    }
                }
            }
            else
            {
                // Setting.    
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }
            
            return this.View(model);
        }
        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
        public string Decrypt(string clearText)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        #endregion

        #region Register method.    
        /// <summary>  
        /// Get: /Account/Register    
        /// </summary>  
        /// <returns>Return Register action for new Users</returns> 
        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            NEMISEntities Db = new NEMISEntities();
            RegViewModel ViewModel = new RegViewModel();
            List<SelectListItem> QtnList = new List<SelectListItem>();
            List<SelectListItem> OrgList = new List<SelectListItem>();
            List<SelectListItem> CatList = new List<SelectListItem>();
            List<SelectListItem> GenList = new List<SelectListItem>();

            List<STATIC_REGISTER_QUESTION> myQtns = Db.STATIC_REGISTER_QUESTION.ToList();
            myQtns.ForEach(x =>
            {
                QtnList.Add(new SelectListItem { Text = x.Description, Value = x.id.ToString() });
            });
            ViewModel.QtnList = QtnList;
            List<Organization> myOrgs = Db.Organizations.ToList();
            myOrgs.ForEach(x =>
            {
                OrgList.Add(new SelectListItem { Text = x.OrgName, Value = x.OrgID.ToString() });
            });
            ViewModel.OrgList = OrgList;
            List<CategoryViewModel> cateList = Db.proc_Get_Categories().Select(s => new CategoryViewModel()
            {
                CatID = s.CatID,
                CatDescription = s.CatDesc
            }).ToList();
            cateList.ForEach(x =>
            {
                CatList.Add(new SelectListItem { Text = x.CatDescription, Value = x.CatID });
            });
            ViewModel.CategoryList = CatList;
            GenList.Add(new SelectListItem { Text = "Female", Value = "F" });
            GenList.Add(new SelectListItem { Text = "Male", Value = "M" });
            ViewModel.GenderList = GenList;

            return this.View(ViewModel);
        }
           
            /// <summary>  
            /// POST: /Account/Register    
            /// </summary>  
            /// <returns>Return Register action, allow saving of changes or new user information</returns>  
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegViewModel model)
        {
            try
            {
                // Verification.    
                if (ModelState.IsValid)
                {
                    NEMISEntities Db = new NEMISEntities();
                    // Initialization.    
                    var newpass = encryptpass(model.password.ToString());
                    // Verification.    
                    Db.Logins.Add(new Login()
                    {
                        username = model.username,
                        password = newpass,
                        email = model.email,
                        mobile = model.mobile,
                        Q1 = model.Q1,
                        Q1Ans = model.Q1Ans,
                        Q2 = model.Q2,
                        Q2Ans = model.Q2Ans,

                    });
                    var mregion = "9999";
                    if (model.Category == "1") { mregion = "0"; }
                    if (model.Category == "2") { mregion = model.County; }
                    if (model.Category == "3") { mregion = model.County; }
                    if (model.Category == "4") { mregion = model.SubCounty; }
                    Db.REGIONUSERs.Add(new REGIONUSER()
                    {
                        UserName = model.username,
                        Category = model.Category,
                        RegionCode = mregion
                    });

                    Db.Users.Add(new User()
                    {
                        Username = model.username,
                        Institution_Code = model.DepCode,
                        Surname = model.Surname,
                        Other_Name = model.Other_Name,
                        Gender = model.Gender,
                        IDNO = model.IDNO,
                        JobTitle = model.JobTitle,
                        Responsibilities = model.Responsibilities,
                        Phone_Number = model.Phone_Number,
                        Email = model.Email,
                        Password = model.password,
                        NewPass = newpass
                    });

                    Db.SaveChanges();

                    //this.SignInUser(model.username, false);
                    // Info.    
                    return this.RedirectToAction("Login", "Account");

                }
            }
            catch (Exception ex)
            {
                // Info    
                Console.Write(ex);
            }
            // If we got this far, something failed, redisplay form    
            return this.View(model);
        }
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            ForgotPasswordViewModel ViewModel = new ForgotPasswordViewModel();
            
            return this.View(ViewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel mymodel)
        {
            //Validate Email and Send an Email for Reset on this platform

            var ViewModel = mymodel;
            return this.View(ViewModel);
        }
        #endregion

        #region Log Out method.    
        /// <summary>  
        /// POST: /Account/LogOff    
        /// </summary>  
        /// <returns>Return log off action</returns>  
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            try
            {
                // Setting.    
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign Out.    
                authenticationManager.SignOut();
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            // Info.    
            return this.RedirectToAction("Login", "Account");
        }
        #endregion
        #region Helpers    
        #region Sign In method.    
        /// <summary>  
        /// Sign In User method.    
        /// </summary>  
        /// <param name="username">Username parameter.</param>  
        /// <param name="isPersistent">Is persistent parameter.</param>  
        private void SignInUser(string username, bool isPersistent)
        {
            // Initialization.    
            var claims = new List<Claim>();
            try
            {
                // Setting    
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign In.    
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
        }
        #endregion
        
        public string Encryptor(string strText, string EncrKey)
        {
            byte[] byKey = { };
            byte[] IV =
              {
                18,52,86,120,144,171,205,239
            };
            byKey = System.Text.Encoding.UTF8.GetBytes(EncrKey);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = System.Text.Encoding.UTF8.GetBytes(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        
        public string DecryptFromBase64String(string stringToDecrypt, string EncryptionKey)
        {
            byte[] inputByteArray = new byte[stringToDecrypt.Length];
            byte[] byKey = { };
            byte[] IV =
            {
                18,52,86,120,144,171,205,239
            };
            byKey = System.Text.Encoding.UTF8.GetBytes(EncryptionKey);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(stringToDecrypt);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        #region Redirect to local method.    
        /// <summary>  
        /// Redirect to local method.    
        /// </summary>  
        /// <param name="returnUrl">Return URL parameter.</param>  
        /// <returns>Return redirection action</returns>  
        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                // Verification.    
                if (Url.IsLocalUrl(returnUrl))
                {
                    // Info.    
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            // Info.    
            return this.RedirectToAction("Index", "Home");
        }
        #endregion
        #endregion
    }
}