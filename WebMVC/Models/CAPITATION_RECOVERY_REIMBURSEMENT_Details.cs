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
    
    public partial class CAPITATION_RECOVERY_REIMBURSEMENT_Details
    {
        public Nullable<int> TransactionID { get; set; }
        public string UIC { get; set; }
        public string Institution_Name { get; set; }
        public Nullable<int> Enrol { get; set; }
        public string AccType { get; set; }
        public string Bank_Name { get; set; }
        public string Sort_Code { get; set; }
        public string Branch_Name { get; set; }
        public string AccountNumber { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string RecoveredAmount { get; set; }
        public string CategoryDesc { get; set; }
    }
}
