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
    
    public partial class ADMISSIONATTACHMENT
    {
        public int UploadID { get; set; }
        public string UPI { get; set; }
        public string SelectionDescription { get; set; }
        public Nullable<System.DateTime> AttachDate { get; set; }
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
