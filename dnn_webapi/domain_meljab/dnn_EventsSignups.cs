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
    
    public partial class dnn_EventsSignups
    {
        public int SignupID { get; set; }
        public int ModuleID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> Approved { get; set; }
        public string PayPalStatus { get; set; }
        public string PayPalReason { get; set; }
        public string PayPalTransID { get; set; }
        public string PayPalPayerID { get; set; }
        public string PayPalPayerStatus { get; set; }
        public string PayPalRecieverEmail { get; set; }
        public string PayPalUserEmail { get; set; }
        public string PayPalPayerEmail { get; set; }
        public string PayPalFirstName { get; set; }
        public string PayPalLastName { get; set; }
        public string PayPalAddress { get; set; }
        public string PayPalCity { get; set; }
        public string PayPalState { get; set; }
        public string PayPalZip { get; set; }
        public string PayPalCountry { get; set; }
        public string PayPalCurrency { get; set; }
        public Nullable<System.DateTime> PayPalPaymentDate { get; set; }
        public Nullable<decimal> PayPalAmount { get; set; }
        public Nullable<decimal> PayPalFee { get; set; }
        public Nullable<System.DateTime> EventTimeBegin { get; set; }
        public Nullable<int> TimezoneOffset { get; set; }
    
        public virtual dnn_Events dnn_Events { get; set; }
    }
}
