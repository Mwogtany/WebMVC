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
    
    public partial class proc_Get_Summary_Institutions_Per_Level_Result
    {
        public string Level_Code { get; set; }
        public string Level_Name { get; set; }
        public int Private { get; set; }
        public int Public { get; set; }
        public Nullable<int> Total { get; set; }
    }
}