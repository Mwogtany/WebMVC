using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Models
{
    public class InstitutionViewModel
    {

        [Display(Name = "UIC")]
        [Editable(false)]
        public string Institution_Code { get; set; }
        [Display(Name = "Registration Number")]
        public string Institution_Current_Code { get; set; }
        [Display(Name = "Institution Name")]
        [Editable(false)]
        public string Institution_Name { get; set; }
        [Display(Name = "Registration Status")]
        [Editable(false)]
        public string Institution_Status { get; set; }
        public string Status_Name { get; set; }
        [Display(Name = "Type")]
        [Editable(false)]
        public string Institution_Type { get; set; }
        public string Institution_Cat_Name { get; set; }
        [Display(Name = "Category")]
        public string Institution_Category_Code { get; set; }
        [Display(Name = "Level")]
        [Editable(false)]
        public string Institution_Level_Code { get; set; }
        [Display(Name = "Level Name")]
        public string Level_Name { get; set; }
        [Display(Name = "Cluster")]
        public string Institution_Cluster { get; set; }
        public string Cluster_Name { get; set; }
        public string School_Gender_Name { get; set; }
        [Display(Name = "Institution Gender Type")]
        public string Classification_by_Gender { get; set; }
        [Display(Name = "Institution Accomodation")]
        public string Accommodation_Code { get; set; }
        [Display(Name = "Accommodation Type")]
        public string Accommodation_Name { get; set; }
        [Display(Name = "Institution Mobility")]
        public string Mobile_Institution { get; set; }
        public string Mobility_Name { get; set; }
        [Display(Name = "Formality-Use")]
        public string Formal_Status { get; set; }
        public string Formality_Name { get; set; }
        [Display(Name = "Residence")]
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
        [Display(Name = "Alternative Telephone")]
        public string Tel_Number2 { get; set; }
        public string Email_Address { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile_Number1 { get; set; }
        [Display(Name = "Alternative Mobile")]
        public string Mobile_Number2 { get; set; }
        public string Website { get; set; }
        [Display(Name = "Ownership Document Type")]
        public string Ownership_Document { get; set; }
        public string Document_Name { get; set; }
        [Display(Name = "Ownership")]
        public string Premise_Ownership { get; set; }
        [Display(Name = "Social Media")]
        public string Social_Media { get; set; }
        public string Educationa_System_Name { get; set; }
        [Display(Name = "Education System")]
        public string Education_System_Code { get; set; }
        [Display(Name = "Registration Date")]
        public string Registration_Date { get; set; }
        [Display(Name = "Proprietor Name(Applies only private)")]
        public string Proprietor_Code { get; set; }
        public string Proprietor_Name { get; set; }
        [Display(Name = "Nearest Police Station")]
        public string Nearest_Police_Station { get; set; }
        [Display(Name = "Incorporation Certificate No")]
        public string Registration_Certificate { get; set; }
        [Display(Name = "Nearest Health Facility")]
        public string Nearest_Health_Facility { get; set; }
        [Display(Name = "Nearest Town")]
        public string Nearest_Town { get; set; }
        public string Captured_By { get; set; }
        public Nullable<System.DateTime> Date_Captured { get; set; }
        [Display(Name = "Institution KRA PIN")]
        public string Employer_pin { get; set; }
        [Display(Name = "Ownership Document")]
        public string Ownershipdocuments { get; set; }
        [Display(Name = "Incorporation document")]
        public string Incorporationdocument { get; set; }
        [Display(Name = "Institution Certificate")]
        public string InstitutionRegDocument { get; set; }
        [Display(Name = "TSC Code")]
        public string Tsc_Code { get; set; }
        [Display(Name = "KNEC Code")]
        public string Knec_Code { get; set; }
        public string Sponsor_Name { get; set; }
        public string Institution_Sponsor { get; set; }
        [Display(Name = "County")]
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
        public string PlusCode { get; set; }
        public string Address { get; set; }

        public IList<SelectListItem> LevelList { get; set; }
        public IList<SelectListItem> TypeList { get; set; }
        public IList<SelectListItem> RegStatusList { get; set; }
        public IList<SelectListItem> CategoryList { get; set; }
        public IList<SelectListItem> ClusterList { get; set; }
        public IList<SelectListItem> GenderList { get; set; }
        public IList<SelectListItem> AccommodationList { get; set; }
        public IList<SelectListItem> MobileList { get; set; }
        public IList<SelectListItem> FormalityList { get; set; }
        public IList<SelectListItem> ResidenceList { get; set; }
        public IList<SelectListItem> EduSysList { get; set; }
        public IList<SelectListItem> CountyList { get; set; }
        public IList<SelectListItem> SCountyList { get; set; }
        public IList<SelectListItem> ZoneList { get; set; }
        public IList<SelectListItem> ConstituencyList { get; set; }
        public IList<SelectListItem> WardList { get; set; }
        public IList<SelectListItem> PremOwnList { get; set; }
        public IList<SelectListItem> OwnerDocList { get; set; }
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
    public class InstitutionContactViewModel
    {

        [Display(Name = "UIC")]
        [Editable(false)]
        public string Institution_Code { get; set; }
        public string Postal_Address { get; set; }
        [Display(Name = "Telephone")]
        public string Tel_Number { get; set; }
        [Display(Name = "Alternative Telephone")]
        public string Tel_Number2 { get; set; }
        public string Email_Address { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile_Number1 { get; set; }
        [Display(Name = "Alternative Mobile")]
        public string Mobile_Number2 { get; set; }
        public string Website { get; set; }
        [Display(Name = "Social Media")]
        public string Social_Media { get; set; }
    }
    public class InstitutionOwnershipViewModel
    {

        [Display(Name = "UIC")]
        [Editable(false)]
        public string Institution_Code { get; set; }
        public string Ownership_Document { get; set; }
        [Display(Name = "Ownership")]
        public string Premise_Ownership { get; set; }
        [Display(Name = "Proprietor Name(Applies only private)")]
        public string Proprietor_Code { get; set; }
        public string Proprietor_Name { get; set; }
        [Display(Name = "Nearest Police Station")]
        public string Nearest_Police_Station { get; set; }
        [Display(Name = "Incorporation Certificate No")]
        public string Registration_Certificate { get; set; }
        [Display(Name = "Nearest Health Facility")]
        public string Nearest_Health_Facility { get; set; }
        [Display(Name = "Nearest Town")]
        public string Nearest_Town { get; set; }
    }
}