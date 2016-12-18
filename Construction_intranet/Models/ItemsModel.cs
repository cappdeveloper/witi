using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL_Construction.Data;

namespace Construction_intranet.Models
{
    public class ItemsModel
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public string Description { get; set; }
        public string UnitType { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<double> InitialQuantity { get; set; }
        public Nullable<double> PreviousQuantity { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> FinalTotal { get; set; }
        public Nullable<double> SubContractorQuantity { get; set; }
        public Nullable<int> SubContractorId { get; set; }
        public Nullable<double> SubUnit_price { get; set; }
        public string subcontractor_Name { get; set; }


        public Nullable<double> CurrentQuantity { get; set; }
        public int ItemNumber { get; set; }
        public Nullable<double> ChangeQuantity { get; set; }
        public string Contract { get; set; }

        public virtual Job Job { get; set; }
    }

    public class ItemDB
    {
        Construction_DBEntities _entities = new Construction_DBEntities();

        public List<ItemsModel> GetitembyjobId(int id)
        {
            var _list = (from p in _entities.Items
                         where p.JobID == id
                         select new ItemsModel
                         {

                             ID =p.ID,
                             Description = p.Description,
                             UnitType=p.UnitType,
                             UnitPrice=p.UnitPrice,
                             InitialQuantity=p.InitialQuantity,
                             JobID=p.JobID,
                             SubContractorQuantity=p.SubContractorQuantity,
                              SubUnit_price=p.SubUnit_price
                         }).ToList();
            return _list;


        }
        public ItemsModel GetitembyId(int id)
        {
            var _list = (from p in _entities.Items
                         where p.ID == id
                         select new ItemsModel
                         {

                             ID = id,
                             Description = p.Description,
                             UnitType = p.UnitType,
                             UnitPrice = p.UnitPrice,
                             InitialQuantity = p.InitialQuantity,
                             JobID=p.JobID
                         }).SingleOrDefault();
            return _list;


        }
    }
    }