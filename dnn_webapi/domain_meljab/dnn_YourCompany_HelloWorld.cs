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
    
    public partial class dnn_YourCompany_HelloWorld
    {
        public int ModuleID { get; set; }
        public int ItemID { get; set; }
        public string Content { get; set; }
        public int CreatedByUser { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual dnn_Modules dnn_Modules { get; set; }
    }
}