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
    
    public partial class CAPITATION_RECOVERY_AMOUNT
    {
        public int Transaction_ID { get; set; }
        public string UIC { get; set; }
        public decimal RecoveryRate { get; set; }
        public int RecoveryID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string AccType { get; set; }
        public Nullable<bool> Done { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> ControlID { get; set; }
    }
}
