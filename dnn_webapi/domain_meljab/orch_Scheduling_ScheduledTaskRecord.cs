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
    
    public partial class orch_Scheduling_ScheduledTaskRecord
    {
        public int Id { get; set; }
        public string TaskType { get; set; }
        public Nullable<System.DateTime> ScheduledUtc { get; set; }
        public Nullable<int> ContentItemVersionRecord_id { get; set; }
    }
}
