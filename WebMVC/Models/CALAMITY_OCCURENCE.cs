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
    
    public partial class CALAMITY_OCCURENCE
    {
        public int ID { get; set; }
        public string Institution_Code { get; set; }
        public string Calamity_Code { get; set; }
        public System.DateTime Calamity_Date { get; set; }
        public Nullable<System.DateTime> Reporting_Date { get; set; }
        public string Calamity_Description { get; set; }
        public string Response { get; set; }
        public string Status { get; set; }
        public string Captured_By { get; set; }
        public Nullable<System.DateTime> Date_Captured { get; set; }
        public string Nature { get; set; }
    }
}
