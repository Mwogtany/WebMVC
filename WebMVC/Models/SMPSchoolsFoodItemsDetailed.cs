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
    
    public partial class SMPSchoolsFoodItemsDetailed
    {
        public int TransactionID { get; set; }
        public string UIC { get; set; }
        public Nullable<int> Total { get; set; }
        public Nullable<int> LowerTotal { get; set; }
        public string FoodID { get; set; }
        public int TermID { get; set; }
        public Nullable<int> FeedingDays { get; set; }
        public Nullable<int> ConsumptionPerChild { get; set; }
        public Nullable<decimal> EstimatedCost { get; set; }
        public Nullable<int> PackageWeight { get; set; }
        public string GradeConsumption { get; set; }
        public Nullable<int> Enrol { get; set; }
        public Nullable<int> FoodQtyGrams { get; set; }
        public Nullable<decimal> FoodQtyKgs { get; set; }
        public Nullable<int> FoodQtyPackage { get; set; }
        public Nullable<decimal> FoodQtyPackageBal { get; set; }
    }
}
