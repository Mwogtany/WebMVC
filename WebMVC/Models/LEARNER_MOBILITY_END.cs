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
    
    public partial class LEARNER_MOBILITY_END
    {
        public int Trans_ID { get; set; }
        public string UPI { get; set; }
        public Nullable<System.DateTime> Effective_Date { get; set; }
        public string Mobility_Type_Code { get; set; }
        public string Claiming_Institution_Code { get; set; }
        public string Discharging_Institution_Code { get; set; }
        public string Reasons { get; set; }
        public string Captured_By { get; set; }
        public Nullable<System.DateTime> Date_Captured { get; set; }
        public string Dis_Mobility_Type_Code { get; set; }
        public string Dis_Reasons { get; set; }
        public Nullable<System.DateTime> Dis_Effective_Date { get; set; }
        public string EffectedBy { get; set; }
        public Nullable<System.DateTime> EffectedDate { get; set; }
    }
}
