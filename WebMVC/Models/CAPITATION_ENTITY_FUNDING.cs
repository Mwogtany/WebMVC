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
    
    public partial class CAPITATION_ENTITY_FUNDING
    {
        public int TransactionID { get; set; }
        public int EntityID { get; set; }
        public int CategoryID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string AccountType { get; set; }
    }
}
