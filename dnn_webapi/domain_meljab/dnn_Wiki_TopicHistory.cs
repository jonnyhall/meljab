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
    
    public partial class dnn_Wiki_TopicHistory
    {
        public int TopicHistoryID { get; set; }
        public int TopicID { get; set; }
        public string Content { get; set; }
        public string Cache { get; set; }
        public string Name { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public int UpdatedByUserID { get; set; }
    }
}