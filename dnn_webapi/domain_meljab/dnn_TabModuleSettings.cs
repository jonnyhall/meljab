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
    
    public partial class dnn_TabModuleSettings
    {
        public int TabModuleID { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    
        public virtual dnn_TabModules dnn_TabModules { get; set; }
    }
}
