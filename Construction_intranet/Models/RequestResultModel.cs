using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction_intranet.Models
{

    public class RequestResultModel
    {
        public String Title { get; set; }
        public String Message { get; set; }
        public int HideInSeconds { get; set; }
        public RequestResultInfoType InfoType { get; set; }
    }
    public enum RequestResultInfoType : int
    {
        Information = 0,
        Success = 1,
        Warning = 2,
        ErrorOrDanger = 3
    }

    public enum NotifyType : int
    {
        PageInline = 0,
        DialogInline = 1,
        Dialog = 2,
        PageFixedPoupUp = 3
    }

}