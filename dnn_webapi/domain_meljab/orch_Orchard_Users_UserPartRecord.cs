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
    
    public partial class orch_Orchard_Users_UserPartRecord
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string Password { get; set; }
        public string PasswordFormat { get; set; }
        public string HashAlgorithm { get; set; }
        public string PasswordSalt { get; set; }
        public string RegistrationStatus { get; set; }
        public string EmailStatus { get; set; }
        public string EmailChallengeToken { get; set; }
    }
}
