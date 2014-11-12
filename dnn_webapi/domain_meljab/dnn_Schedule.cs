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
    
    public partial class dnn_Schedule
    {
        public dnn_Schedule()
        {
            this.dnn_ScheduleHistory = new HashSet<dnn_ScheduleHistory>();
            this.dnn_ScheduleItemSettings = new HashSet<dnn_ScheduleItemSettings>();
        }
    
        public int ScheduleID { get; set; }
        public string TypeFullName { get; set; }
        public int TimeLapse { get; set; }
        public string TimeLapseMeasurement { get; set; }
        public int RetryTimeLapse { get; set; }
        public string RetryTimeLapseMeasurement { get; set; }
        public int RetainHistoryNum { get; set; }
        public string AttachToEvent { get; set; }
        public bool CatchUpEnabled { get; set; }
        public bool Enabled { get; set; }
        public string ObjectDependencies { get; set; }
        public string Servers { get; set; }
    
        public virtual ICollection<dnn_ScheduleHistory> dnn_ScheduleHistory { get; set; }
        public virtual ICollection<dnn_ScheduleItemSettings> dnn_ScheduleItemSettings { get; set; }
    }
}