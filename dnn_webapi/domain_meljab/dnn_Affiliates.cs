//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace domain_meljab
{
    using System;
    using System.Collections.Generic;
    
    public partial class dnn_Affiliates
    {
        public int AffiliateId { get; set; }
        public Nullable<int> VendorId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public double CPC { get; set; }
        public int Clicks { get; set; }
        public double CPA { get; set; }
        public int Acquisitions { get; set; }
    
        public virtual dnn_Vendors dnn_Vendors { get; set; }
    }
}
