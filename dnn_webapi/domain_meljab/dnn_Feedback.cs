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
    
    public partial class dnn_Feedback
    {
        public int ModuleID { get; set; }
        public int Status { get; set; }
        public string Subject { get; set; }
        public string CreatedByEmail { get; set; }
        public int ApprovedBy { get; set; }
        public string Message { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int FeedbackID { get; set; }
        public int PortalID { get; set; }
        public string CategoryID { get; set; }
    }
}