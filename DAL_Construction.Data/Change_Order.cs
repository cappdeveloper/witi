//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL_Construction.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Change_Order
    {
        public int id { get; set; }
        public Nullable<int> JobID { get; set; }
        public Nullable<int> itemid { get; set; }
        public Nullable<int> new_quantity { get; set; }
        public Nullable<System.DateTime> quantity_Added { get; set; }
        public string changeOrder { get; set; }
    
        public virtual Item Item { get; set; }
    }
}
