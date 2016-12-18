using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Construction_intranet.Models;
using DAL_Construction.Data;
using Construction_intranet.Concrete_Classes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.IO;

namespace Construction_intranet.Controllers
{
    public class JobController : Controller
    {
        Construction_DBEntities _entities = new Construction_DBEntities();
        Construction_BaseController _login = new Construction_BaseController();
        // GET: Job
        public ActionResult Index()
        {
            List<JobModel> model = new List<JobModel>();
         model = (new JobDB()).GetAllJobs();
            return View(model);

        }

   

        public ActionResult IndexDailyEntry(int id)
        {

            List<JobDataModel> model = new List<JobDataModel>();
           model = (new JobDataDB()).GetallEntry(id);
            ViewBag.Id = id;
            return View(model);
        }
      
               public JsonResult Savepayment(PaymentModel O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {


                payment tblitem = new payment();
                tblitem.Jobid = O.Jobid;
                tblitem.Itemid = O.Itemid;
                tblitem.createddate = DateTime.UtcNow.Date;
                tblitem.Clientname = O.Clientname;
                tblitem.FromUser = SessionManager.UserId;
                tblitem.units = O.units;
                tblitem.UnitPrice = O.UnitPrice;
                 
                    _entities.payments.Add(tblitem);

                
                _entities.SaveChanges();
                status = true;

            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }

        public JsonResult SaveDailyAdjustItems(JobDataModel O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                foreach (var item1 in O.DailyEntryItems)
                {
                    DailyItem tblitem = new DailyItem();
                    tblitem.JobDataId = item1.JobDataId;
                    tblitem.ItemNumber = item1.ItemNumber;
                    tblitem.Quantity = item1.Quantity;
                    tblitem.EntryType = "Ad";

                    tblitem.added_date = DateTime.UtcNow.Date;

                    _entities.DailyItems.Add(tblitem);

                }
                _entities.SaveChanges();
                status = true;

            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }
        public JsonResult SaveChangeorder1(JobDataModel O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                foreach (var item1 in O.DailyEntryItems)
                {
                    Change_Order tblitem = new Change_Order();
                    tblitem.itemid = item1.ItemNumber;
                    tblitem.new_quantity = (int)item1.Quantity;
                    tblitem.JobID = item1.JobDataId;
                    tblitem.quantity_Added = DateTime.UtcNow.Date;
                    tblitem.changeOrder = "Sub";
                    _entities.Change_Order.Add(tblitem);

                }
                _entities.SaveChanges();
                status = true;

            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }
        public JsonResult SaveChangeorder(JobDataModel O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                foreach (var item1 in O.DailyEntryItems)
                {
                    Change_Order tblitem = new Change_Order();
                    tblitem.itemid = item1.ItemNumber;
                    tblitem.new_quantity = (int)item1.Quantity;
                    tblitem.JobID = item1.JobDataId;
                    tblitem.quantity_Added = DateTime.UtcNow.Date;

                    _entities.Change_Order.Add(tblitem);

                }
                _entities.SaveChanges();
                status = true;

            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult itemlookup()
        {
           // ViewBag.oJob = (new JobDB()).GetAllJobs();


            return View();

        }

        public ActionResult ItemResult(int id)
        {

            ViewBag.ProjectName = (from p in _entities.Jobs
                                   where p.ID == id
                                   select p.Name).FirstOrDefault();
            ViewBag.ProjectId = id;


            ViewBag.Subcontractor = (from i in _entities.Items
                                     where i.JobID == id && i.SubContractorId != null

                                     select new ItemsModel
                                     {
                                         ID = i.ID,
                                         ItemNumber = i.ItemNumber,
                                         UnitType = i.UnitType,
                                         UnitPrice = i.SubUnit_price,
                                         subcontractor_Name = _entities.tbl_sub_contractor.Where(m => m.id == i.SubContractorId).FirstOrDefault().Name,
                                         SubContractorQuantity = i.SubContractorQuantity,
                                         CurrentQuantity = (from p in _entities.JobDatas

                                                            join e in _entities.DailyItems on p.ID equals e.JobDataId
                                                            where (e.ItemNumber == i.ID && e.Subcontractorid != null) && e.JobDataId == (from k in _entities.JobDatas
                                                                                                                                         where k.JobID == id && k.EntryType != "Ad"
                                                                                                                                         orderby k.ID descending
                                                                                                                                         select k.ID).FirstOrDefault()
                                                            select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum(),
                                      



        }).ToList();
   
            var q = (from i in _entities.Items
                     where i.JobID == id

                     select new ItemsModel
                     {
                         ID = i.ID,
                         ItemNumber=i.ItemNumber,
                         UnitType = i.UnitType,
                         UnitPrice = i.UnitPrice,
                         InitialQuantity = (from v in _entities.Items
                                            where v.ID == i.ID
                                            select v.InitialQuantity ?? 0).Sum() + (from v in _entities.Change_Order
                                                                                    where v.itemid == i.ID
                                                                                    select v.new_quantity ?? 0).DefaultIfEmpty(0).Sum(),






                         PreviousQuantity = (from p in _entities.JobDatas

                                             join e in _entities.DailyItems on p.ID equals e.JobDataId
                                             where (e.ItemNumber==i.ID && e.EntryType!="Ad") && e.JobDataId!=(from k in _entities.JobDatas where k.JobID==id &&k.EntryType!= "Ad"
                                                                                                            orderby k.ID descending
                                                                                                            select k.ID).FirstOrDefault()
                                             select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum()+ (from p in _entities.JobDatas

                                                                                                                                     join e in _entities.DailyItems on p.ID equals e.JobDataId
                                                                                                                                     where (e.ItemNumber == i.ID && e.EntryType == "Ad") && e.JobDataId != (from k in _entities.JobDatas
                                                                                                                                                                                                            where k.JobID == id && k.EntryType == "Ad"
                                                                                                                                                                                                            orderby k.ID descending
                                                                                                                                                                                                            select k.ID).FirstOrDefault()
                                                                                                                                     select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum(),



                        CurrentQuantity = (from p in _entities.JobDatas

                                             join e in _entities.DailyItems on p.ID equals e.JobDataId
                                             where (e.ItemNumber == i.ID && e.EntryType != "Ad") && e.JobDataId == (from k in _entities.JobDatas
                                                                                                                    where k.JobID == id && k.EntryType != "Ad"
                                                                                                                    orderby k.ID descending
                                                                                                                    select k.ID).FirstOrDefault()
                                             select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum() + (from p in _entities.JobDatas

                                                                                                                                      join e in _entities.DailyItems on p.ID equals e.JobDataId
                                                                                                                                      where (e.ItemNumber == i.ID && e.EntryType == "Ad") && e.JobDataId == (from k in _entities.JobDatas
                                                                                                                                                                                                             where k.JobID == id && k.EntryType == "Ad"
                                                                                                                                                                                                             orderby k.ID descending
                                                                                                                                                                                                             select k.ID).FirstOrDefault()
                                                                                                                                      select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum(),




                        Total = (from v in _entities.Items
                                      where v.ID == i.ID
                                      select v.InitialQuantity ?? 0).Sum() + (from v in _entities.Change_Order
                                                                              where v.itemid == i.ID
                                                                              select v.new_quantity ?? 0).DefaultIfEmpty(0).Sum(),
                         FinalTotal= (from p in _entities.JobDatas

                                  join e in _entities.DailyItems on p.ID equals e.JobDataId
                                  where p.JobID == id && e.EntryType != "Ad" &&e.ItemNumber==i.ID
                                  select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum() + (from p in _entities.JobDatas

                                                                                                                           join e in _entities.DailyItems on p.ID equals e.JobDataId
                                                                                                                           where p.JobID ==id && e.EntryType == "Ad"&&e.ItemNumber==i.ID
                                                                                                                           select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum(),

                   


                         //                         SELECT sum(DailyItems.Quantity)
                         //FROM JobData
                         //INNER JOIN DailyItems
                         //ON JobData.ID = DailyItems.JobDataId
                         //where(DailyItems.ItemNumber = 1029 AND DailyItems.EntryType = 'Ad')  AND(DailyItems.JobDataId not in (select max(JobData.ID) from JobData where JobData.JobID = 16 AND JobData.EntryType = 'Ad'))


                         //   PreviousQuantity =Convert.ToDouble(_entities.JobDatas.SqlQuery("SELECT sum(DailyItems.Quantity) FROM JobData INNER JOIN DailyItems ON JobData.ID = DailyItems.JobDataId where(DailyItems.ItemNumber =" + i.ID + " AND  DailyItems.EntryType ='Ad')  AND(DailyItems.JobDataId not in (select max(JobData.ID) from JobData where JobData.JobID =" +id+ "AND JobData.EntryType = 'Ad'))").Single()),

                     }).ToList();

            return View(q);

        }

        public ActionResult InvoiceScreen(int id)
        {
            string User_id = System.Web.HttpContext.Current.User.Identity.GetUserId();

            var q = (from i in _entities.Jobs
                     where i.Active == true && i.ContractorID == _entities.AspNetUsers.Where(m => m.Id == User_id).FirstOrDefault().ContractorId

                     select new PaymentModel
                     {
                         ProjectName = (from p in _entities.Jobs
                                       where p.ID == id select p.Name).FirstOrDefault(),
                         ProjectAddress= (from p in _entities.Jobs
                                         where p.ID == id
                                         select p.Address).FirstOrDefault(),
                         GeneralContractorName=(from p in _entities.tblContractors
                                               where p.Id==SessionManager.ContractorId
                                               select p.FirstName+p.LastName).FirstOrDefault(),
                         GeneralContractorAddress= (from p in _entities.tblContractors
                                                   where p.Id == SessionManager.ContractorId
                                                   select p.Address).FirstOrDefault(),

                         OriginalContractAmount = (from v in _entities.Items
                                                   where v.JobID == id
                                                   select v.InitialQuantity * v.UnitPrice ?? 0).Sum(),
                         AmendedContractAmount = (from v in _entities.Change_Order
                                                  where v.JobID == id
                                                  select v.new_quantity * v.Item.UnitPrice ?? 0).Sum(),
                         TotalWorkCompleted = (from p in _entities.JobDatas

                                               join e in _entities.DailyItems on p.ID equals e.JobDataId
                                               where p.JobID ==id && e.EntryType != "Ad"
                                               select new { e, p }).AsEnumerable().Select(x => (x.e.Quantity*x.e.Item.UnitPrice)).DefaultIfEmpty(0).Sum() + (from p in _entities.JobDatas

                                                                                                                                        join e in _entities.DailyItems on p.ID equals e.JobDataId
                                                                                                                                        where p.JobID ==id && e.EntryType == "Ad"
                                                                                                                                        select new { e, p }).AsEnumerable().Select(x => (x.e.Quantity*x.e.Item.UnitPrice)).DefaultIfEmpty(0).Sum(),
                         PreviousPayment= (from p in _entities.payments
                                           where p.Jobid ==id
                                           select (p.units*p.UnitPrice)).DefaultIfEmpty(0).Sum(),

                         FullTotal = (from v in _entities.Items
                                      where v.JobID ==id
                                      select v.InitialQuantity ?? 0).Sum() + (from v in _entities.Change_Order
                                                                              where v.JobID ==id
                                                                              select v.new_quantity ?? 0).DefaultIfEmpty(0).Sum(),
                         Total = (from p in _entities.JobDatas

                                  join e in _entities.DailyItems on p.ID equals e.JobDataId
                                  where p.JobID ==id && e.EntryType != "Ad"
                                  select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum() + (from p in _entities.JobDatas

                                                                                                                           join e in _entities.DailyItems on p.ID equals e.JobDataId
                                                                                                                           where p.JobID ==id && e.EntryType == "Ad"
                                                                                                                           select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum(),






                     }).FirstOrDefault();

            ViewBag.jobid = id;

            ViewBag.Payment = (from p in _entities.payments
                               where p.Jobid == id
                               select new PaymentModel
                               {
                                    createddate = p.createddate,
                                   Total= p.units*p.UnitPrice
                                   




                               }).ToList();

            ViewBag.Payment1 = (from p in _entities.Change_Order
                               where p.JobID == id
                               select new PaymentModel
                               {
                                   
                                   Total = p.new_quantity*p.Item.UnitPrice,
                                    createddate=p.quantity_Added





                               }).ToList();

            return View(q);
        }


        public ActionResult JobDashboard()
        {
            string userID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ViewBag.TotalProject = (from p in _entities.Jobs
                                    where p.ContractorID == _entities.AspNetUsers.Where(m => m.Id == userID).FirstOrDefault().ContractorId
                                    select p).Count();

            ViewBag.active = (from p in _entities.Jobs
                                    where p.Active==true && p.ContractorID == _entities.AspNetUsers.Where(m => m.Id == userID).FirstOrDefault().ContractorId
                                    select p).Count();
            ViewBag.inactive1 = (from p in _entities.Jobs
                                    where p.Active==false && p.ContractorID == _entities.AspNetUsers.Where(m => m.Id == userID).FirstOrDefault().ContractorId
                                    select p).Count();
            var q = (from i in _entities.Jobs
                     where i.Active == true && i.ContractorID == _entities.AspNetUsers.Where(m => m.Id == userID).FirstOrDefault().ContractorId

                     select new JobModel
                     {
                         ID = i.ID,
                         Name = i.Name,

                         paidItem = (from p in _entities.payments
                                     where p.Jobid == i.ID
                                     select p.units).DefaultIfEmpty(0).Sum(),
                         TotalEstimate= (from p in _entities.JobDatas
                                   where p.JobID==i.ID
                                   select p.Estimate).Count(),
                          FullTotal = (from v in _entities.Items
                                       where v.JobID == i.ID
                                       select v.InitialQuantity ?? 0).Sum() + (from v in _entities.Change_Order
                                                                               where v.JobID == i.ID
                                                                               select v.new_quantity ?? 0).DefaultIfEmpty(0).Sum(),
                          Total = (from p in _entities.JobDatas

                                    join e in _entities.DailyItems on p.ID equals e.JobDataId
                                    where p.JobID ==i.ID && e.EntryType != "Ad"
                                    select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum()+ (from p in _entities.JobDatas

                                                                                                                            join e in _entities.DailyItems on p.ID equals e.JobDataId
                                                                                                                            where p.JobID == i.ID && e.EntryType == "Ad"
                                                                                                                          select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum(),

                      

                     }).ToList();
            ViewBag.Inactive = (from i in _entities.Jobs
                                where i.Active == false && i.ContractorID == _entities.AspNetUsers.Where(m => m.Id == userID).FirstOrDefault().ContractorId
                                select new JobModel
                     {
                         ID = i.ID,
                         Name = i.Name,
                         TotalEstimate = (from p in _entities.JobDatas
                                          where p.JobID == i.ID
                                          select p.Estimate).Count(),
                         FullTotal = (from v in _entities.Items
                                      where v.JobID == i.ID
                                      select v.InitialQuantity ?? 0).Sum() + (from v in _entities.Change_Order
                                                                              where v.JobID == i.ID
                                                                              select v.new_quantity ?? 0).DefaultIfEmpty(0).Sum(),
                         Total = (from p in _entities.JobDatas

                                  join e in _entities.DailyItems on p.ID equals e.JobDataId
                                  where p.JobID == i.ID && e.EntryType != "Ad"
                                  select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum() + (from p in _entities.JobDatas

                                                                                                                           join e in _entities.DailyItems on p.ID equals e.JobDataId
                                                                                                                           where p.JobID == i.ID && e.EntryType == "Ad"
                                                                                                                           select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).DefaultIfEmpty(0).Sum(),



                     }).ToList();


            //                     (from p in _entities.Jobs
            //   join e in _entities.Items on p.ID equals e.JobID into s
            //   //join n in _entities.JobDatas on p.ID equals n.JobID 
            //   //join d in _entities.DailyItems on n.ID equals d.JobDataId into h
            //join l in _entities.Change_Order on p.ID equals l.JobID into k
            //   where p.ContractorID == _entities.tblUsers.Where(m => m.Id == SessionManager.UserId).FirstOrDefault().ContractorId

            //   select new JobModel
            //   {
            //       Name = p.Name,
            //       Current = s.Sum(x =>x.InitialQuantity),
            //       current1=





            //   }).ToList();









            return View(q);
        }


        [HttpGet]
        public ActionResult itemlookups(int jobid,int itemid)
        {
          //  ViewBag.oJob = (new JobDB()).GetAllJobs();

            Construction_DBEntities obj = new Construction_DBEntities();

            double? a = (from od in obj.Items
                                    where od.JobID==jobid && od.ID==itemid  
                                    select od.InitialQuantity).Sum();
           double? b= (from od in obj.Change_Order
                    where od.JobID == jobid && od.itemid == itemid
                    select od.new_quantity).Sum();
            if (b == null)
                b = 0;
            if (a == null)
                a = 0;
            
            double? fulltotal= a + b;

            JobModel model = new JobModel();
            model.dailyentry = (from p in obj.JobDatas

                                join e in obj.DailyItems on p.ID equals e.JobDataId
                                where p.JobID == jobid && e.ItemNumber == itemid
                                select new { e, p }).AsEnumerable().Select(x => new
                                             DailyEntryModel
                                {
                                    ItemNumber = _entities.Items.Where(m => m.ID == x.e.ItemNumber).FirstOrDefault().ItemNumber,
                                    Description = _entities.Items.Where(m => m.ID == x.e.ItemNumber).FirstOrDefault().Description,
                                    added_date = x.e.added_date.Value == null ? x.e.added_date.Value : DateTime.Now,
                                    Location = x.e.Location,
                                    Quantity = x.e.Quantity,
                                    entrytype=x.e.EntryType

                                }).ToList();
            double? c = (from p in obj.JobDatas

                                       join e in obj.DailyItems on p.ID equals e.JobDataId
                                       where p.JobID == jobid && e.EntryType == "Ad" && e.ItemNumber==itemid
                                       select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).Sum();

            double? d = (from p in obj.JobDatas

                                       join e in obj.DailyItems on p.ID equals e.JobDataId
                                       where p.JobID == jobid && e.EntryType != "Ad" && e.ItemNumber==itemid
                                       select new { e, p }).AsEnumerable().Select(x => x.e.Quantity).Sum();
            if (c == null)
                c = 0;
            if (d == null)
                d = 0;
            double? itemtotal = c + d;
            double? totalafteradjustment =d+c;
            double? percentage = (totalafteradjustment * 100) / fulltotal;
            model.Percentage =(int)percentage;
            model.Total = itemtotal;
            model.Adjustment = c;
            model.AfterAdjustment = totalafteradjustment;
            model.FullTotal = fulltotal;


            //            [4/30/2016 11:56:18 PM]
            //        Trevor West: total:245 (the item total) will be the sum of the initial item you added(20) plus the three change orders
            //[4 / 30 / 2016 11:56:36 PM] Trevor West: the total:168 (the itemdata total) would be the sum of the daily entry and the adjustment




            return PartialView("_itemlookup", model);
        }

        public JsonResult EditDailyEntryItems(JobDataModel O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                Construction_DBEntities _entities = new Construction_DBEntities();
                if (O.Shift != null)
                {
                    var oData1 = _entities.JobDatas.Where(m => m.ID == O.ID).FirstOrDefault();
                    if (oData1 != null)
                    {



                        oData1.Date = DateTime.UtcNow.Date;
                        oData1.Estimate = O.Estimate;
                        oData1.Temperature = O.Temperature;
                        oData1.Shift = O.Shift;
                        oData1.Notes = O.Notes;
                        oData1.EntryType = O.EntryType;
                        oData1.Weather = O.Weather;
                        _entities.JobDatas.Attach(oData1);
                        _entities.Entry(oData1).State = System.Data.Entity.EntityState.Modified;

                        _entities.SaveChanges();

                    }
                }

                if (O.DailyEntryItems != null)
                {
                    foreach (var item1 in O.DailyEntryItems)
                    {
                        DailyItem tblitem = new DailyItem();
                        tblitem.JobDataId = O.ID;
                        tblitem.ItemNumber = item1.ItemNumber;
                        tblitem.Location = item1.Location;
                        tblitem.Quantity = item1.Quantity;
                        tblitem.added_date = DateTime.UtcNow.Date;
                        tblitem.EntryType = O.EntryType;
                        _entities.DailyItems.Add(tblitem);

                    }
                    _entities.SaveChanges();
                }
                if (O.equipment != null)
                {
                    foreach (var item1 in O.equipment)
                    {

                        tblDailyEquipment tblitem = new tblDailyEquipment();
                        tblitem.jobdataid = O.ID;
                        tblitem.equipmentid = item1.equipmentid;
                        tblitem.numberof = item1.numberof;
                        _entities.tblDailyEquipments.Add(tblitem);
                    }
                    _entities.SaveChanges();
                }

                if (O.workforce != null)
                {
                    foreach (var item1 in O.workforce)
                    {

                        tblworkforce tblitem = new tblworkforce();
                        tblitem.JobDataid = O.ID;
                        tblitem.Workforcename = item1.Workforcename;
                        tblitem.numberof = item1.numberof;
                        _entities.tblworkforces.Add(tblitem);
                    }
                    _entities.SaveChanges();
                }
                status = true;

            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }


        public ActionResult CopyEntry(int id)
        {
            var Userid = System.Web.HttpContext.Current.User.Identity.GetUserId();

            bool status = false;
            Construction_DBEntities _entities = new Construction_DBEntities();
            var abc = (from p in _entities.JobDatas where p.ID == id select p).SingleOrDefault();

            try
            {
            if (abc != null)
                {
                    JobData obj = new JobData();
                    obj.JobID = abc.JobID;
                    obj.Date = DateTime.UtcNow.Date;
                    obj.Estimate = abc.Estimate;
                    obj.Temperature = abc.Temperature;
                    obj.Shift = abc.Shift;
                    obj.Notes = abc.Notes;
                    obj.ContractorId = _entities.AspNetUsers.Where(m => m.Id == Userid).FirstOrDefault().ContractorId;
                    obj.EntryType = abc.EntryType;
                    obj.Weather = abc.Weather;
                    _entities.JobDatas.Add(obj);
                    _entities.SaveChanges();
                    int k = obj.ID;

                    var DailyEntryItems = (from p in _entities.DailyItems where p.JobDataId == id select p).ToList();
                    if (DailyEntryItems != null)
                    {
                        foreach (var item1 in DailyEntryItems)
                        {

                            DailyItem tblitem = new DailyItem();
                            tblitem.JobDataId = k;
                            tblitem.ItemNumber = item1.ItemNumber;
                            tblitem.Location = item1.Location;
                            tblitem.Quantity = item1.Quantity;
                            tblitem.added_date = DateTime.UtcNow.Date;
                            tblitem.EntryType = abc.EntryType;
                            tblitem.Unit_Contractor = item1.Unit_Contractor;
                            tblitem.Subcontractorid = item1.Subcontractorid;
                            _entities.DailyItems.Add(tblitem);
                        }
                        _entities.SaveChanges();

                    }
                    var equipment = (from p in _entities.tblDailyEquipments where p.jobdataid == id select p).ToList();

                    if (equipment != null)
                    {
                        foreach (var item1 in equipment)
                        {
                            tblDailyEquipment tblitem = new tblDailyEquipment();
                            tblitem.jobdataid = k;
                            tblitem.equipmentid = item1.equipmentid;
                            tblitem.numberof = item1.numberof;
                            _entities.tblDailyEquipments.Add(tblitem);


                        }
                        _entities.SaveChanges();

                    }
                    var workforce = (from p in _entities.tblworkforces where p.JobDataid == id select p).ToList();

                    if (workforce != null)
                    {
                        foreach (var item1 in workforce)
                        {
                            tblworkforce tblitem = new tblworkforce();
                            tblitem.JobDataid = k;
                            tblitem.Workforcename = item1.Workforcename;
                            tblitem.numberof = item1.numberof;
                            _entities.tblworkforces.Add(tblitem);

                        }
                        _entities.SaveChanges();

                    }
                  
                }
                status = true;
            }
            catch (Exception)
            {

                status = false;
            }





            return RedirectToAction("IndexDailyEntry", new
            {
                id = abc.JobID
            });


        }


        public JsonResult SaveDailyEntryItems(JobDataModel O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                Construction_DBEntities _entities = new Construction_DBEntities();
                JobData obj = new JobData();
                obj.JobID = O.JobID;
                obj.Date = DateTime.UtcNow.Date;
                obj.Estimate = O.Estimate;
                obj.Temperature = O.Temperature;
                obj.Shift = O.Shift;
                obj.Notes = O.Notes;
                obj.ContractorId = SessionManager.ContractorId;
                obj.EntryType = O.EntryType;
                obj.Weather = O.Weather;
                _entities.JobDatas.Add(obj);
                _entities.SaveChanges();
                int k = obj.ID;

                if (O.DailyEntryItems != null)
                {
                    foreach (var item1 in O.DailyEntryItems)
                    {
                        DailyItem tblitem = new DailyItem();
                        tblitem.JobDataId = k;
                        tblitem.ItemNumber = item1.ItemNumber;
                        tblitem.Location = item1.Location;
                        tblitem.Quantity = item1.Quantity;
                        tblitem.added_date = DateTime.UtcNow.Date;
                        tblitem.EntryType = O.EntryType;
                        tblitem.Unit_Contractor = item1.Unit_Contractor;
                        tblitem.Subcontractorid = item1.Subcontractorid;
                        _entities.DailyItems.Add(tblitem);

                    }
                }
                if (O.equipment != null)
                {
                    foreach (var item1 in O.equipment)
                    {
                        tblDailyEquipment tblitem = new tblDailyEquipment();
                        tblitem.jobdataid = k;
                        tblitem.equipmentid = item1.equipmentid;
                        tblitem.numberof = item1.numberof;
                        _entities.tblDailyEquipments.Add(tblitem);

                    }
                }
                if (O.workforce != null)
                {
                    foreach (var item1 in O.workforce)
                    {
                        tblworkforce tblitem = new tblworkforce();
                        tblitem.JobDataid = k;
                        tblitem.Workforcename = item1.Workforcename;
                        tblitem.numberof = item1.numberof;
                        _entities.tblworkforces.Add(tblitem);

                    }
                }
                _entities.SaveChanges();
                status = true;

            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }
        public JsonResult GetpricebyitemIdG(int Id)
        {
            Construction_DBEntities _entities = new Construction_DBEntities();
            ItemsModel abc = new ItemsModel();
            abc = (from c in _entities.Items
                   where c.ID == Id
                   select new ItemsModel
                   {
                       UnitPrice = c.UnitPrice




                   }).FirstOrDefault();
            return Json(abc);
        }


            public JsonResult GetpricebyitemId(int Id)
        {
            Construction_DBEntities _entities = new Construction_DBEntities();
            ItemsModel abc = new ItemsModel();
            abc = (from c in _entities.Items
                        where c.ID == Id && c.SubContractorId != null
                        select new ItemsModel
                        {
                             SubUnit_price = c.SubUnit_price




                        }).FirstOrDefault();
            return Json(abc);

        }


        public JsonResult GetsubcontractorbyitemId(int Id)
        {
            Construction_DBEntities _entities = new Construction_DBEntities();

            var city = (from c in _entities.Items
                        where c.ID == Id && c.SubContractorId != null
                        select new ItemsModel
                        {
                            SubContractorId = c.SubContractorId,
                            subcontractor_Name = _entities.tbl_sub_contractor.Where(m => m.id == c.SubContractorId).FirstOrDefault().Name,
                            SubUnit_price = c.SubUnit_price




                        });
            return Json(new SelectList(city.ToArray(), "SubContractorId", "subcontractor_Name"), JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetItemByJobId(int Id)
        {
            Construction_DBEntities _entities = new Construction_DBEntities();

            var city = from c in _entities.Items
                       where c.JobID == Id
                       select c;
            return Json(new SelectList(city.ToArray(), "ID", "Description"), JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetItemidByJobId(int Id)
        {
            Construction_DBEntities _entities = new Construction_DBEntities();

            var city = from c in _entities.Items
                       where c.JobID == Id
                       select c;
            return Json(new SelectList(city.ToArray(), "ID", "ItemNumber"), JsonRequestBehavior.AllowGet);

        }
        public ActionResult ChangeOrder(Int32 id)
        {


            JobModel Ojob = new JobModel();
            ViewBag.value1 = (from p in _entities.Jobs
                             where p.ID == id
                             select p.ID).FirstOrDefault();
            ViewBag.changeorder = from p in _entities.Items
                                  where p.JobID == id select p;
            ViewBag.changeorder1 = from p in _entities.Items
                                  where p.JobID == id && p.SubContractorId!=null
                                  select p;


            Ojob.ChangeOrder = (from p in _entities.Change_Order
                                where p.JobID == id && p.changeOrder==null
                                select new DailyEntryModel
                                {
                                    Id=p.id,
                                    ItemNumber = _entities.Items.Where(m => m.ID == p.itemid).FirstOrDefault().ItemNumber,
                                    Description = _entities.Items.Where(m => m.ID == p.itemid).FirstOrDefault().Description,
                                    Quantity = p.new_quantity




                                }).ToList();
            Ojob.dailyentry = (from p in _entities.Change_Order
                                where p.JobID == id && p.changeOrder =="Sub"
                                select new DailyEntryModel
                                {
                                    Id = p.id,
                                    ItemNumber = _entities.Items.Where(m => m.ID == p.itemid).FirstOrDefault().ItemNumber,
                                    Description = _entities.Items.Where(m => m.ID == p.itemid).FirstOrDefault().Description,
                                    Quantity = p.new_quantity




                                }).ToList();
            ViewBag.value = id;


            return View(Ojob);


        }

        public ActionResult Adjust_Entry(Int32 id)
        {
            


            ViewBag.dailyentry= (from p in _entities.DailyItems
                                 where p.JobDataId == id
                                 select new DailyEntryModel
                                 {
                                     ItemNumber =p.ItemNumber,
                                     Description = _entities.Items.Where(m => m.ID == p.ItemNumber).FirstOrDefault().Description,
                                   }).ToList();

            ViewBag.value = id;


            return View();


        }



  


        public ActionResult DailyEntry(int id)
        {

            ViewBag.oJob = (from c in _entities.Items
                            where c.JobID == id
                            select new ItemsModel
                            {
                                ID = c.ID,
                                Description = c.Description + " " + c.ItemNumber
                            }).ToList();

            ViewBag.Equipment= (from c in _entities.tblEquipments
                                where c.COntractor_id ==SessionManager.ContractorId
                                select new EquipmentModel
                                {
                                    id =c.id,
                                    Equipment_name=c.Equipment_name
                                   
                                }).ToList();

            ViewBag.oSubContractor= (from c in _entities.tbl_sub_contractor
                                     where c.Contractorid == SessionManager.ContractorId
                                     select new SUbcontractorModel
                                     {
                                         id = c.id,
                                         Name = c.Name

                                     }).ToList();

            ViewBag.Id = id;


            return View();
        }
      

        public ActionResult Details(Int32 Id)
        {
            Construction_DBEntities _entities = new Construction_DBEntities();
            JobModel Ojob = new JobModel();
          
            Ojob= (from p in _entities.Jobs
                       where p.ID== Id
                       select new JobModel
                       {
                           ID=p.ID,
                           Name=p.Name,
                           ContractorName=p.tblContractor.FirstName,
                           Created_Date=p.Created_Date,
                           Modified_date=p.Modified_date,
                           Email=p.Email,
                           Zip=p.Zip,                                            
                           Phone = p.Phone,
                           City = p.City,                        
                           State = p.State,                        
                           Address = p.Address,
                         

                       }).FirstOrDefault();

            Ojob.ItemDetails1 = (from p in _entities.Items
                                where p.JobID == Id
                                select new ItemsModel
                                {
                                    ID=p.ID,
                                   
                                    ItemNumber =p.ItemNumber,
                                    UnitType=p.UnitType,
                                    UnitPrice=p.UnitPrice,
                                    subcontractor_Name=_entities.tbl_sub_contractor.Where(m=>m.id==p.SubContractorId).FirstOrDefault().Name,
                                    Description = p.Description,
                                    InitialQuantity = p.InitialQuantity,
                                    SubContractorQuantity=p.SubContractorQuantity,
                                    SubUnit_price=p.SubUnit_price




                                }).ToList();




            _entities.Items.Where(p => p.JobID ==Id).ToList();
      
            Ojob.ChangeOrder = (from p in _entities.Change_Order
                                    where p.JobID == Id
                                    select new DailyEntryModel
                                    {
                                        Id=p.id,
                                        ItemNumber = _entities.Items.Where(m => m.ID == p.itemid).FirstOrDefault().ItemNumber,
                                        Description = _entities.Items.Where(m => m.ID == p.itemid).FirstOrDefault().Description,
                                       Quantity = p.new_quantity




                                    }).ToList();



            return View(Ojob);

        }

        public ActionResult DailyEntryDetails(Int32 Id)
        {
            Construction_DBEntities _entities = new Construction_DBEntities();
            JobDataModel Ojob = new JobDataModel();

            Ojob = (from p in _entities.JobDatas
                    where p.ID == Id
                    select new JobDataModel
                    {
                        ID = p.ID,
                        JobName = _entities.Jobs.Where(m => m.ID == p.JobID).FirstOrDefault().Name,
                        JobID = p.JobID,
                        Estimate = p.Estimate,
                        Weather = p.Weather,
                        Temperature = p.Temperature,
                        Notes = p.Notes,
                        Shift = p.Shift,
                        Date = p.Date,



                    }).FirstOrDefault();

            Ojob.DailyEntryItems = (from p in _entities.DailyItems
                                    where p.JobDataId == Id && p.EntryType!="Ad"
                                    select new DailyEntryModel
                                    {
                                        ItemNumber=_entities.Items.Where(m=>m.ID==p.ItemNumber).FirstOrDefault().ItemNumber,
                                        Description= _entities.Items.Where(m => m.ID == p.ItemNumber).FirstOrDefault().Description,
                                        Location=p.Location,
                                        added_date=p.added_date.Value,
                                        Quantity=p.Quantity




                                    }).ToList();
            Ojob.DailyEntryItems1= (from p in _entities.DailyItems
                                    where p.JobDataId == Id
                                    select new DailyEntryModel
                                    {
                                        ItemNumber = _entities.Items.Where(m => m.ID == p.ItemNumber).FirstOrDefault().ItemNumber,
                                        Description = _entities.Items.Where(m => m.ID == p.ItemNumber).FirstOrDefault().Description,
                                        Unit_Contractor=p.Unit_Contractor,
                                        SubcontractorName = _entities.tbl_sub_contractor.Where(m => m.id == p.Subcontractorid).FirstOrDefault().Name





                                    }).ToList();

            Ojob.workforce = (from p in _entities.tblworkforces
                              where p.JobDataid == Id
                              select new WorkforceModel
                              {
                                  id=p.id,
                                  Workforcename = p.Workforcename,
                                  numberof = p.numberof
                              }).ToList();
            Ojob.equipment = (from p in _entities.tblDailyEquipments
                              where p.jobdataid == Id
                              select new dailyEquipmentModel
                              {
                                  id=p.id,
                                  Equipment_name = _entities.tblEquipments.Where(m => m.id == p.equipmentid).FirstOrDefault().Equipment_name,

                                  numberof = p.numberof
                              }).ToList();





            return View(Ojob);

        }

        public ActionResult DailyEntryEdit(Int32 Id)
        {
            Construction_DBEntities _entities = new Construction_DBEntities();
            JobDataModel Ojob = new JobDataModel();
            ViewBag.nId = _entities.JobDatas.Where(m => m.ID == Id).FirstOrDefault().JobID;
            ViewBag.oJob = (from c in _entities.Items
                            where c.JobID ==_entities.JobDatas.Where(m => m.ID ==Id).FirstOrDefault().JobID
                            select new ItemsModel
                            {
                                ID = c.ID,
                                Description = c.Description + " " + c.ItemNumber
                            }).ToList();

            ViewBag.Equipment = (from c in _entities.tblEquipments
                                 where c.COntractor_id == SessionManager.ContractorId
                                 select new EquipmentModel
                                 {
                                     id = c.id,
                                     Equipment_name = c.Equipment_name

                                 }).ToList();

            ViewBag.oSubContractor = (from c in _entities.tbl_sub_contractor
                                      where c.Contractorid == SessionManager.ContractorId
                                      select new SUbcontractorModel
                                      {
                                          id = c.id,
                                          Name = c.Name

                                      }).ToList();

            ViewBag.Id = Id;
            Ojob = (from p in _entities.JobDatas
                    where p.ID == Id
                    select new JobDataModel
                    {
                        ID = p.ID,
                        JobName = _entities.Jobs.Where(m => m.ID == p.JobID).FirstOrDefault().Name,
                        JobID = p.JobID,
                        Estimate = p.Estimate,
                        Weather = p.Weather,
                        Temperature = p.Temperature,
                        Notes = p.Notes,
                        Shift = p.Shift,
                        Date = p.Date,
                        EntryType=p.EntryType



                    }).FirstOrDefault();
            if (Ojob.EntryType!="Ad")
            {

                Ojob.DailyEntryItems = (from p in _entities.DailyItems
                                        where p.JobDataId == Id && p.EntryType !="Ad"
                                        select new DailyEntryModel
                                        {
                                            Id = p.Id,
                                            ItemNumber = _entities.Items.Where(m => m.ID == p.ItemNumber).FirstOrDefault().ItemNumber,
                                            Description = _entities.Items.Where(m => m.ID == p.ItemNumber).FirstOrDefault().Description,
                                            Location = p.Location,
                                            added_date = p.added_date.Value,
                                            Quantity = p.Quantity




                                        }).ToList();

            }
            else
            {
                Ojob.DailyEntryItems = (from p in _entities.DailyItems
                                        where p.JobDataId == Id && p.EntryType =="Ad"
                                        select new DailyEntryModel
                                        {
                                            Id = p.Id,
                                            ItemNumber = _entities.Items.Where(m => m.ID == p.ItemNumber).FirstOrDefault().ItemNumber,
                                            Description = _entities.Items.Where(m => m.ID == p.ItemNumber).FirstOrDefault().Description,
                                            Location = p.Location,
                                            added_date = p.added_date.Value,
                                            Quantity = p.Quantity




                                        }).ToList();

            }


            Ojob.equipment = (from p in _entities.tblDailyEquipments
                              where p.jobdataid == Id
                              select new dailyEquipmentModel
                              {
                                 id=p.id,
                                 Equipment_name=_entities.tblEquipments.Where(m=>m.id==p.equipmentid).FirstOrDefault().Equipment_name,
                                 numberof=p.numberof
                                  
                                 


                              }).ToList();

            Ojob.workforce = (from p in _entities.tblworkforces
                              where p.JobDataid == Id
                              select new WorkforceModel
                              {
                                  id = p.id,
                                  Workforcename =p.Workforcename,
                                  numberof=p.numberof
                                 



                              }).ToList();


            return View(Ojob);

        }




        public JsonResult SaveProjectItems(JobModel O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                Construction_DBEntities _entities = new Construction_DBEntities();

                    foreach (var item1 in O.ItemDetails)
                    {
                    Item tblitem = new Item();
                    tblitem.JobID = item1.JobID;
                    tblitem.ItemNumber = item1.ItemNumber;
                    tblitem.Description = item1.Description;
                    tblitem.UnitType = item1.UnitType;
                    tblitem.UnitPrice = item1.UnitPrice;
                    tblitem.InitialQuantity = item1.InitialQuantity;
                    tblitem.SubContractorId = item1.SubContractorId;
                    tblitem.SubContractorQuantity = item1.SubContractorQuantity;
                    tblitem.SubUnit_price = item1.SubUnit_price;
                    _entities.Items.Add(item1);                      
                       
                    }
                _entities.SaveChanges();
                    status = true;
              
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status} };
        }

        public ActionResult CreateEditPayment(int id)
        {
            ViewBag.Items = from p in _entities.Items
                                  where p.JobID == id
                                  select p;
            ViewBag.jobid = id;

            return View();
        }
        public ActionResult IndexPayment(int id)
        {
            ViewBag.jobid = id;

            //ViewBag.Payment = (from p in _entities.payments
            //                   where p.Jobid == id
            //                   select new PaymentModel
            //                   {
            //                       id = p.id,
            //                       Clientname = p.Clientname,
            //                       GeneralContractorName = _entities.AspNetUsers.Where(m => m.Id == p.FromUser).FirstOrDefault().UserName,
            //                       createddate = p.createddate,
            //                       itemnumber = _entities.Items.Where(m => m.ID == p.Itemid).FirstOrDefault().ItemNumber,
            //                       units = p.units,
            //                       UnitPrice = p.UnitPrice




            //                   }).ToList();

            return View();
        }




        public ActionResult CreateEdit(int id = 0, string activeMenu = "general-details-tab")
        {
            JobMangementViewModel model = new JobMangementViewModel();
          
            if (id > 0)
            {
                model.GeneralDetails = (new JobDB()).GetJobbyId(id);
                ViewBag.Action = "Edit";
            }
            else
            {
                ViewBag.Action = "Create";
            }
            ViewBag.ActiveMenu = activeMenu;


            ViewBag.oSubContractor = (from c in _entities.tbl_sub_contractor
                                      where c.Contractorid == SessionManager.ContractorId
                                      select new SUbcontractorModel
                                      {
                                          id = c.id,
                                          Name = c.Name

                                      }).ToList();

            return View(model);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(JobModel model)
        {
            RequestResultModel requestModel = new RequestResultModel();

            int returnId = 0;
            try
            {
                model.Created_Date = DateTime.UtcNow;
                model.Modified_date = DateTime.UtcNow;
                if (ModelState.IsValid)
                {
                    if (model.ID > 0)
                    {
                        var job = _entities.Jobs.Where(m => m.ID == model.ID).FirstOrDefault();
                        job.Name = model.Name;
                        job.Phone = model.Phone;
                        job.Email = model.Email;
                        job.Address = model.Address;
                        job.City = model.City;
                        job.Created_Date = model.Created_Date;
                        job.Modified_date= model.Modified_date;
                        job.Zip = model.Zip;
                        job.State = model.State;
                        job.Fax = model.Fax;

                        _entities.Entry(job).State = System.Data.Entity.EntityState.Modified;
                        _entities.SaveChanges();


                        returnId =model.ID;
                    }
                    else
                    {
                   
                       Job job= new Job();
                        job.Name = model.Name;
                        job.Phone = model.Phone;
                        job.Email = model.Email;
                        job.Address = model.Address;
                        job.City = model.City;
                        job.Created_Date = model.Created_Date;
                        job.Modified_date = model.Modified_date;
                        job.Zip = model.Zip;
                        job.State = model.State;
                        job.Fax = model.Fax;
                        job.ContractorID = _entities.AspNetUsers.Where(m => m.Id ==User.Identity.GetUserId()).SingleOrDefault().ContractorId;
                        job.Active = true;
                        _entities.Jobs.Add(job);
                        _entities.SaveChanges();

                        returnId = job.ID;
                    }

                    requestModel.Title = "Success!";
                    requestModel.Message = _login.GetMessage("save");
                    requestModel.InfoType = RequestResultInfoType.Success;
                    return Json(new
                    {
                        returnId = returnId,
                        NotifyType = NotifyType.PageInline,
                        Html = this.RenderPartialView(@"_RequestResultPageInlineMessage", requestModel)

                    }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    returnId = model.ID;
                    requestModel.Message = _login.GetValidationErrors();
                }
            }
            catch (Exception)
            {
                requestModel.Message = _login.GetMessage("error");
            }

            ViewBag.Action = (model.ID > 0) ? "Edit" : "Create";

            requestModel.Title = "Error!";
            requestModel.InfoType = RequestResultInfoType.ErrorOrDanger;
            return Json(new
            {
                returnId = returnId,
                NotifyType = NotifyType.PageInline,
                Html = this.RenderPartialView(@"_RequestResultPageInlineMessage", requestModel)

            }, JsonRequestBehavior.AllowGet);
        }
        #region Contact

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEditItem(ItemsModel model)
        {
            RequestResultModel requestModel = new RequestResultModel();
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ID > 0)
                    {
                        var item = _entities.Items.Where(m => m.ID == model.ID).FirstOrDefault();
                        item.Description = model.Description;
                        item.UnitType = model.UnitType;
                        item.UnitPrice = model.UnitPrice;
                        item.InitialQuantity = model.UnitPrice;
                        item.JobID = model.JobID;
                        _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        _entities.SaveChanges();


                     
                    }
                    else
                    {
                        Item item = new Item();
                        item.Description = model.Description;
                        item.UnitType = model.UnitType;
                        item.UnitPrice = model.UnitPrice;
                        item.InitialQuantity = model.UnitPrice;
                        item.JobID = model.JobID;
                       
                        _entities.Items.Add(item);
                        _entities.SaveChanges();

                    }

                    requestModel.Title = "Success!";
                    requestModel.Message = _login.GetMessage("save");
                    requestModel.InfoType = RequestResultInfoType.Success;
                    return Json(new
                    {
                        Success = true,
                        NotifyType = NotifyType.PageInline,
                        Html = this.RenderPartialView(@"_RequestResultPageInlineMessage", requestModel)

                    }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    requestModel.Message = _login.GetValidationErrors();
                }
            }
            catch (Exception)
            {
                requestModel.Message = _login.GetMessage("error");
            }

            ViewBag.Action = (model.ID > 0) ? "Edit" : "Create";

            requestModel.Title = "Error!";
            requestModel.InfoType = RequestResultInfoType.ErrorOrDanger;
            return Json(new
            {
                Success = false,
                NotifyType = NotifyType.PageInline,
                Html = this.RenderPartialView(@"_RequestResultPageInlineMessage", requestModel)

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetJobItem(int id)
        {
            JobMangementViewModel model = new JobMangementViewModel();

            ViewBag.oSubContractor = (from c in _entities.tbl_sub_contractor
                                      where c.Contractorid == SessionManager.ContractorId
                                      select new SUbcontractorModel
                                      {
                                          id = c.id,
                                          Name = c.Name

                                      }).ToList();
            var contacts = (new ItemDB()).GetitembyjobId(id);
            if (contacts != null && contacts.Count() > 0)
            {
                model.Items = contacts.ToList();
            }
            var html = this.RenderPartialView("_ItemsList", model);

            return Json(new { html = html }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetItemForm(int jobId, int Id = 0)
        {
            var model = new ItemsModel();
            //if (Id > 0)
            //{
            //    model = (new ItemDB()).GetitembyId(Id);
            //}
         model.JobID= jobId;
            return PartialView("_ItemsForm", model);
        }

        //[HttpPost]
        //public ActionResult DeleteContact(int id)
        //{
        //    try
        //    {
        //        Context.ContactRepository.Delete(id);
        //        Context.Save();
        //        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        //}
        #endregion

        [HttpPost]
        public ActionResult InActive(int id)
        {
            try
            {
                var q = _entities.Jobs.Where(m => m.ID == id && m.Active== true).SingleOrDefault();
                if (q != null)
                {
                    q.Active = false;

                }
                _entities.Entry(q).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();




                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }
       [HttpPost]
        public ActionResult Active(int id)
        {
            try
            {
                var q = _entities.Jobs.Where(m => m.ID== id && m.Active == false).SingleOrDefault();
                if (q != null)
                {
                    q.Active= true;

                }
                _entities.Entry(q).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();




                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult deletepayment(int id)
        {
            try
            {
                var q = _entities.payments.Where(m => m.id == id).SingleOrDefault();
                _entities.payments.Remove(q);
                _entities.SaveChanges();




                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult deleteChangeOrder(int id)
        {
            try
            {
                var q = _entities.Change_Order.Where(m => m.id == id).SingleOrDefault();
                _entities.Change_Order.Remove(q);
                _entities.SaveChanges();




                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult deleteItems(int id)
        {
            try
            {
                var q = _entities.Items.Where(m => m.ID == id).SingleOrDefault();
                _entities.Items.Remove(q);
                _entities.SaveChanges();




                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult DeleteEntry(int id)
        {
            try
            {
                var q = _entities.JobDatas.Where(m => m.ID == id).SingleOrDefault();
                _entities.JobDatas.Remove(q);
                _entities.SaveChanges();




                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }
      [HttpPost]
        public ActionResult deletedailydata(int id)
        {
            try
            {
                var q = _entities.DailyItems.Where(m => m.Id== id).SingleOrDefault();
                _entities.DailyItems.Remove(q);
                _entities.SaveChanges();




                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult deleteworkforcedata(int id)
        {
            try
            {
                var q = _entities.tblworkforces.Where(m => m.id == id).SingleOrDefault();
                _entities.tblworkforces.Remove(q);
                _entities.SaveChanges();




                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }


    }
}