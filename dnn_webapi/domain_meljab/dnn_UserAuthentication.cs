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
    
    public partial class dnn_UserAuthentication
    {
        public int UserAuthenticationID { get; set; }
        public int UserID { get; set; }
        public string AuthenticationType { get; set; }
        public string AuthenticationToken { get; set; }
    
        public virtual dnn_Users dnn_Users { get; set; }
    }
}
