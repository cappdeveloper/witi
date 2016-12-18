using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL_Construction.Data;

namespace Construction_intranet.Models
{
    public class EquipmentModel
    {
        public int id { get; set; }
        public string Equipment_name { get; set; }
        public Nullable<int> COntractor_id { get; set; }
        public Nullable<int> Jobdataid { get; set; }
        public Nullable<int> numberof { get; set; }

    }

    public class dailyEquipmentModel
    {
        public int id { get; set; }
        public Nullable<int> equipmentid { get; set; }
        public Nullable<int> jobdataid { get; set; }
        public Nullable<int> numberof { get; set; }
        public string Equipment_name { get; set; }

    }
    public class WorkforceModel
    {
        public int id { get; set; }
        public string Workforcename { get; set; }
        public Nullable<int> numberof { get; set; }
        public Nullable<int> JobDataid { get; set; }
    }
    public class EquipmentDB
    {
        Construction_DBEntities oDB = new Construction_DBEntities();

    

     
       public EquipmentModel GetEquipmentbyId(int id)
        {
            var _list = (from p in oDB.tblEquipments
                         where p.id == id
                         select new EquipmentModel
                         {

                          id=p.id,
                          Equipment_name=p.Equipment_name







                         }).SingleOrDefault();
            return _list;


        }


    }
}