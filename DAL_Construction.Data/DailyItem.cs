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
    
    public partial class DailyItem
    {
        public int Id { get; set; }
        public Nullable<int> ItemNumber { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<System.DateTime> added_date { get; set; }
        public Nullable<int> JobDataId { get; set; }
        public string Location { get; set; }
        public string EntryType { get; set; }
        public Nullable<int> Unit_Contractor { get; set; }
        public Nullable<int> Subcontractorid { get; set; }
    
        public virtual Item Item { get; set; }
    }
}
