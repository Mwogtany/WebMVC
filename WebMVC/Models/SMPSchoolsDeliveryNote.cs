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
    
    public partial class SMPSchoolsDeliveryNote
    {
        public int TransactionID { get; set; }
        public string UIC { get; set; }
        public string DeliveryNoteNo { get; set; }
        public Nullable<System.DateTime> DispatchedOn { get; set; }
        public string DispatchedBy { get; set; }
        public Nullable<int> TransporterID { get; set; }
        public string DriverName { get; set; }
        public string DriverIDNo { get; set; }
        public string VehicleRegNo { get; set; }
        public string RouteID { get; set; }
        public string Sub_County_Code { get; set; }
        public string DispatchedFlag { get; set; }
        public string DeliveryNoteCloseFlag { get; set; }
        public string DeliveryNoteClosedBy { get; set; }
        public Nullable<System.DateTime> DeliveryNoteClosedDate { get; set; }
    }
}
