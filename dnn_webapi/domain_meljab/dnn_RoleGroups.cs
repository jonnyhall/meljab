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
    
    public partial class dnn_RoleGroups
    {
        public dnn_RoleGroups()
        {
            this.dnn_Roles = new HashSet<dnn_Roles>();
        }
    
        public int RoleGroupID { get; set; }
        public int PortalID { get; set; }
        public string RoleGroupName { get; set; }
        public string Description { get; set; }
    
        public virtual dnn_Portals dnn_Portals { get; set; }
        public virtual ICollection<dnn_Roles> dnn_Roles { get; set; }
    }
}