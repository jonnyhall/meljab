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
    
    public partial class dnn_EventsLocation
    {
        public int PortalID { get; set; }
        public int Location { get; set; }
        public string LocationName { get; set; }
        public string MapURL { get; set; }
    
        public virtual dnn_Portals dnn_Portals { get; set; }
    }
}
