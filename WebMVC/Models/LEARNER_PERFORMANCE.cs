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
    
    public partial class LEARNER_PERFORMANCE
    {
        public int Transaction_ID { get; set; }
        public string UPI { get; set; }
        public string Agency_Code { get; set; }
        public string Programme_Code { get; set; }
        public string Course_Code { get; set; }
        public string Institution_Code { get; set; }
        public string Learner_Level_Id { get; set; }
        public string Academic_Year { get; set; }
        public string Semester { get; set; }
        public Nullable<decimal> Score { get; set; }
        public string Grade { get; set; }
        public string Certificate_No { get; set; }
        public string Mean_Grade { get; set; }
        public string Captured_By { get; set; }
        public Nullable<System.DateTime> Date_Captured { get; set; }
        public string NumberofDaysAbsent { get; set; }
    }
}
