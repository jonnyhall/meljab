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
    
    public partial class dnn_SearchWord
    {
        public dnn_SearchWord()
        {
            this.dnn_SearchItemWord = new HashSet<dnn_SearchItemWord>();
        }
    
        public int SearchWordsID { get; set; }
        public string Word { get; set; }
        public Nullable<bool> IsCommon { get; set; }
        public int HitCount { get; set; }
    
        public virtual ICollection<dnn_SearchItemWord> dnn_SearchItemWord { get; set; }
    }
}