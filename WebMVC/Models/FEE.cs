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
    
    public partial class FEE
    {
        public int Transaction_Id { get; set; }
        public string Institution_Code { get; set; }
        public string Academic_Year { get; set; }
        public string Financial_Year { get; set; }
        public string Term_Code { get; set; }
        public string Class_Code { get; set; }
        public string Fee_Item_Id { get; set; }
        public string Amount { get; set; }
        public string Learner_Level_Id { get; set; }
        public string Done_By { get; set; }
        public Nullable<System.DateTime> Date_Done { get; set; }
    }
}
