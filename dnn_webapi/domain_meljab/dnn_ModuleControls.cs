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
    
    public partial class dnn_ModuleControls
    {
        public int ModuleControlID { get; set; }
        public Nullable<int> ModuleDefID { get; set; }
        public string ControlKey { get; set; }
        public string ControlTitle { get; set; }
        public string ControlSrc { get; set; }
        public string IconFile { get; set; }
        public int ControlType { get; set; }
        public Nullable<int> ViewOrder { get; set; }
        public string HelpUrl { get; set; }
        public bool SupportsPartialRendering { get; set; }
    
        public virtual dnn_ModuleDefinitions dnn_ModuleDefinitions { get; set; }
    }
}
