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
    
    public partial class dnn_Announcements
    {
        public int ItemID { get; set; }
        public int ModuleID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public string Description { get; set; }
        public Nullable<int> ViewOrder { get; set; }
        public int CreatedByUser { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public string ImageSource { get; set; }
    
        public virtual dnn_Modules dnn_Modules { get; set; }
    }
}