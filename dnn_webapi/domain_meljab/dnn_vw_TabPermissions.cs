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
    
    public partial class dnn_vw_TabPermissions
    {
        public int TabPermissionID { get; set; }
        public int TabID { get; set; }
        public Nullable<int> PermissionID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string RoleName { get; set; }
        public bool AllowAccess { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string PermissionCode { get; set; }
        public Nullable<int> ModuleDefID { get; set; }
        public string PermissionKey { get; set; }
        public string PermissionName { get; set; }
        public Nullable<int> PortalId { get; set; }
    }
}
