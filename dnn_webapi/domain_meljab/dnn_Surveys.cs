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
    
    public partial class dnn_Surveys
    {
        public dnn_Surveys()
        {
            this.dnn_SurveyOptions = new HashSet<dnn_SurveyOptions>();
        }
    
        public int SurveyID { get; set; }
        public int ModuleID { get; set; }
        public string Question { get; set; }
        public Nullable<int> ViewOrder { get; set; }
        public string OptionType { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedByUser { get; set; }
    
        public virtual dnn_Modules dnn_Modules { get; set; }
        public virtual ICollection<dnn_SurveyOptions> dnn_SurveyOptions { get; set; }
    }
}
