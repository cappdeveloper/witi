using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Construction_intranet.Models;
using DAL_Construction.Data;
using Construction_intranet.Concrete_Classes;
using Microsoft.AspNet.Identity;
using System.IO;
namespace Construction_intranet.Models
{
    public class JobDataModel
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public string JobName { get; set; }
        public System.DateTime Date { get; set; }
        public string Weather { get; set; }
        public Nullable<double> Temperature { get; set; }
        public string Shift { get; set; }
        public string Estimate { get; set; }
        public string Notes { get; set; }
        public string contractorid { get; set; }
        public string EntryType { get; set; }
        public List<DailyEntryModel> DailyEntryItems { get; set; }
        public List<DailyEntryModel> DailyEntryItems1 { get; set; }

        public List<DailyEntryModel> Adjustment { get; set; }
        public List<WorkforceModel> workforce { get; set; }
        public List<dailyEquipmentModel> equipment { get; set; }
    }

    public class DailyEntryModel
    {

        public int Id { get; set; }
        public Nullable<int> ItemNumber { get; set; }
        public string Description { get; set; }
       
        public Nullable<double> Quantity { get; set; }
        public System.DateTime added_date { get; set; }
        public Nullable<int> JobDataId { get; set; }
        public string Location { get; set; }
        public string entrytype { get; set; }
        public Nullable<int> Unit_Contractor { get; set; }
        public Nullable<int> Subcontractorid { get; set; }
        public string SubcontractorName { get; set; }




    }

    public class JobDataDB
    {
        Construction_DBEntities _entities = new Construction_DBEntities();

        public List<JobDataModel> GetallEntry(int id)
        {
            string User_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var _list = (from p in _entities.JobDatas
                         where p.ContractorId == _entities.AspNetUsers.Where(m => m.Id ==User_id).FirstOrDefault().ContractorId
                         && p.JobID == id
                         select new JobDataModel
                         {
                             ID = p.ID,
                             JobName = _entities.Jobs.Where(m => m.ID == p.JobID).FirstOrDefault().Name,
                             Estimate = p.Estimate,
                             Shift = p.Shift,
                             Date = p.Date,
                             EntryType = p.EntryType






                         }).ToList();
            return _list;








        }

    }
}