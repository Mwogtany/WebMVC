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
    
    public partial class INSTITUTION_CO_CURRICULAR
    {
        public int ID { get; set; }
        public string Institution_Code { get; set; }
        public string Activity_Code { get; set; }
        public string year { get; set; }
        public string Period { get; set; }
        public string Highest_Level_Attained { get; set; }
        public string Captured_By { get; set; }
        public Nullable<System.DateTime> Date_Captured { get; set; }
    }
}