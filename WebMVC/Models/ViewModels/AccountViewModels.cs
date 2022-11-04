using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebMVC.Models
{
    // Models returned by AccountController actions.
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username
        {
            get;
            set;
        }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get;
            set;
        }
    }
    public class RegViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string confirmpassword { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Mobile")]
        public string mobile { get; set; }
        [Required]
        [Display(Name = "Question 1")]
        public Nullable<int> Q1 { get; set; }
        public string Q1Ans { get; set; }
        [Display(Name = "Question 2")]
        public Nullable<int> Q2 { get; set; }
        public string Q2Ans { get; set; }
        public Nullable<int> LoginAttempts { get; set; }
        //Used to Create User in Users Table
        [Display(Name = "Organization")]
        public string Institution_Code { get; set; }
        public string DepCode { get; set; }
        public string Category { get; set; }
        public string County { get; set; }
        public string SubCounty { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Other_Name { get; set; }
        public string Role_ID { get; set; }
        public Nullable<System.DateTime> Date_Created { get; set; }
        public string Created_By { get; set; }
        public string Creator_Title { get; set; }
        [Display(Name = "ID Number")]
        public string IDNO { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Job Title/Designation")]
        public string JobTitle { get; set; }
        [Display(Name = "Your Responsibilities(Brief)")]
        public string Responsibilities { get; set; }

        public IList<SelectListItem> OrgList { get; set; }
        public IList<SelectListItem> DepList { get; set; }
        public IList<SelectListItem> QtnList { get; set; }
        public IList<SelectListItem> GenderList { get; set; }
        public IList<SelectListItem> CategoryList { get; set; }
        public IList<SelectListItem> CountyList { get; set; }
        public IList<SelectListItem> SubCountyList { get; set; }
    }
    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        public string Email { get; set; }
    }
    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
