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
    
    public partial class CAPITATION_FUND
    {
        public Nullable<int> TransationID { get; set; }
        public string Source_Code { get; set; }
        public string AccountType { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public int UID { get; set; }
    }
}
