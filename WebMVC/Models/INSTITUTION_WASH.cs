//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class INSTITUTION_WASH
    {
        public string UIC { get; set; }
        public Nullable<bool> PipedWater { get; set; }
        public Nullable<bool> ProtectedSpring { get; set; }
        public Nullable<bool> UnprotectedSpring { get; set; }
        public Nullable<bool> Rainwater { get; set; }
        public Nullable<bool> BottledWaterd { get; set; }
        public Nullable<bool> Tanker_cart { get; set; }
        public Nullable<bool> Lake_river_stream { get; set; }
        public Nullable<bool> Nowatersource { get; set; }
        public string Mainsource { get; set; }
        public Nullable<bool> AvailabilityMainSourceLast2Weeks { get; set; }
        public string AvailabilityMainSourceDrinkingWater { get; set; }
        public Nullable<bool> AccessibilityDrinkingWater { get; set; }
        public Nullable<bool> AccessibilityDrinkingWaterSmallerChildren { get; set; }
        public Nullable<int> DrinkingWaterPoints { get; set; }
        public Nullable<bool> QualityWorkonMainSource { get; set; }
        public Nullable<bool> Filtration { get; set; }
        public Nullable<bool> Boiling { get; set; }
        public Nullable<bool> Chlorination { get; set; }
        public Nullable<bool> SODIS { get; set; }
        public Nullable<bool> Ultraviolet { get; set; }
        public Nullable<bool> Other { get; set; }
        public string Otherdesc { get; set; }
        public string Contaminant_EColi_Tested { get; set; }
        public string Contaminant_EColi_Compliant { get; set; }
        public string Contaminant_Arsenic_Tested { get; set; }
        public string Contaminant_Arsenic_Compliant { get; set; }
        public string Contaminant_Lead_Tested { get; set; }
        public string Contaminant_Lead_Compliant { get; set; }
        public string Contaminant_Other_Tested { get; set; }
        public string Contaminant_Other_Compliant { get; set; }
        public string Contaminant_Other_Description { get; set; }
        public string Contaminant_Unknown_Tested { get; set; }
        public string Contaminant_Unknown_Compliant { get; set; }
        public Nullable<int> ToiletBoys { get; set; }
        public Nullable<int> ToiletGirls { get; set; }
        public Nullable<int> ToiletCommon { get; set; }
        public Nullable<int> ToiletBoysUsable { get; set; }
        public Nullable<int> ToiletGirlsUsable { get; set; }
        public Nullable<int> ToiletCommonUsable { get; set; }
        public string SoapAndWaterForGirls { get; set; }
        public Nullable<bool> BinsForDisposalofMenstrual { get; set; }
        public Nullable<bool> DisposalMechanismofMenstrual { get; set; }
        public string FrequencyStudentToiletsClean { get; set; }
        public string GeneralCleannessToilets { get; set; }
        public Nullable<bool> AtleastOneUsableToiletForKids { get; set; }
        public Nullable<bool> AtleastOneUsableToiletForDisable { get; set; }
        public string LocationOfStudentToilets { get; set; }
        public string AvailabilityUseOfToilet { get; set; }
        public Nullable<bool> QualityAppropriateCleansingMaterial { get; set; }
        public string FunctionalLightinginToilet { get; set; }
        public Nullable<bool> LatrinesEmptied { get; set; }
        public string HandwashingFacilities { get; set; }
        public Nullable<bool> HandwashingFacilitiesForDisable { get; set; }
        public Nullable<bool> HandwashingFacilitiesForKids { get; set; }
        public string LocationOfToiletsInSchool { get; set; }
        public string LocationOtherDesc { get; set; }
        public Nullable<int> HowManyHandwashingFacilities { get; set; }
        public string FrequencyForGroupHandwashing { get; set; }
        public string MenstrualHMatSchool { get; set; }
        public string SolidWasteDisposal { get; set; }
        public Nullable<int> HowManyHandwashingFacilitiesWithWater { get; set; }
    }
}
