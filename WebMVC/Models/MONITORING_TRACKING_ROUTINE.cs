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
    
    public partial class MONITORING_TRACKING_ROUTINE
    {
        public int PeriodID { get; set; }
        public string UIC { get; set; }
        public Nullable<System.DateTime> ReportedOn { get; set; }
        public string ReportedBy { get; set; }
        public string AdvType { get; set; }
        public Nullable<int> AdvNoBenefitiariesOrd_M { get; set; }
        public Nullable<int> AdvNoBenefitiariesOrd_F { get; set; }
        public Nullable<int> AdvNoBenefitiariesSNE_M { get; set; }
        public Nullable<int> AdvNoBenefitiariesSNE_F { get; set; }
        public Nullable<int> AdvIECPosters { get; set; }
        public Nullable<int> AdvIECReflectorJackets { get; set; }
        public Nullable<int> AdvIECLeaflets { get; set; }
        public Nullable<int> AdvIECOther { get; set; }
        public Nullable<int> MentorNoBenefitiariesORD_M { get; set; }
        public Nullable<int> MentorNoBenefitiariesORD_F { get; set; }
        public Nullable<int> MentorNoBenefitiariesSNE_M { get; set; }
        public Nullable<int> MentorNoBenefitiariesSNE_F { get; set; }
        public string MentorshipStrategy { get; set; }
        public Nullable<bool> GBVIncidence { get; set; }
        public Nullable<int> GBV_CasesORD_M { get; set; }
        public Nullable<int> GBV_CasesORD_F { get; set; }
        public Nullable<int> GBV_CasesSNE_M { get; set; }
        public Nullable<int> GBV_CasesSNE_F { get; set; }
        public string GBV_Type { get; set; }
        public Nullable<bool> GenderChampion { get; set; }
        public string GenderChampion_Gender { get; set; }
        public Nullable<int> GenderORD_M { get; set; }
        public Nullable<int> GenderORD_F { get; set; }
        public Nullable<int> GenderSNE_M { get; set; }
        public Nullable<int> GenderSNE_F { get; set; }
        public Nullable<int> GenderTr_M { get; set; }
        public Nullable<int> GenderTr_F { get; set; }
        public Nullable<int> GenderCom_M { get; set; }
        public Nullable<int> GenderCom_F { get; set; }
        public string GenderSensitization { get; set; }
        public Nullable<bool> SocialPads { get; set; }
    }
}
