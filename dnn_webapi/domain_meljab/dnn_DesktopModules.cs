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
    
    public partial class dnn_DesktopModules
    {
        public dnn_DesktopModules()
        {
            this.dnn_ModuleDefinitions = new HashSet<dnn_ModuleDefinitions>();
            this.dnn_PortalDesktopModules = new HashSet<dnn_PortalDesktopModules>();
        }
    
        public int DesktopModuleID { get; set; }
        public string FriendlyName { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool IsPremium { get; set; }
        public bool IsAdmin { get; set; }
        public string BusinessControllerClass { get; set; }
        public string FolderName { get; set; }
        public string ModuleName { get; set; }
        public int SupportedFeatures { get; set; }
        public string CompatibleVersions { get; set; }
        public string Dependencies { get; set; }
        public string Permissions { get; set; }
    
        public virtual ICollection<dnn_ModuleDefinitions> dnn_ModuleDefinitions { get; set; }
        public virtual ICollection<dnn_PortalDesktopModules> dnn_PortalDesktopModules { get; set; }
    }
}
