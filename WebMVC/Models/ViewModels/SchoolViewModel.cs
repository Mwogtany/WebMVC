using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Models
{
    public class LearnerViewModel
    {
        [Required]
        [Display(Name = "Learner UPI")]
        public string UPI { get; set; }
        public string Surname { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Other Name")]
        public string OtherNames { get; set; }
        [Display(Name = "Learner Name")]
        public string Names { get; set; }
        public string Institution_Name { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone_Number { get; set; }
        [Display(Name = "Email Address")]
        public string Email_Address { get; set; }
        [Display(Name = "Postal Address")]
        public string Postal_Address { get; set; }
        public string Father_UPI { get; set; }
        public string Mother_UPI { get; set; }
        public string Guardian_UPI { get; set; }
        [Display(Name = "Father Name")]
        public string Father_Name { get; set; }
        [Display(Name = "Father ID No")]
        public string Father_IDNo { get; set; }
        [Display(Name = "Father Mobile")]
        public string Father_Contacts { get; set; }
        [Display(Name = "Mother Name")]
        public string Mother_Name { get; set; }
        [Display(Name = "Mother ID No")]
        public string Mother_IDNo { get; set; }
        [Display(Name = "Mother Mobile")]
        public string Mother_Contacts { get; set; }
        [Display(Name = "Guardian Mobile")]
        public string Guardian_Contacts { get; set; }
        [Display(Name = "Guardian ID No")]
        public string Guardian_IDNo { get; set; }
        [Display(Name = "Guardian Name")]
        public string Guardian_Name { get; set; }
        [Display(Name = "Special Medication Condition")]
        public string Special_Medical_Condition { get; set; }
        [Display(Name = "Medical Condition")]
        public string Medical_Name { get; set; }
        public string Any_Special_Medical_Condition { get; set; }
        public string Institution_Code { get; set; }
        [Display(Name = "County")]
        public string County_Code { get; set; }
        [Display(Name = "County Name")]
        public string County_Name { get; set; }
        [Display(Name = "Sub-County")]
        public string Sub_County_Code { get; set; }
        [Display(Name = "Sub-County Name")]
        public string Sub_County_Name { get; set; }
        [Display(Name = "Gender")]
        public string LGender { get; set; }
        public string Disability_Name { get; set; }
        [Display(Name = "Disability Type")]
        public string Disability_Name2 { get; set; }
        public string Class_Name { get; set; }
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DOB2 { get; set; }
        public string DOB { get; set; }
        public string Nationality { get; set; }
        [Display(Name = "Country Name")]
        public string Country_Name { get; set; }
        public Nullable<int> IsDateDOB { get; set; }
        [Display(Name = "Birth Cert No")]
        public string Birth_Cert_No { get; set; }
        public string ID_No { get; set; }
        [Display(Name = "Disability")]
        public string Disability_Code { get; set; }
        [Display(Name = "Grade")]
        public string Class_Code { get; set; }
        [Display(Name = "Home County Name")]
        public string County_Learner { get; set; }
        [Display(Name = "Home Sub-County Name")]
        public string Sub_County_Learner { get; set; }
        public string Special_Needs_List { get; set; }
        [Display(Name = "Father E-mail")]
        public string Father_Email { get; set; }
        [Display(Name = "Mother E-mail")]
        public string Mother_Email { get; set; }
        [Display(Name = "Guardian E-mail")]
        public string Guardian_Email { get; set; }
        [Display(Name = "Age")]
        public Nullable<int> AGE { get; set; }
        [Display(Name = "NHIF No")]
        public string NHIF_No { get; set; }

    }
    public class ListLearnerViewModel
    {
        public IList<SelectListItem> CategoryList { get; set; }
        public IList<SelectListItem> GradeList { get; set; }
        public IList<SelectListItem> PageRecordsList { get; set; }

        public IEnumerable<LearnerViewModel> LearnerViewModelList { get; set; }
    }

    public class MoveLearnerViewModel
    {
        public string UPI { get; set; }
        public string Category { get; set; }
        [Display(Name = "Current Grade")]
        public string OriginalGrade { get; set; }
        [Display(Name = "New Grade to Move")]
        public string NewGrade { get; set; }
        public Nullable<System.DateTime> DateEffected { get; set; }

        public IList<SelectListItem> NewGradeList { get; set; }

        public LearnerViewModel ALearnerViewModel { get; set; }
    }
}