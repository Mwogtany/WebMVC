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
    
    public partial class DEVELOPMENT_FUND
    {
        public string Unique_Project_Code { get; set; }
        public string Project_Code { get; set; }
        public string Institution_Code { get; set; }
        public string Financial_Year { get; set; }
        public string Academic_Year { get; set; }
        public string Project_Name { get; set; }
        public string Project_description { get; set; }
        public Nullable<decimal> Project_cost { get; set; }
        public string Source_Code { get; set; }
        public Nullable<decimal> Amount_allocated { get; set; }
        public Nullable<decimal> Amount_Disbursed { get; set; }
        public Nullable<System.DateTime> State_date { get; set; }
        public Nullable<System.DateTime> Expected_complet_date { get; set; }
        public string Project_status { get; set; }
        public string Key_Milestones { get; set; }
        public Nullable<decimal> Percentage_Completion { get; set; }
        public string Done_By { get; set; }
        public Nullable<System.DateTime> Date_Done { get; set; }
        public int Transaction_Id { get; set; }
    }
}
