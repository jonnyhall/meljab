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
    
    public partial class dnn_Blog_Comments
    {
        public int CommentID { get; set; }
        public int EntryID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Comment { get; set; }
        public System.DateTime AddedDate { get; set; }
        public string Title { get; set; }
        public Nullable<bool> Approved { get; set; }
        public string Author { get; set; }
    
        public virtual dnn_Blog_Entries dnn_Blog_Entries { get; set; }
    }
}
