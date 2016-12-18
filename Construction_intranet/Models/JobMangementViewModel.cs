using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Construction_intranet.Models;

namespace Construction_intranet.Models
{
    public class JobMangementViewModel
    {
        
            public JobMangementViewModel()
            {
                Items = new List<ItemsModel>();
             
                GeneralDetails = new JobModel();
            }

            public JobModel GeneralDetails { get; set; }
            public List<ItemsModel> Items { get; set; }
            
        }
    
}