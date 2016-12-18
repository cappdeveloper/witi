using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction_intranet.Models
{
    public class PaymentModel
    {
        public int id { get; set; }
        public string Clientname { get; set; }
        public Nullable<int> FromUser { get; set; }
        public Nullable<System.DateTime> createddate { get; set; }
        public Nullable<double> units { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<int> Jobid { get; set; }
        public Nullable<int> Itemid { get; set; }
        public string jobname { get; set; }
        public int itemnumber { get; set; }
        public string itemname{get ;set;}
        public string GeneralContractorName { get; set; }
        public string GeneralContractorAddress { get; set; }
        public string ProjectName { get; set; }
        public string ProjectAddress { get; set; }

        public double? OriginalContractAmount { get; set; }
        public double? AmendedContractAmount { get; set; }
        public double? TotalWorkCompleted { get; set; }
        public double? PreviousPayment { get; set; }
        public double? FullTotal { get; set; }
        public double? Total{ get; set; }






    }
}