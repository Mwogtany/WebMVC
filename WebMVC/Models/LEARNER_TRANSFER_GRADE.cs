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
    
    public partial class LEARNER_TRANSFER_GRADE
    {
        public string UPI { get; set; }
        public string Category { get; set; }
        public string OriginalGrade { get; set; }
        public string NewGrade { get; set; }
        public Nullable<System.DateTime> DateEffected { get; set; }
        public string Processed { get; set; }
        public Nullable<System.DateTime> ProcessedOn { get; set; }
    }
}
