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
    
    public partial class dnn_EventLogTypes
    {
        public dnn_EventLogTypes()
        {
            this.dnn_EventLog = new HashSet<dnn_EventLog>();
            this.dnn_EventLogConfig = new HashSet<dnn_EventLogConfig>();
        }
    
        public string LogTypeKey { get; set; }
        public string LogTypeFriendlyName { get; set; }
        public string LogTypeDescription { get; set; }
        public string LogTypeOwner { get; set; }
        public string LogTypeCSSClass { get; set; }
    
        public virtual ICollection<dnn_EventLog> dnn_EventLog { get; set; }
        public virtual ICollection<dnn_EventLogConfig> dnn_EventLogConfig { get; set; }
    }
}
