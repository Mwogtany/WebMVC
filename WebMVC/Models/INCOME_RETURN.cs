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
    
    public partial class INCOME_RETURN
    {
        public string Institution_Code { get; set; }
        public string Financial_Year { get; set; }
        public string Academic_Year { get; set; }
        public string Term { get; set; }
        public string Fund_Source { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> Date_Received { get; set; }
        public string Done_by { get; set; }
        public Nullable<System.DateTime> Date_captured { get; set; }
        public int Transaction_Id { get; set; }
    }
}