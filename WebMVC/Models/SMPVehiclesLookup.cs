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
    
    public partial class SMPVehiclesLookup
    {
        public int TransactionID { get; set; }
        public int TransporterID { get; set; }
        public string VehicleRegNo { get; set; }
        public string VehicleModel { get; set; }
        public string DriverName { get; set; }
        public string DriverMobile { get; set; }
        public string DriverLicenseNo { get; set; }
        public Nullable<int> Tonage { get; set; }
        public string DEL { get; set; }
    }
}