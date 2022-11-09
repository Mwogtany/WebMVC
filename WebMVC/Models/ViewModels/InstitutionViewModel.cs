using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Models
{
    public class InstitutionViewModel
    {

        [Display(Name = "UIC")]
        public string Institution_Code { get; set; }
        public string Institution_Current_Code { get; set; }
        [Display(Name = "Institution Name")]
        public string Institution_Name { get; set; }
        public string Institution_Status { get; set; }
        public string Status_Name { get; set; }
        [Display(Name = "Type")]
        public string Institution_Type { get; set; }
        public string Institution_Cat_Name { get; set; }
        public string Institution_Category_Code { get; set; }
        public string Institution_Level_Code { get; set; }
        [Display(Name = "Level")]
        public string Level_Name { get; set; }
        public string Institution_Cluster { get; set; }
        public string Cluster_Name { get; set; }
        public string School_Gender_Name { get; set; }
        public string Classification_by_Gender { get; set; }
        public string Accommodation_Code { get; set; }
        [Display(Name = "Accommodation Type")]
        public string Accommodation_Name { get; set; }
        public string Mobile_Institution { get; set; }
        public string Mobility_Name { get; set; }
        public string Formal_Status { get; set; }
        public string Formality_Name { get; set; }
        public string Institution_Residence { get; set; }
        public string Residence { get; set; }
        [Display(Name = "Sub-County")]
        public string Sub_County_Code { get; set; }
        public string Sub_County_Name { get; set; }
        [Display(Name = "Constituency")]
        public string Constituency_Code { get; set; }
        public string Constituency_Name { get; set; }
        [Display(Name = "Zone")]
        public string Zone_Code { get; set; }
        public string Zone_Name { get; set; }
        public string Ward_Name { get; set; }
        [Display(Name = "Ward")]
        public string Ward_Code { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [Display(Name = "Address")]
        public string Postal_Address { get; set; }
        [Display(Name = "Telephone")]
        public string Tel_Number { get; set; }
        public string Tel_Number2 { get; set; }
        public string Email_Address { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile_Number1 { get; set; }
        public string Mobile_Number2 { get; set; }
        public string Website { get; set; }
        public string Ownership_Document { get; set; }
        public string Document_Name { get; set; }
        public string Premise_Ownership { get; set; }
        public string Social_Media { get; set; }
        public string Educationa_System_Name { get; set; }
        public string Education_System_Code { get; set; }
        public string Registration_Date { get; set; }
        public string Proprietor_Code { get; set; }
        public string Proprietor_Name { get; set; }
        public string Nearest_Police_Station { get; set; }
        public string Registration_Certificate { get; set; }
        public string Nearest_Health_Facility { get; set; }
        public string Nearest_Town { get; set; }
        public string Captured_By { get; set; }
        public Nullable<System.DateTime> Date_Captured { get; set; }
        public string Employer_pin { get; set; }
        public string Ownershipdocuments { get; set; }
        public string Incorporationdocument { get; set; }
        public string InstitutionRegDocument { get; set; }
        public string Tsc_Code { get; set; }
        public string Knec_Code { get; set; }
        public string Sponsor_Name { get; set; }
        public string Institution_Sponsor { get; set; }
        public string County_Code { get; set; }
        public string County_Name { get; set; }
        [Display(Name = "Learners (BC)")]
        public int BC_Total { get; set; }
        [Display(Name = "Learners (WBC)")]
        public int WBC_Total { get; set; }
        public Nullable<int> Learners { get; set; }
        [Display(Name = "TSC")]
        public int TSC_Total { get; set; }
        [Display(Name = "BOM/Private")]
        public int BOM_Total { get; set; }
        public Nullable<int> Staff { get; set; }
        public string EffectiveName { get; set; }
        public string StudSel { get; set; }
        public string StudAdm { get; set; }
        public Nullable<int> BankAccs { get; set; }
        public Nullable<bool> fse { get; set; }
        public string FSEStatus { get; set; }
        public string CovidStatus { get; set; }
        public string DHIS { get; set; }
        public string HeadsName { get; set; }
    }
    public class InstitutionsViewModel
    {
        public IList<SelectListItem> CountyList { get; set; }
        public IList<SelectListItem> SubCountyList { get; set; }
        public IList<SelectListItem> LevelList { get; set; }
        public IList<SelectListItem> TypeList { get; set; }
        public IList<SelectListItem> PageRecordsList { get; set; }
        public IEnumerable<InstitutionViewModel> Institutions { get; set; }
    }
}