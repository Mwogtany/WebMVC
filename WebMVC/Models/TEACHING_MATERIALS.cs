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
    
    public partial class TEACHING_MATERIALS
    {
        public int ID { get; set; }
        public string Institution_Code { get; set; }
        public string Class { get; set; }
        public string Subject_Code { get; set; }
        public Nullable<decimal> Core_Books { get; set; }
        public Nullable<decimal> Other_Books { get; set; }
        public Nullable<decimal> Other_Reference_Books { get; set; }
        public string Captured_By { get; set; }
        public Nullable<System.DateTime> Date_Captured { get; set; }
    }
}
