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
    
    public partial class INTEGRATION_SMS
    {
        public Nullable<int> ApplicationID { get; set; }
        public int SMSId { get; set; }
        public string MobileNo { get; set; }
        public string Message { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UserCategory { get; set; }
        public Nullable<System.DateTime> SentOn { get; set; }
        public Nullable<bool> MessageDelivered { get; set; }
    }
}
