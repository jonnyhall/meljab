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
    
    public partial class dnn_SurveyResults
    {
        public int SurveyResultID { get; set; }
        public int SurveyOptionID { get; set; }
        public int UserID { get; set; }
    
        public virtual dnn_SurveyOptions dnn_SurveyOptions { get; set; }
    }
}
