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
    
    public partial class INSTITUTION_INFRASTRUCTURE_PROJECTS_DETAIL
    {
        public string CompID { get; set; }
        public string TypeID { get; set; }
        public int ID { get; set; }
        public string ProjectDesription { get; set; }
        public Nullable<decimal> ProjectCost { get; set; }
        public string ProjectStatus { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ContractorName { get; set; }
        public string ContractorMobile { get; set; }
        public string ContractorEmail { get; set; }
        public Nullable<int> ContractPeriod { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string ProjectCompletionLevel { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> Quantity { get; set; }
    }
}
