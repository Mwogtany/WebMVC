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
    
    public partial class SMPSchools_Final_Disbursement_Detailed
    {
        public int TransactionID { get; set; }
        public int TermID { get; set; }
        public Nullable<int> FeedingDays { get; set; }
        public Nullable<decimal> AmountPerChild { get; set; }
        public string Sub_County_Code { get; set; }
        public string County_Name { get; set; }
        public string Sub_County_Name { get; set; }
        public string UIC { get; set; }
        public string Institution_Name { get; set; }
        public Nullable<int> Enrol { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string AccountType { get; set; }
        public string Bank_code { get; set; }
        public string Bank_Name { get; set; }
        public string Branch_code { get; set; }
        public string Branch_Name { get; set; }
        public string AccountNumber { get; set; }
    }
}