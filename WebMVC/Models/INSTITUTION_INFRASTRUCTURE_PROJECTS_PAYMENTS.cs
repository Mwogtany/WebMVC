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
    
    public partial class INSTITUTION_INFRASTRUCTURE_PROJECTS_PAYMENTS
    {
        public int ProjectID { get; set; }
        public string InvoiceNo { get; set; }
        public string Description { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string PaymentVoucherNo { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public string FileCode { get; set; }
        public string FileExt { get; set; }
        public string FileContentType { get; set; }
        public string FileName { get; set; }
        public string UploadedBy { get; set; }
        public Nullable<System.DateTime> UploadedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}
