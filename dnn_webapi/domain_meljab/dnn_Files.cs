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
    
    public partial class dnn_Files
    {
        public int FileId { get; set; }
        public Nullable<int> PortalId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public Nullable<int> Width { get; set; }
        public Nullable<int> Height { get; set; }
        public string ContentType { get; set; }
        public string Folder { get; set; }
        public int FolderID { get; set; }
        public byte[] Content { get; set; }
    
        public virtual dnn_Folders dnn_Folders { get; set; }
        public virtual dnn_Portals dnn_Portals { get; set; }
    }
}
