using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL_Construction.Data;
using Construction_intranet.Concrete_Classes;
using System.Web.Mvc;
using Construction_intranet.Models;
using Construction_intranet.Controllers;
using Microsoft.AspNet.Identity;
using System.IO;

namespace Construction_intranet.Models
{
    public class JobModel
    {
        public int ID { get; set; }
        public int TotalEstimate { get; set; }
        public int ContractorID { get; set; }
        public string ContractorName { get; set; }
        public double? paidItem { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Active { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public Nullable<System.DateTime> Modified_date { get; set; }
       
      public double? Progress { get; set; }
        public double? Current { get; set; }
       public double? current1 { get; set; }

            public double? FullTotal { get; set; }
        public double? Total { get; set; }
        public double? AfterAdjustment { get; set; }
        public double? Adjustment { get; set; }

        public int? Percentage { get; set; }



        public List<ItemsModel> ItemDetails1 { get; set; }

        public List<Item> ItemDetails { get; set; }
        public List<DailyEntryModel> ChangeOrder { get; set; }
        public List<DailyEntryModel> dailyentry { get; set; }


        public virtual tblContractor tblContractor { get; set; }
    }


    public class JobDB
    {
        string User_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
        Construction_DBEntities _entities = new Construction_DBEntities();

        public JobModel GetJobbyId(int id)
        {
            var _list = (from p in _entities.Jobs
                         where p.ID == id
                         select new JobModel
                         {
                            ID = id,
                            Name = p.Name,
                            Fax=p.Fax,
                           
                             Email = p.Email,
                             Address = p.Address,
                             City = p.City,
                         
                             Phone = p.Phone,
                             State = p.State,
                             Zip = p.Zip

                         }).SingleOrDefault();
            return _list;


        }
        public List<JobModel> GetAllJobs()
        {
           
            var _list = (from p in _entities.Jobs
                         where p.ContractorID == _entities.AspNetUsers.Where(m => m.Id ==User_id).FirstOrDefault().ContractorId

                         select new JobModel
                         {
                             ID = p.ID,
                             Name = p.Name,
                             ContractorName = _entities.tblContractors.Where(m => m.Id == p.ContractorID).FirstOrDefault().FirstName,
                             Email = p.Email,
                             Address = p.Address,
                             City = p.City,
                             Phone = p.Phone,
                             State = p.State,
                             //Zip = p.Zip,
                             Modified_date = p.Modified_date,
                             Created_Date = p.Created_Date,
                             Active = p.Active,
                             status = p.Active == true ? "Active" : "Inactive"






                         }).ToList();
            return _list;


        }
        public List<JobModel> GetAllJobs(int id)
        {
            var _list = (from p in _entities.Jobs
                         where p.ContractorID == _entities.AspNetUsers.Where(m => m.Id ==User_id).FirstOrDefault().ContractorId
                         && p.ID == id
                         select new JobModel
                         {
                             ID = p.ID,
                             Name = p.Name,
                             ContractorName = _entities.tblContractors.Where(m => m.Id == p.ContractorID).FirstOrDefault().FirstName,
                             Email = p.Email,
                             Address = p.Address,
                             City = p.City,
                             Phone = p.Phone,
                             State = p.State,
                             //  Zip = p.Zip,
                             Modified_date = p.Modified_date,
                             Created_Date = p.Created_Date,
                             Active = p.Active,
                             status = p.Active == true ? "Active" : "Inactive"






                         }).ToList();
            return _list;


        }

    }
    }