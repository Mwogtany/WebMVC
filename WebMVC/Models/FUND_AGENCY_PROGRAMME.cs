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
    
    public partial class FUND_AGENCY_PROGRAMME
    {
        public string AgencyID { get; set; }
        public string ProgrammeID { get; set; }
        public string ProgrammeName { get; set; }
        public Nullable<System.DateTime> ProgrammeDate { get; set; }
        public Nullable<decimal> ProgrammeAmount { get; set; }
        public string TargetLevel { get; set; }
        public string PaymentMode { get; set; }
    }
}
